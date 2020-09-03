using CORE.Api.Models;
using CORE.Api.Services;
using System;
using System.Collections.Generic;

namespace CORE.Api.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private readonly ICacheService<Roulette> _cacheService;
        private readonly string cacheKey = "Roulette";
        public RouletteRepository(ICacheService<Roulette> cacheService)
        {
            _cacheService = cacheService;
        }
        public Roulette Create()
        {
            var id = Guid.NewGuid().ToString();
            Roulette roulette = new Roulette
            {
                Id = id,
                Open = false,
                CreateDate = DateTime.UtcNow
            };
            _cacheService.SetCacheService(cacheKey, id, roulette);
            return roulette;
        }
        public Roulette Read(string id)
        {
            var rouletteId = $"{cacheKey}{id}";
            var roulette = _cacheService.GetCacheService(rouletteId);
            return roulette;
        }
        public List<Roulette> Read()
        {
            var roulettes = _cacheService.GetAllCacheService(cacheKey);
            return roulettes;
        }
        public Roulette Update(string id, Roulette roulette)
        {
            _cacheService.SetCacheService(cacheKey, id, roulette);
            return roulette;
        }
        public Roulette Delete(string id, Roulette roulette)
        {
            throw new NotImplementedException();
        }
    }
}
