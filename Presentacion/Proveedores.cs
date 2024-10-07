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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        #region "MIS VARIABLES"
        int EstadoGuardar = 1;
        int vcodigo_proveedor = 0;
        #endregion

        #region "MIS MÉTODOS" 
        private void cargarCategorias()
        {
            D_Categorias categorias = new D_Categorias();


        }

        private void EstadoTexto(bool Lstado)
        {
            txt_Nombre.Enabled = Lstado;
            txt_Nombre.Enabled = Lstado;
        }

        private void LimpiarTexto()
        {
            txt_Nombre.Text = "";
            txt_Nombre.Text = "";
        }


        private void EstadoBotones(bool lEstado)
        {
            btn_cancelar.Visible = lEstado;
            btn_guardar.Visible = lEstado;



        }

        private void formato_proveedores()
        {
            dgv_proveedores.Columns[0].Width = 50;
            dgv_proveedores.Columns[0].HeaderText = "ID Proveedor";
            dgv_proveedores.Columns[1].Width = 200;
            dgv_proveedores.Columns[1].HeaderText = "Nombre";
            dgv_proveedores.Columns[2].Width = 250;
            dgv_proveedores.Columns[2].HeaderText = "Telefono";


        }


        private void ListadoProveedores(string ctexto)
        {
            D_Proveedores Datos = new D_Proveedores();
            dgv_proveedores.DataSource = Datos.Listado_Proveedores(ctexto);
            this.formato_proveedores();
        }

        private void selecciona_item_categoria()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_proveedores.CurrentRow.Cells["idProveedor"].Value)))
            {
                MessageBox.Show("No se tiene informacion seleccionada",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                this.vcodigo_proveedor = Convert.ToInt32(dgv_proveedores.CurrentRow.Cells["idProveedor"].Value);
                this.txt_Nombre.Text = Convert.ToString(dgv_proveedores.CurrentRow.Cells["nombre"].Value);
                this.txt_Telefono.Text = Convert.ToString(dgv_proveedores.CurrentRow.Cells["telefono"].Value);


            }
        }

        #endregion

        private void Proveedores_Load(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            if (txt_Nombre.Text == string.Empty || txt_Telefono.Text == string.Empty)
            {
                MessageBox.Show("no se han ingresado todos los campos requeridos (*)",
                    "Mensaje del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                string Rpta = "";
                E_Proveedores oProveedor = new E_Proveedores();

                //oCiudad.idCiudad = this.vcodigo_Ciudad;
                oProveedor.nombre = Convert.ToString(txt_Nombre.Text);

                oProveedor.idProveedor = vcodigo_proveedor;

                oProveedor.telefono = Convert.ToString(txt_Telefono.Text);

                D_Proveedores Datos = new D_Proveedores();

                // Llamada al método Guardar_Ciudad, convirtiendo EstadoGuardar a int en la misma línea
                Rpta = Datos.Guardar_Proveedor(this.EstadoGuardar, oProveedor);


                if ((Rpta) == "Ok")
                {
                    this.ListadoProveedores("%");
                    MessageBox.Show("Se ha guardado el producto exitosamente");
                    this.vcodigo_proveedor = 0;

                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            
        }

       
         }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.EstadoGuardar = 2;
            txt_Nombre.Select();
            this.EstadoTexto(true);
            this.EstadoBotones(true);
            dgv_proveedores.Enabled = true;
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.vcodigo_proveedor = 0;
            this.EstadoGuardar = 1;
            this.EstadoTexto(true);
            this.EstadoBotones(true);
            dgv_proveedores.Enabled = false;
        }
    }
}
