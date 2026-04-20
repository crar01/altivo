using System;

namespace Altivo.Shared
{
    public static class ModeMessages
    {
        public const string WarmUp = "Warm up";
        public const string SeriousMode = "Serious mode";
        public const string DeepWork = "Deep work";
        public const string FatigueRisk = "Fatigue risk";
    }

    public static class ModeColors
    {
        public static System.Drawing.Color WarmUp = System.Drawing.Color.Orange;
        public static System.Drawing.Color SeriousMode = System.Drawing.Color.Gold;
        public static System.Drawing.Color DeepWork = System.Drawing.Color.MediumSeaGreen;
        public static System.Drawing.Color FatigueRisk = System.Drawing.Color.Crimson;
    }
}
