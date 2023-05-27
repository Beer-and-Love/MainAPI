using Service.DTO;

namespace Service.Interfaces
{
    public interface ILocalizationService
    {
        Task<List<LocalizationDto>> Get();

    }
}