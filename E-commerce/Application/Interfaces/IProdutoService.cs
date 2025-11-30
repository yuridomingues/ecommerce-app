using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProdutoInterface
{
    public interface IProdutoService
    {
        void CadastrarProduto(CriarProdutoDto dto);
        IEnumerable<ProdutoDto> ListarTodos();
        ProdutoDto ObterPorId(Guid Id);

        void AtualizarPreco(Guid Id, decimal novoPreco);

    }
}
