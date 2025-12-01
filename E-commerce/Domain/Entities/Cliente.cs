using Domain.ClienteExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }

        public string Nome { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;

        public string Senha { get; private set; } = string.Empty;

        public string Cpf { get; private set; } = string.Empty;



        private readonly List<Endereco> _enderecos = new();

        public IReadOnlyList<Endereco> Enderecos => _enderecos;

        

        public void DefinirId()
        {
            this.Id = Guid.NewGuid();
        }
        public void AlterarNome(string NovoNome)
        {
            if (NovoNome == Nome)
            {
                throw new NomesIguais();
            }
            else
            {
                Nome = NovoNome;

            }
        }
        public void AlterarEmail(string NovoEmail)
        {
            if (NovoEmail == Email)
            {
                throw new EmailsIguais();
            }

            Email = NovoEmail;

        }
        public void AlterarSenha(string NovaSenha)
        {
           
            Senha = NovaSenha;
        }

        public void CadastrarEndereco(Endereco endereco)
        {
            bool enderecoExiste = _enderecos.Any(e =>
        e.Rua == endereco.Rua &&
        e.Numero == endereco.Numero &&
        e.Bairro == endereco.Bairro &&
        e.Cidade == endereco.Cidade &&
        e.CEP == endereco.CEP &&
        e.Estado == endereco.Estado);
            
            if (!enderecoExiste)
            {
                _enderecos.Add(endereco);

            }
            else
            {
                throw new EnderecoJaExiste();
            }
        }

        public void RemoverEndereco( Guid enderecoid)
        {
            Endereco? enderecoExistente = BuscarPorId(enderecoid);

            if (enderecoExistente == null)
            {
                throw new EnderecoInexistente();
            }
            else
            {
                _enderecos.Remove(enderecoExistente);

            }

        }

        public void AtualizarEndereco(
        Guid EnderecoId,
        string NovaRua,
        int NovoNumero,
        string NovoBairro,
        string NovaCidade,
        string NovoCep,
        string NovoEstado
        )
        {
            Endereco? endereco = _enderecos.FirstOrDefault(e => e.Id == EnderecoId);

            if (endereco == null)
            {
                throw new EnderecoInexistente();
            }
            endereco.AtualizarEndereco(
            NovaRua,
            NovoNumero,
            NovoBairro,
            NovaCidade,
            NovoCep,
            NovoEstado);

        }

        public Endereco? BuscarPorId(Guid Id)
        {
            return _enderecos.FirstOrDefault(i => i.Id == Id);
        }





    }
}
