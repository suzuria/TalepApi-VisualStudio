using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationKod.Models
{
    public partial class Birim
    {
        public Birim()
        {
            Kullanici = new HashSet<Kullanici>();
        }

        public string BirimKodu { get; set; }
        public string BirimAd { get; set; }

        public virtual ICollection<Kullanici> Kullanici { get; set; }
    }
}
