using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaGlushkovApi.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdMovie { get; set; }
        public string? MovieName { get; set; }
        public string? MovieLenght { get; set; }
        public string? FilmCompany { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
