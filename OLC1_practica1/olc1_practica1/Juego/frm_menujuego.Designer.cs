namespace OLC1_practica1.Juego
{
    partial class frm_menujuego
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
            this.btnanterior = new System.Windows.Forms.Button();
            this.btnsiguiente = new System.Windows.Forms.Button();
            this.btnselecionar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEscSeleccionar = new System.Windows.Forms.Button();
            this.btnEscSiguiente = new System.Windows.Forms.Button();
            this.btnEscAnterior = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnJugar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnanterior
            // 
            this.btnanterior.Location = new System.Drawing.Point(77, 200);
            this.btnanterior.Name = "btnanterior";
            this.btnanterior.Size = new System.Drawing.Size(75, 23);
            this.btnanterior.TabIndex = 0;
            this.btnanterior.Text = "Anterior";
            this.btnanterior.UseVisualStyleBackColor = true;
            this.btnanterior.Click += new System.EventHandler(this.btnanterior_Click);
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.Location = new System.Drawing.Point(158, 200);
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnsiguiente.TabIndex = 1;
            this.btnsiguiente.Text = "Siguiente";
            this.btnsiguiente.UseVisualStyleBackColor = true;
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // btnselecionar
            // 
            this.btnselecionar.Location = new System.Drawing.Point(77, 241);
            this.btnselecionar.Name = "btnselecionar";
            this.btnselecionar.Size = new System.Drawing.Size(156, 23);
            this.btnselecionar.TabIndex = 2;
            this.btnselecionar.Text = "Seleccionar";
            this.btnselecionar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(77, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 156);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnEscSeleccionar
            // 
            this.btnEscSeleccionar.Location = new System.Drawing.Point(311, 241);
            this.btnEscSeleccionar.Name = "btnEscSeleccionar";
            this.btnEscSeleccionar.Size = new System.Drawing.Size(156, 23);
            this.btnEscSeleccionar.TabIndex = 6;
            this.btnEscSeleccionar.Text = "Seleccionar";
            this.btnEscSeleccionar.UseVisualStyleBackColor = true;
            // 
            // btnEscSiguiente
            // 
            this.btnEscSiguiente.Location = new System.Drawing.Point(392, 200);
            this.btnEscSiguiente.Name = "btnEscSiguiente";
            this.btnEscSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnEscSiguiente.TabIndex = 5;
            this.btnEscSiguiente.Text = "Siguiente";
            this.btnEscSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnEscAnterior
            // 
            this.btnEscAnterior.Location = new System.Drawing.Point(311, 200);
            this.btnEscAnterior.Name = "btnEscAnterior";
            this.btnEscAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnEscAnterior.TabIndex = 4;
            this.btnEscAnterior.Text = "Anterior";
            this.btnEscAnterior.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "ESCENARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "NAVE";
            // 
            // btnJugar
            // 
            this.btnJugar.Location = new System.Drawing.Point(196, 304);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(150, 41);
            this.btnJugar.TabIndex = 10;
            this.btnJugar.Text = "JUGAR";
            this.btnJugar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(314, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 156);
            this.panel1.TabIndex = 11;
            // 
            // frm_menujuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 378);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEscSeleccionar);
            this.Controls.Add(this.btnEscSiguiente);
            this.Controls.Add(this.btnEscAnterior);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnselecionar);
            this.Controls.Add(this.btnsiguiente);
            this.Controls.Add(this.btnanterior);
            this.Name = "frm_menujuego";
            this.Text = "frm_menujuego";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnanterior;
        private System.Windows.Forms.Button btnsiguiente;
        private System.Windows.Forms.Button btnselecionar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEscSeleccionar;
        private System.Windows.Forms.Button btnEscSiguiente;
        private System.Windows.Forms.Button btnEscAnterior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJugar;
        private System.Windows.Forms.Panel panel1;
    }
}