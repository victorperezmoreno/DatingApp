using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseAPIController
    {
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context, ITokenService tokenService)
    {
      _tokenService = tokenService;
      _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>>Register(RegisterDTO registerDTO)
    {
        if (await UserExists(registerDTO.UserName) == true) return BadRequest("Username is already taken");

        using var hmac = new HMACSHA512();
        var user = new AppUser(registerDTO.UserName.ToLower(), hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)), hmac.Key);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new UserDTO(user.UserName, _tokenService.CreateToken(user));
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>>Login(LoginDTO login)
    {
     var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == login.UserName);
     if (user == null) return Unauthorized("Invalid username");
     using var hmac = new HMACSHA512(user.PasswordSalt);
     var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
     for (int i = 0; i < computedHash.Length; i++)
     {
        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
     }

     return new UserDTO(user.UserName, _tokenService.CreateToken(user));
     }

    private async Task<bool> UserExists(string userName)
    {
        return await _context.Users.AnyAsync(u => u.UserName == userName.ToLower());
    }

    }
}