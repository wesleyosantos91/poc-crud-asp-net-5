using System.Collections.Generic;

namespace app.Responses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; set; }

        public ErrorResponse(List<string> errors)
        {
            Errors = errors;
        }
    }
}