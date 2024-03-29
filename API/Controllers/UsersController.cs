using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class UsersController : BaseAPIController
    {
        private readonly ILogger<UsersController> _logger;
    private readonly IUserRepository _userRepository;

    public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
    {
      _logger = logger;
      _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() 
    {
     return Ok(await _userRepository.GetMembersAsync());
    } 

    //api/users/2 or 3
    [Authorize]
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
      return await _userRepository.GetMemberAsync(username);
    } 
  }
}