using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class NuevosPermisos
    {
        public static List<Entidades.NuevosPermisosT> MostrarTabla()
        {
            var servicio = new SrvPermisosUsuarios.SrvPermisosDUsuarios();

            var lista = JsonConvert.DeserializeObject<List<Entidades.NuevosPermisosT>>(JsonConvert.DeserializeObject(servicio.MostrarTabla()).ToString());

            return lista;
        }
        public static void AgregarPermiso(Entidades.NuevosPermisosT NuevoPermiso)
        {
            var Serializado = JsonConvert.SerializeObject(NuevoPermiso);
            var Servicio = new SrvPermisosUsuarios.SrvPermisosDUsuarios();
            Servicio.AgregarPermisoUsuario(Serializado);
        }
        public static void EliminarPermiso(Entidades.NuevosPermisosT PermisoEliminar)
        {
            var Serializado = JsonConvert.SerializeObject(PermisoEliminar);
            var Servicio = new SrvPermisosUsuarios.SrvPermisosDUsuarios();
            Servicio.EliminarPermisoUsuario(Serializado);
        }
        public static void ModificiarPermiso(Entidades.NuevosPermisosT NuevoModificar)
        {
        }

        public static DataTable CompletarchklistBoxPermisosNuevos()
        {
            return Datos.PermisosCRUD.CompletarchklistBoxPermisosNuevos();
        }
    }
}
