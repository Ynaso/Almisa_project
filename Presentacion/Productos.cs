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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }


        #region "MIS VARIABLES"
        int EstadoGuardar = 1;
        int vcodigo_producto = 0;
        #endregion

        #region "MIS MÉTODOS" 
        private void cargarProductos()
        {
            D_Productos productos = new D_Productos();
        }

        private void cargar_categorias()
        {
            D_Categorias Datos = new D_Categorias();
            cbox_Categoria.DataSource = Datos.listar_categorias("%");
            cbox_Categoria.ValueMember = "idCategoria";
            cbox_Categoria.DisplayMember = "nombre";


        }

        private void cargar_productores()
        {
            D_Productores Datos = new D_Productores();
            cbox_Productor.DataSource = Datos.Listado_Productores("%");
            cbox_Productor.ValueMember = "IdProductor";
            cbox_Productor.DisplayMember = "nombreProductor";


        }

        private void EstadoTexto(bool Lstado)
        {
            txt_Nombre.Enabled = Lstado;
            txt_CodigoBarra.Enabled = Lstado;
            txt_Existencias.Enabled = Lstado;
            txt_PesoKG.Enabled = Lstado;
            txt_PrecioU.Enabled = Lstado;
            txt_Presentacion.Enabled = Lstado;
        }

        private void LimpiarText()
        {
            txt_Nombre.Text = "";
            txt_CodigoBarra.Text = "";
            txt_Existencias.Text = "";
            txt_PesoKG.Text = "";
            txt_PrecioU.Text = "";
            txt_Presentacion.Text = "";
            cbox_Categoria.Text = "";
            cbox_Productor.Text = "";
        }



        private void EstadoBotones(bool lEstado)
        {
            btn_cancelar.Visible = lEstado;
            btn_guardar.Visible = lEstado;



        }

        private void formato_productos()
        {
            dgv_productos.Columns[0].Width = 50;
            dgv_productos.Columns[0].HeaderText = "ID Producto";
            dgv_productos.Columns[1].Width = 40;
            dgv_productos.Columns[1].HeaderText = "Codigo";
            dgv_productos.Columns[2].Width = 150;
            dgv_productos.Columns[2].HeaderText = "Nombre";
            dgv_productos.Columns[3].Width = 70;
            dgv_productos.Columns[3].HeaderText = "Presentacion";
            dgv_productos.Columns[4].Width = 70;
            dgv_productos.Columns[4].HeaderText = "Peso en KG";
            dgv_productos.Columns[5].Width = 70;
            dgv_productos.Columns[5].HeaderText = "Unidades en bodegas";
            dgv_productos.Columns[6].Width = 100;
            dgv_productos.Columns[6].HeaderText = "Categorias";
            dgv_productos.Columns[7].Width = 100;
            dgv_productos.Columns[7].HeaderText = "Productor";



        }


        private void ListadoProductos(string ctexto)
        {
            D_Productos Datos = new D_Productos();
            dgv_productos.DataSource = Datos.Listado_Productos(ctexto);
            formato_productos();

        }

        private void selecciona_item_productores()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_productos.CurrentRow.Cells["idProducto"].Value)))
            {
                MessageBox.Show("No se tiene informacion seleccionada",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                this.vcodigo_producto = Convert.ToInt32(dgv_productos.CurrentRow.Cells["idProducto"].Value);
                this.txt_Nombre.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["nombre"].Value);
                this.txt_Presentacion.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["presentacionComercial"].Value);
                this.txt_PrecioU.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["precioUnitarioActual"].Value);
                this.txt_PesoKG.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["pesoEnKilogramos"].Value);
                this.txt_Existencias.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["unidadesEnBodega"].Value);
                this.txt_CodigoBarra.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["codigoBarras"].Value);
                this.cbox_Categoria.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["CategoriaNombre"].Value);
                this.cbox_Productor.Text = Convert.ToString(dgv_productos.CurrentRow.Cells["NombreProductor"].Value);
            }
        }

        #endregion


        private void Productor_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            
        }


        private void Productos_Load(object sender, EventArgs e)
        {
            this.ListadoProductos("%");
            cargar_productores();
            cargar_categorias();
            EstadoTexto(false);
            LimpiarText();
            dgv_productos.Enabled = false;
        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == string.Empty || txt_Existencias.Text == string.Empty || cbox_Categoria.Text == string.Empty || cbox_Productor.Text == string.Empty || txt_Existencias.Text == string.Empty || txt_PesoKG.Text == string.Empty || txt_PrecioU.Text == string.Empty || txt_Presentacion.Text == string.Empty || txt_CodigoBarra.Text == string.Empty)

            {
                MessageBox.Show("no se han ingresado todos los campos requeridos (*)",
                    "Mensaje del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                string Rpta = "";
                E_Productos oProducto = new E_Productos();

                //oCiudad.idCiudad = this.vcodigo_Ciudad;
                oProducto.idProducto = this.vcodigo_producto;
                oProducto.Nombre = Convert.ToString(txt_Nombre.Text); // Desde el TextBox
                oProducto.CodigoBarras = Convert.ToString(txt_CodigoBarra.Text); // Desde el TextBox
                oProducto.PresentacionComercial = Convert.ToString(txt_Presentacion.Text); // Desde el TextBox
                oProducto.PrecioUnitarioActual = Convert.ToDecimal(txt_PrecioU.Text); // Desde el TextBox
                oProducto.PesoEnKilogramos = Convert.ToDecimal(txt_PesoKG.Text); // Desde el TextBox
                oProducto.UnidadesEnBodega = Convert.ToInt32(txt_Existencias.Text); // Desde el TextBox
                oProducto.IdCategoria = Convert.ToInt32(cbox_Categoria.SelectedValue); // Desde el ComboBox
                oProducto.idProductor = Convert.ToInt32(cbox_Productor.SelectedValue); // Desde el ComboBox



                D_Productos Datos = new D_Productos();

                // Llamada al método Guardar_Ciudad, convirtiendo EstadoGuardar a int en la misma línea
                Rpta = Datos.Guardar_Producto(this.EstadoGuardar, oProducto);


                if ((Rpta) == "Ok")
                {
                    this.ListadoProductos("%");
                    MessageBox.Show("Se ha guardado el producto exitosamente");
                    this.vcodigo_producto = 0;
                    LimpiarText();

                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {

        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            this.EstadoGuardar = 2;
            EstadoTexto(true);
            EstadoBotones(true);
            LimpiarText();
            dgv_productos.Enabled = true;
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoTexto(true);
            EstadoBotones(true);
            LimpiarText();
            dgv_productos.Enabled = false;
        }

        private void dgv_productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selecciona_item_productores();
        }
    }
}
