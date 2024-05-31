﻿namespace Domain.Helpers
{
    public class ServiceDataResponse<T> : ServiceResponse<T>
    {
        public T? Data { get; set; }
        public static new ServiceDataResponse<T> Failed(string message)
        {
            return new ServiceDataResponse<T>
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }

        public static ServiceDataResponse<T> Succeeded(T data)
        {
            return new ServiceDataResponse<T>
            {
                IsSuccess = true,
                Data = data
            };
        }
    }
}
