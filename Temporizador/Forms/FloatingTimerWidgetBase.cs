using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Altivo
{
    public class FloatingTimerWidgetBase : Form
    {
        private const int WM_NCHITTEST = 0x0084;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HTCAPTION = 0x0002;

        public event EventHandler CloseRequested;
        public event EventHandler WidgetDoubleClicked;

        protected int CurrentRemainingSeconds { get; private set; }
        protected int SessionTotalSeconds { get; private set; }

        protected FloatingTimerWidgetBase()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = Color.FromArgb(22, 22, 22);
            ForeColor = Color.WhiteSmoke;
            Opacity = 0.93;
            Padding = new Padding(1);
            DoubleBuffered = true;

            MouseDown += Widget_MouseDown;
        }

        public void SetRemainingTime(int remainingSeconds)
        {
            if (remainingSeconds < 0)
            {
                remainingSeconds = 0;
            }

            if (remainingSeconds > CurrentRemainingSeconds)
            {
                SessionTotalSeconds = remainingSeconds;
            }

            CurrentRemainingSeconds = remainingSeconds;
            OnRemainingTimeChanged(remainingSeconds);
        }

        public void ShowNearOwner(Form owner)
        {
            if (owner != null)
            {
                var workingArea = Screen.FromControl(owner).WorkingArea;
                Location = new Point(workingArea.Right - Width - 20, workingArea.Top + 20);
            }

            Show();
            BringToFront();
            Refresh();
        }

        protected void WireMouseDown(Control control)
        {
            if (control != null)
            {
                control.MouseDown += Widget_MouseDown;
            }
        }

        protected virtual void OnRemainingTimeChanged(int remainingSeconds)
        {
        }

        protected virtual void OnWidgetDoubleClicked()
        {
            WidgetDoubleClicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnCloseRequested()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            OnCloseRequested();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if ((int)m.Result == 1)
                {
                    m.Result = (IntPtr)HTCAPTION;
                }

                return;
            }

            base.WndProc(ref m);
        }

        private void Widget_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (e.Clicks == 2)
            {
                OnWidgetDoubleClicked();
                return;
            }

            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
