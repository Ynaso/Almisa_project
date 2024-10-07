namespace Almisa_project.Presentacion
{
    partial class Ciudades
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ciudad = new System.Windows.Forms.TextBox();
            this.dgv_listaCiudades = new System.Windows.Forms.DataGridView();
            this.txt_buscarCiudad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_nuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listaCiudades)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escribe la ciudad";
            // 
            // txt_ciudad
            // 
            this.txt_ciudad.Location = new System.Drawing.Point(155, 71);
            this.txt_ciudad.Name = "txt_ciudad";
            this.txt_ciudad.Size = new System.Drawing.Size(155, 26);
            this.txt_ciudad.TabIndex = 1;
            this.txt_ciudad.TextChanged += new System.EventHandler(this.label2_Click);
            // 
            // dgv_listaCiudades
            // 
            this.dgv_listaCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listaCiudades.Location = new System.Drawing.Point(35, 277);
            this.dgv_listaCiudades.Name = "dgv_listaCiudades";
            this.dgv_listaCiudades.RowHeadersWidth = 62;
            this.dgv_listaCiudades.RowTemplate.Height = 28;
            this.dgv_listaCiudades.Size = new System.Drawing.Size(365, 150);
            this.dgv_listaCiudades.TabIndex = 2;
            this.dgv_listaCiudades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_listaCiudades_CellClick);
            // 
            // txt_buscarCiudad
            // 
            this.txt_buscarCiudad.Location = new System.Drawing.Point(151, 223);
            this.txt_buscarCiudad.Name = "txt_buscarCiudad";
            this.txt_buscarCiudad.Size = new System.Drawing.Size(155, 26);
            this.txt_buscarCiudad.TabIndex = 4;
            this.txt_buscarCiudad.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Buscar ciudad";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_buscar.Location = new System.Drawing.Point(312, 218);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(88, 36);
            this.btn_buscar.TabIndex = 5;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_cancelar.Location = new System.Drawing.Point(316, 46);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(84, 36);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_guardar.Location = new System.Drawing.Point(316, 88);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(84, 36);
            this.btn_guardar.TabIndex = 7;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardarCiudad);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_actualizar.Location = new System.Drawing.Point(114, 3);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(99, 36);
            this.btn_actualizar.TabIndex = 8;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_nuevo.Location = new System.Drawing.Point(24, 3);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(84, 36);
            this.btn_nuevo.TabIndex = 9;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // Ciudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 473);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.txt_buscarCiudad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_listaCiudades);
            this.Controls.Add(this.txt_ciudad);
            this.Controls.Add(this.label1);
            this.Name = "Ciudades";
            this.Text = "Ciudades";
            this.Load += new System.EventHandler(this.Ciudades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listaCiudades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ciudad;
        private System.Windows.Forms.DataGridView dgv_listaCiudades;
        private System.Windows.Forms.TextBox txt_buscarCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_nuevo;
    }
}