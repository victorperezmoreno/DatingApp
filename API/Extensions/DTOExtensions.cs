using System.Linq;
using API.DTOs;
using API.Entities;

namespace API.Extensions
{
  public static class DTOExtensions
  {
    public static MemberDto ToMemberDTOMap(this AppUser user)
    {
      return new MemberDto(
        user.Id, user.UserName,
        user.Photos.FirstOrDefault(p => p.IsMain == true).Url,
        user.DateOfBirth.CalculateAge(),
        user.KnownAs,
        user.Created,
        user.LastActive,
        user.Gender,
        user.Introduction,
        user.LookingFor,
        user.Interests,
        user.City,
        user.Country,
        user.Photos.Select(p => p.ToPhotoDTOMap()).ToList());
    }

    public static PhotoDto ToPhotoDTOMap(this Photo p)
    {
      return new PhotoDto(p.Id, p.Url, p.IsMain);
    }
  }
}