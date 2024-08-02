using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models;

public class FuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
}

public class InserirFuncionarioViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Login é obrigatório!")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string Senha { get; set; }
}

public class EditarFuncionarioViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo nome necessita de ao menos 3 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O Login é obrigatório!")]
    public string Login { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória!")]
    public string Senha { get; set; }

}

public class ExcluirFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public IEnumerable<ListarFuncionarioViewModel> Funcionarios { get; set; }
}

public class DetalhesFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public IEnumerable<ListarFuncionarioViewModel> Funcionarios { get; set; }
}

public class ListarFuncionarioViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
}
