using System.Collections.Generic;

namespace WebApi.Const
{
    public static class RoleConst
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Manager = "Manager";
    }
    public static class AuthStatus
    {
        public const string Submitted = "Submitted";
        public const string Approved = "Approved";
        public const string Rejected = "Rejected";
    }
    
    public static class StatusCode{
        public const int UnAuthorized = 401;
        public const int BadRequest = 400;
        public const int Forbidden = 403;
        public const int NotFound = 404;
        public const int OK = 200;
        public const int InternalServerError = 500;
    }

    public static class OrderStatus{
        public const string Sent = "Đã gửi";
        public const string Received = "Đã nhận";
        public const string onShipping = "Đang giao";
        public const string Shipped = "Đã giao";
        public const string Cancel = "Đã hủy";
    }

    public static class Response{
    public static IDictionary<string,object> ControlerResponse(int statusCode, string msg = null){
        var result = new {type = statusCode, message = msg};
        return new Dictionary<string,object>{
            {"result",result}
        };
    }
    }
}