using Domain;
using Domain.Interfaces;
using Domain.Entities;

namespace Infraestrutucture.DataBase;

public class DataBaseEndereco : IDataBaseEndereco
{
    
    public List<Endereco> ListaEnderecos { get; set; } = new List<Endereco>();

    public Endereco BuscarEndereco(Guid id)
    {
        return ListaEnderecos.FirstOrDefault(e => e.Id == id);
    }

}
