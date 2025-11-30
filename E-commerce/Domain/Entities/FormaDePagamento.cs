using System;

namespace Domain.Entities
{

    public class FormaDePagamento
    {
        public string Forma { get;  private set; }

        public bool Ativo { get; private set; }

        public Guid Id { get; private set; }

        public FormaDePagamento(string forma, bool ativo)
        {
            Forma = forma;
            Ativo = ativo;
        }
    }
