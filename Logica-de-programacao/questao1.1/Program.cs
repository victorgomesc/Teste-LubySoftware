using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número para calcular o fatorial: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            try
            {
                long resultado = CalcularFatorial(numero);
                Console.WriteLine($"O fatorial de {numero} é {resultado}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida! Digite um número inteiro válido.");
        }
    }
    static long CalcularFatorial(int numero)
    {
        if (numero < 0)
            throw new ArgumentException("O número não pode ser negativo.");

        long resultado = 1;
        for (int i = 2; i <= numero; i++)
        {
            resultado *= i;
        }
        return resultado;
    }
}

