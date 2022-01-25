namespace ProductManagement.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public string Message { get; set; }
        public ResponseBase()
        {
            Message = ("Operation performed successfully!");
        }

    }
}
