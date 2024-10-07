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
    public partial class Ciudades : Form
    {
        public Ciudades()
        {
            InitializeComponent();
        }

        #region "MIS VARIABLES"
            int EstadoGuardar = 1;
            int vcodigo_Ciudad = 0;
        #endregion

        #region "MIS MÉTODOS" 
            private void cargarCiudades()
            {
                D_Ciudades ciudades = new D_Ciudades();

                
            }

            private void EstadoTexto(bool Lstado)
            {
                txt_ciudad.Enabled = Lstado;
            
            }


        private void EstadoBotones(bool lEstado)
            {
                btn_cancelar.Visible = lEstado;
                btn_guardar.Visible = lEstado;

                btn_buscar.Enabled = lEstado;
                txt_buscarCiudad.Enabled = lEstado;
           


            }

        private void formato_ciudades()
            {
                dgv_listaCiudades.Columns[0].Width = 50;
                dgv_listaCiudades.Columns[0].HeaderText = "ID CIUDAD";
                dgv_listaCiudades.Columns[1].Width = 150;
                dgv_listaCiudades.Columns[1].HeaderText = "CIUDAD";
              

            }


            private void ListadoCiudades(string ctexto)
            {
                D_Ciudades Datos = new D_Ciudades();
                dgv_listaCiudades.DataSource = Datos.listado_ciudades(ctexto);
                this.formato_ciudades();
            }

        private void selecciona_item_ciudad()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_listaCiudades.CurrentRow.Cells["idCiudad"].Value)))
            {
                MessageBox.Show("No se tiene informacion seleccionada",
                    "Aviso del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                this.vcodigo_Ciudad = Convert.ToInt32((dgv_listaCiudades.CurrentRow.Cells["idCiudad"].Value));
                this.txt_ciudad.Text = Convert.ToString(dgv_listaCiudades.CurrentRow.Cells["nombre"].Value);
                

            }
        }

        #endregion
        private void Ciudades_Load(object sender, EventArgs e)
        {
            this.ListadoCiudades("%");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardarCiudad(object sender, EventArgs e)
        {
            if (txt_ciudad.Text == string.Empty
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
                E_Ciudades oCiudad = new E_Ciudades();

                //oCiudad.idCiudad = this.vcodigo_Ciudad;
                oCiudad.nombre = Convert.ToString(txt_ciudad.Text);

                oCiudad.idCiudad = vcodigo_Ciudad;
               
                D_Ciudades Datos = new D_Ciudades();

                // Llamada al método Guardar_Ciudad, convirtiendo EstadoGuardar a int en la misma línea
                Rpta = Datos.Guardar_Ciudad(this.EstadoGuardar, oCiudad);


                if ((Rpta) == "Ok")
                {
                    this.ListadoCiudades("%");
                    MessageBox.Show("Se ha guardado el producto exitosamente");
                    this.vcodigo_Ciudad = 0;

                }
                else
                {   
                    MessageBox.Show(Rpta);
                }
            }
        }

        private void dgv_listaCiudades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selecciona_item_ciudad();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //actualizar
            this.EstadoGuardar = 2;
            txt_ciudad.Select();
            this.EstadoTexto(true);
            this.EstadoBotones(true);
            dgv_listaCiudades.Enabled = true;
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            this.vcodigo_Ciudad = 0;
            this.EstadoGuardar = 1;
            this.EstadoTexto(true);
            this.EstadoBotones(true);
            dgv_listaCiudades.Enabled = false;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.EstadoBotones(true);
            this.EstadoTexto(false);
        }
    }
    
}
