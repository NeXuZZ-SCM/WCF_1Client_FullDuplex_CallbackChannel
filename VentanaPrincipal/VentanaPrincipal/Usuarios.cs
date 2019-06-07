using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentanaPrincipal
{
    public partial class Usuarios : Form
    {

        private static readonly HttpClient client = new HttpClient();
        public Usuarios()
        {
            InitializeComponent();
            MostrarTabla();
            AgregarBotonColumna();
        }

        #region ABM

        #region BAJA
        /// <summary>
        /// Evento encargado de borrar usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Borrar_Click(object sender, EventArgs e)
        {
            //Servicios.Usuarios.EliminarUsuario(RellenarUSuario());

            var u = RellenarUSuario(); //Creo un objeto Entidad.Usuario 
            JsonSerializerSettings ConfiguracionJSON = new JsonSerializerSettings(); // Creo un nuevo objeto JSONSerializerSettings para configurar el objeto JSONSerializer

            byte[] Datos = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u, Formatting.None, ConfiguracionJSON));


            HttpWebRequest WebRequest = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WebServiceRESTFUL/api/test/Delete");
            WebRequest.ContentType = "application/json; charset=UTF-8";
            WebRequest.ContentLength = Datos.Length;
            WebRequest.Method = "DELETE";
            WebRequest.GetRequestStream().Write(Datos, 0, Datos.Length);

            HttpWebResponse webResponse = (HttpWebResponse)WebRequest.GetResponse();


            MostrarTabla();
        }
        #endregion

        #region ALTA
        /// <summary>
        /// INSERTA usuarios a origenes de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AgregarUsuario_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    txt_IDUsuario.Text = Servicios.Usuarios.AgregarUsuario(RellenarUSuario()).ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ERROR AL INGRESAR DATO:" + ex.ToString());
            //}

            //this.MostrarTabla();
            //string url = "http://localhost/WebServiceRESTFUL/api/test";


            var u = RellenarUSuario(); //Creo un objeto Entidad.Usuario 
            JsonSerializerSettings ConfiguracionJSON = new JsonSerializerSettings(); // Creo un nuevo objeto JSONSerializerSettings para configurar el objeto JSONSerializer

            byte[] Datos = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u, Formatting.None, ConfiguracionJSON));





            HttpWebRequest WebRequest = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WebServiceRESTFUL/api/test");
            WebRequest.ContentType = "application/json; charset=UTF-8";
            WebRequest.ContentLength = Datos.Length;
            WebRequest.Method = "POST";
            WebRequest.GetRequestStream().Write(Datos, 0, Datos.Length);

            HttpWebResponse webResponse = (HttpWebResponse)WebRequest.GetResponse();

            MostrarTabla();


        }
        #endregion

        #region MODIFICACION
        /// <summary>
        /// Evento encargado de editar usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //RellenarUSuario();
            //Servicios.Usuarios.EditarUsuarios(RellenarUSuario());
            //MostrarTabla();

            var u = RellenarUSuario(); //Creo un objeto Entidad.Usuario 
            JsonSerializerSettings ConfiguracionJSON = new JsonSerializerSettings(); // Creo un nuevo objeto JSONSerializerSettings para configurar el objeto JSONSerializer

            byte[] Datos = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(u, Formatting.None, ConfiguracionJSON));


            HttpWebRequest WebRequest = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WebServiceRESTFUL/api/test/PostEditar");
            WebRequest.ContentType = "application/json; charset=UTF-8";
            WebRequest.ContentLength = Datos.Length;
            WebRequest.Method = "PUT";
            WebRequest.GetRequestStream().Write(Datos, 0, Datos.Length);

            HttpWebResponse webResponse = (HttpWebResponse)WebRequest.GetResponse();
            MostrarTabla();



        }

        #endregion

        #endregion

        #region SHOW TABLE
        /// <summary>
        /// Muestra Tabla En FRM 
        /// </summary>  
        private void MostrarTabla()
        {
            #region Este codigo no usaba RESTFUL e iba directamente a la capa servicios para luego consolidarse con la capa datos. 
            //dgv_Usuarios.DataSource = Servicios.Usuarios.obtenerTabla();
            //this.dgv_Usuarios.Columns["Identificador"].Visible = false;
            //dgv_Usuarios.DataSource = Servicios.Usuarios.obtenerTabla();
            #endregion


            string url = "http://localhost/WebServiceRESTFUL/api/test";
            var json = new WebClient().DownloadString(url);
            var UserList = JsonConvert.DeserializeObject<List<Entidades.UsuariosCast>>(JsonConvert.DeserializeObject(json).ToString());
            dgv_Usuarios.DataSource = UserList;


        }

        #endregion

        #region AGREGAR BOTON COLUMNA


        /// <summary>
        /// Agrega un boton en una columna, establece texto de cabecera en columna, tag name usado para conocer la celda tocada.
        /// </summary>
        private void AgregarBotonColumna()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Permisos";
            btn.Name = "boton";
            btn.Text = "Ver Permisos";
            btn.UseColumnTextForButtonValue = true;
            dgv_Usuarios.Columns.Add(btn);
        }

        #endregion

        #region RELLENAR USUARIO
        /// <summary>
        /// Este metodo se encarga de extraer los datos de los textbox y conformar el objeto Usuario
        /// </summary>
        /// <returns></returns>
        private Entidades.Usuario RellenarUSuario()
        {
            Entidades.Usuario Usuario = new Entidades.Usuario();

            Usuario.Nombre = txt_NombreUsuario.Text;
            Usuario.Apellido = txt_ApellidoUsuario.Text;

            try
            {
                Usuario.Id = (string.IsNullOrWhiteSpace(txt_IDUsuario.Text)) ? (int?)null : Convert.ToInt32(txt_IDUsuario.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Excepcion de formato " + ex.ToString());
            }

            return Usuario;
        }
        #endregion

        #region CELL EVENT SINGLE AND DOUBLE CLICK 

        /// <summary>
        /// Evento doble clic para DATAGRIDVIEW Usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Usuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgv_Usuarios.Rows[e.RowIndex];
            txt_IDUsuario.Text = Convert.ToString(row.Cells["Identificador"].Value);
            txt_NombreUsuario.Text = Convert.ToString(row.Cells["Nombre"].Value);
            txt_ApellidoUsuario.Text = Convert.ToString(row.Cells["Apellido"].Value);
        }
        /// <summary>
        /// Evento Clic simple para DataGridView Usuarios Obtiene el index de la columna referenciado por un tag para saber si estan tocando el boton 
        /// ver metodo AgregarBotonColumna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_Usuarios.Columns["boton"].Index)
            {
                try
                {
                    DataGridViewRow row = dgv_Usuarios.Rows[e.RowIndex];

                    int id = Convert.ToInt32(row.Cells["Identificador"].Value);
                    string nombre = Convert.ToString(row.Cells["Nombre"].Value);
                    string apellido = Convert.ToString(row.Cells["Apellido"].Value);


                    var frmPermisos = new Permisos(id, nombre, apellido);
                    frmPermisos.ShowDialog();
                }
                catch (NullReferenceException nre)
                {
                    //TODO:Logger
                    MessageBox.Show(nre.Message);
                }
                catch (InvalidCastException ice)
                {
                    //TODO:Logger
                    MessageBox.Show(ice.Message);
                }
                catch (ArgumentOutOfRangeException AORE)
                {
                    //TODO:Logger
                    MessageBox.Show(AORE.Message);
                }

            }
        }
        #endregion


    }
}
