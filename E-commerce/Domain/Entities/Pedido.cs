namespace Domain;
using Domain.Entities;

public class Pedido
{  

    public Guid Id { get; private set; }

    public Guid ClienteId { get; private set; }

    public Endereco? Endereco { get; private set; }

    public List<ItemPedido> Itens { get; private set; }

    public decimal ValorFrete { get; private set; }

    public decimal SubTotal { get; private set; }

    public bool Status { get; private set; } // true = finalizado e false = aberto

    public Pagamento? Pagamento { get; private set; }


    public Pedido(Guid clienteId, Endereco endereco)
    {
        ClienteId = clienteId;
        Endereco = endereco;
        Status = false;
        Itens = new List<ItemPedido>();
    }

    public Pedido()
    {
        Itens = new List<ItemPedido>();
    }


    public void DefinirId()
    {
        if (Id != Guid.Empty)
        {
            throw new InvalidOperationException("Id já definido.");
        }

        Id = Guid.NewGuid();
    }


    public void FinalizarPedido()
    {
        if(Itens == null || Itens.Count <= 0)
        {
            throw new InvalidOperationException("Não é possível finalizar um pedido sem itens.");
        }

        if (Pagamento == null)
        {
            throw new InvalidOperationException("Não é possível finalizar um pedido sem forma de pagamento definida.");
        }

        Status = true;
    }


    public void AlterarEndereco(Endereco novoEndereco)
    {
        if (Status)
        {
            throw new InvalidOperationException("Não é possível alterar o endereço de um pedido finalizado.");
        }

        Endereco = novoEndereco;
    }

    public void DefinirPagamento(Pagamento pagamento)
    {
        if (Status)
        {
            throw new InvalidOperationException("Não é possível alterar o pagamento de um pedido finalizado.");
        }

        if (pagamento == null)
        {
            throw new ArgumentNullException(nameof(pagamento));
        }

        Pagamento = pagamento;
    }

    public void DefinirValorFrete(decimal valorFrete)
    {
        if (valorFrete < 0)
        {
            throw new ArgumentException("O valor do frete não pode ser negativo.");
        }

        ValorFrete = valorFrete;
    }

    public void DefinirSubTotal(decimal subTotal)
    {
        if (subTotal < 0)
        {
            throw new ArgumentException("O subtotal não pode ser negativo.");
        }

        SubTotal = subTotal;
    }

}
