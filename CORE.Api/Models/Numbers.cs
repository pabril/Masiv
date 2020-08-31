using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CORE.Api.Models
{
    [Serializable]
    public class Numbers
    {
        [Range(0, 38)]
        public int Id { get; set; }
        
        public string BetColor { get; set; }
        
        public List<Numbers> GetBetNumbers()
        {
            List<Numbers> numbers = new List<Numbers>
            {
                new Numbers { Id = 0, BetColor = "Black" },
                new Numbers { Id = 1, BetColor = "Red" },
                new Numbers { Id = 2, BetColor = "Black" },
                new Numbers { Id = 3, BetColor = "Black" },
                new Numbers { Id = 4, BetColor = "Red" },
                new Numbers { Id = 5, BetColor = "Red" },
                new Numbers { Id = 6, BetColor = "Red" },
                new Numbers { Id = 7, BetColor = "Black" },
                new Numbers { Id = 8, BetColor = "Red" },
                new Numbers { Id = 9, BetColor = "Red" },
                new Numbers { Id = 10, BetColor = "Red" },
                new Numbers { Id = 11, BetColor = "Red" },
                new Numbers { Id = 12, BetColor = "Black" },
                new Numbers { Id = 13, BetColor = "Black" },
                new Numbers { Id = 14, BetColor = "Red" },
                new Numbers { Id = 15, BetColor = "Red" },
                new Numbers { Id = 16, BetColor = "Red" },
                new Numbers { Id = 17, BetColor = "Black" },
                new Numbers { Id = 18, BetColor = "Black" },
                new Numbers { Id = 19, BetColor = "Red" },
                new Numbers { Id = 20, BetColor = "Black" },
                new Numbers { Id = 21, BetColor = "Red" },
                new Numbers { Id = 22, BetColor = "Black" },
                new Numbers { Id = 23, BetColor = "Red" },
                new Numbers { Id = 24, BetColor = "Black" },
                new Numbers { Id = 25, BetColor = "Black" },
                new Numbers { Id = 26, BetColor = "Black" },
                new Numbers { Id = 27, BetColor = "Black" },
                new Numbers { Id = 28, BetColor = "Red" },
                new Numbers { Id = 29, BetColor = "Black" },
                new Numbers { Id = 30, BetColor = "Black" },
                new Numbers { Id = 31, BetColor = "Black" },
                new Numbers { Id = 32, BetColor = "Black" },
                new Numbers { Id = 33, BetColor = "Red" },
                new Numbers { Id = 34, BetColor = "Red" },
                new Numbers { Id = 35, BetColor = "Black" },
                new Numbers { Id = 36, BetColor = "Red" },
                new Numbers { Id = 37, BetColor = "Red" },
                new Numbers { Id = 38, BetColor = "Black" }
            };
            return numbers;
        }
    }
}
