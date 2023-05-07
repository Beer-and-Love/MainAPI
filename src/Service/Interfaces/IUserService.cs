using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTO;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> Create(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task Remove(long id);
        Task<UserDto> Get(long id);
        Task<List<UserDto>> Get();

        Task<UserDto> GetByEmail(string email);
        Task<List<UserDto>> SearchByEmail(string email);
        Task<List<UserDto>> SearchByName(string name);
    }
}