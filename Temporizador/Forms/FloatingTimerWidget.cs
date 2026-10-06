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

        protected override void OnRemainingTimeChanged(int remainingSeconds)
        {
            _timeLabel.Text = remainingSeconds < 60
                ? string.Format("{0} sec left", remainingSeconds)
                : string.Format("{0} min left", remainingSeconds / 60);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Use anti-aliasing for smoother rounded edges
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
            int radius = 12;

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int diameter = radius * 2;
                var arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

                // top-left
                path.AddArc(arcRect, 180, 90);
                // top-right
                arcRect.X = rect.Right - diameter;
                path.AddArc(arcRect, 270, 90);
                // bottom-right
                arcRect.Y = rect.Bottom - diameter;
                path.AddArc(arcRect, 0, 90);
                // bottom-left
                arcRect.X = rect.Left;
                path.AddArc(arcRect, 90, 90);
                path.CloseFigure();

                using (var pen = new Pen(Color.FromArgb(60, 60, 60)))
                {
                    e.Graphics.DrawPath(pen, path);
                }

                using (var brush = new SolidBrush(Color.FromArgb(120, 214, 149)))
                {
                    // draw a thin rounded stripe on the left
                    var stripeRect = new Rectangle(0, 0, 6, ClientRectangle.Height);
                    using (var stripePath = new System.Drawing.Drawing2D.GraphicsPath())
                    {
                        int sRadius = Math.Max(0, radius - 4);
                        int sDiameter = sRadius * 2;
                        var sArc = new Rectangle(stripeRect.Location, new Size(sDiameter, sDiameter));

                        // top-left
                        stripePath.AddArc(sArc, 180, 90);
                        // top-right
                        sArc.X = stripeRect.Right - sDiameter;
                        stripePath.AddArc(sArc, 270, 90);
                        // bottom-right
                        sArc.Y = stripeRect.Bottom - sDiameter;
                        stripePath.AddArc(sArc, 0, 90);
                        // bottom-left
                        sArc.X = stripeRect.Left;
                        stripePath.AddArc(sArc, 90, 90);
                        stripePath.CloseFigure();

                        e.Graphics.FillPath(brush, stripePath);
                    }
                }
            }
        }
    }
}
