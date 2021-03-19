using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Inputuri
    {
        public decimal Id { get; set; }
        public string Tip { get; set; }
        public string Producator { get; set; }
        public string UnitateDeMasura { get; set; }
        public decimal CantitateUm { get; set; }
        public decimal PretUm { get; set; }
    }
}
