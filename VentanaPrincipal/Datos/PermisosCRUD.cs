using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Datos
{
    public class PermisosCRUD
    {
        private static string conexionString = ConfigurationManager.ConnectionStrings["Conexion"].ToString();

        public static DataTable CompletarchklistBoxPermisos()
        {
            //TODO:Stored Procedure
            string consulta = "PERMISOS_C_USUARIOS;";
            SqlDataAdapter adaptadorDDeDatos = new SqlDataAdapter(consulta, conexionString);
            DataTable tablaDeDatos = new DataTable();
            adaptadorDDeDatos.Fill(tablaDeDatos);
            return tablaDeDatos;

        }
        public static DataTable ConsultarChequeados(int id)
        {
            string queryString = "PERMISOS_C_CHEQUEADOS_MEJORADOS";
            var lPermisos = new List<PermisoChequeados>();
            var dt = new DataTable();

            using (var cnn = new SqlConnection(conexionString))
            {
                cnn.Open();
                using (var cmd = new SqlCommand(queryString, cnn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@USUARIORECIBIDO", SqlDbType.VarChar)).Value = id;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public static void TransaccionAB(List<int?> permisos, int idUsuario)
        {

            using (var conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                SqlTransaction transaccionSQL = conexion.BeginTransaction();

                SqlCommand comandoSQL = conexion.CreateCommand();
                comandoSQL.Transaction = transaccionSQL;

                try
                {
                    comandoSQL.CommandText = "PERMISOS_B_Usuarios";
                    comandoSQL.CommandType = CommandType.StoredProcedure;
                    comandoSQL.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int)).Value = idUsuario;
                    comandoSQL.ExecuteNonQuery();
                    comandoSQL.Parameters.Clear();

                    comandoSQL.CommandText = "PERMISOS_A_Usuarios";
                    foreach (var item in permisos)
                    {
                        comandoSQL.CommandType = CommandType.StoredProcedure;
                        comandoSQL.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int)).Value = idUsuario;
                        comandoSQL.Parameters.Add(new SqlParameter("@idPermisos", SqlDbType.Int)).Value = item;
                        comandoSQL.ExecuteNonQuery();
                        comandoSQL.Parameters.Clear();

                    }
                    transaccionSQL.Commit();
                    MessageBox.Show("transaccion completada");
                }
                catch (Exception exRollBack)
                {
                    MessageBox.Show(exRollBack.Message);
                }


            }

        }

        public static DataTable CompletarchklistBoxPermisosNuevos()
        {
            //TODO:Stored Procedure
            string consulta = "SELECT descripcion FROM tipo_permiso;";
            SqlDataAdapter adaptadorDDeDatos = new SqlDataAdapter(consulta, conexionString);
            DataTable tablaDeDatos = new DataTable();
            adaptadorDDeDatos.Fill(tablaDeDatos);
            return tablaDeDatos;

        }

    }
}
