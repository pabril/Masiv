using CORE.Api.Models;
using CORE.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CORE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteRepository _rouletteRepository;
        private readonly IBetRepository _betRepository;

        public RouletteController(IRouletteRepository rouletteRepository, IBetRepository betRepository)
        {
            _rouletteRepository = rouletteRepository;
            _betRepository = betRepository;
        }
        /// <summary>
        /// Roulette Create
        /// </summary>
        /// <returns>Roulette</returns>
        [HttpPost]
        public IActionResult Create()
        {
            var roulette = _rouletteRepository.Create();
            return Ok(roulette);
        }
        /// <summary>
        /// Roulette Open
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("open/{id}")]
        public IActionResult OPen([FromRoute(Name = "id")] string id)
        {
            var roulette = _rouletteRepository.Read(id);

            roulette.Open = true;
            roulette.OpenDate = DateTime.UtcNow;

            var rouletteOpen = _rouletteRepository.Update(id, roulette);

            return Ok(rouletteOpen.Open);
        }
        /// <summary>
        /// Bet
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="betRequest"></param>
        /// <returns>bool</returns>
        [HttpPost("bet")]
        public IActionResult Bet([FromHeader(Name = "userId")] string userId, [FromBody] BetRequest betRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var roulette = _rouletteRepository.Read(betRequest.RouletteId);
            if (!roulette.Open)
            {
                return BadRequest();
            }
            var bet = new Bet
            {
                UserId = userId,
                RouletteId = roulette.Id,
                BetAmount = betRequest.BetAmount,
                BetNumber = betRequest.BetNumber,
                CreateDate = DateTime.UtcNow
            };
            var betCreate = _betRepository.Create(bet);
            return Ok(betCreate);
        }
        /// <summary>
        /// Roulette Close
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Bets</returns>
        [HttpPut("close/{id}")]
        public IActionResult Close([FromRoute(Name = "id")] string id)
        {
            List<Bet> bets = null;
            var roulette = _rouletteRepository.Read(id);
            if (roulette.Open == true)
            {
                roulette.Open = false;
                roulette.CloseDate = DateTime.UtcNow;
                var rouletteOpen = _rouletteRepository.Update(id, roulette);
                bets = _betRepository.Read().Where(b => b.RouletteId == roulette.Id).ToList();
            }
            return Ok(bets);
        }
        /// <summary>
        /// Roulette List
        /// </summary>
        /// <returns>Roulettes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var roulette = _rouletteRepository.Read();
            return Ok(roulette);
        }
    }
}
