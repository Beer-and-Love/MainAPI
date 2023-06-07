using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;

namespace Infra.Repositories
{
    public class LocalizationRepository : BaseRepository<Localization>, ILocalizationRepository
    {
        private readonly ApiContext _context;
        public LocalizationRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

    }
}