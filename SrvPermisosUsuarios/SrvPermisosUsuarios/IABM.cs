using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SrvPermisosUsuarios
{
    interface IABM
    {

        DataTable MostrarTablaPermisoUsuario();
        void AgregarPermisoUsuario(ModeloPermisoUsuario usuario);
        void EliminarPermisoUsuario(ModeloPermisoUsuario usuario);
        void EditarPermisoUsuario(ModeloPermisoUsuario usuario);
    }
}