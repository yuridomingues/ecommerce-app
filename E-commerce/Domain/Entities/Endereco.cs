namespace Domain;

public class Endereco
{

    public Guid Id { get; set; }

    public string? Rua { get; set; }

    public string? Numero { get; set; }

    public string? Bairro { get; set; }
    
    public string? Cidade { get; set; }
    
    public string? CEP { get; set; }
    
    public string? Estado { get; set; }

    
    public Endereco(string rua, string numero, string bairro, string cidade, string cep, string estado)
    {
        Rua = rua;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        CEP = cep;
        Estado = estado;
        Id = Guid.NewGuid();
    }


    public void AtualizarEndereco(Endereco novoEndereco)
    {
        Rua = novoEndereco.Rua;
        Numero = novoEndereco.Numero;
        Bairro = novoEndereco.Bairro;
        Cidade = novoEndereco.Cidade;
        CEP = novoEndereco.CEP;
        Estado = novoEndereco.Estado;
    }
    
}