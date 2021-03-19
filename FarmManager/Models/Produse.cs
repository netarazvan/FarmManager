using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Produse
    {
        public Produse()
        {
            Cereales = new HashSet<Cereale>();
            Orders = new HashSet<Order>();
        }

        public decimal Id { get; set; }
        public string Produs { get; set; }
        public decimal? PretKg { get; set; }

        public virtual ICollection<Cereale> Cereales { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
