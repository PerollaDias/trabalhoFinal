namespace Trabalho
{
    class Cliente
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Nascimento { get; set; }

        public string Telefone { get; set; }

        public Cliente()
        {

        }

        public Cliente(string nome, string cpf, string nascimento, string telefone)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Nascimento = nascimento;
            this.Telefone = telefone;

        }
    }

}
