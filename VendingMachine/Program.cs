using System;

class Program
{
    private static void ExibirMenu()
    {
        Console.WriteLine("\n1. Ver estoque\n2. Comprar produto\n3. Ver total de vendas\n4. Sair");
        Console.Write("Escolha uma opção: ");
    }

    private static bool ProcessarOpcao(VendingMachine vendingMachine, string? opcao)
    {
        switch (opcao)
        {
            case "1":
                vendingMachine.MostrarEstoque();
                break;
            case "2":
                vendingMachine.VenderProduct();
                break;
            case "3":
                vendingMachine.MostrarTotalVendas();
                break;
            case "4":
                return false;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
        return true;
    }
    static void Main()
    {
        VendingMachine vendingMachine = new VendingMachine();
        
        while (true)
        {
            ExibirMenu();
            string? opcao = Console.ReadLine();
            
            if (!ProcessarOpcao(vendingMachine, opcao)) break;
        }
    }
}