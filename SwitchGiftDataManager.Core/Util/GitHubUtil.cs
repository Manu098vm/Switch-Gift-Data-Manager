using SwitchGiftDataManager.Core;
using Octokit;

namespace SwitchGiftDataManager.Core
{
    public static class GitHubUtil
    {
        public static async Task<bool> IsUpdateAvailable()
        {
            var currentVersion = ParseVersion(GetPluginVersion());
            var latestVersion = ParseVersion(await GetLatestVersion());

            if (latestVersion[0] > currentVersion[0])
                return true;
            else if (latestVersion[0] == currentVersion[0])
            {
                if (latestVersion[1] > currentVersion[1])
                    return true;
                else if (latestVersion[1] == currentVersion[1])
                {
                    if (latestVersion[2] > currentVersion[2])
                        return true;
                }
            }
            return false;
        }

        private static string GetPluginVersion() => BCATManager.Version;

        private static async Task<string> GetLatestVersion()
        {
            try
            {
                return await GetLatest();
            }
            catch (Exception)
            {
                return "0.0.0";
            }
        }

        private static async Task<string> GetLatest()
        {
            var client = new GitHubClient(new ProductHeaderValue("Switch-Gift-Data-Manager"));
            var release = await client.Repository.Release.GetLatest("Manu098vm", "Switch-Gift-Data-Manager");
            return release.Name;
        }

        private static int[] ParseVersion(string version)
        {
            var v = new int[3];
            v[0] = int.Parse($"{version[0]}");
            v[1] = int.Parse($"{version[2]}");
            v[2] = int.Parse($"{version[4]}");
            return v;
        }
    }
}
