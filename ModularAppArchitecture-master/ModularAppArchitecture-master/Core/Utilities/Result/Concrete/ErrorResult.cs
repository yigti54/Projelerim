using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Result.Concrete
{
    public class ErrorResult : Result
    {
        // Make this constructor PUBLIC
        public ErrorResult(string message) : base(false, message)
        {
        }

        // Make this constructor PUBLIC too
        public ErrorResult() : base(false)
        {
        }
    }
}