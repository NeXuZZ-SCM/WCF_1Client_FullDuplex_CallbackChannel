using System.Collections.Generic;
using System.Data;
using Entidades;
using Newtonsoft.Json;

namespace Servicios
{
    public class Permisos
    {
        public static List<Entidades.PermisoChequeados> CompletarchklistBoxPermisos()
        {
            var ls = new List<Entidades.PermisoChequeados>();
            var wr = new Servicio.WebService1();
            var listaCheck = JsonConvert.DeserializeObject<List<Entidades.PermisoChequeados>>(wr.CompletarchklistBoxPermisos());
            return listaCheck;
        }
        public static List<Entidades.PermisoChequeados> ConsultarChequeados(int id)
        {
            //return Datos.PermisosCRUD.ConsultarChequeados(id);
            var ls = new List<Entidades.PermisoChequeados>();
            var wr = new Servicio.WebService1();
            var listaCheck = JsonConvert.DeserializeObject<List<Entidades.PermisoChequeados>>(wr.ConsultarChequeados(id));
            return listaCheck;


        }
        public static void TransaccionAB(List<int?> permisos, int idUsuario) {

            Datos.PermisosCRUD.TransaccionAB(permisos, idUsuario);
            var wr = new Servicio.WebService1();
            string listado = JsonConvert.SerializeObject(permisos);
            wr.TransaccionAB(listado, idUsuario);
        }
    }
}
