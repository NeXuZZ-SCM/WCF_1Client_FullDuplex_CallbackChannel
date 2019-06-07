using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Usuarios
    {
        #region ABM

        #region Alta
        public static int AgregarUsuario(Entidades.Usuario Usuario)
        {
            //return Datos.UsuariosCRUD.AgregarUsuario(Usuario);
            //string url = "http://localhost:53747/ModeloPersona";
            //var json = new WebClient().DownloadString(url);
            //dynamic m = JsonConvert.DeserializeObject(json);
            return 1;


        }
    #endregion

    #region BAJA
    public static void EliminarUsuario(Entidades.Usuario usuario)
    {
        Datos.UsuariosCRUD.EliminarUsuario(usuario);
    }
    #endregion

    #region Modificacion
    public static void EditarUsuarios(Entidades.Usuario usuario)
    {
        Datos.UsuariosCRUD.EditarUsuarios(usuario);
    }
    #endregion


    #endregion

    #region Show Table
    public static dynamic obtenerTabla()
    {
        //return Datos.UsuariosCRUD.ObtenerTabla();

        string url = "http://localhost:50816/api/test";
        var json = new WebClient().DownloadString(url);
        dynamic datosCapturados = JsonConvert.DeserializeObject(json);

        return datosCapturados;
    }
    #endregion

}
}
