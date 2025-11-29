using Domain.Entities;
using System.Collections.Generic;
using Domain.Entitities;

namespace Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        Produto? ObterPorId(Guid id);
        IEnumerable<Produto> ObterTodos();
        void Atualizar(Produto produto);
        void Remover(Guid id);    }
}