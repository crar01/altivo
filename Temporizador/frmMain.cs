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
        bool _terminoTiempo = false;
        bool _swParpadear =true;
        int _tiempoTotal = 0;
        bool _corriendoTiempo = false;
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            //tmrControlTiempo.Start();
            pbControl.SizeMode = PictureBoxSizeMode.StretchImage;
            pbControl.BackgroundImage = Properties.Resources.play;

        }
        private void RecuperarHora()
        {
            int minutos = 0;
            string[] tiempo;
            try
            {
                tiempo = txtTiempoPlaneado.Text.Split(':');
                minutos = Convert.ToInt32( tiempo[0]);
                _tiempoTotal = minutos * 60;
                if ( tiempo.Length == 2 )
                {
                    _tiempoTotal += Convert.ToInt32(tiempo[ 1 ]);
                }
                lblTiempoFinal.Text = DateTime.Now.AddMinutes( minutos ).ToString( " HH : mm " );
                pbTiempoPlanificado.Maximum = _tiempoTotal;
                pbTiempoPlanificado.Value = _tiempoTotal;
            }
            catch ( Exception )
            {

            }
        }
        private void CalcularTiempoRestante()
        {
            this.Text = "Quedan " + ( ( pbTiempoPlanificado.Value ) / 60 ).ToString() + " mins";
        }

        private void tmrControlTiempo_Tick( object sender, EventArgs e )
        {

            if ( !_terminoTiempo )
            {
                _taskBar.SetProgressValue( pbTiempoPlanificado.Value--, _tiempoTotal );
                CalcularTiempoRestante();
            }
            else
            {
                if ( _swParpadear )
                    _taskBar.SetProgressValue( 0, 1 );
                else
                    _taskBar.SetProgressValue( 1, 1 );
                _swParpadear = !_swParpadear;

                if ( ckbSonido.Checked )
                    Console.Beep();

                pbControl.Visible = false;
                btnDetener.Visible = true;
                pbTiempoPlanificado.Value = 0;
            }


            if ( pbTiempoPlanificado.Value == 1 )
                _terminoTiempo = true;

            _taskBar.SetProgressState( TaskbarProgressBarState.Normal );
        }

        private void txtTiempoPlaneado_TextChanged( object sender, EventArgs e )
        {
            RecuperarHora();
        }

        private void btnControl_Click( object sender, EventArgs e )
        {

            if ( !_corriendoTiempo )
            {
                tmrControlTiempo.Start();
                pbControl.BackgroundImage = Properties.Resources.pause;
            }
            else
            {
                tmrControlTiempo.Stop();
                pbControl.BackgroundImage = Properties.Resources.play;

            }
            _corriendoTiempo = !_corriendoTiempo;
        }

        private void btnDetener_Click( object sender, EventArgs e )
        {
            tmrControlTiempo.Stop();
            pbControl.BackgroundImage = Properties.Resources.play;
            pbControl.Visible = true;
            btnDetener.Visible = false;
            _corriendoTiempo = false;
            _terminoTiempo = false;
            RecuperarHora();

        }
    }
}
