namespace hakaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clan")]
    public partial class Clan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clan()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Ime { get; set; }

        [StringLength(50)]
        public string Prezime { get; set; }

        [StringLength(50)]
        public string Datum_Rodjenja { get; set; }

        [StringLength(50)]
        public string Adresa { get; set; }

        [StringLength(50)]
        public string Broj_telefona { get; set; }

        [StringLength(50)]
        public string Datum_obnove_clanstva { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? UlogaID { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        public int? KnjigaID { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
