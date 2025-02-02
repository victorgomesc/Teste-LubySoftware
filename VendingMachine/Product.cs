// Produto.cs
public class Product
{
    public string Nome { get; }
    public decimal Preco { get; }
    public int Quantidade { get; set; }

    public Product(string nome, decimal preco, int quantidade)
    {
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }
}
