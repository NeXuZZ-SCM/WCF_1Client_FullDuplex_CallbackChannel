﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class UsuariosCRUD
    {
        public static DataTable ObtenerTabla() {
            var conexionString = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            string consulta = "USUARIOS_C";
            SqlDataAdapter adaptadorDeDatos = new SqlDataAdapter(consulta, conexionString);
            DataTable tablaDeDatos = new DataTable();
            adaptadorDeDatos.Fill(tablaDeDatos);

            return tablaDeDatos;
        }
        public static int AgregarUsuario(Entidades.Usuario Usuario)
        {

            string query = "USUARIOS_A";

            var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = Usuario.Nombre;
            comando.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar)).Value = Usuario.Apellido;

            int idRetornado = Convert.ToInt32(comando.ExecuteScalar());
            conexion.Close();
            return idRetornado;
        }
        public static void EliminarUsuario(Entidades.Usuario usuario)
        {
            string query = "USUARIOS_B";

            var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = usuario.Id;

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Elimine los permisos del usuario para luego borrar el usuario");
            }
            
            conexion.Close();
        }

        public static void EditarUsuarios(Entidades.Usuario usuario)
        {

            string query = "USUARIOS_M";

            var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar)).Value = usuario.Id;
            comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar)).Value = usuario.Nombre;
            comando.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar)).Value = usuario.Apellido;

            comando.ExecuteNonQuery();
            conexion.Close();

        }
    }
}
