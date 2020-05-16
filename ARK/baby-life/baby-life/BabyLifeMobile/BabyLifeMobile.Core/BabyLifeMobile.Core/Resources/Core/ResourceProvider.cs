namespace BabyLifeMobile.Core.Resources.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Windows.ApplicationModel.Resources.Core;

    /// <summary>
    /// Allow access to package resources according with current UI culture.
    /// </summary>
    public class ResourceProvider
    {
        /// <summary>
        /// Path to resource file.
        /// </summary>
        private string subtreeName;

        /// <summary>
        /// A collection of related resources.
        /// </summary>
        private ResourceMap resourceStringMap;

        /// <summary>
        /// Object performs all of the factors ("qualifiers") that might affect resource selection.
        /// </summary>
        private ResourceContext context;

        /// <summary>
        /// Culture used when last query to resource performed.
        /// </summary>
        private CultureInfo lastUsedCultureInfo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceProvider"/> class 
        /// </summary>
        /// <param name="resourceSubtreeName">Path to resource in application package.</param>
        public ResourceProvider(string resourceSubtreeName)
        {
            this.subtreeName = resourceSubtreeName;
        }

        /// <summary>
        /// Gets or sets culture that must be used for every instance of <see cref="ResourceProvider"/>
        /// </summary>
        public static CultureInfo GlobalOverrideCulture
        {
            get
            {
                return CultureInfo.DefaultThreadCurrentUICulture ?? CultureInfo.CurrentUICulture;
            }
        }

        /// <summary>
        /// Gets culture that used globally for retrieving string resources
        /// </summary>
        public static CultureInfo GlobalActualCulture
        {
            get
            {
                var actual = CultureInfo.CurrentUICulture;

                if (GlobalOverrideCulture != null)
                {
                    actual = GlobalOverrideCulture;
                }

                return actual;
            }
        }

        /// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Overrided")]
        public CultureInfo OverridedCulture { get; set; }

        /// <summary>
        /// Gets collection of all resources.
        /// </summary>
        private ResourceMap ResourceStringMap
        {
            get
            {
                if (Object.ReferenceEquals(resourceStringMap, null))
                {
                    resourceStringMap = ResourceManager.Current.MainResourceMap.GetSubtree(this.subtreeName);
                }

                return resourceStringMap;
            }
        }

        /// <summary>
        /// Gets object for querying resources by selected culture.
        /// </summary>
        private ResourceContext Context
        {
            get
            {
                if (this.ActualCulture != this.lastUsedCultureInfo)
                {
                    this.lastUsedCultureInfo = ActualCulture;
                    this.context = new ResourceContext();
                    this.context.Languages = new List<string> { this.lastUsedCultureInfo.Name };
                }

                return this.context;
            }
        }

        /// <summary>
        /// Gets culture that must be used now for resource querying.
        /// </summary>
        private CultureInfo ActualCulture
        {
            get
            {
                var actual = GlobalActualCulture;

                if (this.OverridedCulture != null)
                {
                    actual = this.OverridedCulture;
                }
                return actual;
            }
        }

        /// <summary>
        /// Read string value from resources.
        /// </summary>
        /// <param name="resourceKey">Key of resource.</param>
        /// <returns>Value of resource.</returns>
        public string GetString(string resourceKey)
        {
            return ResourceStringMap.GetValue(resourceKey, this.Context).ValueAsString;
        }
    }
}
