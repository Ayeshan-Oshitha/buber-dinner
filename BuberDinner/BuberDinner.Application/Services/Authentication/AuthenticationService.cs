using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        public readonly IJwtTokenGenerator _jwtTokenGenerator;
        public readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
        {
            // Check if user already exists
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // Create user (generate uniqueId) & persist to DB
            var user = new User 
            { 
                FirstName = firstName, 
                LastName = lastName, 
                Email = email, 
                Password = password 
            };

            _userRepository.AddUser(user);

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            // Validate the user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredebtials;
            }

            // Validate the password is correct
            if(user.Password != password)
            {
                return Errors.Authentication.InvalidCredebtials;
            }

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user , token );
        }

       
    }
}
