namespace AdventureQuest.Result
{
    public interface IResult
    {
        public string Message { get; }

        public static IResult Failure(string message) => new Failure(message);  
        public static IResult Success(string message) => new Success(message);  
        public static IResult Success() => new Success("Success!"); 
    }

    public class Success : IResult
    {
        public Success(string message) => Message = message;
        public string Message { get; }
    }

    public class Failure : IResult
    {
        public Failure(string message) => Message = message;
        public string Message { get; }
    }

}