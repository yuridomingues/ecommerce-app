namespace Domain.Interfaces;

public interface IEnderecoRepository
{
    public void AtualizarEndereco(Endereco novoEndereco, Guid id);
    public Endereco BuscarEndereco(Guid id);
}
