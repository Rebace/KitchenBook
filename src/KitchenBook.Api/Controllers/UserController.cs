using KitchenBook.Api.MessageContracts;
using KitchenBook.Api.MessageContracts.UserModel;
using KitchenBook.Domain.UserModel;
using KitchenBook.Infrastructure.Auxiliary;
using KitchenBook.Infrastructure.UoF;
using Microsoft.AspNetCore.Mvc;

namespace KitchenBook.Api.Controllers;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        User user = await _userRepository.GetByLogin(loginDto.Login);
        string password = Hashing.ToSHA256(loginDto.Password);
        if (password != user.Password)
        {
            return BadRequest();
        }

        string token = Guid.NewGuid().ToString();
        user.Token = token;

        _userRepository.Update(user);
        _unitOfWork.Commit();

        HttpContext.Response.AppendTokenToCookies(token);
        HttpContext.Response.AppendLoginToCookies(loginDto.Login);
        return Ok();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        User user = await _userRepository.GetByLogin(registerDto.Login);
        if (user != null)
        {
            return BadRequest();
        }

        string token = Guid.NewGuid().ToString();

        await _userRepository.Add(new User(
            registerDto.Name,
            registerDto.Login,
            Hashing.ToSHA256(registerDto.Password),
            null,
            token));
        _unitOfWork.Commit();

        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> Update([FromBody] UserDto userDto)
    {
        string login = HttpContext.Request.Cookies["Login"];
        string token = HttpContext.Request.Cookies["Token"];

        User user = await _userRepository.GetByLogin(login);
        User userDtoCheck = await _userRepository.GetByLogin(userDto.Login);

        if ((token != user.Token) || ((userDtoCheck != null) && (login != userDto.Login)))
        {
            return BadRequest();
        }

        user.Edit(
            userDto.Name,
            userDto.Login,
            userDto.Password,
            userDto.Description
        );

        _userRepository.Update(user);
        _unitOfWork.Commit();

        HttpContext.Response.AppendLoginToCookies(userDto.Login);

        return Ok();
    }
}
