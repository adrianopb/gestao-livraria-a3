using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLivraria.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Livro> BuscarLivros(int? id)
        {
            var v_ListaLivros = new List<Livro>(ListaLivros());

            if (id != null)
            {
                return v_ListaLivros.Any(q => q.Id == id) ? v_ListaLivros.Where(q => q.Id == id) : null;
            }

            return v_ListaLivros;
        }

        public IEnumerable<Livro> ListaLivros()
        {
            var v_ListaLivros = new List<Livro>();

            for (int i = 1; i <= 100; i++)
            {
                var v_Livro = new Livro()
                {
                    Id = i,
                    Nome = "Livro " + i,
                };

                v_ListaLivros.Add(v_Livro);
            }

            return v_ListaLivros;
        }
    }
}
