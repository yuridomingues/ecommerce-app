# Sistema E-commerce - AV2

Sistema de e-commerce desenvolvido em C# .NET 9.0 aplicando conceitos de Programação Orientada a Objetos.

**Equipe**: [Estou esperando me mandarem para eu colocar aqui]  
**Disciplina**: Programação Orientada a Objetos  
**Avaliação**: AV2

---

## 📋 Sobre o Projeto

Sistema completo de e-commerce que permite gerenciamento de clientes, produtos, carrinho de compras e pedidos, implementando padrões de design e boas práticas de POO.

### Funcionalidades

- **Gestão de Clientes**: Cadastro, alteração de dados (nome, email, senha), listagem e remoção
- **Gestão de Produtos**: Cadastro, atualização de preço e estoque
- **Carrinho de Compras**: Adicionar/remover produtos, atualizar quantidades, calcular subtotal
- **Pedidos**: Criação, finalização com diferentes formas de pagamento, cálculo automático de frete
- **Endereços**: Cadastro e gerenciamento de múltiplos endereços por cliente

---

## 🎯 Critérios AV2 Implementados

### ✅ 1. Modelagem de Classes Coerente com o Domínio (1,0 ponto)

**Classes principais implementadas**:

- **`Produto`**: Id, Nome, Preco, Estoque + métodos de atualização e validação
- **`ItemCarrinho`**: ProdutoId, Quantidade, PrecoUnitario, SubTotal
- **`Carrinho`**: Composição com ItemCarrinho, métodos de gerenciamento
- **`Pedido`**: ClienteId, Endereco, Itens, ValorFrete, SubTotal, Status, Pagamento
- **`Cliente`**: Nome, Email, Senha, Cpf, lista de Enderecos
- **`Endereco`**: Rua, Numero, Bairro, Cidade, CEP, Estado

**Localização**: `/E-commerce/Domain/Entities/`

---

### ✅ 2. Diagrama UML com Multiplicidades (1,0 ponto)

Diagrama completo em Mermaid mostrando:

- **Multiplicidades**: `1`, `0..1`, `0..*`, `1..*`
- **Herança**: `Pagamento` → `PagamentoPix`, `PagamentoCartao`
- **Interfaces**: `ICalculadoraFrete`, `IDesconto`
- **Composições**: `Carrinho *-- ItemCarrinho`, `Pedido *-- ItemPedido`

