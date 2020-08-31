using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CORE.Api.Models
{
    [Serializable]
    public class Roulette
    {
        public string Id { get; set; }
        
        public bool Open { get; set; }
        
        public DateTime? OpenDate { get; set; }
        
        public DateTime? CloseDate { get; set; }
        
        public DateTime CreateDate { get; set; }
    }
}
