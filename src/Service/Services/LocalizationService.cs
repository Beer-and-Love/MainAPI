using Service.Interfaces;
using Service.DTO;
using Domain.Exceptions;
using AutoMapper;
using Infra.Interfaces;
using Domain.Entities;

namespace Service.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly IMapper _mapper;
        private readonly ILocalizationRepository _localizationRepository;
        private readonly IUserRepository _userRepository;
        private LocalizationDto _currentUserLocalization;


        public LocalizationService(IMapper mapper, ILocalizationRepository localizationRepository,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _localizationRepository = localizationRepository;
            _userRepository = userRepository;
        }
        public async Task<List<LocalizationDto>> Get()
        {
            var allLocalizations = await _localizationRepository.Get();

            return _mapper.Map<List<LocalizationDto>>(allLocalizations);
        }

    }
}
