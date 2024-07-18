using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AccountBusiness _accountBusiness;
    public AuthenticationController()
    {
        _accountBusiness = new AccountBusiness();
    }

    [HttpPost(ApiEndPointConstant.Authentication.LoginEndpoint)]
    [SwaggerOperation(Summary = "Login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var response = await _accountBusiness.Login(email, password);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [HttpPost(ApiEndPointConstant.Authentication.RegisterEndpoint)]
    [SwaggerOperation(Summary = "Register")]
    public async Task<IActionResult> Register(string email, string password)
    {
        var response = await _accountBusiness.Register(email, password);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }
}
