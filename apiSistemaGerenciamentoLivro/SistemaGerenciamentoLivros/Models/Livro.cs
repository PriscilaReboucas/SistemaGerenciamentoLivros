using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaGerenciamentoLivros.Models
{
    public class Livro
    {
        [Key]        
        public int IdLivro { get; set; }
        public int CodigoLivro { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Nome { get; set; }

        public Editora Editora { get; set; }

        public int AnoLancamento { get; set; }

        [Required(AllowEmptyStrings = false)]
        public Autor Autor { get; set; }

    }
}