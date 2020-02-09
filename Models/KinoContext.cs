using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KinoDotNetCore.Models
{
    public partial class KinoContext : DbContext
    {
        public KinoContext()
        {
        }

        public KinoContext(DbContextOptions<KinoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bilety> Bilety { get; set; }
        public virtual DbSet<Filmy> Filmy { get; set; }
        public virtual DbSet<Format> Format { get; set; }
        public virtual DbSet<Gatunki> Gatunki { get; set; }
        public virtual DbSet<Klienci> Klienci { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<OgraniczeniaWiekowe> OgraniczeniaWiekowe { get; set; }
        public virtual DbSet<Opinie> Opinie { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<Repertuar> Repertuar { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Seanse> Seanse { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bilety>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Bilety_id");

                entity.HasIndex(e => e.KlientId)
                    .HasName("Bilety_Klient_id");

                entity.HasIndex(e => e.SeansId)
                    .HasName("Bilety_Seans_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KlientId).HasColumnName("Klient_id");

                entity.Property(e => e.SeansId).HasColumnName("Seans_id");

                entity.Property(e => e.StanBiletu)
                    .IsRequired()
                    .HasColumnName("stan_biletu")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Bilety)
                    .HasForeignKey(d => d.KlientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBilety296476");

                entity.HasOne(d => d.Seans)
                    .WithMany(p => p.Bilety)
                    .HasForeignKey(d => d.SeansId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBilety407188");
            });

            modelBuilder.Entity<Filmy>(entity =>
            {
                entity.HasIndex(e => e.GatunekId)
                    .HasName("Filmy_Gatunek_id");

                entity.HasIndex(e => e.Id)
                    .HasName("Filmy_id");

                entity.HasIndex(e => e.OgraniczenieId)
                    .HasName("Filmy_Ograniczenie_id");

                entity.HasIndex(e => e.Tytul)
                    .HasName("Filmy_tytul");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GatunekId).HasColumnName("Gatunek_id");

                entity.Property(e => e.OgraniczenieId).HasColumnName("Ograniczenie_id");

                entity.Property(e => e.Rezyser)
                    .IsRequired()
                    .HasColumnName("rezyser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RokProdukcji).HasColumnName("rok_produkcji");

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasColumnName("tytul")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gatunek)
                    .WithMany(p => p.Filmy)
                    .HasForeignKey(d => d.GatunekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFilmy957100");

                entity.HasOne(d => d.Ograniczenie)
                    .WithMany(p => p.Filmy)
                    .HasForeignKey(d => d.OgraniczenieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKFilmy281684");
            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Format_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Format1)
                    .IsRequired()
                    .HasColumnName("format")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Gatunki>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Gatunki_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NazwaGatunku)
                    .IsRequired()
                    .HasColumnName("nazwa_gatunku")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasIndex(e => e.AdresEmail)
                    .HasName("Klienci_adres_email");

                entity.HasIndex(e => e.Id)
                    .HasName("Klienci_id");

                entity.HasIndex(e => e.Nazwisko)
                    .HasName("Klienci_nazwisko");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdresEmail)
                    .IsRequired()
                    .HasColumnName("adres_email")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("data_urodzenia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasColumnName("haslo")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("klient");

                entity.Property(e => e.Dzien)
                    .HasColumnName("dzien")
                    .HasColumnType("datetime");

                entity.Property(e => e.Godzina)
                    .HasColumnName("godzina")
                    .HasColumnType("datetime");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StanBiletu)
                    .IsRequired()
                    .HasColumnName("stan_biletu")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasColumnName("tytul")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OgraniczeniaWiekowe>(entity =>
            {
                entity.ToTable("Ograniczenia_wiekowe");

                entity.HasIndex(e => e.Id)
                    .HasName("Ograniczenia_wiekowe_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MinWiek).HasColumnName("min_wiek");
            });

            modelBuilder.Entity<Opinie>(entity =>
            {
                entity.HasIndex(e => e.FilmId)
                    .HasName("Opinie_Film_id");

                entity.HasIndex(e => e.Id)
                    .HasName("Opinie_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FilmId).HasColumnName("Film_id");

                entity.Property(e => e.Ocena).HasColumnName("ocena");

                entity.Property(e => e.TrescOpinii)
                    .IsRequired()
                    .HasColumnName("tresc_opinii")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Opinie)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKOpinie817552");
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Pracownicy_id");

                entity.HasIndex(e => e.Nazwisko)
                    .HasName("Pracownicy_nazwisko");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Admin)
                    .IsRequired()
                    .HasColumnName("admin")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DataUrodzenia)
                    .HasColumnName("data_urodzenia")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataZatrudnienia)
                    .HasColumnName("data_zatrudnienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasColumnName("haslo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Repertuar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("repertuar");

                entity.Property(e => e.DolbyAtmos)
                    .IsRequired()
                    .HasColumnName("Dolby Atmos")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Godzina)
                    .HasColumnName("godzina")
                    .HasColumnType("datetime");

                entity.Property(e => e.MinWiek).HasColumnName("min_wiek");

                entity.Property(e => e.Rezyser)
                    .IsRequired()
                    .HasColumnName("rezyser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasColumnName("tytul")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e._3d)
                    .IsRequired()
                    .HasColumnName("3D")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.FormatId)
                    .HasName("Sale_Format_id");

                entity.HasIndex(e => e.Id)
                    .HasName("Sale_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormatId).HasColumnName("Format_id");

                entity.Property(e => e.Has3D)
                    .IsRequired()
                    .HasColumnName("has3D")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HasDolbyAtmos)
                    .IsRequired()
                    .HasColumnName("has_dolby_atmos")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IloscDostMiejsc).HasColumnName("Ilosc_dost_miejsc");

                entity.Property(e => e.IloscMiejsc).HasColumnName("Ilosc_miejsc");

                entity.HasOne(d => d.Format)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.FormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSale201725");
            });

            modelBuilder.Entity<Seanse>(entity =>
            {
                entity.HasIndex(e => e.FilmyId)
                    .HasName("Seanse_Filmy_id");

                entity.HasIndex(e => e.Id)
                    .HasName("Seanse_id");

                entity.HasIndex(e => e.SaleId)
                    .HasName("Seanse_Sale_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dzien)
                    .HasColumnName("dzien")
                    .HasColumnType("datetime");

                entity.Property(e => e.FilmyId).HasColumnName("Filmy_id");

                entity.Property(e => e.Godzina)
                    .HasColumnName("godzina")
                    .HasColumnType("datetime");

                entity.Property(e => e.SaleId).HasColumnName("Sale_id");

                entity.HasOne(d => d.Filmy)
                    .WithMany(p => p.Seanse)
                    .HasForeignKey(d => d.FilmyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSeanse970619");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.Seanse)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKSeanse334290");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
