﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SrvPermisosUsuarios
{
    public class Datos : IABM
    {

        public void AgregarPermisoUsuario(ModeloPermisoUsuario usuario)
        {
            string query = "INSERT INTO tipo_permiso (descripcion, vigente) values (@descripcion, @vigente);";

            var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = usuario.descripcion;
            comando.Parameters.Add(new SqlParameter("@vigente", SqlDbType.Bit)).Value = usuario.vigente;

            comando.ExecuteNonQuery();
            conexion.Close();


        }

        public void EditarPermisoUsuario(ModeloPermisoUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public void EliminarPermisoUsuario(ModeloPermisoUsuario usuario)
        {
            string query = "DELETE from tipo_permiso WHERE id = @id;";

            var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);

            comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = usuario.id;

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable MostrarTablaPermisoUsuario()
        {
            var conexionString = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            string consulta = "select tp.* from tipo_permiso tp";
            SqlDataAdapter adaptadorDeDatos = new SqlDataAdapter(consulta, conexionString);
            DataTable tablaDeDatos = new DataTable();
            adaptadorDeDatos.Fill(tablaDeDatos);

            return tablaDeDatos;
        }
    }
}