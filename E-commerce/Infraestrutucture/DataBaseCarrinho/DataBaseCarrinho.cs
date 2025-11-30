using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutucture.DataBaseCarrinho
{
    public class DataBaseCarrinho: IDataBaseCarrinho
    {
        private readonly List<Carrinho> carrinhos = new();

        public Carrinho? BuscarClienteID(Guid clienteid)
        {
            return carrinhos.FirstOrDefault(i => i.ClienteId == clienteid);
        }

        public void Salvar(Carrinho carrinho)
        {
            bool existe = carrinhos.Any(c => c.Id == carrinho.Id);

            if (!existe)
            {
                carrinhos.Add(carrinho);
            }
        }



    }
}
