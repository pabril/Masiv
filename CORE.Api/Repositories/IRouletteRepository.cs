using CORE.Api.Models;
using System.Collections.Generic;

namespace CORE.Api.Repositories
{
    public interface IRouletteRepository
    {
        Roulette Create();
        Roulette Read(string id);
        List<Roulette> Read();
        Roulette Update(string id, Roulette bet);
        Roulette Delete(string id, Roulette bet);
    }
}
