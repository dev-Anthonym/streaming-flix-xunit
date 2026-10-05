# 🎬 StreamingFlix

Aplicação desenvolvida em **JAVA com .NET 10**, criada para representar regras de negócio de uma plataforma de streaming. O projeto também possui uma suíte de **testes unitários utilizando xUnit**, com testes parametrizados para validar as principais regras da aplicação.

O projeto foi desenvolvido como atividade da disciplina de **Garantia da Qualidade de Software / Gestão e Qualidade de Software**.

---

## 📋 Sobre o projeto

O **StreamingFlix** possui regras relacionadas aos planos de streaming, cálculo de mensalidade com desconto e controle de acesso a conteúdo adulto.

As principais funcionalidades implementadas são:

- Classificação do plano de acordo com a quantidade de telas simultâneas;
- Cálculo da mensalidade com descontos conforme o período contratado;
- Validação do acesso a conteúdo adulto considerando a idade do usuário e o controle parental;
- Testes unitários parametrizados utilizando **xUnit**.

---

## 🛠️ Tecnologias utilizadas

- **JAVA**
- **.NET 10**
- **xUnit**
- **.NET CLI**
- **Git**
- **GitHub**

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
├── StreamingFlix.sln
├── .gitignore
├── LICENSE
└── README.md
```

---

## ⚙️ Requisitos

Para executar o projeto, é necessário ter instalado:

- **.NET SDK 10.0 ou superior**
- **Git**

Para verificar se o .NET está instalado:

```bash
dotnet --version
```

O projeto utiliza **.NET 10**, conforme especificado na atividade.

---

## 🚀 Como executar o projeto

### 1. Clonar o repositório

No terminal, execute:

```bash
git clone https://github.com/SEU-USUARIO/streaming-flix-xunit.git
```

Depois, entre na pasta do projeto:

```bash
cd streaming-flix-xunit
```

> Substitua `SEU-USUARIO` pelo seu usuário do GitHub.

### 2. Restaurar as dependências

Execute:

```bash
dotnet restore
```

### 3. Compilar a solução

Execute:

```bash
dotnet build
```

Se não houver erros, o projeto estará pronto para execução e testes.

### 4. Executar a aplicação

Para executar o projeto principal:

```bash
dotnet run --project StreamingFlix.App
```

---

## 🧪 Testes unitários

Os testes foram desenvolvidos utilizando o framework **xUnit** e os atributos `[Theory]` e `[InlineData]`, permitindo executar uma mesma regra com diferentes conjuntos de dados.

Para executar todos os testes, utilize:

```bash
dotnet test
```

O objetivo é garantir que todos os cenários definidos para as regras de negócio sejam executados com sucesso. A atividade estabelece como objetivo a aprovação de **100% dos cenários de teste**.

---

## ✅ Regras de negócio testadas

### 1. Classificação dos planos

A classificação é definida de acordo com a quantidade de telas simultâneas:

| Telas simultâneas | Classificação |
|---:|---|
| 1 | BÁSICO |
| 2 | PADRÃO |
| 4 ou mais | PREMIUM |

Esses cenários são testados através de testes parametrizados:

```csharp
[InlineData(1, "BÁSICO")]
[InlineData(2, "PADRÃO")]
[InlineData(4, "PREMIUM")]
```

A regra está definida na atividade da disciplina.

---

### 2. Cálculo da mensalidade

O desconto aplicado depende da quantidade de meses contratados:

| Meses contratados | Desconto |
|---:|---:|
| Menos de 6 meses | Sem desconto |
| 6 a 11 meses | 10% |
| 12 meses ou mais | 20% |

Exemplos utilizados nos testes:

```csharp
[InlineData(50, 1, 50)]
[InlineData(50, 6, 45)]
[InlineData(50, 12, 40)]
```

Esses testes verificam o valor da mensalidade antes e depois da aplicação dos descontos.

---

### 3. Acesso a conteúdo adulto

O usuário somente poderá acessar conteúdo adulto quando:

- Possuir **18 anos ou mais**;
- O **controle parental estiver desativado**.

A regra utiliza as duas condições simultaneamente.

Casos testados:

```csharp
[InlineData(20, false, true)]
[InlineData(20, true, false)]
[InlineData(16, false, false)]
```

Ou seja:

| Idade | Controle parental | Acesso |
|---:|:---:|:---:|
| 20 | Desativado | ✅ Permitido |
| 20 | Ativado | ❌ Negado |
| 16 | Desativado | ❌ Negado |

A atividade determina que o método retorne `true` somente quando a idade for igual ou superior a 18 anos **e** o controle parental estiver desativado.

---

## 🧩 Testes parametrizados

Os testes utilizam o `[Theory]` do xUnit juntamente com `[InlineData]`.

Essa abordagem permite testar diferentes entradas para o mesmo método sem precisar criar um teste separado para cada cenário.

Por exemplo:

```csharp
[Theory]
[InlineData(1, "BÁSICO")]
[InlineData(2, "PADRÃO")]
[InlineData(4, "PREMIUM")]
public void DeveClassificarPlanoCorretamente(
    int telasSimultaneas,
    string classificacaoEsperada)
{
    // teste
}
```

Dessa forma, o mesmo teste é executado diversas vezes com valores diferentes.

A atividade solicita a utilização dessa abordagem para os testes de classificação, desconto e validação de acesso.

---

## 📊 Cobertura dos testes

A suíte de testes cobre as principais regras de negócio implementadas no projeto:

- ✅ Classificação dos planos;
- ✅ Aplicação de desconto de 10%;
- ✅ Aplicação de desconto de 20%;
- ✅ Ausência de desconto;
- ✅ Acesso permitido a conteúdo adulto;
- ✅ Bloqueio pelo controle parental;
- ✅ Bloqueio para menores de idade.

Para validar os testes, execute:

```bash
dotnet test
```

O resultado esperado é que todos os cenários sejam aprovados.

---

## 📌 Comandos principais

| Comando | Função |
|---|---|
| `dotnet restore` | Restaura as dependências |
| `dotnet build` | Compila o projeto |
| `dotnet run --project StreamingFlix.App` | Executa a aplicação |
| `dotnet test` | Executa os testes unitários |

---

## 👥 Contribuidores

Projeto desenvolvido para fins acadêmicos na disciplina de **Garantia da Qualidade de Software / Gestão e Qualidade de Software**.

**Contribuidores:**

- Nome do aluno 1
- Nome do aluno 2
- Nome do aluno 3
- Nome do aluno 4
- Nome do aluno 5

> Substitua os nomes acima pelos integrantes da equipe.

---

## 📄 Licença

Este projeto está disponibilizado sob a licença **MIT**.
