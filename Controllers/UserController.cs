using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using UserApplication.Exception;
using UserApplication.Models;
using UserApplication.Repository;

namespace UserApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly IUserRegisterRepository _userRepository;
        public UserController(IUserRegisterRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("/Register/RegisterUser")]
        [HttpPost]
        public ActionResult RegisterUser(Register registerUser)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    bool regsiterUserStatus = _userRepository.Register(registerUser);
                    return Ok(regsiterUserStatus);
                }
                
            }
            catch (UserAlreadyExistsException ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest();
        }
        [Route("/Register/LoginUser")]
        [HttpPost]
        public ActionResult LoginUser(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int loginUserStatus = _userRepository.Login(login);
                    return Ok(loginUserStatus);
                }
                
            }
            catch (UserCredentialsInvalid ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest();
        }
    }
}
