using System;

class Program
{
    static void Main()
    {
        int[] vetor1 = new int[] { 1,2,3,4,5 };
        int[] vetor2 = new int[] { 1,2,5 };
        Console.WriteLine("[ " + string.Join(", ", ObterElementosFaltantes(vetor1, vetor2)) + " ]");

        int[] vetor3 = new int[] { 1,4,5 };
        int[] vetor4 = new int[] { 1,2,3,4,5 };
        Console.WriteLine("[ " + string.Join(", ", ObterElementosFaltantes(vetor3, vetor4)) + " ]");

        int[] vetor5 = new int[] { 1,2,3,4 };
        int[] vetor6 = new int[] { 2,3,4,5 };
        Console.WriteLine("[ " + string.Join(", ", ObterElementosFaltantes(vetor5, vetor6)) + " ]");

        int[] vetor7 = new int[] { 1,3,4,5 };
        int[] vetor8 = new int[] { 1,3,4,5 };
        Console.WriteLine("[ " + string.Join(", ", ObterElementosFaltantes(vetor7, vetor8)) + " ]");
    }

    static int[] ObterElementosFaltantes(int[] vetorA, int[] vetorB)
    {
        int[] temp = new int[vetorA.Length + vetorB.Length];
        int count = 0;

        foreach (int num in vetorA)
        {
            if (!ContemElemento(vetorB, num))
            {
                temp[count++] = num;
            }
        }

        foreach (int num in vetorB)
        {
            if (!ContemElemento(vetorA, num))
            {
                temp[count++] = num;
            }
        }

        int[] resultado = new int[count];
        Array.Copy(temp, resultado, count);
        Array.Sort(resultado);
        return resultado;
    }

    static bool ContemElemento(int[] vetor, int elemento)
    {
        foreach (int num in vetor)
        {
            if (num == elemento)
            {
                return true;
            }
        }
        return false;
    }
}

