using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número inteiro positivo: ");
        if (!int.TryParse(Console.ReadLine(), out int numero) || numero < 2)
        {
            Console.WriteLine("Erro: O número deve ser um inteiro maior ou igual a 2.");
            return;
        }

        int totalPrimos = ContarNumerosPrimos(numero);
        Console.WriteLine($"Total de números primos até {numero}: {totalPrimos}");
    }
    static int ContarNumerosPrimos(int limite)
    {
        int contador = 0;

        for (int i = 2; i <= limite; i++)
        {
            if (EhPrimo(i))
            {
                Console.WriteLine($"Número primo: {i}");
                contador++;
            }
        }

        return contador;
    }

    static bool EhPrimo(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}

