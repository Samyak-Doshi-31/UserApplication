using UserApplication.Models;

namespace UserApplication.Repository
{
    public interface IUserRegisterRepository
    {
        public int Login(Login login);
        public Register GetUserByMobileNumber(string mobileNumber);
        public bool Register(Register register);

    }
}
