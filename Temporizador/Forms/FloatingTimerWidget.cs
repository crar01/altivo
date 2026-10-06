using System;
using System.Drawing;
using System.Windows.Forms;

namespace Altivo
{
    public class FloatingTimerWidget : FloatingTimerWidgetBase
    {
        private readonly Panel _contentPanel;
        private readonly Label _timeLabel;

        public FloatingTimerWidget()
        {
            ClientSize = new Size(150, 48);

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
                BackColor = Color.FromArgb(30, 30, 30), // opaque background to avoid transparent redraw flicker
                Text = "0 min left"
            };

            _contentPanel.Controls.Add(_timeLabel);
            Controls.Add(_contentPanel);

            WireMouseDown(_contentPanel);
            WireMouseDown(_timeLabel);

            // Try to enable double buffering on the panel to reduce child-control flicker
            try
            {
                var prop = typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                prop?.SetValue(_contentPanel, true, null);
            }
            catch
            {
                // ignore if reflection fails
            }
        }

        // Override CornerRadius to 0 to disable rounded corners from the base class
        protected override int CornerRadius => 0;

        protected override void OnRemainingTimeChanged(int remainingSeconds)
        {
            _timeLabel.Text = remainingSeconds < 60
                ? string.Format("{0} sec left", remainingSeconds)
                : string.Format("{0} min left", remainingSeconds / 60);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var rect = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

            // Draw square border
            using (var pen = new Pen(Color.FromArgb(60, 60, 60)))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }

            // Draw a thin square stripe on the left (3px wide)
            using (var brush = new SolidBrush(Color.FromArgb(120, 214, 149)))
            {
                var stripeRect = new Rectangle(0, 0, 3, ClientRectangle.Height);
                e.Graphics.FillRectangle(brush, stripeRect);
            }
        }
    }
}
