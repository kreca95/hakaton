namespace hakaton.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KnjiznicaContext : DbContext
    {
        public KnjiznicaContext()
            : base("name=KnjiznicaContext")
        {
        }

        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<Knjiga> Knjiga { get; set; }
        public virtual DbSet<Knjiznicar> Knjiznicar { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clan>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Datum_Rodjenja)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Broj_telefona)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Datum_obnove_clanstva)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Clan>()
                .HasMany(e => e.Rezervacija)
                .WithOptional(e => e.Clan)
                .HasForeignKey(e => e.Clan_ID);

            modelBuilder.Entity<Knjiga>()
                .Property(e => e.Naziv)
                .IsUnicode(false);

            modelBuilder.Entity<Knjiga>()
                .Property(e => e.Autor)
                .IsUnicode(false);

            modelBuilder.Entity<Knjiga>()
                .HasMany(e => e.Rezervacija)
                .WithOptional(e => e.Knjiga)
                .HasForeignKey(e => e.Knjiga_ID);

            modelBuilder.Entity<Knjiznicar>()
                .Property(e => e.Ime)
                .IsUnicode(false);

            modelBuilder.Entity<Knjiznicar>()
                .Property(e => e.Prezime)
                .IsUnicode(false);

            modelBuilder.Entity<Knjiznicar>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Knjiznicar>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Rezervacija>()
                .Property(e => e.Datum)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Uloga)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Clan)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.UlogaID);
        }
    }
}
