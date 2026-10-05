# 🎬 StreamingFlix

Projeto desenvolvido em **C# com .NET 10** para implementação e validação de regras de negócio de uma plataforma de streaming.

O projeto foi desenvolvido como atividade acadêmica da disciplina de **Garantia da Qualidade de Software**, com foco na implementação de regras de negócio e na criação de testes unitários utilizando **xUnit**.

---

## 📋 Sobre o projeto

O StreamingFlix possui regras relacionadas ao funcionamento dos planos de uma plataforma de streaming.

Atualmente, a aplicação possui três funcionalidades principais:

- Classificação do plano de acordo com a quantidade de telas simultâneas;
- Cálculo da mensalidade com desconto conforme o período contratado;
- Validação do acesso a conteúdo adulto de acordo com a idade e o controle parental.

A lógica dessas funcionalidades está concentrada na classe `PlanoStreamingService`.

---

## 🛠️ Tecnologias utilizadas

- **C#**
- **.NET 10**
- **xUnit 2.9.3**
- **Microsoft.NET.Test.Sdk**
- **xUnit Visual Studio Runner**
- **Coverlet**
- **Git**
- **GitHub**

O projeto principal utiliza o framework `Microsoft.NET.Sdk` e tem como alvo o **.NET 10.0**.

O projeto de testes também utiliza .NET 10 e possui dependências do xUnit, Microsoft.NET.Test.Sdk e Coverlet para execução e cobertura dos testes.

---

## 📁 Estrutura do projeto

```text
StreamingFlix/
│
├── StreamingFlix.App/
│   ├── PlanoStreamingService.cs
│   └── StreamingFlix.App.csproj
│
├── StreamingFlix.Tests/
│   ├── PlanoStreamingServiceTests.cs
│   └── StreamingFlix.Tests.csproj
│
├── StreamingFlix.slnx
├── LICENSE
└── README.md
```

### StreamingFlix.App

Projeto principal da aplicação.

Nele está localizada a classe:

```text
PlanoStreamingService
```

Essa classe concentra as regras de negócio relacionadas aos planos do StreamingFlix.

### StreamingFlix.Tests

Projeto responsável pelos testes automatizados da aplicação.

Ele possui uma referência ao projeto `StreamingFlix.App`, permitindo que as classes e métodos da aplicação sejam utilizados durante os testes.

---

## ⚙️ Requisitos

Para executar o projeto, é necessário ter instalado:

- **.NET SDK 10.0 ou superior**
- **Git**

Para verificar a versão do .NET instalada:

```bash
dotnet --version
```

O projeto está configurado para utilizar o framework:

```text
net10.0
```

---

## 🚀 Como executar o projeto

### 1. Clonar o repositório

No terminal, execute:

```bash
git clone https://github.com/dev-Anthonym/streaming-flix-xunit.git
```

Entre na pasta do projeto:

```bash
cd streaming-flix-xunit
```

---

### 2. Restaurar as dependências

Execute:

```bash
dotnet restore
```

Esse comando restaura os pacotes necessários para o projeto e para a execução dos testes.

---

### 3. Compilar a solução

Execute:

```bash
dotnet build
```

Esse comando realiza a compilação dos projetos presentes na solução.

---

## 🧪 Executando os testes

Para executar os testes automatizados, utilize:

```bash
dotnet test
```

O comando executa o projeto `StreamingFlix.Tests` e apresenta no terminal a quantidade de testes executados, aprovados e, caso existam, os testes que apresentaram falhas.

O projeto utiliza **xUnit** como framework de testes. A configuração atual utiliza:

```text
xunit                    2.9.3
Microsoft.NET.Test.Sdk   17.14.1
xunit.runner.visualstudio 3.1.4
coverlet.collector       6.0.4
```


---

# 📊 Regras de negócio

## 1. Classificação do plano

O método:

```csharp
ObterClassificacaoPorQualidade(int telasSimultaneas)
```

determina a classificação do plano de acordo com a quantidade de telas simultâneas.

A implementação atual possui as seguintes regras:

| Telas simultâneas | Classificação |
|---:|---|
| 1 | BÁSICO |
| 2 | PADRÃO |
| 4 ou mais | PREMIUM |
| Outros valores | NÃO DEFINIDO |

A regra está implementada diretamente na classe `PlanoStreamingService`.

### Exemplos

```text
1 tela  → BÁSICO
2 telas → PADRÃO
4 telas → PREMIUM
5 telas → PREMIUM
10 telas → PREMIUM
```

