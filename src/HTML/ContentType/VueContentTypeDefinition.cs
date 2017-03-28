using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace VuePack
{
    public class VueContentTypeDefinition
    {
        public const string VueContentType = "htmlx";
        private const string VueFileExtension = ".vue";

        [Export(typeof(FileExtensionToContentTypeDefinition))]
        [ContentType(VueContentType)]
        [FileExtension(VueFileExtension)]
        public FileExtensionToContentTypeDefinition VueFileExtensionDefinition { get; set; }
    }
}
