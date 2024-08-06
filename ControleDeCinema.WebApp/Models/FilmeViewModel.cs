using ControleDeCinema.Dominio.ModuloFilme;
using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class InserirFilmeViewModel
{
    [Required(ErrorMessage = "O campo: Título é obrigatório!")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo: Duração é obrigatório!")]
    public DateTime Duracao { get; set; }
    
    [Required(ErrorMessage = "O campo: Data de Lançamento é obrigatório!")]

    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "O campo: Genero é obrigatório!")]
    public TipoGeneroEnum Genero { get; set; }

}

public class EditarFilmeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo: Título é obrigatório!")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo: Duração é obrigatório!")]
    public DateTime Duracao { get; set; }

    [Required(ErrorMessage = "O campo: Data de Lançamento é obrigatório!")]

    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "O campo: Genero é obrigatório!")]
    public TipoGeneroEnum Genero { get; set; }

}

public class ExcluirFilmeViewModel
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public DateTime Duracao { get; set; }
    public DateTime DataLancamento { get; set; }

    public TipoGeneroEnum Genero { get; set; }


    public IEnumerable<ListarFilmeViewModel> Filmes { get; set; }
}

public class ListarFilmeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo: Título é obrigatório!")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo: Duração é obrigatório!")]
    public DateTime Duracao { get; set; }

    [Required(ErrorMessage = "O campo: Data de Lançamento é obrigatório!")]

    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "O campo: Genero é obrigatório!")]
    public TipoGeneroEnum Genero { get; set; }

}

public class DetalhesFilmeViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo: Título é obrigatório!")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo: Duração é obrigatório!")]
    public DateTime Duracao { get; set; }

    [Required(ErrorMessage = "O campo: Data de Lançamento é obrigatório!")]

    public DateTime DataLancamento { get; set; }

    [Required(ErrorMessage = "O campo: Genero é obrigatório!")]
    public TipoGeneroEnum Genero { get; set; }


    public IEnumerable<ListarFilmeViewModel> Filmes { get; set; }
}
