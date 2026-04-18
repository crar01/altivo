using System;

namespace Altivo.Shared
{
    public static class ModeTimeLimits
    {
        public const int WarmUpMin = 1;
        public const int WarmUpMax = 20;
        public const int SeriousModeMin = 21;
        public const int SeriousModeMax = 40;
        public const int DeepWorkMin = 41;
        public const int DeepWorkMax = 90;
        public const int FatigueRiskMin = 91;
    }
}
