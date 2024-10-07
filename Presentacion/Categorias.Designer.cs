namespace Almisa_project.Presentacion
{
    partial class Categorias
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
            this.txt_CategoriaName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CategoriaDescripcion = new System.Windows.Forms.TextBox();
            this.btn_nuevo = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.dgv_categorias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categorias)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_CategoriaName
            // 
            this.txt_CategoriaName.Location = new System.Drawing.Point(115, 65);
            this.txt_CategoriaName.Name = "txt_CategoriaName";
            this.txt_CategoriaName.Size = new System.Drawing.Size(299, 26);
            this.txt_CategoriaName.TabIndex = 0;
            this.txt_CategoriaName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion";
            // 
            // txt_CategoriaDescripcion
            // 
            this.txt_CategoriaDescripcion.Location = new System.Drawing.Point(115, 122);
            this.txt_CategoriaDescripcion.Name = "txt_CategoriaDescripcion";
            this.txt_CategoriaDescripcion.Size = new System.Drawing.Size(299, 26);
            this.txt_CategoriaDescripcion.TabIndex = 2;
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(775, 68);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(88, 46);
            this.btn_nuevo.TabIndex = 4;
            this.btn_nuevo.Text = "Nuevo";
            this.btn_nuevo.UseVisualStyleBackColor = true;
            this.btn_nuevo.Click += new System.EventHandler(this.btn_nuevo_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Location = new System.Drawing.Point(775, 13);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(88, 46);
            this.btn_actualizar.TabIndex = 5;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(461, 197);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(88, 46);
            this.btn_cancelar.TabIndex = 7;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_guardar
            // 
            this.btn_guardar.Location = new System.Drawing.Point(373, 197);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(82, 46);
            this.btn_guardar.TabIndex = 6;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = true;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // dgv_categorias
            // 
            this.dgv_categorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_categorias.Location = new System.Drawing.Point(21, 249);
            this.dgv_categorias.Name = "dgv_categorias";
            this.dgv_categorias.RowHeadersWidth = 62;
            this.dgv_categorias.RowTemplate.Height = 28;
            this.dgv_categorias.Size = new System.Drawing.Size(842, 187);
            this.dgv_categorias.TabIndex = 8;
            this.dgv_categorias.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_categorias_CellContentDoubleClick);
            this.dgv_categorias.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dgv_categorias_CellContextMenuStripNeeded);
            // 
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 448);
            this.Controls.Add(this.dgv_categorias);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_guardar);
            this.Controls.Add(this.btn_actualizar);
            this.Controls.Add(this.btn_nuevo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CategoriaDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_CategoriaName);
            this.Name = "Categorias";
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.Categorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_categorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_CategoriaName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CategoriaDescripcion;
        private System.Windows.Forms.Button btn_nuevo;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.DataGridView dgv_categorias;
    }
}