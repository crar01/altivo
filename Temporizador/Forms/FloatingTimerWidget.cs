using System;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Altivo
{
    public class FloatingTimerWidget : Form
    {
        // Enables the form to behave like a draggable caption-less window.
        private const int WM_NCHITTEST = 0x0084;
        // Instructs Windows to begin a window move operation.
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        // Hit-test result that represents the title bar area.
        private const int HTCAPTION = 0x0002;

        private readonly Panel _contentPanel;
        private readonly Label _timeLabel;

        public event EventHandler CloseRequested;
        public event EventHandler WidgetDoubleClicked;

        public FloatingTimerWidget()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            TopMost = true;
            ShowInTaskbar = false;
            BackColor = Color.FromArgb(22, 22, 22);
            ForeColor = Color.WhiteSmoke;
            Opacity = 0.93;
            ClientSize = new Size(150, 48);
            Padding = new Padding(1);
            DoubleBuffered = true;

            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30),
                Padding = new Padding(10)
            };

            _timeLabel = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Gainsboro,
                Text = "0 min left"
            };

            _contentPanel.Controls.Add(_timeLabel);
            Controls.Add(_contentPanel);

            MouseDown += Widget_MouseDown;
            _contentPanel.MouseDown += Widget_MouseDown;
            _timeLabel.MouseDown += Widget_MouseDown;
        }

        public void SetRemainingTime(int remainingSeconds)
        {
            if (remainingSeconds < 0)
            {
                remainingSeconds = 0;
            }

            _timeLabel.Text = remainingSeconds < 60
                ? string.Format("{0} sec left", remainingSeconds)
                : string.Format("{0} min left", remainingSeconds / 60);
        }

        public void ShowNearOwner(Form owner)
        {
            if (owner != null)
            {
                // Place the widget near the top-right area of the current screen.
                var workingArea = Screen.FromControl(owner).WorkingArea;
                Location = new Point(workingArea.Right - Width - 20, workingArea.Top + 20);
            }

            Show();
            BringToFront();
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw a minimal border and a small accent bar for a modern look.
            using (var pen = new Pen(Color.FromArgb(60, 60, 60)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            }

            using (var brush = new SolidBrush(Color.FromArgb(120, 214, 149)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, 3, ClientRectangle.Height);
            }
        }

        protected override void WndProc(ref Message m)
        {
            // Intercept the non-client hit test so the whole form can be dragged.
            // Without this, a borderless form would not move when the user clicks it.
            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                // Treat the client area like a title bar.
                if ((int)m.Result == 1)
                {
                    m.Result = (IntPtr)HTCAPTION;
                }

                return;
            }

            base.WndProc(ref m);
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

        protected virtual void OnWidgetDoubleClicked()
        {
            WidgetDoubleClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Widget_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 2)
                {
                    // A left double click should focus the main form.
                    OnWidgetDoubleClicked();
                    return;
                }

                // Simulate dragging the title bar so the widget can be moved.
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, (IntPtr)HTCAPTION, IntPtr.Zero);
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
