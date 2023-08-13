namespace Equifinance.Mock.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string ProblemField { get; set; }
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public EntityNotFoundException(string message, string problemField) : base(message)
        {
            ProblemField = problemField;
        }
    }
}
