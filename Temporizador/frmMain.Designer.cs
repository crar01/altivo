namespace Altivo
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pbTiempoPlanificado = new System.Windows.Forms.ProgressBar();
            this.tmrControlTiempo = new System.Windows.Forms.Timer(this.components);
            this.txtTiempoPlaneado = new System.Windows.Forms.TextBox();
            this.lblTiempoFinal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetener = new System.Windows.Forms.Button();
            this.ckbSonido = new System.Windows.Forms.CheckBox();
            this.pbControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTiempoPlanificado
            // 
            this.pbTiempoPlanificado.Location = new System.Drawing.Point(42, 52);
            this.pbTiempoPlanificado.Margin = new System.Windows.Forms.Padding(4);
            this.pbTiempoPlanificado.Name = "pbTiempoPlanificado";
            this.pbTiempoPlanificado.Size = new System.Drawing.Size(338, 23);
            this.pbTiempoPlanificado.TabIndex = 0;
            // 
            // tmrControlTiempo
            // 
            this.tmrControlTiempo.Interval = 1000;
            this.tmrControlTiempo.Tick += new System.EventHandler(this.tmrControlTiempo_Tick);
            // 
            // txtTiempoPlaneado
            // 
            this.txtTiempoPlaneado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtTiempoPlaneado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTiempoPlaneado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTiempoPlaneado.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtTiempoPlaneado.Location = new System.Drawing.Point(110, 16);
            this.txtTiempoPlaneado.Name = "txtTiempoPlaneado";
            this.txtTiempoPlaneado.Size = new System.Drawing.Size(56, 26);
            this.txtTiempoPlaneado.TabIndex = 2;
            this.txtTiempoPlaneado.TextChanged += new System.EventHandler(this.txtTiempoPlaneado_TextChanged);
            // 
            // lblTiempoFinal
            // 
            this.lblTiempoFinal.AutoSize = true;
            this.lblTiempoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoFinal.Location = new System.Drawing.Point(316, 21);
            this.lblTiempoFinal.Name = "lblTiempoFinal";
            this.lblTiempoFinal.Size = new System.Drawing.Size(64, 17);
            this.lblTiempoFinal.TabIndex = 3;
            this.lblTiempoFinal.Text = " 00 : 00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "End:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minutes :";
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDetener.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetener.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.ForeColor = System.Drawing.Color.Lavender;
            this.btnDetener.Location = new System.Drawing.Point(293, 82);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(87, 25);
            this.btnDetener.TabIndex = 4;
            this.btnDetener.Text = "Stop";
            this.btnDetener.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Visible = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // ckbSonido
            // 
            this.ckbSonido.AutoSize = true;
            this.ckbSonido.Checked = true;
            this.ckbSonido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSonido.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSonido.Location = new System.Drawing.Point(42, 85);
            this.ckbSonido.Name = "ckbSonido";
            this.ckbSonido.Size = new System.Drawing.Size(70, 22);
            this.ckbSonido.TabIndex = 6;
            this.ckbSonido.Text = "Sound";
            this.ckbSonido.UseVisualStyleBackColor = true;
            // 
            // pbControl
            // 
            this.pbControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbControl.Location = new System.Drawing.Point(387, 47);
            this.pbControl.Name = "pbControl";
            this.pbControl.Size = new System.Drawing.Size(32, 32);
            this.pbControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbControl.TabIndex = 5;
            this.pbControl.TabStop = false;
            this.pbControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(459, 122);
            this.Controls.Add(this.ckbSonido);
            this.Controls.Add(this.pbControl);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTiempoFinal);
            this.Controls.Add(this.txtTiempoPlaneado);
            this.Controls.Add(this.pbTiempoPlanificado);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Altivo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbTiempoPlanificado;
        private System.Windows.Forms.Timer tmrControlTiempo;
        private System.Windows.Forms.TextBox txtTiempoPlaneado;
        private System.Windows.Forms.Label lblTiempoFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.PictureBox pbControl;
        private System.Windows.Forms.CheckBox ckbSonido;
    }
}

