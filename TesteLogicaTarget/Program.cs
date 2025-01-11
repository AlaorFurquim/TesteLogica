
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Data;

// Questao 1

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Questão 1");

        int indice = 13;
        int soma = 0;

        for (int k = 1; k < indice; k++)
        {
            soma = soma + k;
        }

        Console.WriteLine("O valor de SOMA é: " + soma);

        // Questao 2

        Console.WriteLine();
        Console.WriteLine("Questão 2");
        Console.WriteLine();

        Console.WriteLine("Digite um numero");
        int numero = int.Parse(Console.ReadLine());
        while (numero < 0)
        {
            Console.WriteLine("Digite número maior que zero!");
            numero = int.Parse(Console.ReadLine());
        }

        int a = 0; int b = 1;

        while (a <= numero)
        {
            if (a == numero)
            {
                Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
            }

            int temp = a;
            a = b;
            b = temp + b;
        }


        // Questao 3

        Console.WriteLine();
        Console.WriteLine("Questão 3");
        Console.WriteLine();


        string primeroDados = @"C:\Users\Alaor\source\repos\TesteLogicaTarget\TesteLogicaTarget\dados.json";
        string segundoDados = @"C:\Users\Alaor\source\repos\TesteLogicaTarget\TesteLogicaTarget\dados1.json";



        var listaDeFaturamento = new List<FaturamentoDiario>();
        listaDeFaturamento.AddRange(JsonConvert.DeserializeObject<List<FaturamentoDiario>>(File.ReadAllText(primeroDados)));
        listaDeFaturamento.AddRange(JsonConvert.DeserializeObject<List<FaturamentoDiario>>(File.ReadAllText(segundoDados)));


        var diasComFaturamento = listaDeFaturamento.Where(f => f.Valor > 0).ToList();

        decimal menorFaturamento = diasComFaturamento.Min(f => f.Valor);
        decimal maiorFaturamento = diasComFaturamento.Max(f => f.Valor);
        decimal mediaMensal = diasComFaturamento.Average(f => f.Valor);
        int diasAcimaDaMedia = diasComFaturamento.Count(f => f.Valor > mediaMensal);

        // Exibe os resultados
        Console.WriteLine($"Menor valor de faturamento: {menorFaturamento:C}");
        Console.WriteLine($"Maior valor de faturamento: {maiorFaturamento:C}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");

        // Questao 4

        Console.WriteLine();
        Console.WriteLine("Questão 4");
        Console.WriteLine();

        DataTable faturamentoPorEstado = new DataTable();


        faturamentoPorEstado.Columns.Add("Estado", typeof(string));
        faturamentoPorEstado.Columns.Add("Faturamento", typeof(decimal));

        // Adiciona linhas com os estados e seus faturamentos
        faturamentoPorEstado.Rows.Add("SP", 67836.43m);
        faturamentoPorEstado.Rows.Add("RJ", 36678.66m);
        faturamentoPorEstado.Rows.Add("MG", 29229.88m);
        faturamentoPorEstado.Rows.Add("ES", 27165.48m);
        faturamentoPorEstado.Rows.Add("Outros", 19849.53m);

        decimal somaTotal = 0;

        for(int i = 0; i < faturamentoPorEstado.Rows.Count; i++)
        {
            somaTotal = somaTotal + Convert.ToDecimal(faturamentoPorEstado.Rows[i]["Faturamento"].ToString());
        }

        for (int i = 0; i < faturamentoPorEstado.Rows.Count; i++)
        {
            decimal percentualIndividual = (Convert.ToDecimal(faturamentoPorEstado.Rows[i]["Faturamento"].ToString()) / somaTotal) * 100;
            Console.WriteLine( "Percentual:" + $"{faturamentoPorEstado.Rows[i]["Estado"].ToString()}: {percentualIndividual:F2}%");
        }
        Console.WriteLine();
        Console.WriteLine($"\nFaturamento total: {somaTotal:C}");

        Console.WriteLine();
        Console.WriteLine("Questão 5");
        Console.WriteLine();

        Console.WriteLine("Digite uma palavra!");
        string resposta = Console.ReadLine();

        char[] inverteResposta = new char[resposta.Length];

        int inverter = 0;

        for (int i = resposta.Length - 1; i >= 0;i--)
        {
            inverteResposta[inverter] = resposta[i];
            inverter++;
        }

        string respostaInvertida = new string(inverteResposta);
        Console.WriteLine("String invertida: " + respostaInvertida.ToString());
    }
}

class FaturamentoDiario
{
    public int Dia { get; set; }
    public decimal Valor { get; set; }
}