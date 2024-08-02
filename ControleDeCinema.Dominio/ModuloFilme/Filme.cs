using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleDeCinema.Dominio.Compartilhado;

namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme : EntidadeBase
    {
        public string Titulo
        {
            get => default;
            set
            {
            }
        }

        public DateTime Duracao
        {
            get => default;
            set
            {
            }
        }

        public Genero Genero
        {
            get => default;
            set
            {
            }
        }

        public DateTime DataLancamento
        {
            get => default;
            set
            {
            }
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            throw new NotImplementedException();
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}