using System;

namespace Domain.Entities
{

    public class Pagamento
	{
		public decimal ValorTotal { get; private set; }

		public int Parcelas { get; private set; }

		public Guid PedidoId { get; private set; }

		public Guid FormaDePagamentoId { get; private set; }

		public bool status { get; private set; }

		public Guid Id { get; private set; }
		
		public Pagamento(decimal valortotal, int parcelas, Guid pedidoid, Guid formadepagamentoid, bool status, Guid id)
		{
			ValorTotal = valortotal;
			Parcelas = parcelas;
			PedidoId = pedidoid;
			FormaDePagamentoId = formadepagamentoid;
			status = status;
			Id = id;

		}
	}
