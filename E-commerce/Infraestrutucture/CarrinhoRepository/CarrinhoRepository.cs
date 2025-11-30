using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;

namespace Infraestrutucture.CarrinhoRepository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IDataBaseCarrinho _db;

        public CarrinhoRepository(IDataBaseCarrinho db)
        {
            _db = db;
        }

        public Carrinho? BuscarClienteId(Guid clienteid)
        {
            return _db.BuscarClienteID(clienteid);
        }

        public void Salvar(Carrinho carrinho)
        {
            _db.Salvar(carrinho);
        }
    }
}
