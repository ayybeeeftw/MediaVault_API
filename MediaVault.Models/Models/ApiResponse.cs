namespace MediaVault.Models
{
    public class ApiResponse<T>
    {
        public string Status { get; set; } = "success";
        public string Message { get; set; } = "";
        public T? Data { get; set; }
        public object? Error { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Success") => new()
        {
            Status = "success",
            Message = message,
            Data = data
        };

        public static ApiResponse<T> Fail(string message, object? error = null) => new()
        {
            Status = "fail",
            Message = message,
            Error = error
        };

        public static ApiResponse<T> FromError(string message, object? error = null) => new() // ✅ Renamed
        {
            Status = "error",
            Message = message,
            Error = error
        };
    }
}
