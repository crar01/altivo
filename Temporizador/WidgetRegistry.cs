using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Altivo
{
    public static class WidgetRegistry
    {
        // Human-friendly display names
        private static readonly Dictionary<string, (string DisplayName, Func<FloatingTimerWidgetBase> InstanceCreator)> widgets =
            new Dictionary<string, (string DisplayName, Func<FloatingTimerWidgetBase> InstanceCreator)>()
            {
                { "Simple", (DisplayName: "Simple", InstanceCreator: () => new FloatingTimerWidget()) },
                { "CZ", (DisplayName: "Sanctuary Fire Clock", InstanceCreator: () => new FloatingTimerWidgetCZ()) }
            };

        public static IEnumerable<string> GetAllIds() => widgets.Keys;

        public static string GetDisplayName(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return string.Empty;
            if (widgets.TryGetValue(id, out var widget)) return widget.DisplayName;
            return id;
        }

        public static FloatingTimerWidgetBase CreateWidget(string id)
        {
            return widgets.TryGetValue(id, out var widget) ? widget.InstanceCreator() : null;
        }

        public static string GetDefaultWidgetId()
        {
            foreach (var id in widgets.Keys)
            {
                return id;
            }

            return string.Empty;
        }

    }
}
