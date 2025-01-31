using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o valor (ex: R$ 6.800,00): ");
        string valorEntrada = Console.ReadLine();

        Console.Write("Digite o desconto (ex: 30%): ");
        string descontoEntrada = Console.ReadLine();

        try
        {
            string resultado = CalcularValorComDescontoFormatado(valorEntrada, descontoEntrada);
            Console.WriteLine($"Valor com desconto: {resultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static string CalcularValorComDescontoFormatado(string valor, string desconto)
    {
        if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(desconto))
        {
            throw new ArgumentException("Valor e desconto não podem ser vazios.");
        }

        valor = valor.Replace("R$", "").Trim();
        valor = valor.Replace(".", ""); 
        valor = valor.Replace(",", "."); 

        decimal valorNumerico;
        if (!decimal.TryParse(valor, out valorNumerico) || valorNumerico <= 0)
        {
            throw new ArgumentException("Valor inválido.");
        }

        desconto = desconto.Replace("%", "").Trim();
        decimal descontoNumerico;
        if (!decimal.TryParse(desconto, out descontoNumerico) || descontoNumerico < 0 || descontoNumerico > 100)
        {
            throw new ArgumentException("Desconto inválido.");
        }

        decimal valorComDesconto = valorNumerico * (1 - (descontoNumerico / 100));

        string valorFormatado = "R$ " + valorComDesconto.ToString("0.00").Replace(".", ",");

        return valorFormatado;
    }
}
