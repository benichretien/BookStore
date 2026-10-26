namespace BookStore.API.Common
{
    public enum ErrorType
    {
        NotFound,
        Validation
    }
    public record Error(string Code, string Description, ErrorType Type)
    {
        public static Error NotFound(string code, string description) =>
        new(code, description, ErrorType.NotFound);

        public static Error Validation(string code, string description) =>
            new(code, description, ErrorType.Validation);
    }
    
}
