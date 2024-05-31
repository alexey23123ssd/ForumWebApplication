namespace Domain.Helpers
{
    public class ServiceResponse<T>
    {
        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }

        public static ServiceResponse<T> Failed(string errorMessage)
        {
            return new ServiceResponse<T>
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }

        public static ServiceResponse<T> Succeeded()
        {
            return new ServiceResponse<T>
            {
                IsSuccess = true,
            };
        }

    }
}
