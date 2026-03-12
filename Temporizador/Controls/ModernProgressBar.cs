using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Altivo.Controls
{
    public class ModernProgressBar : UserControl
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private int _value = 0;
        private Color _progressColor = Color.FromArgb(87, 242, 135);
        private Color _backgroundColor = Color.FromArgb(45, 45, 45);
        private Color _borderColor = Color.FromArgb(60, 60, 60);
        private int _cornerRadius = 8;
        private bool _showPercentage = false;
        private Font _percentageFont = new Font("Segoe UI", 9, FontStyle.Bold);
        private Color _textColor = Color.WhiteSmoke;

        public ModernProgressBar()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(300, 30);
            this.MinimumSize = new Size(50, 20);
        }

        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Minimum value of the progress bar")]
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > _maximum)
                    _maximum = value;
                _minimum = value;
                if (_value < _minimum)
                    _value = _minimum;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Maximum value of the progress bar")]
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                if (value < _minimum)
                    value = _minimum;
                _maximum = value;
                if (_value > _maximum)
                    _value = _maximum;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Current value of the progress bar")]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < _minimum)
                    value = _minimum;
                if (value > _maximum)
                    value = _maximum;
                _value = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Color of the progress")]
        public Color ProgressColor
        {
            get { return _progressColor; }
            set
            {
                _progressColor = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Background color of the progress bar")]
        public new Color BackColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Border color of the progress bar")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Corner radius for rounded edges")]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Show percentage text")]
        public bool ShowPercentage
        {
            get { return _showPercentage; }
            set
            {
                _showPercentage = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Font for percentage text")]
        public Font PercentageFont
        {
            get { return _percentageFont; }
            set
            {
                _percentageFont = value;
                Invalidate();
            }
        }

        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Color of the percentage text")]
        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Draw background with rounded corners
            using (GraphicsPath backgroundPath = GetRoundedRectanglePath(bounds, _cornerRadius))
            {
                using (SolidBrush backgroundBrush = new SolidBrush(_backgroundColor))
                {
                    g.FillPath(backgroundBrush, backgroundPath);
                }

                using (Pen borderPen = new Pen(_borderColor, 1))
                {
                    g.DrawPath(borderPen, backgroundPath);
                }
            }

            // Calculate progress width
            int progressWidth = CalculateProgressWidth();

            if (progressWidth > 0)
            {
                Rectangle progressBounds = new Rectangle(0, 0, progressWidth, this.Height - 1);

                // Draw progress with rounded corners
                using (GraphicsPath progressPath = GetRoundedRectanglePath(progressBounds, _cornerRadius))
                {
                    // Create gradient for progress
                    using (LinearGradientBrush progressBrush = new LinearGradientBrush(
                        progressBounds,
                        LightenColor(_progressColor, 20),
                        _progressColor,
                        LinearGradientMode.Vertical))
                    {
                        g.FillPath(progressBrush, progressPath);
                    }

                    // Add subtle highlight
                    Rectangle highlightBounds = new Rectangle(0, 0, progressWidth, this.Height / 2);
                    using (GraphicsPath highlightPath = GetRoundedRectanglePath(highlightBounds, _cornerRadius))
                    {
                        using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
                        {
                            g.FillPath(highlightBrush, highlightPath);
                        }
                    }
                }
            }

            // Draw percentage text
            if (_showPercentage)
            {
                int percentage = CalculatePercentage();
                string percentageText = $"{percentage}%";
                
                SizeF textSize = g.MeasureString(percentageText, _percentageFont);
                PointF textPosition = new PointF(
                    (this.Width - textSize.Width) / 2,
                    (this.Height - textSize.Height) / 2
                );

                // Draw text shadow for better readability
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                {
                    g.DrawString(percentageText, _percentageFont, shadowBrush, 
                        textPosition.X + 1, textPosition.Y + 1);
                }

                using (SolidBrush textBrush = new SolidBrush(_textColor))
                {
                    g.DrawString(percentageText, _percentageFont, textBrush, textPosition);
                }
            }
        }

        private int CalculateProgressWidth()
        {
            if (_maximum == _minimum)
                return 0;

            double percentage = (double)(_value - _minimum) / (_maximum - _minimum);
            return (int)(this.Width * percentage);
        }

        private int CalculatePercentage()
        {
            if (_maximum == _minimum)
                return 0;

            return (int)(((double)(_value - _minimum) / (_maximum - _minimum)) * 100);
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;

            // Ensure diameter doesn't exceed rectangle dimensions
            if (diameter > rect.Width)
                diameter = rect.Width;
            if (diameter > rect.Height)
                diameter = rect.Height;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private Color LightenColor(Color color, int amount)
        {
            return Color.FromArgb(
                color.A,
                Math.Min(255, color.R + amount),
                Math.Min(255, color.G + amount),
                Math.Min(255, color.B + amount)
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}