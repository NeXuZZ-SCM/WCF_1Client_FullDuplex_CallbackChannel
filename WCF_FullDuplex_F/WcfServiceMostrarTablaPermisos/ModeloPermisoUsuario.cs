﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceMostrarTablaPermisos
{
    public class ModeloPermisoUsuario
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public bool vigente { get; set; }
    }
}