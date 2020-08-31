using CORE.Api.Models;
using CORE.Api.Services;
using CORE.Commons.Tools;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace CORE.Api.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly ICacheService<Bet> _cacheService;
        private readonly string cacheKey = "Bet";
        public BetRepository(ICacheService<Bet> cacheService)
        {
            _cacheService = cacheService;
        }

        public Bet Create(Bet bet)
        {
            var id = Guid.NewGuid().ToString();
            bet.Id = id;
            bet.CreateDate = DateTime.UtcNow;
            _cacheService.SetCacheService(cacheKey, id, bet);
            return bet;
        }
        public Bet Read(string id)
        {
            var betId = $"{cacheKey}{id}";
            var bet = _cacheService.GetCacheService(betId);
            return bet;
        }
        public List<Bet> Read()
        {
            var bets = _cacheService.GetAllCacheService(cacheKey);
            return bets;
        }
        public Bet Update(string id, Bet bet)
        {
            return null;
        }
        public Bet Delete(string id, Bet bet)
        {
            throw new NotImplementedException();
        }
    }
}
