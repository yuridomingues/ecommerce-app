using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICarrinhoRepository
    {
        Carrinho? BuscarClienteId(Guid clienteid);
        void Salvar(Carrinho carrinho);
    }
}
