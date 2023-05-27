using Domain.Enuns;
using Domain.Entities;

namespace Service.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public string City { get;  set; }
        public string Informations { get;  set; }
        public Localization Localization { get;  set; }
        public Status? Status { get;  set; }

        public UserDto()
        {}
        public UserDto(long id, string name, string email, string password, string city, string information,
         Status status, Localization localization)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            City = city;
            Informations = information;
            Localization = localization;
            Status = status;

        }
    }
}