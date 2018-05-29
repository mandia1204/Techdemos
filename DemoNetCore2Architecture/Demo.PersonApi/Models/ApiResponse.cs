using System.Collections.Generic;

namespace Demo.PersonApi.Models
{
    public class ApiResponse<T>
    {
        public List<string> Errors { get; set; }
        public ApiResponse() {
            Errors = new List<string>();
        }
        
        public bool Success { 
            get 
            {
                return Errors.Count == 0;
            } 
        }
        public T Data { get; set; }
    }
}