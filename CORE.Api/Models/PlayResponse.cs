using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE.Api.Models
{
    public class PlayResponse
    {
        public PlayRequest PlayRequest{ get; set; }
        
        public Roulette Roulette { get; set; }

        public List<Bet> Winners { get; set; }

        public List<Bet> Losers { get; set; }

    }
}
