namespace hakaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezervacija")]
    public partial class Rezervacija
    {
        public int ID { get; set; }

        public int? Clan_ID { get; set; }

        public int? Knjiga_ID { get; set; }

        [StringLength(50)]
        public string Datum { get; set; }

        public virtual Clan Clan { get; set; }

        public virtual Knjiga Knjiga { get; set; }
    }
}
