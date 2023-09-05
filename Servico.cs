namespace Trabalho
{
    internal class Servico
    {
        public string Nome { get; set; }

        public string Profissional { get; set; }

        public string Descrição { get; set; }

        public string Valor { get; set; }

        public Servico()
        {

        }

        public Servico(string nome, string profissional, string descricao, string valor)
        {
            this.Nome = nome;
            this.Profissional = profissional;
            this.Descrição = descricao;
            this.Valor = valor;

        }

    }
}
