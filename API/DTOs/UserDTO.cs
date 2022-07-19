using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDTO
    {
    public UserDTO(string userName, string token)
    {
      UserName = userName;
      Token = token;
    }

    public string UserName { get; set; }
    public string Token { get; set; }
  }
}