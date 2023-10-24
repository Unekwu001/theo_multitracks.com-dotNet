using System;
using System.Collections.Generic;
using API_with_EntityFramework.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_with_EntityFramework.Data.MyMultitrackDbContext;

public partial class MultitrackDbContext : DbContext
{
    public MultitrackDbContext()
    {
    }

    public MultitrackDbContext(DbContextOptions<MultitrackDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<AssessmentStep> AssessmentSteps { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=THEO\\SQLEXPRESS;database=oldMultitrackDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PK__Album__75BF3EEF4FE6B4CA");

            entity.ToTable("Album");

            entity.Property(e => e.AlbumId).HasColumnName("albumID");
            entity.Property(e => e.ArtistId).HasColumnName("artistID");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("dateCreation");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artist__4F4393676BFF91FA");

            entity.ToTable("Artist");

            entity.Property(e => e.ArtistId).HasColumnName("artistID");
            entity.Property(e => e.Biography)
                .IsUnicode(false)
                .HasColumnName("biography");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("dateCreation");
            entity.Property(e => e.HeroUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("heroURL");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<AssessmentStep>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PK__Assessme__4E25C23DF5D721CE");

            entity.Property(e => e.StepId).HasColumnName("stepID");
            entity.Property(e => e.Text)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("text");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Song__0364D6AD6D565221");

            entity.ToTable("Song");

            entity.Property(e => e.SongId).HasColumnName("songID");
            entity.Property(e => e.AlbumId).HasColumnName("albumID");
            entity.Property(e => e.ArtistId).HasColumnName("artistID");
            entity.Property(e => e.Bpm)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("bpm");
            entity.Property(e => e.Chart).HasColumnName("chart");
            entity.Property(e => e.CustomMix).HasColumnName("customMix");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("dateCreation");
            entity.Property(e => e.Multitracks).HasColumnName("multitracks");
            entity.Property(e => e.Patches).HasColumnName("patches");
            entity.Property(e => e.ProPresenter).HasColumnName("proPresenter");
            entity.Property(e => e.RehearsalMix).HasColumnName("rehearsalMix");
            entity.Property(e => e.SongSpecificPatches).HasColumnName("songSpecificPatches");
            entity.Property(e => e.TimeSignature)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("timeSignature");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
