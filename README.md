# 🎬 StreamingFlix

Projeto desenvolvido em **Java** para representar regras de negócio de uma plataforma de streaming, com foco em **qualidade de software e testes unitários**.

O projeto foi desenvolvido como atividade da disciplina de **Garantia da Qualidade de Software / Gestão e Qualidade de Software**.

A aplicação implementa regras relacionadas à classificação dos planos, cálculo de mensalidade com desconto e controle de acesso a conteúdo adulto.

---

## 📋 Sobre o projeto

O **StreamingFlix** possui três principais regras de negócio:

- Classificação do plano de acordo com a quantidade de telas simultâneas;
- Cálculo da mensalidade de acordo com o período contratado;
- Validação do acesso a conteúdo adulto considerando a idade do usuário e o controle parental.

Além da aplicação, foram desenvolvidos **testes unitários parametrizados** para verificar o funcionamento dessas regras.

---

## 🛠️ Tecnologias utilizadas

- **Java**
- **JUnit**
- **Maven**
- **Git**
- **GitHub**

---

## 📁 Estrutura do projeto

```text
StreamingFlix/
│
├── src/
│   ├── main/
│   │   └── java/
│   │       └── ...
│   │
│   └── test/
│       └── java/
│           └── ...
│
├── pom.xml
├── .gitignore
├── LICENSE
└── README.md
```

---

## ⚙️ Requisitos

Para executar o projeto, é necessário ter instalado:

- **JDK 17 ou superior**
- **Maven**
- **Git**

Para verificar a versão do Java instalada:

```bash
java -version
```

Para verificar o Maven:

```bash
mvn -version
```

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

### 2. Compilar o projeto

Execute:

```bash
mvn compile
```

### 3. Executar os testes

Para executar toda a suíte de testes:

```bash
mvn test
```

Se todos os testes forem executados corretamente, o Maven apresentará o resultado no terminal.

---

## 🧪 Testes unitários

Os testes unitários foram desenvolvidos utilizando **JUnit**, com o objetivo de validar as principais regras de negócio da aplicação.

Foram criados testes para:

- Classificação dos planos;
- Cálculo da mensalidade com desconto;
- Validação do acesso a conteúdo adulto.

---

## 📊 Regras de negócio

### 1. Classificação dos planos

A classificação do plano é determinada pela quantidade de telas simultâneas:

| Telas simultâneas | Plano |
|---:|---|
| 1 | BÁSICO |
| 2 | PADRÃO |
| 4 ou mais | PREMIUM |

Casos de teste:

```text
1 tela  → BÁSICO
2 telas → PADRÃO
4 telas → PREMIUM
```

Esses são os cenários definidos na atividade.

---

### 2. Cálculo da mensalidade

O valor da mensalidade recebe desconto conforme a quantidade de meses contratados:

| Período contratado | Desconto |
|---:|---:|
| Menos de 6 meses | Sem desconto |
| 6 a 11 meses | 10% |
| 12 meses ou mais | 20% |

Exemplos:

```text
Valor: R$ 50,00
1 mês  → R$ 50,00

Valor: R$ 50,00
6 meses → R$ 45,00

Valor: R$ 50,00
12 meses → R$ 40,00
```

Esses cenários são especificados na atividade.

---

### 3. Validação de acesso a conteúdo adulto

O acesso ao conteúdo adulto somente deve ser permitido quando o usuário:

- Possuir **18 anos ou mais**;
- Estiver com o **controle parental desativado**.

Casos de teste:

| Idade | Controle parental | Resultado |
|---:|:---:|:---:|
| 20 | Desativado | ✅ Permitido |
| 20 | Ativado | ❌ Negado |
| 16 | Desativado | ❌ Negado |

Esses cenários fazem parte dos casos de teste definidos na atividade.

---

## 🧪 Testes parametrizados

Os testes podem utilizar os recursos de parametrização disponibilizados pelo **JUnit**, permitindo executar o mesmo teste com diferentes conjuntos de valores.

Por exemplo, o teste de classificação pode verificar diferentes quantidades de telas:

```java
@ParameterizedTest
@CsvSource({
    "1, BÁSICO",
    "2, PADRÃO",
    "4, PREMIUM"
})
void deveClassificarPlanoCorretamente(
        int telasSimultaneas,
        String classificacaoEsperada) {

    // teste
}
```

Essa abordagem permite testar vários cenários sem precisar criar um método de teste separado para cada entrada.

A atividade solicita testes parametrizados para as regras de classificação, desconto e validação de acesso.

---

## 📈 Cobertura dos testes

A suíte de testes contempla as principais regras de negócio:

- ✅ Classificação do plano BÁSICO;
- ✅ Classificação do plano PADRÃO;
- ✅ Classificação do plano PREMIUM;
- ✅ Mensalidade sem desconto;
- ✅ Desconto de 10%;
- ✅ Desconto de 20%;
- ✅ Acesso permitido para maiores de idade sem controle parental;
- ✅ Bloqueio pelo controle parental;
- ✅ Bloqueio para menores de idade.

Para executar todos os testes:

```bash
mvn test
```

O objetivo é garantir que todos os cenários definidos sejam executados com sucesso.

---

## 📌 Principais comandos

| Comando | Descrição |
|---|---|
| `mvn compile` | Compila o projeto |
| `mvn test` | Executa os testes unitários |
| `java -version` | Verifica a versão do Java |
| `mvn -version` | Verifica a versão do Maven |

---

## 👥 Contribuidores

Projeto desenvolvido para fins acadêmicos na disciplina de **Garantia da Qualidade de Software / Gestão e Qualidade de Software**.

**Contribuidores:**

- Anthony Rafael Braga Magalhães
- Guilherme de Oliveira Navais

---

## 📄 Licença

Este projeto está disponibilizado sob a licença **MIT**.

---

## 📄 Licença

Este projeto está disponibilizado sob a licença **MIT**.
