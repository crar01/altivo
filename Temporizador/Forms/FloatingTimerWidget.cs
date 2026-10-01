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
                Text = "0 min left"
            };

            _contentPanel.Controls.Add(_timeLabel);
            Controls.Add(_contentPanel);

            WireMouseDown(_contentPanel);
            WireMouseDown(_timeLabel);
        }

        protected override void OnRemainingTimeChanged(int remainingSeconds)
        {
            _timeLabel.Text = remainingSeconds < 60
                ? string.Format("{0} sec left", remainingSeconds)
                : string.Format("{0} min left", remainingSeconds / 60);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var pen = new Pen(Color.FromArgb(60, 60, 60)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            }

            using (var brush = new SolidBrush(Color.FromArgb(120, 214, 149)))
            {
                e.Graphics.FillRectangle(brush, 0, 0, 3, ClientRectangle.Height);
            }
        }
    }
}
