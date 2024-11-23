namespace Altivo.Forms
{
    partial class FrmConcentrationRate
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
            this.btnNone = new System.Windows.Forms.Button();
            this.btnLow = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHigh = new System.Windows.Forms.Button();
            this.btnExtreme = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNone
            // 
            this.btnNone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNone.Location = new System.Drawing.Point(15, 55);
            this.btnNone.Margin = new System.Windows.Forms.Padding(4);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(66, 28);
            this.btnNone.TabIndex = 0;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnLow
            // 
            this.btnLow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLow.Location = new System.Drawing.Point(89, 55);
            this.btnLow.Margin = new System.Windows.Forms.Padding(4);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(66, 28);
            this.btnLow.TabIndex = 1;
            this.btnLow.Text = "Low";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMedium.Location = new System.Drawing.Point(163, 55);
            this.btnMedium.Margin = new System.Windows.Forms.Padding(4);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(66, 28);
            this.btnMedium.TabIndex = 2;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHigh
            // 
            this.btnHigh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHigh.Location = new System.Drawing.Point(237, 55);
            this.btnHigh.Margin = new System.Windows.Forms.Padding(4);
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(66, 28);
            this.btnHigh.TabIndex = 3;
            this.btnHigh.Text = "High";
            this.btnHigh.UseVisualStyleBackColor = true;
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnExtreme
            // 
            this.btnExtreme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtreme.Location = new System.Drawing.Point(311, 55);
            this.btnExtreme.Margin = new System.Windows.Forms.Padding(4);
            this.btnExtreme.Name = "btnExtreme";
            this.btnExtreme.Size = new System.Drawing.Size(66, 28);
            this.btnExtreme.TabIndex = 4;
            this.btnExtreme.Text = "Extreme";
            this.btnExtreme.UseVisualStyleBackColor = true;
            this.btnExtreme.Click += new System.EventHandler(this.btnExtreme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Level of Concentration";
            // 
            // FrmConcentrationRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 105);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExtreme);
            this.Controls.Add(this.btnHigh);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.btnNone);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmConcentrationRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmConcentrationRate";
            this.Load += new System.EventHandler(this.FrmConcentrationRate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnLow;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHigh;
        private System.Windows.Forms.Button btnExtreme;
        private System.Windows.Forms.Label label1;
    }
}