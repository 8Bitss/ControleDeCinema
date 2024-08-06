using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.ModuloFilme;

public class RepositorioFilmeEmOrm : RepositorioBaseEmOrm<Filme>, IRepositorioFilme
{
    public RepositorioFilmeEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
    {

    }

    protected override DbSet<Filme> ObterRegistros()
    {
        return dbContext.Filmes;
    }
}

