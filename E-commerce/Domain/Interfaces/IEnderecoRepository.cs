namespace Domain.Interfaces;

public interface IEnderecoRepository
{
    public void AtualizarEndereco(Endereco novoEndereco, int id);
    public Endereco BuscarEndereco(int id);
}
