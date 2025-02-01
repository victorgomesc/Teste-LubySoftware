using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o tamanho do vetor: ");
        int tamanho = int.Parse(Console.ReadLine());

        string[] vetor = new string[tamanho];

        for (int i = 0; i < tamanho; i++)
        {
            Console.Write($"Digite o nome para a posição {i}: ");
            vetor[i] = Console.ReadLine();
        }

        Console.Write("Digite o termo de busca: ");
        string termoBusca = Console.ReadLine();

        string[] resultados = BuscarPessoa(vetor, termoBusca);

        Console.WriteLine("Resultados da busca:");
        foreach (string resultado in resultados)
        {
            Console.WriteLine(resultado);
        }
    }

    static string[] BuscarPessoa(string[] vetor, string termoBusca)
    {
        int count = 0;
        for (int i = 0; i < vetor.Length; i++)
        {
            if (ContemTermo(vetor[i], termoBusca))
            {
                count++;
            }
        }

        string[] resultados = new string[count];

        int index = 0;
        for (int i = 0; i < vetor.Length; i++)
        {
            if (ContemTermo(vetor[i], termoBusca))
            {
                resultados[index] = vetor[i];
                index++;
            }
        }

        return resultados;
    }

    static bool ContemTermo(string texto, string termoBusca)
    {
        if (termoBusca.Length > texto.Length)
        {
            return false;
        }

        for (int i = 0; i <= texto.Length - termoBusca.Length; i++)
        {
            bool encontrado = true;
            for (int j = 0; j < termoBusca.Length; j++)
            {
                if (texto[i + j] != termoBusca[j])
                {
                    encontrado = false;
                    break;
                }
            }
            if (encontrado)
            {
                return true;
            }
        }

        return false;
    }
}
