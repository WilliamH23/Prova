using System;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text.Json;

namespace Challange
{
    public class Program
    {
        public class Faturamento
        {
            public int dia { get; set; }
            public float valor { get; set; }
        }
        public static void Main()
        {
            int v = 1;
            int e = 0;
            while (v != 0)
            {
                Console.WriteLine("\nDigite o exercicio a ser realizado:\n-Digite 0 para encerrar-");
                try
                {
                    v = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Entrada inválida: {ex.Message}");
                    continue;
                }

                switch (v)
                {
                    case 1:
                        //1)  int INDICE = 13, SOMA = 0, K = 0;
                        //Enquanto K<INDICE faça { K = K + 1; SOMA = SOMA + K; }
                        //Imprimir(SOMA);
                        // Ao final do processamento, qual será o valor da variável SOMA ?
                        int indice = 13, soma = 0, k = 0;
                        while (k < indice)
                        {
                            k = k + 1;
                            soma = soma + k;
                        }
                        Console.WriteLine($"O valor da variável SOMA é: {soma}");
                        break;
                    case 2:
                        //2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma 
                        //    dos 2 valores anteriores(exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), escreva um programa na 
                        //    linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne 
                        //    uma mensagem avisando se o número informado pertence ou não a sequência.
                        Console.WriteLine("Digite um número para verificar se pertence a sequência de Fibonacci:");
                        string input = Console.ReadLine();
                        int num;
                        if (!int.TryParse(input, out num))
                        {
                            Console.WriteLine("Entrada inválida. Tente novamente.");
                            continue;
                        }

                        int a = 0, b = 1, c = 0;
                        while (c < num)
                        {
                            c = a + b;
                            a = b;
                            b = c;
                        }
                        if (c == num)
                        {
                            Console.WriteLine($"{num} pertence a sequência de Fibonacci.");
                        }
                        else
                        {
                            Console.WriteLine($"{num} não pertence a sequência de Fibonacci.");
                        }
                        break;
                    case 3:
                        //3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa,
                        //na linguagem que desejar, que calcule e retorne:
                        //O menor valor de faturamento ocorrido em um dia do mês;
                        // O maior valor de faturamento ocorrido em um dia do mês;
                        // Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.

                        //IMPORTANTE:
                        //a) Usar o json ou xml disponível como fonte dos dados do faturamento mensal;
                        //b) Podem existir dias sem faturamento, como nos finais de semana e feriados.
                        //Estes dias devem ser ignorados no cálculo da médio
                        float menorFaturamento = float.MaxValue; ;
                        float maiorFaturamento = 0;
                        float totalFaturamento = 0;
                        int contador = 0;
                        string caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"dados.json");
                        string jsonContent = File.ReadAllText(caminho);
                        var faturamentos = JsonSerializer.Deserialize<List<Faturamento>>(jsonContent);
                        foreach (var faturamento in faturamentos)
                        {
                            if (faturamento.valor > 0)
                            {
                                contador++;
                            }
                            if (faturamento.valor < menorFaturamento)
                            {
                                menorFaturamento = faturamento.valor;
                            }
                            if (faturamento.valor > maiorFaturamento)
                            {
                                maiorFaturamento = faturamento.valor;
                            }
                            totalFaturamento += faturamento.valor;

                        }
                        Console.WriteLine("O menor faturamento foi:" + menorFaturamento);
                        Console.WriteLine("O maior faturamento foi:" + maiorFaturamento);
                        Console.WriteLine("A média de faturamento foi:" + (totalFaturamento / contador));
                        int countDiasMaiorFatura = 0;
                        foreach (var faturamento in faturamentos)
                        {
                            if (faturamento.valor > (totalFaturamento / contador))
                            {
                                countDiasMaiorFatura++;
                            }
                        }
                        Console.WriteLine("Número de dias no mês em que o valor de faturamento diário foi superior à média mensal: " + countDiasMaiorFatura);
                        break;
                    case 4:
                        //4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
                        //• SP – R$67.836,43
                        //• RJ – R$36.678,66
                        //• MG – R$29.229,88
                        //• ES – R$27.165,48
                        //• Outros – R$19.849,53

                        //Escreva um programa na linguagem que desejar onde calcule o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.  
                        double sp = 67836.43d, rj = 36678.66d, mg = 29229.88d;
                        double es = 27165.48, outros = 19849.53d;


                        double total = sp + rj + mg + es + outros;

                        Console.WriteLine($"Peso SP: {(sp / total) * 100:F2}%");
                        Console.WriteLine($"Peso RJ: {(rj / total) * 100:F2}%");
                        Console.WriteLine($"Peso MG: {(mg / total) * 100:F2}%");
                        Console.WriteLine($"Peso ES: {(es / total) * 100:F2}%");
                        Console.WriteLine($"Peso Outros: {(outros / total) * 100:F2}%");
                        break;

                    case 5:
                        //5) Escreva um programa que inverta os caracteres de um strinng
                        //IMPORTANTE:
                        //a) Essa string pode ser informada através de qualquer entrada de sua preferência ou pode ser previamente definida no código;
                        //b) Evite usar funções prontas, como, por exemplo, reverse;


                        Console.WriteLine("Digite um texto:\n");
                        String texto = Console.ReadLine();

                        for (int i = texto.Length - 1; i >= 0; i--)
                        {
                            Console.Write(texto[i]);
                        }
                        break;
                }

            }


        }
    }
}