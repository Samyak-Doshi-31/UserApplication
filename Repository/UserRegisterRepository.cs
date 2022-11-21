using System.Linq;
using UserApplication.Context;
using UserApplication.Exception;
using UserApplication.Models;

namespace UserApplication.Repository
{
    public class UserRegisterRepository:IUserRegisterRepository
    {
        readonly UserApplicationDbContext _userDbContext;
        public UserRegisterRepository(UserApplicationDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public int Login(Login login)
        {
            var checkLogin = _userDbContext.Register.Where(u => u.UserMobileNumber == login.UserMobileNumber && u.UserPassword == login.UserPassword).FirstOrDefault();
            if (checkLogin==null)
            {
                throw new UserCredentialsInvalid("Invalid!! Incorrect MobileNumber or Password");
            }
            else return checkLogin.UserRegisterId;
        }
        public Register GetUserByMobileNumber(string mobileNumber)
        {
            
            return _userDbContext.Register.Where(u => u.UserMobileNumber == mobileNumber).FirstOrDefault();
        }
        public bool Register(Register register)
        {
            
            Register userRegister= GetUserByMobileNumber(register.UserMobileNumber);
            if (userRegister == null)
            {
                _userDbContext.Register.Add(register);
                _userDbContext.SaveChanges();
                return true;
            }
            else
            {
                throw new UserAlreadyExistsException($"Account with {register.UserMobileNumber} already exists");
            }
        }
    }
}
