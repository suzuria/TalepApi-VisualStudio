using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationKod.Models
{
    public partial class Kullanici
    {
        public Kullanici()
        {
            Gonderi = new HashSet<Gonderi>();
        }

        public int UserId { get; set; }
        public string Eposta { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string BirimKod { get; set; }
        public string RolKodu { get; set; }

        public virtual Birim BirimKodNavigation { get; set; }
        public virtual Rol RolKoduNavigation { get; set; }
        public virtual ICollection<Gonderi> Gonderi { get; set; }
    }
}
