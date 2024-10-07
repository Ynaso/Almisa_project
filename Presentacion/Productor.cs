using Almisa_project.Datos;
using Almisa_project.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almisa_project.Presentacion
{
    public partial class Productor : Form
    {
        public Productor()
        {
            InitializeComponent();
        }

        #region "MIS VARIABLES"
        int EstadoGuardar = 1;
        int vcodigo_productor = 0;
        #endregion

        #region "MIS MÉTODOS" 
        private void cargarClientes()
        {
            D_Productores productores = new D_Productores();
        }

        private void cargar_ciudades()
        {
            D_Ciudades Datos = new D_Ciudades();
            cbox_Ciudad.DataSource = Datos.listado_ciudades("%");
            cbox_Ciudad.ValueMember = "idCiudad";
            cbox_Ciudad.DisplayMember = "nombre";


        }

        private void EstadoTexto(bool Lstado)
        {
            txt_Nombre.Enabled = Lstado;
            txt_Direccion.Enabled = Lstado;
            txt_Telefono.Enabled = Lstado;
            cbox_Ciudad.Enabled = Lstado;
        }

        private void LimpiarText()
        {
            txt_Nombre.Text = "";
            txt_Direccion.Text = "";
            txt_Telefono.Text = "";
            cbox_Ciudad.Text = "";
        }



        private void EstadoBotones(bool lEstado)
        {
            btn_cancelar.Visible = lEstado;
            btn_guardar.Visible = lEstado;



        }

        private void formato_productores()
        {
            dgv_productor.Columns[0].Width = 50;
            dgv_productor.Columns[0].HeaderText = "ID Productor";
            dgv_productor.Columns[1].Width = 200;
            dgv_productor.Columns[1].HeaderText = "Nombre";
            dgv_productor.Columns[2].Width = 250;
            dgv_productor.Columns[2].HeaderText = "Direccion";
            dgv_productor.Columns[3].Width = 80;
            dgv_productor.Columns[3].HeaderText = "Telefono";
            dgv_productor.Columns[4].Width = 80;
            dgv_productor.Columns[4].HeaderText = "Ciudad";


        }


        private void ListadoProductor(string ctexto)
        {
            D_Productores Datos = new D_Productores();
            this.cargarClientes();
            this.cargar_ciudades();
            dgv_productor.DataSource = Datos.Listado_Productores(ctexto);
            this.formato_productores();
        }

        private void selecciona_item_productores()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_productor.CurrentRow.Cells["idProductor"].Value)))
            {
                MessageBox.Show("No se tiene informacion seleccionada",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                this.vcodigo_productor = Convert.ToInt32(dgv_productor.CurrentRow.Cells["idProductor"].Value);
                this.txt_Nombre.Text = Convert.ToString(dgv_productor.CurrentRow.Cells["nombreProductor"].Value);
                this.txt_Direccion.Text = Convert.ToString(dgv_productor.CurrentRow.Cells["DireccionPrincipal"].Value);
                this.txt_Telefono.Text = Convert.ToString(dgv_productor.CurrentRow.Cells["Telefono"].Value);
                this.cbox_Ciudad.Text = Convert.ToString(dgv_productor.CurrentRow.Cells["nombreCiudadOficina"].Value);

            }
        }

        #endregion


        private void Productor_Load(object sender, EventArgs e)
        {
            this.ListadoProductor("%");
            EstadoTexto(false);
            dgv_productor.Enabled = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == string.Empty || txt_Telefono.Text == string.Empty || txt_Direccion.Text == string.Empty || cbox_Ciudad.Text == string.Empty
            )
            {
                MessageBox.Show("no se han ingresado todos los campos requeridos (*)",
                    "Mensaje del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                string Rpta = "";
                E_Productor oProductor = new E_Productor();

                //oCiudad.idCiudad = this.vcodigo_Ciudad;
                oProductor.Nombre = Convert.ToString(txt_Nombre.Text);

                oProductor.IdProductor = vcodigo_productor;

                oProductor.DireccionOficinaPrincipal = Convert.ToString(txt_Direccion.Text);


                oProductor.Telefono = Convert.ToString(txt_Telefono.Text);

                oProductor.CidCiudadOficinaPrincipal = Convert.ToInt32(cbox_Ciudad.SelectedValue);


                D_Productores Datos = new D_Productores();

                // Llamada al método Guardar_Ciudad, convirtiendo EstadoGuardar a int en la misma línea
                Rpta = Datos.Guardar_Productor(this.EstadoGuardar, oProductor);


                if ((Rpta) == "Ok")
                {
                    this.ListadoProductor("%");
                    MessageBox.Show("Se ha guardado el producto exitosamente");
                    this.vcodigo_productor = 0;
                    LimpiarText();

                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            EstadoTexto(true);
            EstadoBotones(true);
            LimpiarText();
            dgv_productor.Enabled = false;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            LimpiarText();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.EstadoGuardar = 2;
            EstadoTexto(true);
            EstadoBotones(true);
            LimpiarText();
            dgv_productor.Enabled = true;
        }

        private void dgv_productor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selecciona_item_productores();
        }
    }
}
