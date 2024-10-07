using Almisa_project.Entidades;
using Almisa_project.Datos;
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
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }


        #region "MIS VARIABLES"
        int EstadoGuardar = 1;
        int vcodigo_cliente = 0;
        #endregion

        #region "MIS MÉTODOS" 
        private void cargarClientes()
        {
           D_Clientes clientes = new D_Clientes();
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

        private void formato_clientes()
        {
            dgv_clientes.Columns[0].Width = 50;
            dgv_clientes.Columns[0].HeaderText = "ID Cliente";
            dgv_clientes.Columns[1].Width = 200;
            dgv_clientes.Columns[1].HeaderText = "Nombre";
            dgv_clientes.Columns[2].Width = 250;
            dgv_clientes.Columns[2].HeaderText = "Direccion";
            dgv_clientes.Columns[3].Width = 80;
            dgv_clientes.Columns[3].HeaderText = "Telefono";
            dgv_clientes.Columns[4].Width = 80;
            dgv_clientes.Columns[4].HeaderText = "Ciudad";


        }


        private void ListadoClientes(string ctexto)
        {
            D_Clientes Datos = new D_Clientes();
            this.cargarClientes();
            this.cargar_ciudades();
            dgv_clientes.DataSource = Datos.Listado_Clientes(ctexto);
            this.formato_clientes();
        }

        private void selecciona_item_clientes()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_clientes.CurrentRow.Cells["idCliente"].Value)))
            {
                MessageBox.Show("No se tiene informacion seleccionada",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                this.vcodigo_cliente = Convert.ToInt32(dgv_clientes.CurrentRow.Cells["idCliente"].Value);
                this.txt_Nombre.Text = Convert.ToString(dgv_clientes.CurrentRow.Cells["nombre"].Value);
                this.txt_Direccion.Text = Convert.ToString(dgv_clientes.CurrentRow.Cells["direccionOficinaPrincipal"].Value);
                this.txt_Telefono.Text = Convert.ToString(dgv_clientes.CurrentRow.Cells["telefono"].Value);
                this.cbox_Ciudad.Text = Convert.ToString(dgv_clientes.CurrentRow.Cells["CiudadNombre"].Value);

            }
        }

        #endregion

        private void Clientes_Load(object sender, EventArgs e)
        {
            this.ListadoClientes("%");
            EstadoTexto(false);
            dgv_clientes.Enabled = false;
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
                E_Clientes oCliente = new E_Clientes();

                //oCiudad.idCiudad = this.vcodigo_Ciudad;
                oCliente.nombre = Convert.ToString(txt_Nombre.Text);

                oCliente.idCliente = vcodigo_cliente;

                oCliente.direccion = Convert.ToString(txt_Direccion.Text);


                oCliente.telefono = Convert.ToString(txt_Telefono.Text);

                oCliente.idCiudadOficinaPrincipal = Convert.ToInt32(cbox_Ciudad.SelectedValue);

                MessageBox.Show(Convert.ToString(oCliente.idCiudadOficinaPrincipal));

                D_Clientes Datos = new D_Clientes();

                // Llamada al método Guardar_Ciudad, convirtiendo EstadoGuardar a int en la misma línea
                Rpta = Datos.Guardar_Cliente(this.EstadoGuardar, oCliente);


                if ((Rpta) == "Ok")
                {
                    this.ListadoClientes("%");
                    MessageBox.Show("Se ha guardado el producto exitosamente");
                    this.vcodigo_cliente = 0;
                    LimpiarText();

                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoTexto(true);
            EstadoBotones(true);

            dgv_clientes.Enabled = false;
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            this.EstadoGuardar = 2;
            EstadoTexto(true);
            EstadoBotones(true);
            dgv_clientes.Enabled = true;

        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selecciona_item_clientes();
        }
    }
}
