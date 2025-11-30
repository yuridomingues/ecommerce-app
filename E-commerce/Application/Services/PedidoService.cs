namespace Application;
using Domain;
using Domain.Interface;
using Application.DTOs;
using Domain.DTOs;
using Domain.Entities;
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


    public void CriarPedido(Domain.DTOs.PedidoDTO novoPedido)
    {
        if(novoPedido == null)
        {
            throw new ArgumentNullException(nameof(novoPedido));
        }

        var pedido = mapper.Map<Pedido>(novoPedido);

        pedidoRepository.CriarPedido(pedido);
    }


    public void FinalizarPedido(Domain.DTOs.PedidoDTO pedidoFinalizado)
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


    public void ExcluirPedido(Domain.DTOs.PedidoDTO pedidoExcluido)
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


    public List<Domain.DTOs.PedidoDTO> ListarPedidos()
    {
        var pedidos = pedidoRepository.ListarPedidos();

        if(pedidos == null)
        {
            return new List<Domain.DTOs.PedidoDTO>();
        }

        return mapper.Map<List<Domain.DTOs.PedidoDTO>>(pedidos);
    }


    public Domain.DTOs.PedidoDTO BuscarPedido(Guid id)
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


        return mapper.Map<Domain.DTOs.PedidoDTO>(pedido); 
    }


    public void AlterarEndereco(Domain.DTOs.EnderecoDTO novoEndereco, Guid id)
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
