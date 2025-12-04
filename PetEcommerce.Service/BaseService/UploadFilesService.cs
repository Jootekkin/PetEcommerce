using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetEcommerce.Domain.BaseReponse;
using PetEcommerce.Domain.UploadedFiles;
using System.Net;
namespace PetEcommerce.Service.BaseService
{
    #region Interfaces
    public interface IUploadFilesService
    {
        Task<BaseResponse<bool>> UploadFiles(IFormFileCollection files, string name, Guid guid);
        Task<BaseResponse<UploadedFileInfo>> GetFileInfo(string path);
        Task<BaseResponse<bool>> DownloadFiles(string path);

    }
    #endregion

    #region Implementations
    public class UploadFilesService : ResponseHandler, IUploadFilesService
    {
        #region Fields
        private readonly IConfiguration _configuration;
        private long _maxfileSize;
        private string? _uploadsFolder;
        private string[] _allowedExtensions;
        #endregion

        #region Constructors
        public UploadFilesService(IConfiguration configuration)
        {
            _configuration = configuration;
            _maxfileSize = long.Parse(configuration.GetSection("UploadFileSettings:MaxFileSizeMB").Value) * 1024 * 1024;
            _uploadsFolder = configuration.GetSection("UploadFileSettings:UploadPath").Value;
            _allowedExtensions = configuration.GetSection("UploadFileSettings:AllowedExtensions").GetChildren().Select(x => x.Value).ToArray();
        }
        #endregion

        #region Methods

        public async Task<BaseResponse<bool>> UploadFiles(IFormFileCollection files, string name, Guid guid)
        {
            int index = 1;

            if (files == null || files.Count == 0)
                return Failure<bool>(HttpStatusCode.BadRequest, "Images Required");

            foreach (var item in files)
            {

                if (item.Length > _maxfileSize)
                    return Failure<bool>(HttpStatusCode.BadRequest, "One of the images size bigger than 10MP");


                var extension = Path.GetExtension(item.FileName).ToLower();
                if (!IsExtensionAllowed(extension))
                    return Failure<bool>(HttpStatusCode.BadRequest, "One of the images has invalid format");

                var FullPath = Path.Combine(_uploadsFolder, guid.ToString(), $"{name}{index.ToString()}{extension}");

                var directory = Path.GetDirectoryName(FullPath);
                if (string.IsNullOrWhiteSpace(directory))
                    return Failure<bool>(HttpStatusCode.InternalServerError, "Invalid upload path");

                Directory.CreateDirectory(directory);

                using (var stream = new FileStream(FullPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await item.CopyToAsync(stream);
                }
                index++;
            }
            return Success(true);
        }

        public async Task<BaseResponse<UploadedFileInfo>> GetFileInfo(string path)
        {
            if (!File.Exists(path))
                return Failure<UploadedFileInfo>(HttpStatusCode.NotFound, "File not found");

            var fileInfo = new FileInfo(path);
            var uploadedFileInfo = new UploadedFileInfo
            {
                FileName = fileInfo.Name,
                Size = fileInfo.Length,
                ContentType = GetContentType(fileInfo.Extension),
                Path = fileInfo.FullName,
                Url = $"uploads/{fileInfo.Name}" // Assuming a base URL structure
            };

            return Success(uploadedFileInfo);
        }


        public Task<BaseResponse<bool>> DownloadFiles(string path)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Helpers
        private bool IsExtensionAllowed(string extension)
        {
            return _allowedExtensions.Contains(extension.ToLower());
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        private string GetContentType(string extension)
        {
            return extension.ToLowerInvariant() switch
            {
                ".pdf" => "application/pdf",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".txt" => "text/plain",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".zip" => "application/zip",
                ".csv" => "text/csv",
                _ => "application/octet-stream"
            };
        }
        #endregion
    }
    #endregion
}
