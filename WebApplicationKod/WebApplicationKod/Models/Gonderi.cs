using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationKod.Models
{
    public partial class Gonderi
    {
        public int UserId { get; set; }
        public string GonderiNo { get; set; }
        public DateTime Tarih { get; set; }
        public string Talep { get; set; }

        public virtual Kullanici User { get; set; }
    }
}
