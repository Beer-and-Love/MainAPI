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
        private const double EarthRadiusKm = 6371.0;
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

        public async Task<LocalizationDto> UpdateUserLocalization(long id, LocalizationDto localizationDto)
        {
            var user = await _userRepository.Get(id);

            if (user == null)
                throw new DomainException("Não existe nenhum usuário cadastrado com esse Id");

            user.Localization = _mapper.Map<Localization>(localizationDto);
            user.Localization.Validate();

            var userUpdated = await _userRepository.Update(user);

            var localizationUpdated = _mapper.Map<LocalizationDto>(userUpdated.Localization);
            return localizationUpdated;
        }

        public async Task<List<(UserDto user, double distance)>> CalculateDistance(string city, long currentUserId)
        {

            var usersByCity = await _userRepository.SearchByCity(city);

            var currentUser = await _userRepository.Get(currentUserId);
            var currentUserLocalization = _mapper.Map<LocalizationDto>(currentUser.Localization);

            List<(UserDto user, double distance)> distances = new List<(UserDto user, double distance)>();


            foreach (var user in usersByCity)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var userLocalization = _mapper.Map<LocalizationDto>(user.Localization);
                double distance = CalculateDistanceBetweenLocations(currentUserLocalization, userLocalization);

                distances.Add((userDto, distance));
            }

            return distances;

        }
        private double CalculateDistanceBetweenLocations(LocalizationDto location1, LocalizationDto location2)
        {
            double latitude1 = DegreeToRadian(location1.Latitude);
            double longitude1 = DegreeToRadian(location1.Longitude);
            double latitude2 = DegreeToRadian(location2.Latitude);
            double longitude2 = DegreeToRadian(location2.Longitude);

            double deltaLatitude = latitude2 - latitude1;
            double deltaLongitude = longitude2 - longitude1;

            double a = Math.Pow(Math.Sin(deltaLatitude / 2), 2) +
                       Math.Cos(latitude1) * Math.Cos(latitude2) *
                       Math.Pow(Math.Sin(deltaLongitude / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = EarthRadiusKm * c;

            return distance;
        }

        private double DegreeToRadian(double degree)
        {
            return degree * Math.PI / 180.0;
        }
    }
}