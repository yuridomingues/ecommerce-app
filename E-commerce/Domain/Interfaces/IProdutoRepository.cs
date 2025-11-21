using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        void Atualizar(Produto produto);
        void Remover(int id);    }
}