using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Clienti
    {
        public Clienti()
        {
            Orders = new HashSet<Order>();
        }

        public decimal Id { get; set; }
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public decimal? SuprafataHa { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
