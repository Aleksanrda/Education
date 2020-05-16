namespace BabyLifeMobile.Core.Provider
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Windows.System.UserProfile;

    public class CultureProvider
    {
        private static CultureInfo selectedCulture;
        private static readonly CultureInfo defaultCulture = new CultureInfo("de-DE");

        private static readonly List<CultureInfo> supportedLanguages = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("uk-UA")
        };

        public static IReadOnlyList<CultureInfo> SupportedLanguages => CultureProvider.supportedLanguages;

        public static CultureInfo SelectedCulture
        {
            get
            {
                if (CultureProvider.selectedCulture == null)
                {
                    CultureProvider.InitializeCultureInFirstTime();
                }

                return selectedCulture;
            }
            set
            {
                selectedCulture = value;
                CultureProvider.ApplyCulture();
            }
        }

        public static void ApplyCulture()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureProvider.SelectedCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureProvider.SelectedCulture;
        }

        private static void InitializeCultureInFirstTime()
        {
            var language = GlobalizationPreferences.Languages[0].ToString();
            var currentUICulture = new CultureInfo(language);

            var cultureInfo = supportedLanguages.FirstOrDefault(c => c.TwoLetterISOLanguageName == currentUICulture.TwoLetterISOLanguageName);

            if (cultureInfo != null && currentUICulture != null)
            {
                CultureProvider.SelectedCulture = cultureInfo;
            }
            else
            {
                CultureProvider.SelectedCulture = CultureProvider.defaultCulture;
            }
        }
    }
}