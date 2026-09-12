using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Altivo.Services
{
    // Minimal updater helper (ponytail: keep it tiny and focused).
    public static class GitHubUpdater
    {
        // minimal, focused API (ponytail): call IsNewVersionAvailableAsync(), read LatestVersion/ReleasesUrl if true
        public readonly static string owner = "crar01";
        public readonly static string repo = "altivo";

        public static Version LatestVersion { get; private set; }
        public static string ReleasesUrl => $"https://github.com/{owner}/{repo}/releases";

        public static async Task<bool> IsNewVersionAvailableAsync()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "Altivo-Updater");
                    var json = await wc.DownloadStringTaskAsync($"https://api.github.com/repos/{owner}/{repo}/releases/latest").ConfigureAwait(false);
                    var tag = Regex.Match(json, "\"tag_name\"\\s*:\\s*\"([^\"]+)\"").Groups[1].Value;
                    
                    if (string.IsNullOrEmpty(tag)) 
                        tag = Regex.Match(json, "\"name\"\\s*:\\s*\"([^\"]+)\"").Groups[1].Value;
                    
                    if (string.IsNullOrEmpty(tag)) 
                        return false;
                    
                    tag = tag.Trim().TrimStart('v', 'V');
                    if (!Version.TryParse(tag, out var latest)) 
                        return false;

                    var asm = System.Reflection.Assembly.GetEntryAssembly() ?? System.Reflection.Assembly.GetExecutingAssembly();
                    Version.TryParse(System.Diagnostics.FileVersionInfo.GetVersionInfo(asm.Location).FileVersion, out var current);
                    current = current ?? asm.GetName().Version;

                    if (current != null && latest > current)
                    {
                        LatestVersion = latest;
                        return true;
                    }
                }
            }
            catch { }
            return false;
        }
    }
}
