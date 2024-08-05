using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.ModuloSala;

public class RepositorioSalaEmOrm : RepositorioBaseEmOrm<Sala>, IRepositorioSala
{
    public RepositorioSalaEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
    {
        
    }

    public void Inserir(Sala registro, List<Poltrona> poltronas)
    {
        ObterRegistros().Add(registro);
        registro.Poltronas = poltronas;

        dbContext.SaveChanges();
    }

    protected override DbSet<Sala> ObterRegistros()
    {
        return dbContext.Salas;
    }
}