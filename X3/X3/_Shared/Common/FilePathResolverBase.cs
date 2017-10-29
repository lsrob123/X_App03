namespace X3._Shared.Common
{
    public abstract class FilePathResolverBase : IFilePathResolver
    {
        public abstract string GetToolbarItemIconPath(string iconFileName);

        /// <summary>
        ///     Using string.Format(pattern, fileName) to compose the file path
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="fileName"></param>
        /// <returns>string.Format(pattern, fileName)</returns>
        protected string Compose(string pattern, string fileName)
        {
            return string.Format(pattern, fileName);
        }
    }
}