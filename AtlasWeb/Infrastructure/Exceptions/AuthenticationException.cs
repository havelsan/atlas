using System;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message): base (message)
        {
        }
    }
}