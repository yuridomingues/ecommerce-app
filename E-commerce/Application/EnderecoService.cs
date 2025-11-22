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


    public Endereco BuscarEndereco(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id não pode ser vazio");
        }

        return enderecoRepository.BuscarEndereco(id);
    }

    public void AtualizarEndereco(EnderecoDTO novoEndereco, Guid id)
    {

        if (novoEndereco == null)
        {
            throw new ArgumentException("Endereco não pode ser vazio");
        }

        var endereco = mapper.Map<Endereco>(novoEndereco);


        enderecoRepository.AtualizarEndereco(endereco, id);
    }


}
