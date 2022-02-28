using System.Collections.Generic;

namespace MyRecipeApp.DTOs
{
    public class ErrorDetails
    {
        public ErrorDetails(string errorCode = "", params string[] errors)
        {
            ErrorCode = errorCode;
            Errors = new List<string>(errors);
        }

        public string ErrorCode { get; set; }
        public List<string> Errors { get; set; }
    }
}
