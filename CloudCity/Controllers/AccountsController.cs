using CloudCity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using System.Security.Claims;

namespace CloudCity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly CloudCityContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, CloudCityContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
      _db = db;
    }

    //POST api/accounts/login
    [HttpPost("login")]
    public async Task<ActionResult> Login(string username, string password)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        //TODO: give token??
        return Ok();
      }
      else
      {
        return Forbid();
      }
    }

    //POST api/accounts/register
    [HttpPost]
    public async Task<ActionResult> Post(string username, string password)
    {
      ApplicationUser user = new ApplicationUser { UserName = username };
      IdentityResult result = await _userManager.CreateAsync(user, password);
      if (result.Succeeded)
      {
        return Ok();
      }
      else
      {
        return BadRequest();
      }
    }

    private string generateJwtToken(ApplicationUser user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes("Super secret secret!");
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        Expires = DateTime.UtcNow.AddDays(1),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }

    //TODO: add routes? 
    //? GET api/accounts

    // [HttpPost]
    // public async Task<ActionResult> Register(RegisterViewModel model, string RoleName)
    // {
    //   ApplicationUser user = new ApplicationUser { UserName = model.Email };
    //   IdentityResult result = await _userManager.CreateAsync(user, model.Password);
    //   if (result.Succeeded)
    //   {
    //     await _userManager.AddToRoleAsync(user, RoleName);
    //     return RedirectToAction("Index");
    //   }
    //   else
    //   {
    //     return View();
    //   }
    // }
  }
}