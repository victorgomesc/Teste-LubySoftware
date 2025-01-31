using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma frase ou palavra: ");
        string entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("Erro: A entrada não pode ser vazia.");
            return;
        }

        int totalVogais = CalcularVogais(entrada);
        Console.WriteLine($"Total de vogais na string: {totalVogais}");
    }

    static int CalcularVogais(string texto)
    {
        int contador = 0;
        string vogais = "aeiouAEIOU";

        foreach (char c in texto)
        {
            if (vogais.Contains(c))
            {
                contador++;
            }
        }

        return contador;
    }
}

