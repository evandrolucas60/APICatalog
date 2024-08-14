namespace ApiCatalogo.DTOs
{
    public class ProdutoDTOUpdateResponse
    {
        public int ProdutoId { get; set; }
        public string? nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
    }
}
