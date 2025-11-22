using Domain;
using Domain.Interfaces;
using Infraestrutucture.DataBase;

namespace Infraestrutucture.Repository;

public class EnderecoRepository : IEnderecoRepository
{

    private DataBaseEndereco dataBaseEndereco;

    public EnderecoRepository(DataBaseEndereco dataBaseEndereco)
    {
        this.dataBaseEndereco = dataBaseEndereco;
    }
    
    
    public void AtualizarEndereco(Endereco novoEndereco, Guid id)
    {
        Endereco endereco = BuscarEndereco(id);

        endereco.AtualizarEndereco(novoEndereco);

    }


    public Endereco BuscarEndereco(Guid id)
    {
        return dataBaseEndereco.BuscarEndereco(id);
    }

}
