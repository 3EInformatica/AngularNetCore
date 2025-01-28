namespace WebApplication2.Models
{
    public class Response<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
