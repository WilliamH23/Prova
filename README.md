# Projeto dos 5 Exercícios

Este projeto contém 5 exercícios de C#, abordando lógica de programação e manipulação de dados.

## Estrutura do Projeto

1. **Exercício 1**: Soma de números de 1 a 5.
2. **Exercício 2**: Verifica se um número está na sequência de Fibonacci.
3. **Exercício 3**: Calcula menor, maior faturamento e dias com faturamento acima da média (requere `dados.json`).
4. **Exercício 4**: Calcula percentual de faturamento por estado.
5. **Exercício 5**: Inverte uma string.

## Pré-requisitos

- Visual Studio 2022 ou superior.
- .NET 9.0 ou superior.

## Como Configurar

1. **Clone o Repositório**:
    ```bash
    git clone https://github.com/WilliamH23/Prova.git
    ```

2. **Adicione o Arquivo `dados.json`**:
    - Copie o `dados.json` para a pasta `bin\Debug\net8.0` do seu projeto.

    Caminho:  
    ```
    <diretório_do_projeto>\bin\Debug\net8.0\dados.json
    ```

## Como Executar

1. Abra o projeto no Visual Studio.
2. Certifique-se de que o arquivo `dados.json` está na pasta correta.
3. Execute o código.

## Observações

- O código acessa o arquivo `dados.json` usando:
  ```csharp
  string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados.json");
  ATENÇÂO:
  Isso significa que voce deve colar seu arquivo dados.json nas pasta "net8.0\" caso queira executar o Exercicio 3.
