using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string? Rua { get; private set; }

        public int Numero { get; private set; }

        public string? Bairro { get; private set; }

        public string? Cidade { get;  private set; }

        public string? CEP { get; private set; }

        public string? Estado { get; private set; }

        public void AtualizarEndereco(string NovaRua, int NovoNumero, string NovoBairro, string NovaCidade, string NovoCep, string NovoEstado )
        {
            Rua = NovaRua;
            Numero = NovoNumero;
            Bairro = NovoBairro;
            Cidade = NovaCidade;
            CEP = NovoCep;
            Estado = NovoEstado;
        }
    }
}
