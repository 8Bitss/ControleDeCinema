namespace ControleDeCinema.Dominio.ModuloSala;

public class Poltrona
{
    public int Id { get; set; }
    public bool Status { get; set; }

    public Poltrona(){}

    public void AlterarStatus(Poltrona poltronaSelecionada)
    {
        poltronaSelecionada.Status = false;
    }
}
