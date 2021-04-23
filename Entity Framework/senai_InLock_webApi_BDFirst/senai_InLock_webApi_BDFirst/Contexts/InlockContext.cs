using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_InLock_webApi_BDFirst.Domains;

#nullable disable

// Scaffold-DbContext "Data Source=SERVIDOR; initial catalog=InLock_Games; user Id=sa; pwd=senai@132;" Microsoft.EntityFramework.Core.SqlServer -OutputDir Domains -ContextDir Contexts -Context InlockContext

namespace senai_InLock_webApi_BDFirst.Contexts
{
    public partial class InlockContext : DbContext
    {
        public InlockContext()
        {
        }

        public InlockContext(DbContextOptions<InlockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudio> Estudios { get; set; }
        public virtual DbSet<Jogo> Jogos { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MLTUQRR; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.IdEstudio)
                    .HasName("PK__Estudios__F31FDB3697EF6B6F");

                entity.Property(e => e.IdEstudio).HasColumnName("idEstudio");

                entity.Property(e => e.NomeEstudio)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeEstudio");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.HasKey(e => e.IdJogo)
                    .HasName("PK__Jogos__05C4E665FBDCBBDE");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.DataLancamento)
                    .HasColumnType("date")
                    .HasColumnName("dataLancamento");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdEstudio).HasColumnName("idEstudio");

                entity.Property(e => e.NomeJogo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("nomeJogo");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.IdEstudio)
                    .HasConstraintName("FK__Jogos__idEstudio__267ABA7A");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TiposUsu__03006BFF6891236C");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Permissao)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("permissao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A60B21053A");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__idTipo__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
