using Service.DTO;

namespace Service.Interfaces
{
    public interface ILocalizationService
    {
        Task<List<LocalizationDto>> Get();
        Task<LocalizationDto> UpdateUserLocalization(long id, LocalizationDto localizationDto);
        Task<List<(UserDto user, double distance)>> CalculateDistance(string city, long currentUserId);
    }
}