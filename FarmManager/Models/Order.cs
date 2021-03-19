using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Order
    {
        public decimal Id { get; set; }
        public decimal IdClient { get; set; }
        public decimal IdProdus { get; set; }
        public decimal Cantitate { get; set; }
        public bool Ridicat { get; set; }

        public decimal Valoare
        {
            get { return Convert.ToDecimal(IdProdusNavigation.PretKg * Cantitate); }
        }

        public virtual Clienti IdClientNavigation { get; set; }
        public virtual Produse IdProdusNavigation { get; set; }
    }
}