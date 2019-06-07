using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceMostrarTablaPermisos
{
    public class Service1 : IService1
    {
        public void Conectar()
        {
            var TablaDatosPermisos = DatosOrigenes.MostrarTabla();
            //
            //ACA SERIALIZAMOS DATOS CON NEWTONSOFT 
            //
            var tablaSerializada = JsonConvert.SerializeObject(TablaDatosPermisos);
            var Callback = OperationContext.Current.GetCallbackChannel<IMiServicioDuplexCallback>();
            Callback.MostrarTabla(tablaSerializada);


        }
        public void Agregar(string json)
        {
            var UsuarioDeserializar = JsonConvert.DeserializeObject<ModeloPermisoUsuario>(json);
            DatosOrigenes.AgregarUsuario(UsuarioDeserializar);
            Conectar();
        }
        public void Eliminar(string json)
        {
            var UsuarioDeserializar = JsonConvert.DeserializeObject<ModeloPermisoUsuario>(json);
            DatosOrigenes.EliminarPermisoUsuario(UsuarioDeserializar);
            Conectar();
        }
        public void Editar()
        {
            throw new NotImplementedException();
        }
    }
}
