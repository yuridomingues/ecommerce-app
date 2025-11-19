using AutoMapper;
using Domain;
using Domain.DTOs;
using Infraestrutucture.Repository;

namespace Application;

public class EnderecoService
{
    private EnderecoRepository enderecoRepository;
    private IMapper mapper;

    public EnderecoService(EnderecoRepository enderecoRepository, IMapper mapper)
    {
        this.enderecoRepository = enderecoRepository;
        this.mapper = mapper;
    }


    public Endereco BuscarEndereco(int id)
    {
        return enderecoRepository.BuscarEndereco(id);
    }

    public void AtualizarEndereco(EnderecoDTO novoEndereco, int id)
    {

        var endereco = mapper.Map<Endereco>(novoEndereco);


        enderecoRepository.AtualizarEndereco(endereco, id);
    }


}
