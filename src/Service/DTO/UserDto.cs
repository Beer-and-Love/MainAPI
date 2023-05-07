using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enuns;

namespace Service.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }

        public Status Status { get;  set; }

        public UserDto()
        {}
        public UserDto(long id, string name, string email, string password, Status status)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Status = status;

        }
    }
}