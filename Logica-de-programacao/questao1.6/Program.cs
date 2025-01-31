using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite a primeira data (DDMMAAAA): ");
        string data1 = Console.ReadLine();

        Console.Write("Digite a segunda data (DDMMAAAA): ");
        string data2 = Console.ReadLine();

        try
        {
            int diferenca = CalcularDiferencaData(data1, data2);
            Console.WriteLine($"Diferença de dias: {diferenca}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static int CalcularDiferencaData(string data1, string data2)
    {
        if (data1.Length != 8 || data2.Length != 8)
        {
            throw new ArgumentException("Formato de data inválido. Use DDMMAAAA.");
        }

        int dia1 = int.Parse(data1.Substring(0, 2));
        int mes1 = int.Parse(data1.Substring(2, 2));
        int ano1 = int.Parse(data1.Substring(4, 4));

        int dia2 = int.Parse(data2.Substring(0, 2));
        int mes2 = int.Parse(data2.Substring(2, 2));
        int ano2 = int.Parse(data2.Substring(4, 4));

        int dias1 = ConverterParaDias(dia1, mes1, ano1);
        int dias2 = ConverterParaDias(dia2, mes2, ano2);

        return Math.Abs(dias2 - dias1);
    }

    static int ConverterParaDias(int dia, int mes, int ano)
    {
        int[] diasPorMes = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int totalDias = dia + (ano * 365) + ((ano - 1) / 4) - ((ano - 1) / 100) + ((ano - 1) / 400);

        for (int i = 0; i < mes - 1; i++)
        {
            totalDias += diasPorMes[i];
        }

        return totalDias;
    }
}

