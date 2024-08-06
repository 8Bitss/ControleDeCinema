using ControleDeCinema.Dominio.Compartilhado;
using Microsoft.VisualBasic;

namespace ControleDeCinema.Dominio.ModuloFilme;

public class Filme : EntidadeBase
{
    public string Titulo { get; set; }

    public DateTime Duracao { get; set; }
    public DateTime DataLancamento { get; set; }

    public TipoGeneroEnum Genero { get; set; }


    public Filme() { }

    public Filme(string titulo, DateTime duracao, DateTime dataLancamento, TipoGeneroEnum genero)
    {
        Titulo = titulo;
        Duracao = duracao;
        DataLancamento = dataLancamento;
        Genero = genero;
    }

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        Filme filmeAtualizado = (Filme)registroAtualizado;

        Titulo = filmeAtualizado.Titulo;
        Duracao = filmeAtualizado.Duracao;
        DataLancamento = filmeAtualizado.DataLancamento;
        Genero = filmeAtualizado.Genero;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrEmpty(Titulo.Trim()))
            erros.Add("O campo \"Título\" é obrigatório");

        if (Duracao == null)
            erros.Add("O campo \"Duração\" é obrigatório");
        
        if (DataLancamento == null)
            erros.Add("O campo \"Data de Lançamento\" é obrigatório");

        if (Genero == null)
            erros.Add("O campo \"Gênero\" é obrigatório");

        return erros;
    }

    public override string ToString()
    {
        return Titulo;
    }
}
