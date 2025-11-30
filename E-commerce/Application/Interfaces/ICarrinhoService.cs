using Application.CarrinhoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CarrinhoService;

namespace Application.CarrinhoInterfaces
{
    public interface ICarrinhoService
    {
        void AdicionarProdutoCarrinho(AdicionarProdutoCarrinhoDTO dto, Guid clienteid);

        List<ListarCarrinhoDTO> ListarItensCarrinho(Guid clienteid);

        void RemoverProduto(Guid clienteid, RemoverProdutoDTO dto);

        void AtualizarQuantidade(AtualizarQuantidadeDTO dto, Guid clienteid);

        void EsvaziarCarrinho(Guid clienteid);

        decimal ObterSubTotal(Guid clienteid);
    }
}
