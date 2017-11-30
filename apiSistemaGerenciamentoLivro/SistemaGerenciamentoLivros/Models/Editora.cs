using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciamentoLivros.Models
{
    public class Editora
    {
        [Key]
        public int IdEditora { get; set; }
        public string Nome { get; set; }
    }
}