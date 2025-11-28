using System.Net;

namespace PetEcommerce.Domain.BaseReponse
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public BaseResponse() { }

        public BaseResponse(T data, bool isSuccess, HttpStatusCode statusCode, string message)
        {
            Data = data;
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
        }

        public BaseResponse(bool isSuccess, HttpStatusCode statusCode, string message)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
