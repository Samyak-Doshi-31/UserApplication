using System;

namespace UserApplication.Exception
{
    public class UserCredentialsInvalid : ApplicationException
    {
        public UserCredentialsInvalid()
        {

        }
        public UserCredentialsInvalid(string message) : base(message)
        {

        }
    }
}
