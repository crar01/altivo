using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Altivo
{
    public class FloatingTimerWidgetCZ : FloatingTimerWidgetBase
    {
        private const int TorchCount = 12;
        private const int TorchWidth = 64;
        private const int TorchHeight = 50;

        private static readonly Point[] TorchPoints =
        {
            new Point(290, 65),  new Point(339, 90),  new Point(354, 152),
            new Point(338, 213), new Point(295, 263), new Point(235, 287),
            new Point(179, 287), new Point(140, 259), new Point(130, 206),
            new Point(139, 154), new Point(178, 101), new Point(230, 69)
        };

        private static readonly byte[] TorchFadeSteps = { 255, 240, 225, 210, 195, 180, 165, 150, 135, 120, 105, 90, 75, 60, 45, 30, 15, 0 };

        // Cached GDI resources to prevent memory leaks and GC pressure
        private readonly Bitmap _backgroundImage = Properties.Resources.clockcz;
        private readonly Bitmap _torchImage = Properties.Resources.fire;

        // Animation state per torch
        private readonly float[] _torchAlphas = new float[TorchCount];
        private readonly int[] _torchFadeIndices = new int[TorchCount];
        private readonly Timer _animationTimer = new Timer { Interval = 30 };

        private readonly PictureBox _backgroundPictureBox;
        private readonly Label _timeLabel;

        public FloatingTimerWidgetCZ()
        {
            BackColor = Color.FromArgb(12, 12, 18);
            Opacity = 1.0;
            DoubleBuffered = true;

            for (int i = 0; i < TorchCount; i++)
            {
                _torchAlphas[i] = 1.0f;
                _torchFadeIndices[i] = -1; // -1 indicates inactive animation
            }

            _backgroundPictureBox = new PictureBox
            {
                Location = Point.Empty,
                Size = _backgroundImage.Size,
                Image = _backgroundImage,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            _backgroundPictureBox.Paint += OnBackgroundPaint;
            Controls.Add(_backgroundPictureBox);

            _timeLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 26,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(150, 165, 185),
                BackColor = Color.FromArgb(10, 10, 14),
                Text = "0 min left"
            };
            Controls.Add(_timeLabel);

            WireMouseDown(_backgroundPictureBox);
            WireMouseDown(_timeLabel);

            ClientSize = new Size(_backgroundImage.Width, _backgroundImage.Height + 26);
            _animationTimer.Tick += OnAnimationTick;
        }

        protected override void OnRemainingTimeChanged(int remainingSeconds)
        {
            _timeLabel.Text = remainingSeconds < 60
                ? $"{remainingSeconds} sec left"
                : $"{remainingSeconds / 60} min left";

            ApplyTorchVisibility();
        }

        private void ApplyTorchVisibility()
        {
            int hiddenCount = TorchCount - GetLitTorchCount();
            bool needAnimation = false;

            for (int i = 0; i < TorchCount; i++)
            {
                needAnimation |= UpdateTorchAnimationState(i, isHidden: i < hiddenCount);
            }

            if (needAnimation && !_animationTimer.Enabled)
            {
                _animationTimer.Start();
            }

            _backgroundPictureBox.Invalidate();
        }

        // Extracted helper: encapsulates state transitions per torch
        private bool UpdateTorchAnimationState(int index, bool isHidden)
        {
            if (!isHidden)
            {
                _torchFadeIndices[index] = -1;
                _torchAlphas[index] = 1.0f;
                return false;
            }

            if (_torchAlphas[index] > 0f && _torchFadeIndices[index] == -1)
            {
                _torchFadeIndices[index] = 0;
            }

            return _torchFadeIndices[index] >= 0;
        }

        private void OnAnimationTick(object sender, EventArgs e)
        {
            bool stillAnimating = false;

            for (int i = 0; i < TorchCount; i++)
            {
                int index = _torchFadeIndices[i];
                if (index < 0) continue;

                if (++index < TorchFadeSteps.Length)
                {
                    _torchFadeIndices[i] = index;
                    _torchAlphas[i] = TorchFadeSteps[index] / 255f;
                    stillAnimating = true;
                }
                else
                {
                    _torchFadeIndices[i] = -1;
                    _torchAlphas[i] = 0f;
                }
            }

            if (!stillAnimating) _animationTimer.Stop();

            _backgroundPictureBox.Invalidate();
        }

        private void OnBackgroundPaint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < TorchCount; i++)
            {
                float alpha = _torchAlphas[i];
                if (alpha <= 0f) continue;

                Rectangle bounds = GetTorchBounds(i);

                if (alpha >= 0.99f)
                {
                    e.Graphics.DrawImage(_torchImage, bounds);
                }
                else
                {
                    DrawTransparentTorch(e.Graphics, bounds, alpha);
                }
            }
        }

        // Extracted helper: returns centered bounding box for a torch point
        private static Rectangle GetTorchBounds(int index) => new Rectangle(
            (int)Math.Round(TorchPoints[index].X - TorchWidth / 2f),
            (int)Math.Round(TorchPoints[index].Y - TorchHeight / 2f),
            TorchWidth,
            TorchHeight
        );

        // Extracted helper: handles alpha blending render pass
        private void DrawTransparentTorch(Graphics g, Rectangle bounds, float alpha)
        {
            using (var attributes = new ImageAttributes())
            {
                var matrix = new ColorMatrix { Matrix33 = alpha };
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(
                    _torchImage,
                    bounds,
                    0, 0, _torchImage.Width, _torchImage.Height,
                    GraphicsUnit.Pixel,
                    attributes
                );
            }
        }

        private int GetLitTorchCount()
        {
            if (SessionTotalSeconds <= 0) return TorchCount;

            double ratio = Math.Max(0d, Math.Min(1d, (double)CurrentRemainingSeconds / SessionTotalSeconds));
            return ratio <= 0d ? 0 : Math.Max(1, (int)Math.Ceiling(ratio * TorchCount));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _animationTimer?.Dispose();
                _backgroundImage?.Dispose();
                _torchImage?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}