Valores que não correspondem às condições acima retornam:

```text
NÃO DEFINIDO
```

Por exemplo:

```text
0 telas → NÃO DEFINIDO
3 telas → NÃO DEFINIDO
```

---

## 2. Cálculo da mensalidade com desconto

O método:

```csharp
CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
```

calcula o valor final da mensalidade considerando o período contratado.

As regras implementadas são:

| Meses contratados | Desconto |
|---:|---:|
| Menos de 6 meses | Sem desconto |
| 6 a 11 meses | 10% |
| 12 meses ou mais | 20% |


### Exemplos

Considerando uma mensalidade de `R$ 50,00`:

```text
1 mês  → R$ 50,00
6 meses → R$ 45,00
12 meses → R$ 40,00
```

O cálculo é realizado diretamente sobre o valor informado no parâmetro `valorBase`.

---

## 3. Validação de acesso a conteúdo adulto

O método:

```csharp
PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
```

verifica se o usuário pode acessar conteúdo adulto.

Para que o acesso seja permitido, as duas condições precisam ser verdadeiras:

1. O usuário deve possuir **18 anos ou mais**;
2. O controle parental deve estar **desativado**.

A implementação utiliza a seguinte condição:

```csharp
idade >= 18 && !controleParentalAtivo
```


### Exemplos

| Idade | Controle parental | Resultado |
|---:|:---:|---|
| 20 | Desativado | ✅ Permitido |
| 18 | Desativado | ✅ Permitido |
| 20 | Ativado | ❌ Negado |
| 16 | Desativado | ❌ Negado |

---

# 🧪 Testes unitários

O projeto possui um projeto separado chamado `StreamingFlix.Tests`, criado especificamente para os testes da aplicação.

A estrutura utiliza **xUnit** e referencia diretamente o projeto principal:

```text
StreamingFlix.Tests
        │
        └── referência
                ↓
        StreamingFlix.App
```


Os testes têm como objetivo verificar se as regras implementadas em `PlanoStreamingService` produzem os resultados esperados para diferentes entradas.

---

## 🔬 Testes parametrizados

A atividade utiliza testes parametrizados para verificar diferentes cenários de uma mesma regra.

Com xUnit, essa abordagem pode ser realizada utilizando recursos como:

```csharp
[Theory]
[InlineData(...)]
```

Isso permite executar o mesmo método de teste diversas vezes utilizando diferentes valores de entrada.

Por exemplo:

```csharp
[Theory]
[InlineData(1, "BÁSICO")]
[InlineData(2, "PADRÃO")]
[InlineData(4, "PREMIUM")]
public void DeveClassificarPlanoCorretamente(
    int telasSimultaneas,
    string resultadoEsperado)
{
    // execução do teste
}
```

Dessa maneira, uma única estrutura de teste pode validar vários cenários.

---

# 📈 Regras contempladas

A aplicação implementa as seguintes regras:

### Classificação

- ✅ 1 tela → BÁSICO
- ✅ 2 telas → PADRÃO
- ✅ 4 ou mais telas → PREMIUM
- ✅ Valores fora dessas condições → NÃO DEFINIDO

### Mensalidade

- ✅ Menos de 6 meses → sem desconto
- ✅ De 6 a 11 meses → 10% de desconto
- ✅ 12 meses ou mais → 20% de desconto

### Conteúdo adulto

- ✅ 18 anos ou mais + controle parental desativado → acesso permitido
- ❌ Controle parental ativado → acesso negado
- ❌ Menor de 18 anos → acesso negado

---

# 📦 Comandos principais

| Comando | Descrição |
|---|---|
| `dotnet restore` | Restaura as dependências do projeto |
| `dotnet build` | Compila a solução |
| `dotnet test` | Executa os testes automatizados |
| `dotnet --version` | Exibe a versão instalada do .NET |

---

# 📄 Licença

Este projeto está disponibilizado sob a **Licença MIT**.

Consulte o arquivo `LICENSE` presente no repositório para obter o texto completo da licença.

---

# 👥 Contribuidores

Projeto desenvolvido para fins acadêmicos na disciplina de **Garantia da Qualidade de Software / Gestão e Qualidade de Software**.

**Contribuidores:**

- Anthony Rafael Braga Magalhães
- Guilherme de Oliveira Navais

---

## 🔗 Repositório

[StreamingFlix — GitHub](https://github.com/dev-Anthonym/streaming-flix-xunit)
