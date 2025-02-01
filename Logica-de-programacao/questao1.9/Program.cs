using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite os números separados por vírgula:");
        string entrada = Console.ReadLine();
        
        int[][] resultado = TransformarEmMatriz(entrada);
        
        foreach (var subArray in resultado)
        {
            Console.WriteLine("[ " + string.Join(", ", subArray) + " ]");
        }
    }

    static int[][] TransformarEmMatriz(string numeros)
    {
        string[] partes = numeros.Split(',');
        int[] valores = new int[partes.Length];
        for (int i = 0; i < partes.Length; i++)
        {
            valores[i] = int.Parse(partes[i]);
        }
        
        int quantidadeSubArrays = (valores.Length + 1) / 2;
        int[][] matriz = new int[quantidadeSubArrays][];
        
        for (int i = 0; i < quantidadeSubArrays; i++)
        {
            int tamanho = (i * 2 + 1 < valores.Length) ? 2 : 1;
            matriz[i] = new int[tamanho];
            for (int j = 0; j < tamanho; j++)
            {
                matriz[i][j] = valores[i * 2 + j];
            }
        }
        
        return matriz;
    }
}

