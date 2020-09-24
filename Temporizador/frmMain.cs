using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Altivo
{
    public partial class frmMain: Form
    {
        TaskbarManager _taskBar = TaskbarManager.Instance;
        Time time = new Time();

        public frmMain()
        {                  
            InitializeComponent();
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            pbControl.SizeMode = PictureBoxSizeMode.StretchImage;
            pbControl.BackgroundImage = Properties.Resources.play;
        }

        private void getEndTime()
        {
            int minutes = 0;
            string[] time;

            try
            {
                time = txtProgressTime.Text.Split(':');
                minutes = Convert.ToInt32( time[0]);
                this.time.TotalTime = minutes * 60;

                if ( time.Length == 2 )
                {
                    this.time.TotalTime += Convert.ToInt32(time[ 1 ]);
                }

                lblEndTime.Text = DateTime.Now.AddMinutes( minutes ).ToString( " HH : mm " );
                pbProgressTime.Maximum = this.time.TotalTime;
                pbProgressTime.Value = this.time.TotalTime;
            }
            catch ( Exception )
            {

            }
        }

        private void CalcTimeLeft()
        {
            this.Text = string.Format("{0} min left", ((pbProgressTime.Value) / 60));
        }

        private void btnControl_Click( object sender, EventArgs e )
        {

            if ( !time.IsRunningTime )
            {
                tmrTimeControl.Start();
                pbControl.BackgroundImage = Properties.Resources.pause;
            }
            else
            {
                tmrTimeControl.Stop();
                pbControl.BackgroundImage = Properties.Resources.play;

            }
            time.IsRunningTime = !time.IsRunningTime;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrTimeControl.Stop();
            pbControl.BackgroundImage = Properties.Resources.play;
            pbControl.Visible = true;
            btnStop.Visible = false;
            time.IsRunningTime = false;
            time.IsTime = false;
            getEndTime();
        }

        private void txtProgressTime_TextChanged(object sender, EventArgs e)
        {
            getEndTime();
        }

        private void tmrTimeControl_Tick(object sender, EventArgs e)
        {
            if (!time.IsTime)
            {
                _taskBar.SetProgressValue(pbProgressTime.Value--, time.TotalTime);
                CalcTimeLeft();
            }
            else
            {
                if (time.IsFullTime)
                    _taskBar.SetProgressValue(0, 1);
                else
                    _taskBar.SetProgressValue(1, 1);
                time.IsFullTime = !time.IsFullTime;

                if (ckbSound.Checked)
                    Console.Beep();

                pbControl.Visible = false;
                btnStop.Visible = true;
                pbProgressTime.Value = 0;
            }


            if (pbProgressTime.Value == 1)
                time.IsTime = true;

            _taskBar.SetProgressState(TaskbarProgressBarState.Normal);
        }
    }
}
