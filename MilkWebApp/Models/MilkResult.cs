namespace MilkWebApp.Models
{
    public interface IMilkResult
    {
        int Status { get; set; }
        string Message { get; set; }
        object? Data { get; set; }
    }

    public class MilkResult : IMilkResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
