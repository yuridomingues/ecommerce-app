namespace Domain.DTOs;

public class EnderecoDTO
{
    public Guid Id { get; set; }
    public string? Rua { get; set; }
    public int Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? CEP { get; set; }
    public string? Estado { get; set; }
}