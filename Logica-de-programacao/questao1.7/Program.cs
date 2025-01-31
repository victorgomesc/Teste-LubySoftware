using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o tamanho do vetor: ");
        int tamanho = int.Parse(Console.ReadLine());

        int[] vetor = new int[tamanho];

        for (int i = 0; i < tamanho; i++)
        {
            Console.Write($"Digite o valor para a posição {i}: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }

        int[] pares = ObterElementosPares(vetor);

        Console.WriteLine("Elementos pares:");
        foreach (int num in pares)
        {
            Console.WriteLine(num);
        }
    }

    static int[] ObterElementosPares(int[] vetor)
    {
        int count = 0;
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] % 2 == 0)
            {
                count++;
            }
        }

        int[] pares = new int[count];

        int index = 0;
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] % 2 == 0)
            {
                pares[index] = vetor[i];
                index++;
            }
        }

        return pares;
    }
}
