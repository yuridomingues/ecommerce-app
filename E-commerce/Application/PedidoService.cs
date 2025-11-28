namespace Application;
using Domain.Interface;
using Domain;
using Domain.DTOs;
using AutoMapper;

public class PedidoService
{
    
    private readonly IPedidoRepository pedidoRepository;
    private readonly IMapper mapper;

    public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
    {
        this.pedidoRepository = pedidoRepository;
        this.mapper = mapper;
    }


    public void CriarPedido(PedidoDTO novoPedido)
    {
        if(novoPedido == null)
        {
            throw new ArgumentNullException(nameof(novoPedido));
        }

        var pedido = mapper.Map<Pedido>(novoPedido);

        pedidoRepository.CriarPedido(pedido);
    }


    public void FinalizarPedido(PedidoDTO pedidoFinalizado)
    {
        if(pedidoFinalizado == null)
        {
            throw new ArgumentNullException(nameof(pedidoFinalizado));
        }

        if(pedidoFinalizado.Id == Guid.Empty)
        {
            throw new ArgumentException("Id inválido");
        }
        
        var pedidoExistente = BuscarPedido(pedidoFinalizado.Id);
        if(pedidoExistente.Status == true)
        {
            throw new InvalidOperationException("Pedido já finalizado");
        }
        
        var pedido = mapper.Map<Pedido>(pedidoFinalizado);
        pedidoRepository.FinalizarPedido(pedido);
    }


    public void ExcluirPedido(PedidoDTO pedidoExcluido)
    {
        if(pedidoExcluido == null)
        {
            throw new ArgumentNullException(nameof(pedidoExcluido));
        }

        if(pedidoExcluido.Id == Guid.Empty)
        {
            throw new ArgumentException("Id inválido");
        }

        var pedidoExistente = pedidoRepository.BuscarPedido(pedidoExcluido.Id);
        if(pedidoExistente == null)
        {
            throw new InvalidOperationException("Pedido não encontrado");
        }

        var pedido = mapper.Map<Pedido>(pedidoExcluido);
        pedidoRepository.ExcluirPedido(pedido.Id);
    }


    public List<PedidoDTO> ListarPedidos()
    {
        var pedidos = pedidoRepository.ListarPedidos();

        if(pedidos == null)
        {
            return new List<PedidoDTO>();
        }

        return mapper.Map<List<PedidoDTO>>(pedidos);
    }


    public PedidoDTO BuscarPedido(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id inválido");
        }

        var pedido = pedidoRepository.BuscarPedido(id);

        if(pedido == null)
        {
            throw new InvalidOperationException("Pedido não encontrado");
        }


        return mapper.Map<PedidoDTO>(pedido); 
    }


    public void AlterarEndereco(EnderecoDTO novoEndereco, Guid id)
    {
        if(novoEndereco == null)
        {
            throw new ArgumentNullException(nameof(novoEndereco));
        }

        if(id == Guid.Empty)
        {
            throw new ArgumentException("Id inválido");
        }

        var pedidoExistente = BuscarPedido(id);
        if(pedidoExistente == null)
        {
            throw new InvalidOperationException("Pedido não encontrado");
        }

        if(pedidoExistente.Status == true)
        {
            throw new InvalidOperationException("Pedido já finalizado. Não é possível alterar o endereço.");
        }
        

        var endereco = mapper.Map<Endereco>(novoEndereco);

        pedidoRepository.AlterarEndereco(endereco, id);
    }


}
