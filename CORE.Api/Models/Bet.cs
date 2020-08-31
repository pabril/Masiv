using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.Api.Models
{
    [Serializable]
    public class Bet
    {
        public string Id { get; set; }

        public string RouletteId { get; set; }

        public string UserId { get; set; }

        [Range(0, 38)]
        public int BetNumber { get; set; }

        [Range(minimum: 1, maximum: 10000)]
        public int BetAmount { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
