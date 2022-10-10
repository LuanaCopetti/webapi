namespace APIProdutos.Models
{
    public class Produto
    {
        private string _codigoBr;
        public string CodigoBr
        {
            get => _codigoBr;
            set => _codigoBr = value?.Trim().ToUpper();
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim();
        }

        public double Preco { get; set; }
    }
}