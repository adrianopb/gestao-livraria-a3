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
        public List<Comentario> Comentarios { get; set; }

        public IEnumerable<Livro> BuscarLivros(int? id)
        {
            var v_ListaLivros = new List<Livro>(ListaLivros());

            if (id != null)
            {
                return v_ListaLivros.Any(q => q.Id == id) ? v_ListaLivros.Where(q => q.Id == id) : null;
            }

            return v_ListaLivros;
        }

        public Livro BuscarLivroNoCarrinho(int p_CarrinhoId, int p_LivroId)
        {
            CarrinhoLivros v_CarrinhoLivros = new CarrinhoLivros();
            List<CarrinhoLivros> v_CarrinhosLivros = new List<CarrinhoLivros>();

            v_CarrinhosLivros = CarrinhoLivros.GerarCarrinhoLivros();
            v_CarrinhoLivros = v_CarrinhosLivros.SingleOrDefault(q => q.Id == p_CarrinhoId);
            
//            if (v_CarrinhoLivros == null)
//            {
//                404
//            }

            Livro v_Livro = new Livro();

            v_Livro = v_CarrinhoLivros.Livros.SingleOrDefault(q => q.Id == p_LivroId);
            
//            if (v_Livro == null)
//            {
//                404
//            }

            return v_Livro;
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
