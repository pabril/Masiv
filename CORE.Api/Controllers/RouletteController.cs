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
        private readonly IRepository _repository;

        public RouletteController(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Roulette Create
        /// </summary>
        /// <returns>Roulette</returns>
        [HttpPost]
        public IActionResult Create()
        {
            var roulette = _repository.RouletteRepository.Create();
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
            var roulette = _repository.RouletteRepository.Read(id);

            roulette.Open = true;
            roulette.OpenDate = DateTime.UtcNow;

            var rouletteOpen = _repository.RouletteRepository.Update(id, roulette);

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
            var roulette = _repository.RouletteRepository.Read(betRequest.RouletteId);
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
            var betCreate = _repository.BetRepository.Create(bet);
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
            var roulette = _repository.RouletteRepository.Read(id);
            if (roulette.Open == true)
            {
                roulette.Open = false;
                roulette.CloseDate = DateTime.UtcNow;
                var rouletteOpen = _repository.RouletteRepository.Update(id, roulette);
                bets = _repository.BetRepository.Read().Where(b => b.RouletteId == roulette.Id).ToList();
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
            var roulette = _repository.RouletteRepository.Read();
            return Ok(roulette);
        }
        /// <summary>
        /// Play Roulette
        /// </summary>
        /// <param name="playRequest"></param>
        /// <returns></returns>
        [HttpPost("playroulette")]
        public IActionResult PlayRoulette([FromBody] PlayRequest playRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var roulette = _repository.RouletteRepository.Read(playRequest.RouletteId);
            //if (roulette.Open) { return BadRequest(new { error = true, msg = "Roulette is open" }); }
            var bets = _repository.BetRepository.Read().Where(b => b.RouletteId == roulette.Id).ToList();
            PlayResponse playResponse = new PlayResponse
            {
                PlayRequest = playRequest,
                Roulette = roulette
            };
            var winn = new List<Bet> { };
            var lose = new List<Bet> { };
            bets.ForEach(delegate (Bet b)
            {
                if (playRequest.NumberId == b.BetNumber) { winn.Add(b); }
                else { lose.Add(b); }
            });
            playResponse.Winners = winn;
            playResponse.Losers = lose;
            return Ok(playResponse);
        }
    }
}
