namespace hakaton.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Knjiga")]
    public partial class Knjiga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Knjiga()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Naziv { get; set; }

        [StringLength(50)]
        public string Autor { get; set; }

        public int? Godina_izdanja { get; set; }

        public bool Dostupnost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
