using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            // Improve rendering to avoid flicker
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint |
                     System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                     System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer |
                     System.Windows.Forms.ControlStyles.ResizeRedraw, true);
            UpdateStyles();

            DoubleBuffered = true;

            MouseDown += Widget_MouseDown;

            // Apply rounded region initially
            UpdateRegion();
        }

        protected virtual int CornerRadius => 12;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            try
            {
                if (ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
                {
                    using (var path = CreateRoundedRectanglePath(ClientRectangle, CornerRadius))
                    {
                        Region = new Region(path);
                    }
                }
            }
            catch
            {
                // If region creation fails for some reason, ignore to avoid crashing the app
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;

            if (diameter > Math.Min(rect.Width, rect.Height)) diameter = Math.Min(rect.Width, rect.Height);

            var arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            // top-left arc
            path.AddArc(arcRect, 180, 90);

            // top edge
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // right edge
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // bottom edge
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Prevent background erasure to reduce flicker; painting is done in OnPaint
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Intentionally empty to avoid flicker. Derived controls should paint entire background.
        }

        public void SetRemainingTime(int remainingSeconds, int? sessionTotalSeconds = null)
        {
            if (remainingSeconds < 0)
            {
                remainingSeconds = 0;
            }

            // If caller provides the session total explicitly, prefer it
            if (sessionTotalSeconds.HasValue && sessionTotalSeconds.Value > 0)
            {
                SessionTotalSeconds = sessionTotalSeconds.Value;
            }
            else
            {
                // Only update stored session total when this looks like a fresh session increase
                if (remainingSeconds > SessionTotalSeconds)
                {
                    SessionTotalSeconds = remainingSeconds;
                }
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
