
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CinemaGlushkovApi.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }

        public int IdEmployee { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeePost { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
