using Domain;
using Domain.Interfaces;

namespace Infraestrutucture.DataBase;

public class DataBaseEndereco : IDataBaseEndereco
{
    
    public List<Endereco> ListaEnderecos { get; set; } = new List<Endereco>();

    public Endereco BuscarEndereco(int id)
    {
        return ListaEnderecos.FirstOrDefault(e => e.Id == id);
    }

}
