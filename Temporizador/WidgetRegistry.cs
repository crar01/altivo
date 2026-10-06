using System;
using System.Collections.Generic;

namespace Altivo
{
    public static class WidgetRegistry
    {
        // Widget identifiers (used in settings and code) - keep stable values
        public const string Simple = "Simple";
        public const string CZ = "CZ"; // internal id for Sanctuary Fire Clock

        // Human-friendly display names
        private static readonly Dictionary<string, string> _displayNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { Simple, "Simple" },
            { CZ, "Sanctuary Fire Clock" }
        };

        public static IEnumerable<string> GetAllIds() => _displayNames.Keys;

        public static string GetDisplayName(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return string.Empty;
            if (_displayNames.TryGetValue(id, out var name)) return name;
            return id;
        }

        public static FloatingTimerWidgetBase CreateWidget(string id)
        {
            switch (id)
            {
                case Simple:
                    return new FloatingTimerWidget();
                case CZ:
                default:
                    return new FloatingTimerWidgetCZ();
            }
        }
    }
}
