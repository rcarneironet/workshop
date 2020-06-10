﻿using Contoso.Store.Shared.Abstractions;

namespace Contoso.Store.Shared.Implementations
{
    public class ApiContract : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public ApiContract(
            bool success, 
            string message, 
            object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
