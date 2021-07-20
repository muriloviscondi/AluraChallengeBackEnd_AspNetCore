namespace AluraChallenge.Domain.Interfaces.Services
{
    public class ResponseBase
    {
        public ResponseBase(string message = "Operação realizada com sucesso")
        {
            Message = message;
        }

        public string Message { get; set; }

        public string Id { get; set; }
    }
}