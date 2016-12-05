namespace Epiphany.Core
{
    /// <summary>
    /// Defines the mode that the Front End has been built in.
    /// </summary>
    public enum FEBuildMode
    {
        /// <summary>
        /// Raw assets, all seperated without minification, compression or concatination.
        /// </summary>
        Development,

        /// <summary>
        /// Minified, concatinated and minified assets.
        /// </summary>
        Production
    }
}
