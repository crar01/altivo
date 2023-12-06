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
    public partial class frmMain : Form
    {
        TaskbarManager _taskBar = TaskbarManager.Instance;
        Time time = new Time();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbControl.SizeMode = PictureBoxSizeMode.StretchImage;
            pbControl.BackgroundImage = Properties.Resources.play;
        }

        private void getEndTime()
        {
            int minutes = 0;
            string[] timeMinutesSeconda;

            try
            {
                timeMinutesSeconda = txtProgressTime.Text.Split(':');
                minutes = Convert.ToInt32(timeMinutesSeconda[0]);
                time.TotalTimeInSeconds = minutes * 60;

                bool isThereSeconds = timeMinutesSeconda.Length == 2;

                if (isThereSeconds)
                {
                    time.TotalTimeInSeconds += Convert.ToInt32(timeMinutesSeconda[1]);
                }

                SetTimeLimit(minutes, time.TotalTimeInSeconds);
            }
            catch (Exception)
            {

            }
        }

        private void SetTimeLimit(int minutes, int totalTimeInSeconds)
        {
            lblEndTime.Text = DateTime.Now.AddMinutes(minutes).ToString(" HH : mm ");
            pbProgressTime.Maximum = totalTimeInSeconds;
            pbProgressTime.Value = totalTimeInSeconds;
        }

        private void CalcTimeLeft()
        {
            this.Text = string.Format("{0} min left", ((pbProgressTime.Value) / 60));
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (pbProgressTime.Value == 0)
                return;

            if (!time.IsRunningTime)
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
            time.IsTimeUp = false;
            getEndTime();
        }

        private void txtProgressTime_TextChanged(object sender, EventArgs e)
        {
            getEndTime();
        }

        private void tmrTimeControl_Tick(object sender, EventArgs e)
        {
            if (!time.IsTimeUp)
            {
                _taskBar.SetProgressValue(pbProgressTime.Value--, time.TotalTimeInSeconds);
                CalcTimeLeft();
            }
            else
            {
                if (time.IsFullTime)
                    _taskBar.SetProgressValue(0, 1);
                else
                    _taskBar.SetProgressValue(1, 1);
                time.IsFullTime = !time.IsFullTime;

                showComponentsWhenTimeUp();
            }


            if (pbProgressTime.Value == 1)
                time.IsTimeUp = true;

            _taskBar.SetProgressState(TaskbarProgressBarState.Normal);
        }

        /// <summary>
        /// Initialize the values to start again
        /// </summary>
        private void showComponentsWhenTimeUp()
        {
            if (ckbSound.Checked)
                Console.Beep();

            pbControl.Visible = false;
            btnStop.Visible = true;
            pbProgressTime.Value = 0;
        }

        private void txtProgressTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
