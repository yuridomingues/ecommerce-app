namespace Domain.Interfaces;
using Domain.Entities;

public interface IDataBaseEndereco
{
    public Endereco BuscarEndereco(Guid id);
}
