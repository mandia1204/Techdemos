using System.Collections.Generic;

namespace Demo.PersonApi.Models
{
    public class ApiResponse<T>
    {
        public List<string> Errors { get; set; }
        public ApiResponse() {
            Errors = new List<string>();
        }
        
        public string Message {
            get {
                return this.Errors.Count > 0 ? "An error has ocurred" : "Operation completed successfully";
            }
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