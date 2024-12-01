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
            this.label3 = new System.Windows.Forms.Label();
            this.lblWeekDays = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBar = new System.Windows.Forms.Label();
            this.lblLevelPoint = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalMinutesWeek = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbControl)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProgressTime
            // 
            this.pbProgressTime.Location = new System.Drawing.Point(15, 50);
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
            this.txtProgressTime.Location = new System.Drawing.Point(83, 14);
            this.txtProgressTime.MaxLength = 4;
            this.txtProgressTime.Name = "txtProgressTime";
            this.txtProgressTime.Size = new System.Drawing.Size(56, 26);
            this.txtProgressTime.TabIndex = 2;
            this.txtProgressTime.TextChanged += new System.EventHandler(this.txtProgressTime_TextChanged);
            this.txtProgressTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProgressTime_KeyPress);
            this.txtProgressTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProgressTime_KeyUp);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(182, 20);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(64, 17);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = " 00 : 00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "End:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minutes :";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Lavender;
            this.btnStop.Location = new System.Drawing.Point(333, 18);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(59, 25);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Finish";
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
            this.ckbSound.Location = new System.Drawing.Point(257, 19);
            this.ckbSound.Name = "ckbSound";
            this.ckbSound.Size = new System.Drawing.Size(70, 22);
            this.ckbSound.TabIndex = 6;
            this.ckbSound.Text = "Sound";
            this.ckbSound.UseVisualStyleBackColor = true;
            // 
            // pbControl
            // 
            this.pbControl.BackColor = System.Drawing.Color.Transparent;
            this.pbControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbControl.Location = new System.Drawing.Point(360, 45);
            this.pbControl.Name = "pbControl";
            this.pbControl.Size = new System.Drawing.Size(32, 32);
            this.pbControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbControl.TabIndex = 5;
            this.pbControl.TabStop = false;
            this.pbControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(160, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "M   T   W   T   F   S   S   ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // lblWeekDays
            // 
            this.lblWeekDays.AutoSize = true;
            this.lblWeekDays.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.lblWeekDays.ForeColor = System.Drawing.Color.LightGray;
            this.lblWeekDays.Location = new System.Drawing.Point(160, 116);
            this.lblWeekDays.Name = "lblWeekDays";
            this.lblWeekDays.Size = new System.Drawing.Size(16, 18);
            this.lblWeekDays.TabIndex = 8;
            this.lblWeekDays.Text = "0";
            this.lblWeekDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWeekDays.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 105);
            this.label4.TabIndex = 9;
            this.label4.Text = "M\r\nT\r\nW\r\nT\r\nF\r\nS\r\nS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBar
            // 
            this.lblBar.AutoSize = true;
            this.lblBar.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBar.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblBar.Location = new System.Drawing.Point(28, 86);
            this.lblBar.Name = "lblBar";
            this.lblBar.Size = new System.Drawing.Size(77, 15);
            this.lblBar.TabIndex = 10;
            this.lblBar.Text = "Hi Padawan";
            this.lblBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLevelPoint
            // 
            this.lblLevelPoint.AutoSize = true;
            this.lblLevelPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelPoint.ForeColor = System.Drawing.Color.LightGreen;
            this.lblLevelPoint.Location = new System.Drawing.Point(314, 175);
            this.lblLevelPoint.Name = "lblLevelPoint";
            this.lblLevelPoint.Size = new System.Drawing.Size(26, 25);
            this.lblLevelPoint.TabIndex = 11;
            this.lblLevelPoint.Text = "●";
            this.lblLevelPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLevelPoint.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(332, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "High";
            this.label6.Visible = false;
            // 
            // lblTotalMinutesWeek
            // 
            this.lblTotalMinutesWeek.AutoSize = true;
            this.lblTotalMinutesWeek.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.lblTotalMinutesWeek.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTotalMinutesWeek.Location = new System.Drawing.Point(28, 203);
            this.lblTotalMinutesWeek.Name = "lblTotalMinutesWeek";
            this.lblTotalMinutesWeek.Size = new System.Drawing.Size(70, 15);
            this.lblTotalMinutesWeek.TabIndex = 13;
            this.lblTotalMinutesWeek.Text = "Total: 0m";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(406, 227);
            this.Controls.Add(this.lblTotalMinutesWeek);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLevelPoint);
            this.Controls.Add(this.lblBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWeekDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.ckbSound);
            this.Controls.Add(this.pbControl);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWeekDays;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBar;
        private System.Windows.Forms.Label lblLevelPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalMinutesWeek;
    }
}

