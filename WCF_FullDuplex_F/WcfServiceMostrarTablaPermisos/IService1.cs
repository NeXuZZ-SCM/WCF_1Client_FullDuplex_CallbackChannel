using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceMostrarTablaPermisos
{
    [ServiceContract(/*SessionMode = SessionMode.Required,*/ CallbackContract = typeof(IMiServicioDuplexCallback))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void Conectar();
        [OperationContract(IsOneWay = true)]
        void Agregar(string u);
        [OperationContract(IsOneWay = true)]
        void Eliminar(string u);
        [OperationContract(IsOneWay = true)]
        void Editar();

    }

    [ServiceContract]
    public interface IMiServicioDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void MostrarTabla(string json);
    }

}
