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
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        #region "MIS VARIABLES"
        int EstadoGuardar = 1;
        int vcodigo_Categoria = 0;
        #endregion

        #region "MIS MÉTODOS" 
        private void cargarCategorias()
        {
            D_Categorias categorias = new D_Categorias();


        }

        private void EstadoTexto(bool Lstado)
        {
            txt_CategoriaName.Enabled = Lstado;
            txt_CategoriaDescripcion.Enabled = Lstado;
        }


        private void EstadoBotones(bool lEstado)
        {
            btn_cancelar.Visible = lEstado;
            btn_guardar.Visible = lEstado;

   

        }

        private void formato_categorias()
        {
            dgv_categorias.Columns[0].Width = 50;
            dgv_categorias.Columns[0].HeaderText = "ID Categoria";
            dgv_categorias.Columns[1].Width = 200;
            dgv_categorias.Columns[1].HeaderText = "Categoria";
            dgv_categorias.Columns[2].Width = 250;
            dgv_categorias.Columns[2].HeaderText = "Descipcion";


        }


        private void ListadoCategorias(string ctexto)
        {
            D_Categorias Datos = new D_Categorias();
            dgv_categorias.DataSource = Datos.listar_categorias(ctexto);
            this.formato_categorias();
        }

        private void selecciona_item_categoria()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_categorias.CurrentRow.Cells["idCategoria"].Value)))
            {
                MessageBox.Show("No se tiene informacion seleccionada",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                this.vcodigo_Categoria = Convert.ToInt32(dgv_categorias.CurrentRow.Cells["idCategoria"].Value);
                this.txt_CategoriaName.Text = Convert.ToString(dgv_categorias.CurrentRow.Cells["nombre"].Value);
                this.txt_CategoriaDescripcion.Text = Convert.ToString(dgv_categorias.CurrentRow.Cells["descripcion"].Value);


            }
        }

        #endregion
        private void Categorias_Load(object sender, EventArgs e)
        {
            this.ListadoCategorias("%");
            this.EstadoTexto(false);
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_CategoriaName.Text == string.Empty
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
                E_Categorias oCategoria = new E_Categorias();

                //oCiudad.idCiudad = this.vcodigo_Ciudad;
                oCategoria.nombre = Convert.ToString(txt_CategoriaName.Text);

                oCategoria.idCategoria = vcodigo_Categoria;

                oCategoria.descripcion = Convert.ToString(txt_CategoriaDescripcion.Text);

                D_Categorias Datos = new D_Categorias();

                // Llamada al método Guardar_Ciudad, convirtiendo EstadoGuardar a int en la misma línea
                Rpta = Datos.guardar_categoria(this.EstadoGuardar, oCategoria);


                if ((Rpta) == "Ok")
                {
                    this.ListadoCategorias("%");
                    MessageBox.Show("Se ha guardado el producto exitosamente");
                    this.vcodigo_Categoria = 0;

                }
                else
                {
                    MessageBox.Show(Rpta);
                }
            }
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            //actualizar
            this.EstadoGuardar = 2;
            txt_CategoriaName.Select();
            this.EstadoTexto(true);
            this.EstadoBotones(true);
            dgv_categorias.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.vcodigo_Categoria = 0;
            this.EstadoGuardar = 1;
            this.EstadoTexto(true);
            this.EstadoBotones(true);
            dgv_categorias.Enabled = false;
        }

        private void dgv_categorias_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {

        }

        private void dgv_categorias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selecciona_item_categoria();
        }
    }
}
