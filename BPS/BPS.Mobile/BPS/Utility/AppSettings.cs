using BPS.Core.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using BPS.Core.Extensions;

namespace BPS.Core.Utility
{
    public static class AppSettings
    {
        private static ISettings Settings => CrossSettings.Current;

        public static User User
        {
            get => Settings.GetValueOrDefault(nameof(User), default(User));

            set => Settings.AddOrUpdateValue(nameof(User), value);
        }
    }
}
