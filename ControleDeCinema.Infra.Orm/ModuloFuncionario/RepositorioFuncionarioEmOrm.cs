using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFuncionario;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace ControleDeCinema.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioEmOrm : RepositorioBaseEmOrm<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
        {
        }

        protected override DbSet<Funcionario> ObterRegistros()
        {
            return dbContext.Funcionarios;
        }
    }
}
