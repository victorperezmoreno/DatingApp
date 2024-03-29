using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<MemberDto> GetMemberAsync(string userName)
    {
       return await _context.Users.Include(u => u.Photos).Where(usr => usr.UserName == userName).Select(user => user.ToMemberDTOMap()).FirstOrDefaultAsync();
    } 

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
      return await _context.Users.Include(u => u.Photos).Select(usr => usr.ToMemberDTOMap()).ToListAsync();
    }

    public async Task<AppUser> GetUserbyId(int id)
    {
      return await _context.Users.FindAsync(id);
    }

    public async Task<AppUser> GetUserByUsernameAsync(string userName)
    {
      return await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
      return await _context.Users.Include(p => p.Photos).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
     _context.Entry(user).State = EntityState.Modified;
    }
  }
}