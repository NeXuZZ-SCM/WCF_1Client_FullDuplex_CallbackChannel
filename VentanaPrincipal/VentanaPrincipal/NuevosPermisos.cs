using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using VentanaPrincipal.ServiceReference2;
using Newtonsoft.Json;

namespace VentanaPrincipal
{
    public partial class NuevosPermisos : Form, ServiceReference2.IService1Callback
    {
        Service1Client service;
        public NuevosPermisos()
        {
            InitializeComponent();
            var instanceContext = new InstanceContext(this);
            service = new Service1Client(instanceContext);
            InicializacionComplementaria();

        }

        private void InicializacionComplementaria()
        {
            MostrarTabla();
        }

        private void MostrarTabla()
        {   //dgv_Permisos.DataSource =  Servicios.NuevosPermisos.MostrarTabla();

            //Aca va la llamada al servicio que implementa callback.
            service.Conectar();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            //Servicios.NuevosPermisos.AgregarPermiso(BuildEntidad());

            var usuarioSerializar = JsonConvert.SerializeObject(BuildEntidad());

            service.Agregar(usuarioSerializar);
        }

        private Entidades.NuevosPermisosT BuildEntidad()
        {
            Entidades.NuevosPermisosT NPermisos = new Entidades.NuevosPermisosT();
            NPermisos.id = Convert.ToInt32(txt_ID.Text);
            NPermisos.descripcion = txt_Descripcion.Text;
            NPermisos.vigente = chk_Vigencia.Checked;

            return NPermisos;
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            //Servicios.NuevosPermisos.EliminarPermiso(BuildEntidad());
            var usuarioSerializar = JsonConvert.SerializeObject(BuildEntidad());

            service.Eliminar(usuarioSerializar);
        }

        private void dgv_Permisos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_Permisos.Rows[e.RowIndex];
            txt_ID.Text = Convert.ToString(row.Cells["id"].Value);
            txt_Descripcion.Text = Convert.ToString(row.Cells["descripcion"].Value);
        }

        void IService1Callback.MostrarTabla(string json)
        {
            //ACA SE DEBE DESERIALIZAR
            var lista = new List<Entidades.NuevosPermisosT>();
            var TablaDeserializada = JsonConvert.DeserializeObject<List<Entidades.NuevosPermisosT>>(json);
            dgv_Permisos.DataSource = TablaDeserializada;
        }
    }
}
