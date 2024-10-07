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
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categorias frm_Categoria = new Categorias();

            // Llama al método Show() o ShowDialog() para abrir el formulario
            frm_Categoria.Show();  // Esto abre el formulario de forma no modal, es decir, no bloquea el formulario actual.


        }

        private void button4_Click(object sender, EventArgs e)
        {

            Ciudades frm_Ciudades = new Ciudades();

            // Llama al método Show() o ShowDialog() para abrir el formulario
            frm_Ciudades.Show();  // Esto abre el formulario de forma no modal, es decir, no bloquea el formulario actual.

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Productor frm_Productor = new Productor();

            // Llama al método Show() o ShowDialog() para abrir el formulario
            frm_Productor.Show();  // Esto abre el formulario de forma no modal, es decir, no 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clientes frm_Clientes = new Clientes();

            // Llama al método Show() o ShowDialog() para abrir el formulario
            frm_Clientes.Show();  // Esto abre el formulario de forma no modal, es decir, no 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Productos frm_Productos = new Productos();

            // Llama al método Show() o ShowDialog() para abrir el formulario
            frm_Productos.Show();  // Esto abre el formulario de forma no modal, es decir, no 
        }
    }
}
