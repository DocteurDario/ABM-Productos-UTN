﻿namespace Activ
{
    partial class Detalle
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
            this.Imagen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxMarca = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cBoxCategoria = new System.Windows.Forms.ComboBox();
            this.textCodigo = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.imagenAnterior = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // Imagen
            // 
            this.Imagen.Location = new System.Drawing.Point(468, 275);
            this.Imagen.Name = "Imagen";
            this.Imagen.Size = new System.Drawing.Size(87, 42);
            this.Imagen.TabIndex = 5;
            this.Imagen.Text = ">>";
            this.Imagen.UseVisualStyleBackColor = true;
            this.Imagen.Click += new System.EventHandler(this.Imagen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pbImagen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textPrecio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUrlImagen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textDescripcion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cBoxMarca);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cBoxCategoria);
            this.groupBox1.Controls.Add(this.textCodigo);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 263);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar articulo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // pbImagen
            // 
            this.pbImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbImagen.Location = new System.Drawing.Point(303, 19);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(271, 238);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 14;
            this.pbImagen.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción:";
            // 
            // textPrecio
            // 
            this.textPrecio.Location = new System.Drawing.Point(84, 190);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(213, 20);
            this.textPrecio.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Marca:";
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(84, 164);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(213, 20);
            this.txtUrlImagen.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Categoria:";
            // 
            // textDescripcion
            // 
            this.textDescripcion.Location = new System.Drawing.Point(84, 84);
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.Size = new System.Drawing.Size(213, 20);
            this.textDescripcion.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio:";
            // 
            // cBoxMarca
            // 
            this.cBoxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxMarca.FormattingEnabled = true;
            this.cBoxMarca.Location = new System.Drawing.Point(84, 110);
            this.cBoxMarca.Name = "cBoxMarca";
            this.cBoxMarca.Size = new System.Drawing.Size(213, 21);
            this.cBoxMarca.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "URL Imagen:";
            // 
            // cBoxCategoria
            // 
            this.cBoxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCategoria.FormattingEnabled = true;
            this.cBoxCategoria.Location = new System.Drawing.Point(84, 137);
            this.cBoxCategoria.Name = "cBoxCategoria";
            this.cBoxCategoria.Size = new System.Drawing.Size(213, 21);
            this.cBoxCategoria.TabIndex = 4;
            // 
            // textCodigo
            // 
            this.textCodigo.Location = new System.Drawing.Point(84, 32);
            this.textCodigo.Name = "textCodigo";
            this.textCodigo.Size = new System.Drawing.Size(213, 20);
            this.textCodigo.TabIndex = 0;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(84, 58);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(213, 20);
            this.textNombre.TabIndex = 1;
            // 
            // imagenAnterior
            // 
            this.imagenAnterior.Location = new System.Drawing.Point(349, 275);
            this.imagenAnterior.Name = "imagenAnterior";
            this.imagenAnterior.Size = new System.Drawing.Size(85, 42);
            this.imagenAnterior.TabIndex = 6;
            this.imagenAnterior.Text = "<<";
            this.imagenAnterior.UseVisualStyleBackColor = true;
            this.imagenAnterior.Click += new System.EventHandler(this.imagenAnterior_Click);
            // 
            // Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 353);
            this.Controls.Add(this.imagenAnterior);
            this.Controls.Add(this.Imagen);
            this.Controls.Add(this.groupBox1);
            this.Name = "Detalle";
            this.Text = "Detalle";
            this.Load += new System.EventHandler(this.Detalle_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Imagen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBoxMarca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cBoxCategoria;
        private System.Windows.Forms.TextBox textCodigo;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button imagenAnterior;
    }
}