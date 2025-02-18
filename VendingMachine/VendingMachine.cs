using System;
using System.Collections.Generic;

public class VendingMachine
{
    private List<Product> estoque = new List<Product>();
    private decimal totalVendas = 0;

    public VendingMachine()
    {
        InicializarEstoque();
    }

    private void InicializarEstoque()
    {
        estoque.Add(new Product("Refrigerante", 5.00m, 10));
        estoque.Add(new Product("Suco", 4.50m, 8));
        estoque.Add(new Product("Água", 2.00m, 15));
    }

    public void MostrarEstoque()
    {
        Console.WriteLine("Estoque disponível:");
        foreach (var product in estoque)
        {
            Console.WriteLine($"{product.Nome} - R${product.Preco} ({product.Quantidade} disponíveis)");
        }
    }

    public void VenderProduct()
    {
        Product product = SelecionarProduct();
        if (product == null) return;

        decimal valorInserido = SolicitarPagamento(product);
        if (valorInserido >= product.Preco)
        {
            FinalizarVenda(product, valorInserido);
        }
    }

    private Product SelecionarProduct()
    {
        Console.Write("Digite o nome do produto desejado: ");
        string? nomeProduct = Console.ReadLine();

        if (string.IsNullOrEmpty(nomeProduct))
        {
            Console.WriteLine("Nome do produto não pode ser vazio.");
            return null;
        }

        Product? product = estoque.Find(p => p.Nome.Equals(nomeProduct, StringComparison.OrdinalIgnoreCase));

        if (product == null || product.Quantidade == 0)
        {
            Console.WriteLine("Produto indisponível ou esgotado!");
            return null;
        }

        return product;
    }

    private decimal SolicitarPagamento(Product product)
    {
        Console.WriteLine($"Preço do {product.Nome}: R${product.Preco}");
        decimal valorInserido = 0;

        while (valorInserido < product.Preco)
        {
            Console.Write("Insira o valor: R$");
            string? input = Console.ReadLine();

            if (input != null && decimal.TryParse(input, out decimal valor))
            {
                valorInserido += valor;
                if (valorInserido < product.Preco)
                {
                    Console.WriteLine($"Falta R${product.Preco - valorInserido}");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido, tente novamente.");
            }
        }

        return valorInserido;
    }

    private void FinalizarVenda(Product product, decimal valorInserido)
    {
        decimal troco = valorInserido - product.Preco;
        product.Quantidade--;
        totalVendas += product.Preco;

        Console.WriteLine($"Compra realizada! Pegue seu {product.Nome}.");
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
