using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SrvPermisosUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SrvPermisosDUsuarios" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SrvPermisosDUsuarios.svc o SrvPermisosDUsuarios.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SrvPermisosDUsuarios : ISrvPermisosDUsuarios
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public string MostrarTabla()
        {
            var datos = new Datos();
            dynamic bleh = JsonConvert.SerializeObject(datos.MostrarTablaPermisoUsuario());
            return JsonConvert.SerializeObject(datos.MostrarTablaPermisoUsuario());
        }
        public void AgregarPermisoUsuario(string json)
        {
            var datos = JsonConvert.DeserializeObject<ModeloPermisoUsuario>(JsonConvert.DeserializeObject(json).ToString());
            var datosClase = new Datos();
            datosClase.AgregarPermisoUsuario(datos);
        }
        public void EliminarPermisoUsuario(string json)
        {
            var datos = JsonConvert.DeserializeObject<ModeloPermisoUsuario>(JsonConvert.DeserializeObject(json).ToString());
            var datosClase = new Datos();
            datosClase.EliminarPermisoUsuario(datos);
        }
    }
}
