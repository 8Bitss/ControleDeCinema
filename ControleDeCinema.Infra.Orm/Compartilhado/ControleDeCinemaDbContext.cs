using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Dominio.ModuloSala;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado;

public class ControleDeCinemaDbContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Poltrona> Poltronas { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Filme> Filmes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString("SqlServer")!;

        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Filme>(filmeBuilder =>
        //{
        //    filmeBuilder.ToTable("TB Filme");


        //    filmeBuilder.Property(f => f.Id)
        //        .IsRequired()
        //        .ValueGeneratedOnAdd();

        //    filmeBuilder.Property(f => f.Titulo)
        //        .IsRequired()
        //        .HasColumnType("varchar (200)");

        //    filmeBuilder.Property(f => f.Duracao)
        //        .IsRequired()
        //        .HasColumnType("datetime2");

        //    filmeBuilder.Property(f => f.DataLancamento)
        //        .IsRequired()
        //        .HasColumnType("datetime2");

        //    //filmeBuilder.Property(f => f.Genero)
        //    //    .Withmany()
            
        //});

        modelBuilder.Entity<Funcionario>(funcionarioBuilder =>
        {
            funcionarioBuilder.ToTable("TBFuncionario");

            funcionarioBuilder.Property(f => f.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            funcionarioBuilder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar (200)");

            funcionarioBuilder.Property(f => f.Login)
                .IsRequired()
                .HasColumnType("varchar (200)");

            funcionarioBuilder.Property(f => f.Senha)
                .IsRequired()
                .HasColumnType("varchar (200)");
        });

        modelBuilder.Entity<Poltrona>(poltronaBuilder =>
        {
            poltronaBuilder.ToTable("TBPoltrona");

            poltronaBuilder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            poltronaBuilder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("bit");
        });

        modelBuilder.Entity<Sala>(salaBuilder =>
        {
            salaBuilder.ToTable("TBSala");

            salaBuilder.Property(s => s.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            salaBuilder.Property(s => s.Capacidade)
                .IsRequired()
                .HasColumnType("int");

            salaBuilder.Property(s => s.QtdAssentosDisponiveis)
                .IsRequired()
                .HasColumnType("int");

            salaBuilder.HasMany(s => s.Poltronas)
                .WithOne()
                .HasForeignKey("Sala_Id")
                .HasConstraintName("FK_TBSala_TBPoltrona")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Filme>(filmeBuilder =>
        {
            filmeBuilder.ToTable("TBFilme");

            filmeBuilder.Property(f => f.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            filmeBuilder.Property(f => f.Titulo)
                .IsRequired()
                .HasColumnType("varchar (200)");

            filmeBuilder.Property(f => f.Duracao)
                .IsRequired()
                .HasColumnType("datetime2");

            filmeBuilder.Property(f => f.DataLancamento)
                .IsRequired()
                .HasColumnType("datetime2");

            filmeBuilder.Property(f => f.Genero)
                .IsRequired()
                .HasConversion(
                    g => g.ToString(),
                    g => (TipoGeneroEnum)Enum.Parse(typeof(TipoGeneroEnum), g))
                .HasColumnType("nvarchar(24)");
        });

        base.OnModelCreating(modelBuilder);
    }
}
