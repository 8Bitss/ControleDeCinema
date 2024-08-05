using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloSala;

public class Sala : EntidadeBase
{
    public int Capacidade { get; set; }
    public int QtdAssentosDisponiveis { get; set; }

    public List<Poltrona> Poltronas { get; set; }

    public Sala(int capacidade)
    {
        Capacidade = capacidade;

        QtdAssentosDisponiveis = capacidade;

        Poltronas = new List<Poltrona>();
    }

    public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
    {
        Sala salaAtualizada = (Sala)registroAtualizado;

        Capacidade = salaAtualizada.Capacidade;
        QtdAssentosDisponiveis = salaAtualizada.QtdAssentosDisponiveis;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Capacidade == null || Capacidade < 1)
            erros.Add("O campo \"Capacidade\" precisa ser maior que 1");

        return erros;
    }

    public void AdicionarPoltrona(Poltrona poltrona)
    {
        Poltronas.Add(poltrona);
    }
}
