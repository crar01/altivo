using Altivo.Dtos;
using Altivo.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Altivo.Controls
{
    public class ContributionGraphControl : UserControl
    {
        private List<DayContributionDto> _contributions;
        private const int CellSize = 10;
        private const int CellSpacing = 3;
        private const int MonthLabelHeight = 20;
        private const int WeekDayLabelWidth = 20;
        private const int CornerRadius = 2;
        private const int TooltipCornerRadius = 5;
        private ToolTip _tooltip;
        private int _lastContributionIndex = -1;

        private readonly Color[] _intensityColors = new Color[]
        {
            Color.FromArgb(45, 45, 45),
            Color.FromArgb(0, 109, 50),
            Color.FromArgb(38, 166, 91),
            Color.FromArgb(57, 211, 83),
            Color.FromArgb(87, 242, 135)
        };

        public ContributionGraphControl()
        {
            _contributions = new List<DayContributionDto>();
            _tooltip = new ToolTip();
            _tooltip.BackColor = Color.FromArgb(40, 40, 40);
            _tooltip.ForeColor = Color.WhiteSmoke;
            _tooltip.OwnerDraw = true;
            _tooltip.Draw += Tooltip_Draw;
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void Tooltip_Draw(object sender, DrawToolTipEventArgs e)
        {
            int customHeight = 75;
            Rectangle customBounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, customHeight);
            
            using (GraphicsPath path = GetRoundedRectanglePath(customBounds, TooltipCornerRadius))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(40, 40, 40)))
                {
                    e.Graphics.FillPath(brush, path);
                }
                
                using (Pen pen = new Pen(Color.FromArgb(80, 80, 80), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
            
            TextRenderer.DrawText(e.Graphics, e.ToolTipText, 
                new Font("Segoe UI", 9), 
                new Rectangle(customBounds.X + 2, customBounds.Y + 2, customBounds.Width - 8, customBounds.Height),
                Color.WhiteSmoke, 
                TextFormatFlags.Left | TextFormatFlags.Top);
        }

        public void LoadData(List<DayContributionDto> contributions)
        {
            _contributions = contributions ?? new List<DayContributionDto>();
            CalculateSize();
            this.Invalidate();
        }

        private void CalculateSize()
        {
            if (_contributions.Count == 0) return;

            int weeks = (int)Math.Ceiling(_contributions.Count / 7.0);
            int width = WeekDayLabelWidth + (weeks * (CellSize + CellSpacing)) + 20;
            int height = MonthLabelHeight + (7 * (CellSize + CellSpacing)) + 20;

            this.Size = new Size(width, height);
            this.MinimumSize = new Size(width, height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_contributions.Count == 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawWeekDayLabels(g);
            DrawMonthLabels(g);
            DrawCells(g);
            DrawLegend(g);
        }

        private void DrawWeekDayLabels(Graphics g)
        {
            string[] days = { "M", "T", "W", "T", "F", "S", "S" };
            Font font = new Font("Segoe UI", 8);
            Brush brush = new SolidBrush(Color.FromArgb(180, 180, 180));

            for (int i = 0; i < 7; i++)
            {
                int y = MonthLabelHeight + (i * (CellSize + CellSpacing));
                g.DrawString(days[i], font, brush, 2, y);
            }
            
            brush.Dispose();
        }

        private void DrawMonthLabels(Graphics g)
        {
            Font font = new Font("Segoe UI", 8);
            Brush brush = new SolidBrush(Color.FromArgb(180, 180, 180));

            DateTime currentMonth = _contributions.First().Date;
            int weekIndex = 0;

            foreach (var contribution in _contributions)
            {
                if (contribution.Date.Month != currentMonth.Month)
                {
                    int x = WeekDayLabelWidth + (weekIndex * (CellSize + CellSpacing));
                    string monthName = contribution.Date.ToString("MMM", CultureInfo.InvariantCulture);
                    g.DrawString(monthName, font, brush, x, 2);
                    currentMonth = contribution.Date;
                }

                if (contribution.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekIndex++;
                }
            }
            
            brush.Dispose();
        }

        private void DrawCells(Graphics g)
        {
            int weekIndex = 0;
            int dayIndex = GetStartDayIndex();

            int maxMinutes = _contributions.Max(c => c.TotalMinutes);
            if (maxMinutes == 0) maxMinutes = 1;

            foreach (var contribution in _contributions)
            {
                int x = WeekDayLabelWidth + (weekIndex * (CellSize + CellSpacing));
                int y = MonthLabelHeight + (dayIndex * (CellSize + CellSpacing));

                Color cellColor = GetIntensityColor(contribution.TotalMinutes, maxMinutes);
                
                Rectangle rect = new Rectangle(x, y, CellSize, CellSize);
                DrawRoundedRectangle(g, rect, CornerRadius, cellColor, Color.FromArgb(60, 60, 60));

                dayIndex++;
                if (dayIndex >= 7)
                {
                    dayIndex = 0;
                    weekIndex++;
                }
            }
        }

        private void DrawRoundedRectangle(Graphics g, Rectangle rect, int radius, Color fillColor, Color borderColor)
        {
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush brush = new SolidBrush(fillColor))
                {
                    g.FillPath(brush, path);
                }
                
                using (Pen pen = new Pen(borderColor, 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void DrawLegend(Graphics g)
        {
            Font font = new Font("Segoe UI", 7);
            Brush textBrush = new SolidBrush(Color.FromArgb(180, 180, 180));

            int startX = this.Width - 150;
            int startY = this.Height - 18;

            g.DrawString("Less", font, textBrush, startX, startY);

            for (int i = 0; i < 5; i++)
            {
                int x = startX + 35 + (i * (CellSize + 2));
                Rectangle rect = new Rectangle(x, startY, CellSize, CellSize);
                DrawRoundedRectangle(g, rect, CornerRadius, _intensityColors[i], Color.FromArgb(60, 60, 60));
            }

            g.DrawString("More", font, textBrush, startX + 110, startY);
            
            textBrush.Dispose();
        }

        private Color GetIntensityColor(int totalMinutes, int maxMinutes)
        {
            if (totalMinutes == 0) return _intensityColors[0];

            double percentage = (double)totalMinutes / maxMinutes;

            if (percentage <= 0.25) return _intensityColors[1];
            if (percentage <= 0.50) return _intensityColors[2];
            if (percentage <= 0.75) return _intensityColors[3];
            return _intensityColors[4];
        }

        private int GetStartDayIndex()
        {
            if (_contributions.Count == 0) return 0;
            
            DayOfWeek startDay = _contributions.First().Date.DayOfWeek;
            return startDay == DayOfWeek.Sunday ? 6 : (int)startDay - 1;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int weekIndex = (e.X - WeekDayLabelWidth) / (CellSize + CellSpacing);
            int dayIndex = (e.Y - MonthLabelHeight) / (CellSize + CellSpacing);

            if (weekIndex >= 0 && dayIndex >= 0 && dayIndex < 7)
            {
                int contributionIndex = (weekIndex * 7) + dayIndex - GetStartDayIndex();

                if (contributionIndex >= 0 && contributionIndex < _contributions.Count)
                {
                    if (contributionIndex != _lastContributionIndex)
                    {
                        _lastContributionIndex = contributionIndex;
                        var contribution = _contributions[contributionIndex];
                        string tooltipText = $"{contribution.Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture)}\n" +
                                           $"{contribution.SessionCount} sessions\n" +
                                           $"{Utilities.TotalTime(contribution.TotalMinutes)}";
                        _tooltip.SetToolTip(this, tooltipText);
                    }
                }
                else
                {
                    var leftValidArea = _lastContributionIndex != -1;
                    if (leftValidArea)
                    {
                        CleanTooltipWhenMouseLeaves();
                    }
                }
            }
            else
            {
                var leftValidGraphArea = _lastContributionIndex != -1;
                if (leftValidGraphArea)
                {
                    CleanTooltipWhenMouseLeaves();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            CleanTooltipWhenMouseLeaves();
        }

        private void CleanTooltipWhenMouseLeaves()
        {
            _lastContributionIndex = -1;
            _tooltip.SetToolTip(this, string.Empty);
        }
    }
}
