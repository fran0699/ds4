namespace Laboratorio131
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConectarDesconectar = new System.Windows.Forms.Button();
            this.lbProductos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnConectarDesconectar
            // 
            this.btnConectarDesconectar.Location = new System.Drawing.Point(320, 77);
            this.btnConectarDesconectar.Name = "btnConectarDesconectar";
            this.btnConectarDesconectar.Size = new System.Drawing.Size(130, 50);
            this.btnConectarDesconectar.TabIndex = 0;
            this.btnConectarDesconectar.Text = "Conectar y desconectar de SQL Server";
            this.btnConectarDesconectar.UseVisualStyleBackColor = true;
            this.btnConectarDesconectar.Click += new System.EventHandler(this.btnConectarDesconectar_Click);
            // 
            // lbProductos
            // 
            this.lbProductos.FormattingEnabled = true;
            this.lbProductos.Location = new System.Drawing.Point(289, 160);
            this.lbProductos.Name = "lbProductos";
            this.lbProductos.Size = new System.Drawing.Size(190, 251);
            this.lbProductos.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbProductos);
            this.Controls.Add(this.btnConectarDesconectar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConectarDesconectar;
        private System.Windows.Forms.ListBox lbProductos;
    }
}

