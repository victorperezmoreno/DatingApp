using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserbyId(int id);
        Task<AppUser> GetUserByUsernameAsync(string userName);
        Task<MemberDto> GetMemberAsync(string userName);
        Task<IEnumerable<MemberDto>> GetMembersAsync();
    }
}