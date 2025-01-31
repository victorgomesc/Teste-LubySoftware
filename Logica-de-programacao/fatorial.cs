using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite um número inteiro: ");
        string input = Console.ReadLine();
        
        int.TryParse(input, out int n); 
        
        if (n < 0)
        {
            Console.WriteLine("Numeros negativos não são aceitos");
        }
        else
        {
            int resultado = 1;
            for (int i = 2; i <= n; i++)
            {
                resultado *= i;
            }
            Console.WriteLine($"O fatorial de {n} é {resultado}.");
        }
    }
}