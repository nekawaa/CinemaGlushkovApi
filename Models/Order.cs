
using System;
using System.Collections.Generic;

namespace CinemaGlushkovApi.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdTicket { get; set; }
        public int? IdProduct { get; set; }
        public decimal? Price { get; set; }
        public int IdEmployee { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
 
        public virtual Buffet? IdProductNavigation { get; set; }
       
        public virtual Ticket IdTicketNavigation { get; set; } = null!;
    }
}
