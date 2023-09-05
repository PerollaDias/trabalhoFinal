public class Produto
{
    public string Nome { get; set; }
    public string Código { get; set; }
    public string Descrição { get; set; }
    public string Valor { get; set; }
    public string Quantidade { get; set; }

    public Produto()
    {

    }

    public Produto(string nome, string codigo, string descricao, string valor, string quantidade)
    {
        this.Nome = nome;
        this.Código = codigo;
        this.Descrição = descricao;
        this.Valor = valor;
        this.Quantidade = quantidade;
    }
}