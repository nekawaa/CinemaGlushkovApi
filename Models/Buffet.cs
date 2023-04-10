
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaGlushkovApi.Models
{
    public partial class Buffet
    {
        public Buffet()
        {
            Orders = new HashSet<Order>();
        }

        public int IdProduct { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
