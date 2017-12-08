using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frases_S2.Models
{
   public class ModelCategorias
    {
        public string Titulo { get; set; }
        public string Pasta { get; set; }//esta propriedade vai representar o nome da pasta referente à categoria, pois algumas categorias possuem acentuação e não podem ser nomes de arquivos e pastas
        public int Itens { get; set; }
    }
}
