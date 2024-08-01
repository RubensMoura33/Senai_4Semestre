using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicios
{
    public class Livro
    {
        private static List<string> list = new List<string> { };

        public static int ListarNumeroDeLivros()
        {
            return list.Count;
        }
        public static int AdicionarLivro (string livro)
        {
            list.Add(livro);
            return list.Count;
        }
    }
}
