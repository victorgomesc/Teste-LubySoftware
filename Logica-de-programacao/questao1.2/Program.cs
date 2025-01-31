using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o valor do prêmio: ");
        if (!double.TryParse(Console.ReadLine(), out double valor) || valor <= 0)
        {
            Console.WriteLine("Erro: O valor do prêmio deve ser um número maior que zero.");
            return;
        }

        Console.Write("Digite o tipo de prêmio (basic, vip, premium, deluxe, special): ");
        string tipo = Console.ReadLine().ToLower();

        Console.Write("Digite um fator de multiplicação próprio (ou pressione Enter para usar o padrão): ");
        string fatorInput = Console.ReadLine();
        double? fatorPersonalizado = string.IsNullOrWhiteSpace(fatorInput) ? (double?)null : double.Parse(fatorInput);

        try
        {
            double resultado = CalcularPremio(valor, tipo, fatorPersonalizado);
            Console.WriteLine($"O valor total do prêmio é: {resultado:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static double CalcularPremio(double valor, string tipo, double? fatorPersonalizado)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor do prêmio deve ser maior que zero.");

        var fatores = new System.Collections.Generic.Dictionary<string, double>
        {
            { "basic", 1.0 },
            { "vip", 1.2 },
            { "premium", 1.5 },
            { "deluxe", 1.8 },
            { "special", 2.0 }
        };

        double fator = fatorPersonalizado ?? (fatores.ContainsKey(tipo) ? fatores[tipo] : 1.0);

        return valor * fator;
    }
}

