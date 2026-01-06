using System.Text.Json;

namespace ToDo.BackEnd
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Trace { get; set; }
        public string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
