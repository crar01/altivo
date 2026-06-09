using Altivo.Shared;
using Altivo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Altivo.Controls
{
    public class MonthlyDashboardControl : UserControl
    {
        private List<ConcentrationSession> _thisMonthSessions = new List<ConcentrationSession>();
        private List<ConcentrationSession> _lastMonthSessions = new List<ConcentrationSession>();

        public MonthlyDashboardControl()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(25, 25, 25);
            this.Size = new Size(500, 310);
        }

        public void LoadData(List<ConcentrationSession> thisMonth, List<ConcentrationSession> lastMonth)
        {
            _thisMonthSessions = thisMonth ?? new List<ConcentrationSession>();
            _lastMonthSessions = lastMonth ?? new List<ConcentrationSession>();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Stats
            int currentDeep = _thisMonthSessions.Count(s => s.DurationInMinutes >= ModeTimeLimits.DeepWorkMin);
            int currentMod = _thisMonthSessions.Count(s => s.DurationInMinutes >= ModeTimeLimits.SeriousModeMin && s.DurationInMinutes <= ModeTimeLimits.SeriousModeMax);
            int currentWarm = _thisMonthSessions.Count(s => s.DurationInMinutes <= ModeTimeLimits.WarmUpMax);
            int total = _thisMonthSessions.Count;

            // Score Calculation
            double CalculateScore(List<ConcentrationSession> sessions)
            {
                if (sessions == null || !sessions.Any()) return 0;

                double score = 0;
                foreach (var s in sessions)
                {
                    double hours = s.DurationInMinutes / 60.0;
                    if (s.DurationInMinutes >= ModeTimeLimits.DeepWorkMin)
                        score += hours * 1.5; // 50% extra points
                    else if (s.DurationInMinutes >= ModeTimeLimits.SeriousModeMin)
                        score += hours * 1.2; // 20% extra points
                    else
                        score += hours * 1.0; // Base points
                }

                return score;
            }

            double scoreThis = CalculateScore(_thisMonthSessions);
            double scoreLast = CalculateScore(_lastMonthSessions);
            int scoreDiffPct = scoreLast > 0 ? (int)Math.Round(((scoreThis - scoreLast) / scoreLast) * 100) : 0;

            // Font
            using (var titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            using (var subtitleFont = new Font("Segoe UI", 8, FontStyle.Regular))
            using (var valueFont = new Font("Segoe UI", 18, FontStyle.Bold))
            using (var smallFont = new Font("Segoe UI", 8, FontStyle.Regular))
            using (var labelFont = new Font("Segoe UI", 9, FontStyle.Bold))
            // Brushes
            using (var whiteBrush = new SolidBrush(Color.Gainsboro))
            using (var subBrush = new SolidBrush(Color.DarkGray))
            using (var colorDeep = new SolidBrush(ModeColors.DeepWork))
            using (var colorMod = new SolidBrush(ModeColors.SeriousMode))
            using (var colorWarm = new SolidBrush(ModeColors.WarmUp))
            using (var bgPanels = new SolidBrush(Color.FromArgb(35, 35, 35)))
            {
                // Title
                g.DrawString("Productivity Score (this month)", titleFont, whiteBrush, new PointF(10, 10));
                g.DrawString("Score based on total time and session quality)", subtitleFont, subBrush, new PointF(10, 35));

                // Averages Box
                int boxWg = 110, boxH = 100;
                int startX = 10;
                int startY = 60;

                g.FillRectangle(bgPanels, new Rectangle(startX, startY, boxWg, boxH));
                DrawCenteredText(g, "Monthly Score", labelFont, whiteBrush, startX, boxWg, startY + 5);
                DrawCenteredText(g, $"{Math.Round(scoreThis)} pts", valueFont, whiteBrush, startX, boxWg, startY + 25);

                Brush diffBrush = scoreDiffPct >= 0 ? Brushes.LightGreen : new SolidBrush(Color.FromArgb(255, 131, 131));
                string diffSign = scoreDiffPct >= 0 ? "▲" : "▼";
                DrawCenteredText(g, $"{diffSign} {Math.Abs(scoreDiffPct)}%", labelFont, diffBrush, startX, boxWg, startY + 60);
                DrawCenteredText(g, "vs last month", labelFont, subBrush, startX, boxWg, startY + 75);

                // Categories logic
                DrawStatBox(g, startX + 120, startY, ModeMessages.WarmUp, $"< {ModeTimeLimits.WarmUpMax + 1} min", currentWarm, total, colorWarm);
                DrawStatBox(g, startX + 240, startY, ModeMessages.SeriousMode, $"{ModeTimeLimits.SeriousModeMin} - {ModeTimeLimits.SeriousModeMax} min", currentMod, total, colorMod);
                DrawStatBox(g, startX + 360, startY, ModeMessages.DeepWork, $"> {ModeTimeLimits.DeepWorkMin - 1} min", currentDeep, total, colorDeep);

                // Lower section: Distribution
                int distY = 170;
                g.DrawString("Distribution of sessions (this month)", labelFont, whiteBrush, new PointF(10, distY));

                // Pie chart
                int pieSz = 100;
                Rectangle pieRect = new Rectangle(20, distY + 30, pieSz, pieSz);

                if (total > 0)
                {
                    float angleDeep = 360f * currentDeep / total;
                    float angleMod = 360f * currentMod / total;
                    float angleWarm = 360f * currentWarm / total;

                    float startAngle = -90f; // top
                    if (currentDeep > 0)
                    {
                        g.FillPie(colorDeep, pieRect, startAngle, angleDeep);
                        startAngle += angleDeep;
                    }
                    if (currentMod > 0)
                    {
                        g.FillPie(colorMod, pieRect, startAngle, angleMod);
                        startAngle += angleMod;
                    }
                    if (currentWarm > 0)
                    {
                        g.FillPie(colorWarm, pieRect, startAngle, angleWarm);
                    }
                }
                else
                {
                    g.FillPie(subBrush, pieRect, 0, 360);
                }

                // Inner circle for donut chart
                g.FillEllipse(new SolidBrush(Color.FromArgb(25, 25, 25)), new Rectangle(pieRect.X + 15, pieRect.Y + 15, 70, 70));

                // Text in circle
                string tStr = total.ToString();
                SizeF tSz = g.MeasureString(tStr, valueFont);
                g.DrawString(tStr, valueFont, whiteBrush, new PointF(pieRect.X + 50 - tSz.Width/2, pieRect.Y + 30));

                string sStr = "Sessions";
                SizeF sSz = g.MeasureString(sStr, smallFont);
                g.DrawString(sStr, smallFont, whiteBrush, new PointF(pieRect.X + 50 - sSz.Width/2, pieRect.Y + 55));

                // Legend
                int legX = 150;
                int legY = distY + 40;
                g.FillRectangle(bgPanels, new Rectangle(legX, legY - 10, 320, 85));

                DrawLegendItem(g, legX + 10, legY, colorWarm, $"Warm Up (< {ModeTimeLimits.WarmUpMax + 1} min)", currentWarm, total);
                DrawLegendItem(g, legX + 10, legY + 25, colorMod, $"Serious Mode ({ModeTimeLimits.SeriousModeMin} - {ModeTimeLimits.SeriousModeMax} min)", currentMod, total);
                DrawLegendItem(g, legX + 10, legY + 50, colorDeep, $"Deep Work (> {ModeTimeLimits.DeepWorkMin - 1} min)", currentDeep, total);
            }
        }

        private void DrawStatBox(Graphics g, int x, int y, string title, string subtitle, int current, int total, SolidBrush colorBrush)
        {
            using (var bgPanels = new SolidBrush(Color.FromArgb(10, colorBrush.Color.R, colorBrush.Color.G, colorBrush.Color.B)))
            using (var tF = new Font("Segoe UI", 10, FontStyle.Bold))
            using (var sF = new Font("Segoe UI", 9, FontStyle.Regular))
            using (var hF = new Font("Segoe UI", 16, FontStyle.Bold))
            using (var subColorBrush = new SolidBrush(Color.FromArgb(40, colorBrush.Color.R, colorBrush.Color.G, colorBrush.Color.B)))
            {
                g.FillRectangle(bgPanels, new Rectangle(x, y, 110, 100));

                SizeF ts = g.MeasureString(title, tF);
                g.DrawString(title, tF, colorBrush, new PointF(x + (110 - ts.Width)/2, y + 5));

                SizeF ss = g.MeasureString(subtitle, sF);
                g.DrawString(subtitle, sF, colorBrush, new PointF(x + (110 - ss.Width)/2, y + 23));

                SizeF hs = g.MeasureString(current.ToString(), hF);
                g.DrawString(current.ToString(), hF, Brushes.WhiteSmoke, new PointF(x + (110 - hs.Width)/2, y + 35));

                int pct = total > 0 ? (int)Math.Round(100.0 * current / total) : 0;
                string pctStr = $"{pct}%";
                SizeF pcts = g.MeasureString(pctStr, tF);
                g.DrawString($"{pct}% ", tF, colorBrush, new PointF(x + (110 - pcts.Width)/2, y + 65));

                // mini bar
                int posY = 85;
                g.FillRectangle(subColorBrush, new Rectangle(x + 10, y + posY, 90, 4));
                g.FillRectangle(colorBrush, new Rectangle(x + 10, y + posY, (int)(90.0 * pct / 100.0), 4));
            }
        }

        private void DrawLegendItem(Graphics g, int x, int y, SolidBrush brush, string text, int count, int total)
        {
            g.FillEllipse(brush, new Rectangle(x, y + 2, 8, 8));
            using (var f = new Font("Segoe UI", 10))
            using (var fb = new Font("Segoe UI", 10, FontStyle.Bold))
            {
                g.DrawString(text, f, Brushes.Gainsboro, new PointF(x + 15, y));

                int pct = total > 0 ? (int)Math.Round(100.0 * count / total) : 0;
                string stats = $"{count} ({pct}%)";
                g.DrawString(stats, fb, Brushes.Gainsboro, new PointF(x + 220, y));
            }
        }

        private void DrawCenteredText(Graphics g, string text, Font font, Brush brush, int destX, int width, int y)
        {
            SizeF size = g.MeasureString(text, font);
            float centerX = destX + (width - size.Width) / 2;
            g.DrawString(text, font, brush, new PointF(centerX, y));
        }
    }
}
