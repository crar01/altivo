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
            this.pbProgressTime = new System.Windows.Forms.ProgressBar();
            this.tmrTimeControl = new System.Windows.Forms.Timer(this.components);
            this.txtProgressTime = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.ckbSound = new System.Windows.Forms.CheckBox();
            this.pbControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProgressTime
            // 
            this.pbProgressTime.Location = new System.Drawing.Point(42, 52);
            this.pbProgressTime.Margin = new System.Windows.Forms.Padding(4);
            this.pbProgressTime.Name = "pbProgressTime";
            this.pbProgressTime.Size = new System.Drawing.Size(338, 23);
            this.pbProgressTime.TabIndex = 0;
            // 
            // tmrTimeControl
            // 
            this.tmrTimeControl.Interval = 1000;
            this.tmrTimeControl.Tick += new System.EventHandler(this.tmrTimeControl_Tick);
            // 
            // txtProgressTime
            // 
            this.txtProgressTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtProgressTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProgressTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgressTime.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtProgressTime.Location = new System.Drawing.Point(110, 16);
            this.txtProgressTime.Name = "txtProgressTime";
            this.txtProgressTime.Size = new System.Drawing.Size(56, 35);
            this.txtProgressTime.TabIndex = 2;
            this.txtProgressTime.TextChanged += new System.EventHandler(this.txtProgressTime_TextChanged);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(316, 21);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(85, 25);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = " 00 : 00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "End:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minutes :";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Lavender;
            this.btnStop.Location = new System.Drawing.Point(293, 82);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 25);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // ckbSound
            // 
            this.ckbSound.AutoSize = true;
            this.ckbSound.Checked = true;
            this.ckbSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSound.Location = new System.Drawing.Point(42, 85);
            this.ckbSound.Name = "ckbSound";
            this.ckbSound.Size = new System.Drawing.Size(109, 33);
            this.ckbSound.TabIndex = 6;
            this.ckbSound.Text = "Sound";
            this.ckbSound.UseVisualStyleBackColor = true;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(459, 122);
            this.Controls.Add(this.ckbSound);
            this.Controls.Add(this.pbControl);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.txtProgressTime);
            this.Controls.Add(this.pbProgressTime);
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

        private System.Windows.Forms.ProgressBar pbProgressTime;
        private System.Windows.Forms.Timer tmrTimeControl;
        private System.Windows.Forms.TextBox txtProgressTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.PictureBox pbControl;
        private System.Windows.Forms.CheckBox ckbSound;
    }
}

