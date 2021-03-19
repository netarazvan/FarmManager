using System;
using System.Collections.Generic;

#nullable disable

namespace FarmManager.Models
{
    public partial class Utilaje
    {
        public Utilaje()
        {
            Defectiunis = new HashSet<Defectiuni>();
        }

        public decimal Id { get; set; }
        public string Tip { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public int An { get; set; }

        public string FullDen
        {
            get { return Marca + " " + Model; }
        }

        public virtual ICollection<Defectiuni> Defectiunis { get; set; }
    }
}