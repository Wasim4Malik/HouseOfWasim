﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;

            public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(UserRegistrationModel model)
            {
                var user = new User { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded) return Ok();
                return BadRequest(result.Errors);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(UserLoginModel model)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                if (result.Succeeded) return Ok();
                return Unauthorized();
            }
        
    }
}
