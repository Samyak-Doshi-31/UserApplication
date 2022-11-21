using System;

namespace UserApplication.Exception
{
    public class UserAlreadyExistsException : ApplicationException
    {
        public UserAlreadyExistsException()
        {

        }
        public UserAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
