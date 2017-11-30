using System.ComponentModel.DataAnnotations;

namespace SistemaGerenciamentoLivros.Models
{
    public class Autor
    {
        [Key]       
        public int IdAutor { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }
    }
}