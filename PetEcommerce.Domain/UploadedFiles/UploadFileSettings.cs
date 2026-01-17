namespace PetEcommerce.Domain.UploadedFiles
{
    public class UploadFileSettings
    {
        public const string SectionName = "UploadFileSettings";
        public string UploadFolderPath { get; set; } = string.Empty;
        public long MaxFileSizeInBytes { get; set; }
        public List<string> AllowedFileExtensions { get; set; } = new List<string>();
    }
}
