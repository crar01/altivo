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
            this.tmrTimeControl = new System.Windows.Forms.Timer(this.components);
            this.txtProgressTime = new System.Windows.Forms.TextBox();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblModeMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbSound = new System.Windows.Forms.CheckBox();
            this.ckbFloatingTimer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWeekDays = new System.Windows.Forms.Label();
            this.lblLevelPoint = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalMinutesWeek = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbControl = new System.Windows.Forms.PictureBox();
            this.pbProgressTime = new Altivo.Controls.ModernProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbControl)).BeginInit();
            this.SuspendLayout();
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
            this.txtProgressTime.TabIndex = 0;
            this.txtProgressTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProgressTime_KeyPress);
            this.txtProgressTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProgressTime_KeyUp);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(580, 53);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(64, 17);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = " 00 : 00";
            // 
            // lblModeMessage
            // 
            this.lblModeMessage.AutoSize = true;
            this.lblModeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModeMessage.Location = new System.Drawing.Point(145, 18);
            this.lblModeMessage.Name = "lblModeMessage";
            this.lblModeMessage.Size = new System.Drawing.Size(11, 16);
            this.lblModeMessage.TabIndex = 20;
            this.lblModeMessage.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Minutes :";
            // 
            // ckbSound
            // 
            this.ckbSound.AutoSize = true;
            this.ckbSound.Checked = true;
            this.ckbSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbSound.Location = new System.Drawing.Point(583, 15);
            this.ckbSound.Name = "ckbSound";
            this.ckbSound.Size = new System.Drawing.Size(61, 22);
            this.ckbSound.TabIndex = 6;
            this.ckbSound.Text = "Beep";
            this.ckbSound.UseVisualStyleBackColor = true;
            // 
            // ckbFloatingTimer
            // 
            this.ckbFloatingTimer.AutoSize = true;
            this.ckbFloatingTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbFloatingTimer.Location = new System.Drawing.Point(467, 15);
            this.ckbFloatingTimer.Name = "ckbFloatingTimer";
            this.ckbFloatingTimer.Size = new System.Drawing.Size(110, 22);
            this.ckbFloatingTimer.TabIndex = 22;
            this.ckbFloatingTimer.Text = "Widget timer";
            this.ckbFloatingTimer.UseVisualStyleBackColor = true;
            this.ckbFloatingTimer.CheckedChanged += new System.EventHandler(this.ckbFloatingTimer_CheckedChanged);
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
            // lblLevelPoint
            // 
            this.lblLevelPoint.AutoSize = true;
            this.lblLevelPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelPoint.ForeColor = System.Drawing.Color.LightGreen;
            this.lblLevelPoint.Location = new System.Drawing.Point(314, 175);
            this.lblLevelPoint.Name = "lblLevelPoint";
            this.lblLevelPoint.Size = new System.Drawing.Size(25, 25);
            this.lblLevelPoint.TabIndex = 11;
            this.lblLevelPoint.Text = "?";
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
            this.lblTotalMinutesWeek.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMinutesWeek.ForeColor = System.Drawing.Color.LightGray;
            this.lblTotalMinutesWeek.Location = new System.Drawing.Point(12, 210);
            this.lblTotalMinutesWeek.Name = "lblTotalMinutesWeek";
            this.lblTotalMinutesWeek.Size = new System.Drawing.Size(120, 18);
            this.lblTotalMinutesWeek.TabIndex = 13;
            this.lblTotalMinutesWeek.Text = "Total week: 0m";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Altivo.Properties.Resources.bell_bell;
            this.pictureBox2.Location = new System.Drawing.Point(566, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Altivo.Properties.Resources.Altivo_Photoroom;
            this.pictureBox1.Location = new System.Drawing.Point(650, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pbControl
            // 
            this.pbControl.BackColor = System.Drawing.Color.Transparent;
            this.pbControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbControl.Location = new System.Drawing.Point(528, 45);
            this.pbControl.Name = "pbControl";
            this.pbControl.Size = new System.Drawing.Size(32, 32);
            this.pbControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbControl.TabIndex = 5;
            this.pbControl.TabStop = false;
            this.pbControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // pbProgressTime
            // 
            this.pbProgressTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.pbProgressTime.CornerRadius = 4;
            this.pbProgressTime.Location = new System.Drawing.Point(15, 50);
            this.pbProgressTime.Margin = new System.Windows.Forms.Padding(4);
            this.pbProgressTime.Maximum = 100;
            this.pbProgressTime.Minimum = 0;
            this.pbProgressTime.MinimumSize = new System.Drawing.Size(50, 20);
            this.pbProgressTime.Name = "pbProgressTime";
            this.pbProgressTime.PercentageFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.pbProgressTime.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(151)))), ((int)(((byte)(105)))));
            this.pbProgressTime.ShowPercentage = false;
            this.pbProgressTime.Size = new System.Drawing.Size(506, 27);
            this.pbProgressTime.TabIndex = 0;
            this.pbProgressTime.TextColor = System.Drawing.Color.WhiteSmoke;
            this.pbProgressTime.Value = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(734, 561);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTotalMinutesWeek);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLevelPoint);
            this.Controls.Add(this.lblWeekDays);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblModeMessage);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.ckbSound);
            this.Controls.Add(this.ckbFloatingTimer);
            this.Controls.Add(this.pbControl);
            this.Controls.Add(this.label2);
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
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ModernProgressBar pbProgressTime;
        private System.Windows.Forms.Timer tmrTimeControl;
        private System.Windows.Forms.TextBox txtProgressTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblModeMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbControl;
        private System.Windows.Forms.CheckBox ckbSound;
        private System.Windows.Forms.CheckBox ckbFloatingTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWeekDays;
        private System.Windows.Forms.Label lblLevelPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalMinutesWeek;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

