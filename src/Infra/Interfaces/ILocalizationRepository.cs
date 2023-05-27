using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infra.Interfaces
{
    public interface ILocalizationRepository : IBaseRepository<Localization>
    {
        Task<List<Localization>> SearchByCity(string city);
    }
}