using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFuncionario;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleDeCinema.Infra.Orm.Compartilhado;

public class ControleDeCinemaDbContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }

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
            funcionarioBuilder.ToTable("TB Funcionario");

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

        base.OnModelCreating(modelBuilder);
    }
}

