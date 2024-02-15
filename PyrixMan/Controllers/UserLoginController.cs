using Microsoft.AspNetCore.Mvc;
using PyrixMan.Helpers.Interface;

namespace PyrixMan.Controllers;

[ApiController]
[Route("[controller]")]
public class UserLoginController : ControllerBase
{
    public UserLoginController(IJwtTokenGenerator jwtTokenGenerator)
    {

    }

}