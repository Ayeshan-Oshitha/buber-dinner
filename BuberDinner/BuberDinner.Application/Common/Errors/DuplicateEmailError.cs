using FluentResults;
using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public class DuplicateEmailError : IError
    {
        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => "A user with this email already exists.";

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }

}
