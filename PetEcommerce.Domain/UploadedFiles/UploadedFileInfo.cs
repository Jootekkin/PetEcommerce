namespace PetEcommerce.Domain.UploadedFiles
{
    public class UploadedFileInfo
    {
        public string FileName { get; set; } = string.Empty;
        public long Size { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
