
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaGlushkovApi.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Orders = new HashSet<Order>();
        }

        public int IdTicket { get; set; }
        public int IdMovie { get; set; }
        public TimeSpan? Time { get; set; }
        public decimal? Price { get; set; }

        public virtual Movie IdMovieNavigation { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
