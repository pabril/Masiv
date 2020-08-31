using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.Api.Models
{
    public class BetRequest
    {
        public string RouletteId { get; set; }

        [Range(0, 38)]
        public int BetNumber { get; set; }

        [Range(minimum: 1, maximum: 10000)]
        public int BetAmount { get; set; }

    }
}
