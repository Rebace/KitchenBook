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

    [HttpGet]
    [Route("get-authorized")]
    public async Task<IActionResult> GetAuthorized()
    {
        string login = HttpContext.Request.Cookies["Login"];
        User user = await _userRepository.GetByLogin(login);

        UserDto userDto = new UserDto(user.Name, user.Description);

        return Ok(userDto);
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
    public async Task<IActionResult> Register(UpsertUserDto upsertUserDto)
    {
        User user = await _userRepository.GetByLogin(upsertUserDto.Login);
        if (user != null)
        {
            return BadRequest();
        }

        string token = Guid.NewGuid().ToString();

        await _userRepository.Add(new User(
            upsertUserDto.Name,
            upsertUserDto.Login,
            Hashing.ToSHA256(upsertUserDto.Password),
            null,
            token));
        _unitOfWork.Commit();

        return Ok();
    }

    [HttpPost]
    [Route("update")]
    public async Task<IActionResult> Update([FromBody] UpsertUserDto upsertUserDto)
    {
        string login = HttpContext.Request.Cookies["Login"];

        User user = await _userRepository.GetByLogin(login);
        User userDtoCheck = await _userRepository.GetByLogin(upsertUserDto.Login);

        if ((userDtoCheck != null) && (login != upsertUserDto.Login))
        {
            return BadRequest();
        }

        user.Edit(
            upsertUserDto.Name,
            upsertUserDto.Login,
            upsertUserDto.Password,
            upsertUserDto.Description
        );

        _userRepository.Update(user);
        _unitOfWork.Commit();

        HttpContext.Response.AppendLoginToCookies(upsertUserDto.Login);

        return Ok();
    }
}
