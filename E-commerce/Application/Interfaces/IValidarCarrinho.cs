using Application.CarrinhoDTO;
using Domain.Entities;
using Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarrinhoInterfaces
{
    public interface IValidarCarrinho
    {
        (Carrinho Carrinho, Produto Produto)  ValidarRecursos(AtualizarQuantidadeDTO dto, Guid clienteid);

        (Carrinho Carrinho, Cliente cliente) ValidarRecursosEsvaziar(Guid clienteid);

        (Carrinho Carrinho, Produto Produto) ValidarRecursosRemover(RemoverProdutoDTO dto, Guid clienteid);

        (Carrinho Carrinho, Produto Produto) ValidarRecursosAdicionar(AdicionarProdutoCarrinhoDTO dto, Guid clienteid);
    }
}
