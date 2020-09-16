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

        private void getTime()
        {
            int minutos = 0;
            string[] tiempo;

            try
            {
                tiempo = txtTiempoPlaneado.Text.Split(':');
                minutos = Convert.ToInt32( tiempo[0]);
                time.TotalTime = minutos * 60;

                if ( tiempo.Length == 2 )
                {
                    time.TotalTime += Convert.ToInt32(tiempo[ 1 ]);
                }

                lblTiempoFinal.Text = DateTime.Now.AddMinutes( minutos ).ToString( " HH : mm " );
                pbTiempoPlanificado.Maximum = time.TotalTime;
                pbTiempoPlanificado.Value = time.TotalTime;
            }
            catch ( Exception )
            {

            }
        }

        private void CalcTimeLeft()
        {
            this.Text = "Quedan " + ( ( pbTiempoPlanificado.Value ) / 60 ).ToString() + " mins";
        }

        private void tmrControlTiempo_Tick( object sender, EventArgs e )
        {

            if ( !time.IsTime )
            {
                _taskBar.SetProgressValue( pbTiempoPlanificado.Value--, time.TotalTime );
                CalcTimeLeft();
            }
            else
            {
                if (time.IsFullTime )
                    _taskBar.SetProgressValue( 0, 1 );
                else
                    _taskBar.SetProgressValue( 1, 1 );
                time.IsFullTime = !time.IsFullTime;

                if ( ckbSonido.Checked )
                    Console.Beep();

                pbControl.Visible = false;
                btnDetener.Visible = true;
                pbTiempoPlanificado.Value = 0;
            }


            if ( pbTiempoPlanificado.Value == 1 )
                time.IsTime = true;

            _taskBar.SetProgressState( TaskbarProgressBarState.Normal );
        }

        private void txtTiempoPlaneado_TextChanged( object sender, EventArgs e )
        {
            getTime();
        }

        private void btnControl_Click( object sender, EventArgs e )
        {

            if ( !time.IsRunningTime )
            {
                tmrControlTiempo.Start();
                pbControl.BackgroundImage = Properties.Resources.pause;
            }
            else
            {
                tmrControlTiempo.Stop();
                pbControl.BackgroundImage = Properties.Resources.play;

            }
            time.IsRunningTime = !time.IsRunningTime;
        }

        private void btnDetener_Click( object sender, EventArgs e )
        {
            tmrControlTiempo.Stop();
            pbControl.BackgroundImage = Properties.Resources.play;
            pbControl.Visible = true;
            btnDetener.Visible = false;
            time.IsRunningTime = false;
            time.IsTime = false;
            getTime();
        }
    }
}