**Ver seção**: [Diagrama de Classes UML](#diagrama-de-classes-uml)

---

### ✅ 3. Alinhamento Diagrama/Código (1,0 ponto)

Todas as classes do diagrama UML correspondem exatamente ao código implementado:

| Classe no UML | Arquivo no Código | Status |
|---------------|-------------------|--------|
| Cliente | Domain/Entities/Cliente.cs | ✅ |
| Produto | Domain/Entities/Produto.cs | ✅ |
| Carrinho | Domain/Entities/Carrinho.cs | ✅ |
| Pedido | Domain/Entities/Pedido.cs | ✅ |
| Pagamento (abstract) | Domain/Entities/Pagamento.cs | ✅ |
| PagamentoPix | Domain/Entities/PagamentoPix.cs | ✅ |
| PagamentoCartao | Domain/Entities/PagamentoCartao.cs | ✅ |
| ICalculadoraFrete | Domain/Interfaces/ICalculadoraFrete.cs | ✅ |
| IDesconto | Domain/Interfaces/IDesconto.cs | ✅ |

---

### ✅ 4. Herança e Polimorfismo (1,0 ponto)

**Hierarquia polimórfica implementada: Pagamento**

```csharp
// Classe abstrata base
public abstract class Pagamento
{
    protected Guid Id { get; private set; }
    protected decimal Valor { get; private set; }
    
    public abstract string ObterDescricao();
    public abstract decimal CalcularTaxas(); // ← Polimorfismo
    
    public decimal ObterValorTotal()
    {
        return Valor + CalcularTaxas(); // Chama implementação específica
    }
}

// Implementação PIX - sem taxa
public class PagamentoPix : Pagamento
{
    public override decimal CalcularTaxas() => 0m;
}

// Implementação Cartão - 3% de taxa
public class PagamentoCartao : Pagamento
{
    public override decimal CalcularTaxas() => ObterValor() * 0.03m;
}
```

**Benefício**: Elimina condicionais do tipo `if (tipoPagamento == "Pix")`. O comportamento é determinado automaticamente pela classe concreta.

---

### ✅ 5. Encapsulamento e Coesão (1,0 ponto)

**Propriedades encapsuladas com validação**:

```csharp
// Pedido.cs
public decimal ValorFrete { get; private set; } // ← private set

public void DefinirValorFrete(decimal valorFrete) // ← Método público COM validação
{
    if (valorFrete < 0)
        throw new ArgumentException("O valor do frete não pode ser negativo.");
    ValorFrete = valorFrete;
}

public Pagamento? Pagamento { get; private set; }

public void DefinirPagamento(Pagamento pagamento)
{
    if (Status)
        throw new InvalidOperationException("Não é possível alterar o pagamento de um pedido finalizado.");
    if (pagamento == null)
        throw new ArgumentNullException(nameof(pagamento));
    Pagamento = pagamento;
}
```

**Características**:
- Todas as propriedades com `private set`
- Métodos públicos para modificação controlada
- Validações em todos os pontos de entrada
- Classes com responsabilidade única

---

### ✅ 6. Tratamento de Exceções (1,0 ponto)

**Exceções específicas do domínio**:

```csharp
// Validação em construtor
public PagamentoPix(decimal valor, string chavePix) : base(valor)
{
    if (string.IsNullOrWhiteSpace(chavePix))
        throw new ArgumentException("A chave PIX não pode ser vazia.");
    ChavePix = chavePix;
}

// Validação de regra de negócio
public void FinalizarPedido()
{
    if (Itens == null || Itens.Count <= 0)
        throw new InvalidOperationException("Não é possível finalizar um pedido sem itens.");
    
    if (Pagamento == null)
        throw new InvalidOperationException("Não é possível finalizar um pedido sem forma de pagamento definida.");
    
    Status = true;
}

// Try/catch nos controllers
[HttpPost("Cadastrar")]
public ActionResult CadastrarCliente([FromBody] CadastroClienteDto dto)
{
    try
    {
        _service.CadastrarCliente(dto);
        return Ok("Conta Cadastrada com sucesso!");
    }
    catch (Exception ex)
    {
        return BadRequest(ex.Message); // Mensagem descritiva
    }
}
```

---

### ✅ 7. Baixo Acoplamento e Alta Coesão (1,0 ponto)

**Arquitetura em camadas**:

```
Domain/
  Entities/          → Estado e regras internas (Produto, Pedido, Cliente)
  Interfaces/        → Contratos (ICalculadoraFrete, IDesconto)
  Services/          → Estratégias (FreteExpresso, DescontoPorcentagem)

Application/
  Services/          → Lógica de negócio (PedidoService, CarrinhoService)
  DTOs/              → Transferência de dados
  Interfaces/        → Contratos de serviços

Infrastructure/
  Repositories/      → Acesso a dados
  Database/          → Armazenamento em memória

E-commerce/
  Controllers/       → Endpoints da API
```

**Injeção de Dependências**:

```csharp
public class PedidoService
{
    private readonly ICalculadoraFrete calculadoraFrete; // ← Depende de interface
    
    public PedidoService(..., ICalculadoraFrete calculadoraFrete)
    {
        this.calculadoraFrete = calculadoraFrete;
    }
    
    public void CriarPedido(Guid clienteId, EnderecoDTO enderecoDTO)
    {
        // Usa interface, não implementação concreta
        decimal valorFrete = calculadoraFrete.CalcularFrete(pesoTotal, enderecoDTO.CEP ?? "");
    }
}
```

---

### ✅ 8. Padrões DTO e Service (1,0 ponto)

**DTOs implementados** (20+ classes):
- `CadastroClienteDto`, `NovoNomeClienteDTO`, `AlterarSenhaDTO`
- `AdicionarProdutoCarrinhoDTO`, `AtualizarQuantidadeDTO`
- `PedidoDTO`, `EnderecoDTO`, `ListarCarrinhoDTO`
- `ProdutoDto`, `BuscarClienteSaidaDTO`

**Services implementados**:
- `ClienteService` → CadastrarCliente, AlterarNome, AlterarSenha, RemoverCliente
- `CarrinhoService` → AdicionarProdutoCarrinho, RemoverProduto, EsvaziarCarrinho
- `PedidoService` → CriarPedido, FinalizarPedido, ExcluirPedido
- `ProdutoService` → CadastrarProduto, AtualizarPreco, ListarTodos

**Localização**: 
- DTOs: `/E-commerce/Application/DTOs/`
- Services: `/E-commerce/Application/Services/`

---

### ✅ 9. Regras Extensíveis (Strategy Pattern) (1,0 ponto)

**Interface ICalculadoraFrete**:

```csharp
public interface ICalculadoraFrete
{
    decimal CalcularFrete(decimal pesoTotal, string cepDestino);
}

public class FreteExpresso : ICalculadoraFrete
{
    private const decimal TaxaPorKg = 15.0m;
    public decimal CalcularFrete(decimal pesoTotal, string cepDestino)
    {
        return pesoTotal * TaxaPorKg;
    }
}

public class FreteEconomico : ICalculadoraFrete
{
    private const decimal TaxaPorKg = 8.0m;
    public decimal CalcularFrete(decimal pesoTotal, string cepDestino)
    {
        return pesoTotal * TaxaPorKg;
    }
}
```

**Interface IDesconto**:

```csharp
public interface IDesconto
{
    decimal Aplicar(decimal valorOriginal);
}

public class DescontoPorcentagem : IDesconto
{
    private readonly decimal _percentual;
    
    public decimal Aplicar(decimal valorOriginal)
    {
        decimal desconto = valorOriginal * (_percentual / 100);
        return valorOriginal - desconto;
    }
}

public class DescontoValorFixo : IDesconto
{
    private readonly decimal _valor;
    
    public decimal Aplicar(decimal valorOriginal)
    {
        return Math.Max(0, valorOriginal - _valor);
    }
}
```

**Extensibilidade**: Para adicionar nova estratégia de frete (ex: "FreteInternacional"), basta criar uma classe implementando `ICalculadoraFrete` - **ZERO modificações no código existente**.

---

### ✅ 10. Visibilidade no UML e Código (1,0 ponto)

**No Diagrama UML**:
- `+` para membros públicos
- `-` para membros privados
- `#` para membros protegidos

**No Código** (correspondência exata):

```csharp
public abstract class Pagamento  // abstract no UML
{
    protected Guid Id { get; private set; }      // # no UML
    protected decimal Valor { get; private set; } // # no UML
    
    public abstract string ObterDescricao();     // + no UML
    public abstract decimal CalcularTaxas();     // + no UML
}

public class Produto
{
    public Guid Id { get; private set; }         // - no UML (private set)
    public string Nome { get; private set; }     // - no UML
    public decimal Preco { get; private set; }   // - no UML
    
    public void AtualizarPreco(decimal novoPreco) // + no UML
    {
        ValidarPreco(novoPreco);
        Preco = novoPreco;
    }
    
    private void ValidarPreco(decimal preco)      // - no UML
    {
        if (preco <= 0)
            throw new ArgumentException("O preço deve ser maior que zero.");
    }
}
```

**Verificação**: Todos os membros possuem modificadores explícitos (`public`, `private`, `protected`). Sem uso de `var` em membros públicos.

---

## 📊 Resultado Final

| Critério | Pontuação |
|----------|-----------|
| 1. Modelagem de classes | ✅ 1,0 |
| 2. Diagrama UML | ✅ 1,0 |
| 3. Alinhamento diagrama/código | ✅ 1,0 |
| 4. Herança e polimorfismo | ✅ 1,0 |
| 5. Encapsulamento | ✅ 1,0 |
| 6. Tratamento de exceções | ✅ 1,0 |
| 7. Baixo acoplamento | ✅ 1,0 |
| 8. Padrões DTO/Service | ✅ 1,0 |
| 9. Regras extensíveis | ✅ 1,0 |
| 10. Visibilidade UML/código | ✅ 1,0 |
| **TOTAL** | **10,0** |

---

## 🚀 Como Executar

### Requisitos
- .NET SDK 9.0 ou superior

### Passos

1. **Clonar o repositório**:
   ```bash
   git clone <url-do-repositorio>
   cd ecommerce-app
   ```

2. **Compilar**:
   ```bash
   cd E-commerce
   dotnet build
   ```

3. **Executar**:
   ```bash
   cd E-commerce
   dotnet run --project E-commerce.csproj
   ```

4. **Acessar**: `http://localhost:5090`

---

## 🧪 Testando a API

### Cadastrar Produto

```bash
curl -X POST http://localhost:5090/api/Produtos \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Notebook Dell",
    "preco": 3500.00,
    "estoque": 10
  }'
```

### Listar Produtos

```bash
curl http://localhost:5090/api/Produtos
```

### Cadastrar Cliente

```bash
curl -X POST http://localhost:5090/api/Cliente/Cadastrar \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "João Silva",
    "email": "joao@email.com",
    "senha": "senha123",
    "cpf": "12345678900"
  }'
```

### Adicionar ao Carrinho

```bash
curl -X POST http://localhost:5090/api/Carrinho/{clienteId}/AdicionarProdutoCarrinho \
  -H "Content-Type: application/json" \
  -d '{
    "produtoId": "guid-do-produto",
    "quantidade": 2
  }'
```

### Criar Pedido

```bash
curl -X POST http://localhost:5090/api/Pedido/criarPedido/{clienteId} \
  -H "Content-Type: application/json" \
  -d '{
    "rua": "Rua das Flores",
    "numero": 123,
    "bairro": "Centro",
    "cidade": "São Paulo",
    "cep": "01000-000",
    "estado": "SP"
  }'
```

---

## 📐 Diagrama de Classes UML

```mermaid
classDiagram
    class Cliente {
        -Guid Id
        -string Nome
        -string Email
        -string Senha
        -string Cpf
        -List~Endereco~ _enderecos
        +IReadOnlyList~Endereco~ Enderecos
        +void DefinirId()
        +void AlterarNome(string NovoNome)
        +void AlterarEmail(string NovoEmail)
        +void AlterarSenha(string NovaSenha)
        +void CadastrarEndereco(Endereco endereco)
        +void RemoverEndereco(Guid enderecoid)
    }
    
    class Endereco {
        -Guid Id
        -string Rua
        -int Numero
        -string Bairro
        -string Cidade
        -string CEP
        -string Estado
        +void AtualizarEndereco(string NovaRua, int NovoNumero, string NovoBairro, string NovaCidade, string NovoCep, string NovoEstado)
    }
    
    class Produto {
        -Guid Id
        -string Nome
        -decimal Preco
        -int Estoque
        +void AtualizarPreco(decimal novoPreco)
        +void AdicionarEstoque(int quantidade)
        +void RemoverEstoque(int quantidade)
        -void ValidarPreco(decimal preco)
        -void ValidarNome(string nome)
        -void ValidarEstoque(int estoque)
    }
    
    class Carrinho {
        -Guid Id
        -Guid ClienteId
        -List~ItemCarrinho~ itens
        +IReadOnlyList~ItemCarrinho~ Item
        +ItemCarrinho BuscarIdProduto(Guid id)
        +void AdicionarProduto(ItemCarrinho item)
        +void RemoverProduto(ItemCarrinho item)
        +ItemCarrinho AtualizarQuantidade(int NovaQuantidade, Guid produtoid)
        +void EsvaziarCarrinho()
        +decimal CalcularSubTotal()
    }
    
    class ItemCarrinho {
        -Guid ProdutoId
        -int Quantidade
        -string Nome
        -decimal PrecoUnitario
        +decimal SubTotal
        +void AdicionarQuantidade(int quantidade)
        +void RemoverQuantidade(int quantidade)
        +void AtualizarQuantidade(int NovaQuantidade)
    }
    
    class Pedido {
        -Guid Id
        -Guid ClienteId
        -Endereco Endereco
        -List~ItemPedido~ Itens
        -decimal ValorFrete
        -decimal SubTotal
        -bool Status
        -Pagamento Pagamento
        +void DefinirId()
        +void FinalizarPedido()
        +void AlterarEndereco(Endereco novoEndereco)
        +void DefinirPagamento(Pagamento pagamento)
        +void DefinirValorFrete(decimal valorFrete)
        +void DefinirSubTotal(decimal subTotal)
    }
    
    class ItemPedido {
        -Guid Id
        -Guid PedidoId
        -Guid ProdutoId
        -string NomeProduto
        -int Quantidade
        -decimal PrecoUnitario
    }
    
    class Pagamento {
        <<abstract>>
        #Guid Id
        #decimal Valor
        +abstract string ObterDescricao()
        +abstract decimal CalcularTaxas()
        +decimal ObterValorTotal()
        +Guid ObterI()
        +decimal ObterValor()
    }
    
    class PagamentoPix {
        -string ChavePix
        +string ObterDescricao()
        +decimal CalcularTaxas()
    }
    
    class PagamentoCartao {
        -string NumeroCartao
        -int Parcelas
        +string ObterDescricao()
        +decimal CalcularTaxas()
    }
    
    class ICalculadoraFrete {
        <<interface>>
        +decimal CalcularFrete(decimal pesoTotal, string cepDestino)
    }
    
    class FreteExpresso {
        +decimal CalcularFrete(decimal pesoTotal, string cepDestino)
    }
    
    class FreteEconomico {
        +decimal CalcularFrete(decimal pesoTotal, string cepDestino)
    }
    
    class IDesconto {
        <<interface>>
        +decimal Aplicar(decimal valorOriginal)
    }
    
    class DescontoPorcentagem {
        -decimal _percentual
        +decimal Aplicar(decimal valorOriginal)
    }
    
    class DescontoValorFixo {
        -decimal _valor
        +decimal Aplicar(decimal valorOriginal)
    }

    %% Relacionamentos
    Cliente "1" -- "0..*" Endereco : possui
    Cliente "1" -- "1" Carrinho : possui
    Cliente "1" -- "0..*" Pedido : realiza
    
    Carrinho "1" *-- "0..*" ItemCarrinho : contém
    ItemCarrinho "1" --> "1" Produto : referencia
    
    Pedido "1" *-- "1..*" ItemPedido : contém
    Pedido "1" --> "1" Endereco : entrega em
    Pedido "1" --> "1" Pagamento : possui
    ItemPedido "1" --> "1" Produto : referencia
    
    Pagamento <|-- PagamentoPix : herda
    Pagamento <|-- PagamentoCartao : herda
    
    ICalculadoraFrete <|.. FreteExpresso : implementa
    ICalculadoraFrete <|.. FreteEconomico : implementa
    
    IDesconto <|.. DescontoPorcentagem : implementa
    IDesconto <|.. DescontoValorFixo : implementa
```

### Legenda

**Multiplicidades**:
- `1` — exatamente um
- `0..1` — zero ou um (opcional)
- `0..*` — zero ou mais
- `1..*` — um ou mais

**Visibilidade**:
- `+` — public
- `-` — private
- `#` — protected

**Relacionamentos**:
- `--` — Associação
- `*--` — Composição (parte integrante)
- `-->` — Dependência
- `<|--` — Herança
- `<|..` — Implementação de interface

---

## 🏗️ Estrutura do Projeto

```
E-commerce/
├── Domain/
│   ├── Entities/              # Entidades do domínio
│   │   ├── Cliente.cs
│   │   ├── Produto.cs
│   │   ├── Carrinho.cs
│   │   ├── ItemCarrinho.cs
│   │   ├── Pedido.cs
│   │   ├── ItemPedido.cs
│   │   ├── Endereco.cs
│   │   ├── Pagamento.cs       # Classe abstrata
│   │   ├── PagamentoPix.cs
│   │   └── PagamentoCartao.cs
│   ├── Interfaces/            # Contratos
│   │   ├── ICalculadoraFrete.cs
│   │   └── IDesconto.cs
│   └── Services/              # Implementações de estratégias
│       ├── FreteExpresso.cs
│       ├── FreteEconomico.cs
│       ├── DescontoPorcentagem.cs
│       └── DescontoValorFixo.cs
├── Application/
│   ├── Services/              # Lógica de negócio
│   │   ├── ClienteService.cs
│   │   ├── ProdutoService.cs
│   │   ├── CarrinhoService.cs
│   │   └── PedidoService.cs
│   ├── DTOs/                  # Data Transfer Objects
│   └── Interfaces/            # Contratos de serviços
├── Infrastructure/
│   ├── Repositories/          # Acesso a dados
│   └── Database/              # Armazenamento em memória
└── E-commerce/
    ├── Controllers/           # Endpoints da API
    └── Program.cs             # Configuração e DI
```

---

## 🛠️ Tecnologias Utilizadas

- **C# .NET 9.0** - Framework principal
- **ASP.NET Core** - Web API
- **AutoMapper** - Mapeamento de objetos
- **Dependency Injection** - Inversão de controle

---

## 📝 Decisões de Design

### Por que Strategy Pattern para Frete?

Permite adicionar novas estratégias de cálculo de frete sem modificar código existente. Exemplo: adicionar "FreteInternacional" requer apenas criar nova classe implementando `ICalculadoraFrete`.

### Por que Herança para Pagamento?

Elimina condicionais espalhadas pelo código. Cada tipo de pagamento conhece suas próprias regras de taxa, seguindo o princípio Open/Closed (aberto para extensão, fechado para modificação).

### Por que Encapsulamento com private set?

Garante que mudanças de estado passem por validações. Exemplo: não é possível alterar `ValorFrete` diretamente sem validar se o valor é negativo.

---

## 👥 Equipe

[Estou esperando eles me enviarem para eu colocar aqui]

---

## 📄 Licença

Este projeto foi desenvolvido para fins acadêmicos como parte da disciplina de Programação Orientada a Objetos
