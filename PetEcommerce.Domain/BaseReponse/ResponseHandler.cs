using System.Net;

namespace PetEcommerce.Domain.BaseReponse
{
    public class ResponseHandler
    {
        public BaseResponse<T> Success<T>(T data)
        {
            return new BaseResponse<T>(data, true, HttpStatusCode.OK, "Operation completed successfully.");
        }

        public BaseResponse<T> Failure<T>(T data, HttpStatusCode statusCode, string errorMessage)
        {
            return new BaseResponse<T>(data, false, statusCode, errorMessage);
        }

        public BaseResponse<T> Created<T>(T data)
        {
            return new BaseResponse<T>(data, true, HttpStatusCode.Created, "Resource created successfully.");
        }

        public BaseResponse<T> Updated<T>(T data)
        {
            return new BaseResponse<T>(data, true, HttpStatusCode.Accepted, "Resource updated successfully.");
        }

        public BaseResponse<T> NotFound<T>()
        {
            return new BaseResponse<T>(false, HttpStatusCode.BadRequest, "Resource not Found.");
        }
    }
}
