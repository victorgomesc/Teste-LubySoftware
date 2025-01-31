using System;
using System.Collections.Generic;

public class VendingMachine
{
    private List<Produto> estoque = new List<Produto>();
    private decimal totalVendas = 0;

    public VendingMachine()
    {
        InicializarEstoque();
    }

    private void InicializarEstoque()
    {
        estoque.Add(new Produto("Refrigerante", 5.00m, 10));
        estoque.Add(new Produto("Suco", 4.50m, 8));
        estoque.Add(new Produto("Agua", 2.00m, 15));
    }

    public void MostrarEstoque()
    {
        Console.WriteLine("Estoque disponível:");
        foreach (var produto in estoque)
        {
            Console.WriteLine($"{produto.Nome} - R${produto.Preco} ({produto.Quantidade} disponíveis)");
        }
    }

    public void VenderProduto()
    {
        Produto produto = SelecionarProduto();
        if (produto == null) return;

        decimal valorInserido = SolicitarPagamento(produto);
        if (valorInserido >= produto.Preco)
        {
            FinalizarVenda(produto, valorInserido);
        }
    }

    private Produto SelecionarProduto()
    {
        Console.Write("Digite o nome do produto desejado: ");
        string nomeProduto = Console.ReadLine("");

        Produto produto = estoque.Find(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));

        if (produto == null || produto.Quantidade == 0)
        {
            Console.WriteLine("Produto indisponível!");
            return null;
        }

        return produto;
    }

    private decimal SolicitarPagamento(Produto produto)
    {
        Console.WriteLine($"Preço do {produto.Nome}: R${produto.Preco}");
        decimal valorInserido = 0;

        while (valorInserido < produto.Preco)
        {
            Console.Write("Insira o valor: R$");
            if (decimal.TryParse(Console.ReadLine(), out decimal valor))
            {
                valorInserido += valor;
                if (valorInserido < produto.Preco)
                {
                    Console.WriteLine($"Falta R${produto.Preco - valorInserido}");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido, tente novamente.");
            }
        }

        return valorInserido;
    }

    private void FinalizarVenda(Produto produto, decimal valorInserido)
    {
        decimal troco = valorInserido - produto.Preco;
        produto.Quantidade--;
        totalVendas += produto.Preco;

        Console.WriteLine($"Compra realizada! Pegue seu {produto.Nome}.");
        if (troco > 0)
        {
            Console.WriteLine($"Seu troco: R${troco}");
        }
    }

    public void MostrarTotalVendas()
    {
        Console.WriteLine($"Total de vendas: R${totalVendas}");
    }
}
