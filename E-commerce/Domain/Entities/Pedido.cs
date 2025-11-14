namespace Domain;

public class Pedido
{

    public static int IdAtual = 1; 

    public int Id { get; private set; }

    public int ClienteId { get; private set; }

    public Endereco Endereco { get; private set; }

    public List<ItemPedido> Itens { get; private set; }

    public decimal ValorFrete { get; private set; } = 15;

    public decimal SubTotal { get; private set; }

    public bool Status { get; private set; } // true = finalziado e false = aberto


    public Pedido(int clienteId, Endereco endereco)
    {
        ClienteId = clienteId;
        Endereco = endereco;
        Status = false;
        Itens = new List<ItemPedido>();
    }


    public void DefinirId()
    {

        Id = IdAtual;
        IdAtual++;

    }


    public void DefinirSubTotal()
    {

        decimal subTotal = 0;


        for (int i = 0; i < Itens.Count; i++)
        {
            subTotal += Itens[i].PrecoUnitario * Itens[i].Quantidade;
        }


        if (subTotal <= 0)
        {

            Console.WriteLine("Valor inválido"); // Criar Exception

        }
        else
        {

            SubTotal = subTotal;

        }

    }


    public void AdicionarItem(ItemPedido item)
    {

        Itens.Add(item);
    
    }


    public void FinalizarPedido(Pedido pedido)
    {
        
        if(Itens.Count <= 0)
        {
            throw new Exception("Não é possível finalizar um pedido sem itens.");
        }

        pedido.Status = true;

    }


    public void AlterarEndereco(Endereco endereco)
    {

        Endereco = endereco;

    }

}
