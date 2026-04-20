using Altivo.Dtos;
using Altivo.Forms;
using Altivo.Models;
using Altivo.Services;
using Altivo.Shared;
using Altivo.Controls;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Altivo
{
    public partial class frmMain : Form
    {
        int _concentrationSessionId = 0;
        int _minutes = 0;

        TaskbarManager _taskBar = TaskbarManager.Instance;
        Time time = new Time();
        ConcentrationService concentrationService = new ConcentrationService();
        MotivationService motivationService = new MotivationService();
        ContributionGraphService contributionGraphService = new ContributionGraphService();
        List<SessionWeekDto> sessionsWeek = new List<SessionWeekDto>();
        ContributionGraphControl contributionGraph;
        Altivo.Controls.MonthlyDashboardControl monthlyDashboard;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterAtTopOfActiveMonitor();

            pbControl.SizeMode = PictureBoxSizeMode.StretchImage;
            pbControl.BackgroundImage = Properties.Resources.play;

            GetCompletedSessionsThisWeek();
            UpdateMetrics();
            LoadContributionGraph();
        }

        private void CenterAtTopOfActiveMonitor()
        {
            this.StartPosition = FormStartPosition.Manual;
            Screen activeScreen = Screen.FromPoint(Cursor.Position);
            this.Location = new Point(activeScreen.WorkingArea.Left + (activeScreen.WorkingArea.Width - this.Width) / 2, activeScreen.WorkingArea.Top);
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

                _minutes = minutes;
            }
            catch (Exception)
            {
                _minutes = 0;
            }
            finally
            { 
                SetTimeLimit(); 
            }
        }

        private void SetDefaultTimeIfEmpty()
        {
            txtProgressTime.Text = string.IsNullOrEmpty(txtProgressTime.Text) ? "25" : txtProgressTime.Text;
        }

        private void SetTimeLimit()
        {
            lblEndTime.Text = DateTime.Now.AddMinutes(_minutes).ToString(" HH : mm ");
            pbProgressTime.Maximum = _minutes * 60;
            pbProgressTime.Value = _minutes * 60;
            
            UpdateModeMessage();
        }

        private void UpdateModeMessage()
        {
            pbControl.Visible = true;

            if (_minutes < ModeTimeLimits.WarmUpMin)
            {
                lblModeMessage.Text = "";
                return;
            }

            if (_minutes <= ModeTimeLimits.WarmUpMax)
            {
                lblModeMessage.Text = ModeMessages.WarmUp;
                lblModeMessage.ForeColor = ModeColors.WarmUp;
                return;
            }

            if (_minutes <= ModeTimeLimits.SeriousModeMax)
            {
                lblModeMessage.Text = ModeMessages.SeriousMode;
                lblModeMessage.ForeColor = ModeColors.SeriousMode;
                return;
            }

            if (_minutes <= ModeTimeLimits.DeepWorkMax)
            {
                lblModeMessage.Text = ModeMessages.DeepWork;
                lblModeMessage.ForeColor = ModeColors.DeepWork;
                return;
            }

            lblModeMessage.Text = ModeMessages.FatigueRisk;
            lblModeMessage.ForeColor = ModeColors.FatigueRisk;
            pbControl.Visible = false;
        }

        private void CalcTimeLeft()
        {
            this.Text = string.Format("{0} min left", GetLeftTimeMinutes());
        }

        private int GetLeftTimeMinutes()
        {
            return pbProgressTime.Value / 60;
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtProgressTime.Text))
            {
                SetDefaultTimeIfEmpty();
                getEndTime();
            }

            if (time.IsRunningTime)
            {
                tmrTimeControl.Stop();
                time.IsPaused = true;
                pbControl.BackgroundImage = Properties.Resources.play;
                txtProgressTime.Enabled = true;
            }
            else
            {
                tmrTimeControl.Start();
                time.IsPaused = false;
                txtProgressTime.Enabled = false;
                pbControl.BackgroundImage = Properties.Resources.pause;

                InitConcentrationSession();
            }

            time.IsRunningTime = !time.IsRunningTime;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrTimeControl.Stop();
            
            SaveEndSession();
            ResetDataSession();
            UpdateMetrics();
            LoadContributionGraph();

            pbControl.BackgroundImage = Properties.Resources.play;
            pbControl.Visible = true;
            btnStop.Visible = false;
            time.IsRunningTime = false;
            time.IsTimeUp = false;
            txtProgressTime.Enabled = true;

            getEndTime();
        }

        /// <summary>
        /// Save the end session when stop is clicked
        /// </summary>
        private void SaveEndSession()
        {
            //var frmConcentrationRate = new FrmConcentrationRate();
            //frmConcentrationRate.ShowDialog();
            //concentrationService.EndCompletedSession(_concentrationSessionId, frmConcentrationRate.concentrationLevel);
            concentrationService.EndCompletedSession(_concentrationSessionId, ConcentrationLevel.High);
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

        private void txtProgressTime_KeyUp(object sender, KeyEventArgs e)
        {
            getEndTime();
        }

        private void ResetDataSession()
        {
            _concentrationSessionId = 0;
        }

        private void InitConcentrationSession()
        {
            if (_concentrationSessionId == 0)
            {
                _concentrationSessionId = concentrationService.StartSession(_minutes);
            }
        }

        private void GetCompletedSessionsThisWeek()
        {
            sessionsWeek = motivationService.GetCompletedPomodorosThisWeek();
        }

        private void UpdateMetrics()
        {
            GetCompletedSessionsThisWeek();

            string formattedText = string.Join(" ", sessionsWeek.Select(v => v.TotalMinutes.ToString().PadRight(3)));
            lblWeekDays.Text = formattedText;

            if (!sessionsWeek.Any(sw => sw.TotalMinutes > 0))
                return;

            int maxValue = sessionsWeek.Max(s => s.TotalMinutes);
            int totalMinutesWeek = sessionsWeek.Sum(d => d.TotalMinutes);            

            lblTotalMinutesWeek.Text = "Total week: " + Utilities.TotalTime(totalMinutesWeek);
        }

        private void LoadContributionGraph()
        {
            var contributions = contributionGraphService.GetYearContributions();
            
            if (contributionGraph == null)
            {
                contributionGraph = new ContributionGraphControl();
                contributionGraph.Location = new Point(15, 87);
                this.Controls.Add(contributionGraph);
            }

            contributionGraph.LoadData(contributions);

            if (monthlyDashboard == null)
            {
                monthlyDashboard = new Altivo.Controls.MonthlyDashboardControl();
                monthlyDashboard.Location = new Point(15, 240);
                this.Controls.Add(monthlyDashboard);
            }

            var thisMonth = motivationService.GetCompletedSessionsThisMonth();
            var lastMonth = motivationService.GetCompletedSessionsLastMonth();
            monthlyDashboard.LoadData(thisMonth, lastMonth);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DatabaseInitializer.Dispose();
        }
    }
}
