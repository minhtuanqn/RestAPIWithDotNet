namespace Business.Dto
{
    public class ResponseModelDTO
    {
        public ResponseModelDTO() { }

        public ResponseModelDTO(int statusCode, object data, string message)
        {
            this.statusCode = statusCode;
            this.data = data;
            this.message = message;
        }

        public int statusCode { get; set; }

        public object data { get; set; }

        public string message { get; set; }

    }
}
