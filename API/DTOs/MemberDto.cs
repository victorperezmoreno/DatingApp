using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
  public class MemberDto
  {
    public MemberDto()
    {

    }

    public MemberDto(int id, string userName, string photoUrl, int age, string knownAs, DateTime created, DateTime lastActive, string gender, string introduction, string lookingFor, string interests, string city, string country, List<PhotoDto> photos)
    {
      Id = id;
      UserName = userName;
      PhotoUrl = photoUrl;
      Age = age;
      KnownAs = knownAs;
      Created = created;
      LastActive = lastActive;
      Gender = gender;
      Introduction = introduction;
      LookingFor = lookingFor;
      Interests = interests;
      City = city;
      Country = country;
      Photos = photos;
    }

    public int Id { get; set; }
    public string UserName { get; set; }
    public string PhotoUrl { get; set; }
    public int Age { get; set; }
    public string KnownAs { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastActive { get; set; }
    public string Gender { get; set; }
    public string Introduction { get; set; }
    public string LookingFor { get; set; }
    public string Interests { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public List<PhotoDto> Photos { get; set; } = new();
  }
}