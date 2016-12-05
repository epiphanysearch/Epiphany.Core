using System;
using System.Web.Configuration;

namespace Epiphany.Core
{
    /// <summary>
    /// Abstraction over the <see cref="FEBuild.AppSettingKey"/> Web.config AppSetting. The
    /// setting is used to define the mode that the Front End Build has been built in. It provides
    /// the value as an Enum (defaulting to  <see cref="FEBuildMode.Development"/>) rather
    /// than a string.
    /// </summary>
    /// <example><![CDATA[
    /// @switch (FEBuild.Mode) {
    ///     case FEBuildMode.Production:
    ///         <script src="/assets/js/bundle.js"></script>
    ///         <script>
    ///             System['import'].call(System, 'app');
    ///         </script>
    ///         break;
    ///     case FEBuildMode.Development:
    ///         <script src="/assets/js/jspm_packages/system.js"></script>
    ///         <script src="/assets/js/config.js"></script>
    ///         <script>
    ///             System['import'].call(System, '/assets/js/app');
    ///         </script>
    ///         break;
    /// }
    /// ]]></example>
    public static class FEBuild
    {
        /// <summary>
        /// Web.config AppSetting key.
        /// </summary>
        private static readonly string AppSettingKey = "FEBuild.Mode";

        /// <summary>
        /// The <see cref="FEBuildMode"/> set in the Web.config AppSettings, will default to
        /// <see cref="FEBuildMode.Development"/> if not set or unexpected value is set. The
        /// value is set through a case insensitive parse by <see cref="Enum"/>.
        /// </summary>
        /// <example>
        /// if (FEBuild.Mode == FEBuildMode.Production) {
        ///     // ...
        /// }
        /// </example>
        public static readonly FEBuildMode Mode = FEBuild.GetMode();

        /// <summary>
        /// Convenience to check if <see cref="Mode"/> is set to <see cref="FEBuildMode.Development"/>.
        /// </summary>
        /// <example><![CDATA[
        /// <link rel="stylesheet" href="/assets/css/screen@(".min".If(FEBuild.IsDev)).css">
        /// ]]></example>
        public static readonly bool IsDev = (FEBuild.Mode == FEBuildMode.Development);

        /// <summary>
        /// Gets the <see cref="FEBuildMode"/> from the Web.config AppSettings, defaulting to
        /// <see cref="FEBuildMode.Development"/> if not set or unexpected value is set.
        /// </summary>
        private static FEBuildMode GetMode()
        {
            FEBuildMode mode;
            string value = WebConfigurationManager.AppSettings[FEBuild.AppSettingKey];

            if (!Enum.TryParse<FEBuildMode>(value, ignoreCase: true, result: out mode)) {
                return FEBuildMode.Development;
            }

            return mode;
        }
    }
}
