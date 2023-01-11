using StarWars.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Domain.Services
{
    public interface IPlanetService : IDisposable
    {
        Task<Planet?> Get(int id);
        Task<IEnumerable<Planet>> GetAll();
        Task<Planet?> FindByName(string name);
        Task Remove(int id);
    }
}
