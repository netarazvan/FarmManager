using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Cereale
    {
        public decimal Id { get; set; }
        public decimal IdProdus { get; set; }
        public decimal CantitateTone { get; set; }

        public virtual Produse IdProdusNavigation { get; set; }
    }
}
