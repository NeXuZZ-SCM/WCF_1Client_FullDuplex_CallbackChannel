using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Entidades;

namespace VentanaPrincipal
{
    public partial class Permisos : Form
    {
        int idUsuario;
        public Permisos(int idUsuario, string nombre, string apellido)
        {
            InitializeComponent();
            lbl_nombre.Text = nombre;
            lbl_Apellido.Text = apellido;
            MostrarListaPermisosChkListBox();
            AgregarChequeos(idUsuario);
            this.idUsuario = idUsuario;
        }
        private void MostrarListaPermisosChkListBox()
        {
            chkboxList_Permisos.DataSource = Servicios.Permisos.CompletarchklistBoxPermisos();/*Servicios.NuevosPermisos.CompletarchklistBoxPermisosNuevos();*/
            chkboxList_Permisos.DisplayMember = "descripcion";
        }
        private void AgregarChequeos(int idUsuario)
        {

            List<Entidades.PermisoChequeados> listado = new List<Entidades.PermisoChequeados>();

            DataTable dt = ConvertirListaATabla(Servicios.Permisos.ConsultarChequeados(idUsuario));


            chkboxList_Permisos.DataSource = dt;
            chkboxList_Permisos.DisplayMember = "descripcion";
            chkboxList_Permisos.ValueMember = "id";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dt.Rows[i]["ch"]))
                {
                    chkboxList_Permisos.SetItemChecked(i, true);
                }
            }

        }
        static DataTable ConvertirListaATabla(List<Entidades.PermisoChequeados> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("descripcion");
            dt.Columns.Add("id_tipo");
            dt.Columns.Add("ch");
            foreach (var item in list)
            {
                dt.Rows.Add(item.id, item.Descripcion, item.id_tipo, item.Ch);
            }
            return dt;
        }
        private void chkboxList_Permisos_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }
        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                var permisos = new List<int?>();
                for (int i = 0; i < chkboxList_Permisos.Items.Count; i++)
                {
                    if (chkboxList_Permisos.GetItemChecked(i))
                    {
                        var castedItem = (DataRowView)chkboxList_Permisos.Items[i];
                        int? id = Convert.ToInt32(castedItem["id"]);
                        permisos.Add(id);
                    }


                }

                Servicios.Permisos.TransaccionAB(permisos, this.idUsuario);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
            }
        }

        private void btn_NuevosPermisos_Click(object sender, EventArgs e)
        {
            NuevosPermisos VtnNuevosPermisos = new NuevosPermisos();
            VtnNuevosPermisos.ShowDialog();

            chkboxList_Permisos.DataSource = Servicios.Permisos.CompletarchklistBoxPermisos();
            chkboxList_Permisos.DisplayMember = "descripcion";
            
        }
    }
}
