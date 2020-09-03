using System;
using System.ComponentModel.DataAnnotations;

namespace CORE.Api.Models
{
    public class PlayRequest
    {
        public string RouletteId { get; set; }
        [Range(0, 38)]
        public int NumberId { get; set; }
    }
}
