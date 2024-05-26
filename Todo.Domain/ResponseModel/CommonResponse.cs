namespace Todo.Domain.ResponseModel
{
    public class CommonResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
    }
}