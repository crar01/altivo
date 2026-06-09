using Altivo.Models;
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
    public class MonthlyScoreHistoryControl : UserControl
    {
        private const int BorderRadius = 10;
        private const int HeaderLeft = 10;
        private const int HeaderTop = 8;
        private const int LegendTop = 40;
        private const int ChartTop = 88;
        private const int HorizontalPadding = 12;
        private const int BottomPadding = 28;
        private const int LabelGap = 18;

        private List<ConcentrationSession> _sessions = new List<ConcentrationSession>();

        private class MonthlySummary
        {
            public DateTime Month { get; set; }
            public double Score { get; set; }
            public double WarmScore { get; set; }
            public double SeriousScore { get; set; }
            public double DeepScore { get; set; }
        }

        public MonthlyScoreHistoryControl()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(25, 25, 25);
            Size = new Size(200, 280);
        }

        public void LoadData(List<ConcentrationSession> sessions)
        {
            _sessions = sessions ?? new List<ConcentrationSession>();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle client = ClientRectangle;
            if (client.Width <= 1 || client.Height <= 1)
            {
                return;
            }

            Rectangle card = new Rectangle(0, 0, client.Width - 1, client.Height - 1);
            using (GraphicsPath path = GetRoundedRectanglePath(card, BorderRadius))
            using (SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(25, 25, 25)))
            using (SolidBrush titleBrush = new SolidBrush(Color.Gainsboro))
            using (SolidBrush subtitleBrush = new SolidBrush(Color.DarkGray))
            using (SolidBrush warmBrush = new SolidBrush(GetMutedTone(ModeColors.WarmUp)))
            using (SolidBrush seriousBrush = new SolidBrush(GetMutedTone(ModeColors.SeriousMode)))
            using (SolidBrush deepBrush = new SolidBrush(GetMutedTone(ModeColors.DeepWork)))
            using (SolidBrush scoreBrush = new SolidBrush(Color.Gainsboro))
            using (SolidBrush trackBrush = new SolidBrush(Color.FromArgb(25, 25, 25)))
            using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (Font subtitleFont = new Font("Segoe UI", 8, FontStyle.Regular))
            using (Font scoreFont = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Font monthFont = new Font("Segoe UI", 8, FontStyle.Regular))
            {
                g.FillPath(backgroundBrush, path);

                DrawHeader(g, titleFont, subtitleFont, titleBrush, subtitleBrush, warmBrush, seriousBrush, deepBrush, monthFont);

                List<MonthlySummary> summaries = BuildSummaries();
                if (summaries.Count == 0)
                {
                    DrawCenteredText(g, "No data", titleFont, subtitleBrush, client);
                    return;
                }

                DrawChart(g, client, summaries, trackBrush, scoreBrush, subtitleBrush, warmBrush, seriousBrush, deepBrush, scoreFont, monthFont);
            }
        }

        private void DrawHeader(Graphics g, Font titleFont, Font subtitleFont, Brush titleBrush, Brush subtitleBrush, Brush warmBrush, Brush seriousBrush, Brush deepBrush, Font legendFont)
        {
            g.DrawString("Monthly Score", titleFont, titleBrush, new PointF(HeaderLeft, HeaderTop));
            g.DrawString("Last 6 months", subtitleFont, subtitleBrush, new PointF(HeaderLeft, 26));

            DrawLegend(g, HeaderLeft, LegendTop, warmBrush, seriousBrush, deepBrush, subtitleBrush, legendFont);
        }

        private void DrawChart(Graphics g, Rectangle client, List<MonthlySummary> summaries, Brush trackBrush, Brush scoreBrush, Brush subtitleBrush, Brush warmBrush, Brush seriousBrush, Brush deepBrush, Font scoreFont, Font monthFont)
        {
            int chartWidth = client.Width - (HorizontalPadding * 2);
            int chartHeight = Math.Max(72, client.Height - ChartTop - BottomPadding - LabelGap);
            int baseY = ChartTop + chartHeight;
            int spacing = 8;
            int barWidth = Math.Max(16, Math.Min(34, (chartWidth - ((summaries.Count - 1) * spacing)) / summaries.Count));
            int totalBarsWidth = (summaries.Count * barWidth) + ((summaries.Count - 1) * spacing);
            int startX = HorizontalPadding + Math.Max(0, (chartWidth - totalBarsWidth) / 2);
            double maxScore = Math.Max(1.0, summaries.Max(x => x.Score));

            for (int i = 0; i < summaries.Count; i++)
            {
                DrawMonthBar(g, summaries[i], i, startX, barWidth, spacing, chartHeight, baseY, maxScore, trackBrush, scoreBrush, subtitleBrush, warmBrush, seriousBrush, deepBrush, scoreFont, monthFont);
            }
        }

        private void DrawMonthBar(Graphics g, MonthlySummary summary, int index, int startX, int barWidth, int spacing, int chartHeight, int baseY, double maxScore, Brush trackBrush, Brush scoreBrush, Brush subtitleBrush, Brush warmBrush, Brush seriousBrush, Brush deepBrush, Font scoreFont, Font monthFont)
        {
            int barHeight = (int)Math.Round(chartHeight * summary.Score / maxScore);
            if (barHeight < 4 && summary.Score > 0)
            {
                barHeight = 4;
            }

            int barX = startX + index * (barWidth + spacing);
            int barY = baseY - barHeight;

            g.FillRectangle(trackBrush, new Rectangle(barX, ChartTop, barWidth, chartHeight));

            if (summary.Score > 0)
            {
                DrawStackedScoreBar(g, barX, barY, barWidth, barHeight, summary, warmBrush, seriousBrush, deepBrush);
            }
            else
            {
                using (SolidBrush emptyBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
                {
                    g.FillRectangle(emptyBrush, new Rectangle(barX, baseY - 4, barWidth, 4));
                }
            }

            string scoreText = Math.Round(summary.Score).ToString("0");
            SizeF scoreSize = g.MeasureString(scoreText, scoreFont);
            float scoreX = barX + (barWidth / 2f) - (scoreSize.Width / 2f);
            float scoreY = barY - scoreSize.Height - 4;
            g.DrawString(scoreText, scoreFont, scoreBrush, new PointF(scoreX, scoreY));

            string monthText = summary.Month.ToString("MMM", CultureInfo.InvariantCulture);
            SizeF monthSize = g.MeasureString(monthText, monthFont);
            float monthX = barX + (barWidth / 2f) - (monthSize.Width / 2f);
            g.DrawString(monthText, monthFont, subtitleBrush, new PointF(monthX, baseY + 2));
        }

        private void DrawCenteredText(Graphics g, string text, Font font, Brush brush, Rectangle bounds)
        {
            SizeF size = g.MeasureString(text, font);
            float x = bounds.X + (bounds.Width - size.Width) / 2;
            float y = bounds.Y + (bounds.Height - size.Height) / 2;
            g.DrawString(text, font, brush, new PointF(x, y));
        }

        private List<MonthlySummary> BuildSummaries()
        {
            DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime firstMonth = currentMonth.AddMonths(-5);

            List<MonthlySummary> summaries = new List<MonthlySummary>();
            for (int i = 0; i < 6; i++)
            {
                summaries.Add(new MonthlySummary { Month = firstMonth.AddMonths(i) });
            }

            if (_sessions == null || _sessions.Count == 0)
            {
                return summaries;
            }

            foreach (ConcentrationSession session in _sessions)
            {
                DateTime createdAt;
                if (!DateTime.TryParseExact(session.CreatedAt, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdAt))
                {
                    continue;
                }

                DateTime sessionMonth = new DateTime(createdAt.Year, createdAt.Month, 1);
                MonthlySummary summary = summaries.FirstOrDefault(x => x.Month == sessionMonth);
                if (summary == null)
                {
                    continue;
                }

                AddSessionScore(summary, session);
            }

            return summaries;
        }

        private void AddSessionScore(MonthlySummary summary, ConcentrationSession session)
        {
            if (session == null)
            {
                return;
            }

            double hours = session.DurationInMinutes / 60.0;
            if (session.DurationInMinutes >= ModeTimeLimits.DeepWorkMin)
            {
                double points = hours * 1.5;
                summary.DeepScore += points;
                summary.Score += points;
                return;
            }

            if (session.DurationInMinutes >= ModeTimeLimits.SeriousModeMin)
            {
                double points = hours * 1.2;
                summary.SeriousScore += points;
                summary.Score += points;
                return;
            }

            summary.WarmScore += hours;
            summary.Score += hours;
        }

        private void DrawStackedScoreBar(Graphics g, int x, int y, int width, int height, MonthlySummary summary, Brush warmBrush, Brush seriousBrush, Brush deepBrush)
        {
            double total = summary.Score;
            if (total <= 0)
            {
                return;
            }

            int warmHeight = (int)Math.Round(height * summary.WarmScore / total);
            int seriousHeight = (int)Math.Round(height * summary.SeriousScore / total);
            int deepHeight = height - warmHeight - seriousHeight;

            if (deepHeight < 0)
            {
                deepHeight = 0;
            }

            int currentY = y + height;
            if (warmHeight > 0)
            {
                currentY -= warmHeight;
                g.FillRectangle(warmBrush, new Rectangle(x, currentY, width, warmHeight));
            }

            if (seriousHeight > 0)
            {
                currentY -= seriousHeight;
                g.FillRectangle(seriousBrush, new Rectangle(x, currentY, width, seriousHeight));
            }

            if (deepHeight > 0)
            {
                currentY -= deepHeight;
                g.FillRectangle(deepBrush, new Rectangle(x, currentY, width, deepHeight));
            }

        }

        private void DrawLegend(Graphics g, int x, int y, Brush warmBrush, Brush seriousBrush, Brush deepBrush, Brush textBrush, Font font)
        {
            DrawLegendItem(g, x, y, warmBrush, "Warm", textBrush, font);
            DrawLegendItem(g, x + 58, y, seriousBrush, "Serious", textBrush, font);
            DrawLegendItem(g, x + 115, y, deepBrush, "Deep work", textBrush, font);
        }

        private void DrawLegendItem(Graphics g, int x, int y, Brush brush, string text, Brush textBrush, Font font)
        {
            g.FillEllipse(brush, new Rectangle(x, y + 2, 7, 7));
            g.DrawString(text, font, textBrush, new PointF(x + 10, y));
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                path.CloseFigure();
                return path;
            }

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Color GetMutedTone(Color color)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R * 0.88),
                (int)(color.G * 0.88),
                (int)(color.B * 0.88));
        }
    }
}
