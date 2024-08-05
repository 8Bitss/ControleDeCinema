using ControleDeCinema.Dominio.ModuloSala;
using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class InserirSalaViewModel
{
    [Required(ErrorMessage = "O campo capacidade é obrigatório!")]
    public int Capacidade { get; set; }
}

public class EditarSalaViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo capacidade é obrigatório!")]
    public int Capacidade { get; set; }
}

public class ExcluirSalaViewModel
{
    public int Id { get; set; }
    public int Capacidade { get; set; }
    public int QtdAssentosDisponiveis { get; set; }

    public List<Poltrona> Poltronas { get; set; }
    
    public IEnumerable<ListarSalaViewModel> Salas { get; set; }
}

public class ListarSalaViewModel
{
    public int Id { get; set; }
    public int Capacidade { get; set; }
}

public class DetalhesSalaViewModel
{
    public int Id { get; set; }
    public int Capacidade { get; set; }

    public IEnumerable<ListarSalaViewModel> Salas { get; set; }
}

