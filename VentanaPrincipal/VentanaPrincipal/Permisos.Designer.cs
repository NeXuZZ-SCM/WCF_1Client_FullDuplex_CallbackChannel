namespace VentanaPrincipal
{
    partial class Permisos
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
            this.chkboxList_Permisos = new System.Windows.Forms.CheckedListBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_Apellido = new System.Windows.Forms.Label();
            this.lbl_Permisos = new System.Windows.Forms.Label();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_NuevosPermisos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(114, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ventana Permisos";
            // 
            // chkboxList_Permisos
            // 
            this.chkboxList_Permisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxList_Permisos.FormattingEnabled = true;
            this.chkboxList_Permisos.Location = new System.Drawing.Point(275, 90);
            this.chkboxList_Permisos.Name = "chkboxList_Permisos";
            this.chkboxList_Permisos.Size = new System.Drawing.Size(203, 244);
            this.chkboxList_Permisos.TabIndex = 6;
            this.chkboxList_Permisos.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkboxList_Permisos_ItemCheck);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre.Location = new System.Drawing.Point(12, 166);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(181, 24);
            this.lbl_nombre.TabIndex = 7;
            this.lbl_nombre.Text = "NOMBRE USUARIO";
            // 
            // lbl_Apellido
            // 
            this.lbl_Apellido.AutoSize = true;
            this.lbl_Apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Apellido.Location = new System.Drawing.Point(12, 190);
            this.lbl_Apellido.Name = "lbl_Apellido";
            this.lbl_Apellido.Size = new System.Drawing.Size(188, 24);
            this.lbl_Apellido.TabIndex = 8;
            this.lbl_Apellido.Text = "APELLIDO USUARIO";
            // 
            // lbl_Permisos
            // 
            this.lbl_Permisos.AutoSize = true;
            this.lbl_Permisos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Permisos.Location = new System.Drawing.Point(13, 131);
            this.lbl_Permisos.Name = "lbl_Permisos";
            this.lbl_Permisos.Size = new System.Drawing.Size(136, 19);
            this.lbl_Permisos.TabIndex = 9;
            this.lbl_Permisos.Text = "PERMISOS PARA: ";
            // 
            // btn_editar
            // 
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_editar.Location = new System.Drawing.Point(206, 90);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(63, 244);
            this.btn_editar.TabIndex = 10;
            this.btn_editar.Text = "EDITAR";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_NuevosPermisos
            // 
            this.btn_NuevosPermisos.Location = new System.Drawing.Point(17, 281);
            this.btn_NuevosPermisos.Name = "btn_NuevosPermisos";
            this.btn_NuevosPermisos.Size = new System.Drawing.Size(183, 53);
            this.btn_NuevosPermisos.TabIndex = 11;
            this.btn_NuevosPermisos.Text = "Nuevos Permisos";
            this.btn_NuevosPermisos.UseVisualStyleBackColor = true;
            this.btn_NuevosPermisos.Click += new System.EventHandler(this.btn_NuevosPermisos_Click);
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 352);
            this.Controls.Add(this.btn_NuevosPermisos);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.lbl_Permisos);
            this.Controls.Add(this.lbl_Apellido);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.chkboxList_Permisos);
            this.Controls.Add(this.label1);
            this.Name = "Permisos";
            this.Text = "UI_Permisos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chkboxList_Permisos;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_Apellido;
        private System.Windows.Forms.Label lbl_Permisos;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_NuevosPermisos;
    }
}