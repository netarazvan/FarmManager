using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Defectiuni
    {
        public decimal Id { get; set; }
        public decimal IdUtilaj { get; set; }
        public string Detalii { get; set; }
        public decimal? CostReparatie { get; set; }
        public bool Reparat { get; set; }

        public virtual Utilaje IdUtilajNavigation { get; set; }
    }
}
