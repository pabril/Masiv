using CORE.Api.Models;
using CORE.Api.Services;

namespace CORE.Api.Repositories
{
    public class Repository : IRepository
    {
        private readonly ICacheService<Bet> _betCache;
        private readonly ICacheService<Roulette> _rouletteCache;

        private IRouletteRepository _rouletteRepository;
        private IBetRepository _betRepository;

        public Repository(ICacheService<Bet> betCache, ICacheService<Roulette> rouletteCache)
        {
            _betCache = betCache;
            _rouletteCache = rouletteCache;
        }

        public IRouletteRepository RouletteRepository
        {
            get { return _rouletteRepository ??= new RouletteRepository(_rouletteCache); }
        }

        public IBetRepository BetRepository
        {
            get { return _betRepository ??= new BetRepository(_betCache); }
        }
    }
}
