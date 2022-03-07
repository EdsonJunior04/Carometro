using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FaceCheck.webAPI.Domains;

#nullable disable

namespace FaceCheck.webAPI.Context
{
    public partial class CarometroContext : DbContext
    {
        public CarometroContext()
        {
        }

        public CarometroContext(DbContextOptions<CarometroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113E4\\SQLEXPRESS; Initial Catalog=FACE_CHECK; user id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAlunos)
                    .HasName("PK__ALUNOS__6089F3CC879B5CD0");

                entity.ToTable("ALUNOS");

                entity.Property(e => e.IdAlunos).HasColumnName("idAlunos");

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("datetime")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("imagem");

                entity.Property(e => e.NomeAluno)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeAluno");

                entity.Property(e => e.Ra)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("RA")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__ALUNOS__idSala__440B1D61");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodo)
                    .HasName("PK__PERIODOS__90A7D3D8951D27A6");

                entity.ToTable("PERIODOS");

                entity.HasIndex(e => e.NomePeriodo, "UQ__PERIODOS__1E82E37C773B1D41")
                    .IsUnique();

                entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

                entity.Property(e => e.NomePeriodo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nomePeriodo");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__SALAS__C4AEB19CF78DB41A");

                entity.ToTable("SALAS");

                entity.HasIndex(e => e.NomeSala, "UQ__SALAS__53BE9CC8BB9DA7EA")
                    .IsUnique();

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.IdPeriodo).HasColumnName("idPeriodo");

                entity.Property(e => e.NomeSala)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("nomeSala");

                entity.HasOne(d => d.IdPeriodoNavigation)
                    .WithMany(p => p.Salas)
                    .HasForeignKey(d => d.IdPeriodo)
                    .HasConstraintName("FK__SALAS__idPeriodo__412EB0B6");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoU)
                    .HasName("PK__TIPOUSUA__CD5FEBAC5122A840");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoU, "UQ__TIPOUSUA__8389AE8D49136936")
                    .IsUnique();

                entity.Property(e => e.IdTipoU)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoU");

                entity.Property(e => e.NomeTipoU)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoU");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A6CD70A497");

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoU).HasColumnName("idTipoU");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoU)
                    .HasConstraintName("FK__USUARIO__idTipoU__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
