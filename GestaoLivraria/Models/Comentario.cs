using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLivraria.Models
{
    public class Comentario
    {
        public string Texto  { get; set; }

        public Livro CriarComentario(int p_LivroId, string p_Text)
        {
            Livro v_Livro = new Livro();
            IEnumerable<Livro> v_Livros = new List<Livro>();
            
            v_Livros = v_Livro.BuscarLivros(p_LivroId);
            v_Livro = v_Livros.Single();
            
            Comentario v_Comentario = new Comentario()
            {
                Texto = p_Text
            };
            
            v_Livro.Comentarios.Add(v_Comentario);

            return v_Livro;
        }

//        public IEnumerable<Comentario> ListaComentario()
//        {
//            var v_ListaComentario = new List<Comentario>();
//
//            for (int i = 1; i <= 100; i++)
//            {
//                List<Livro> v_ListaLivros = new List<Livro>();
//
//                for (int z = 1; z <= ((i%5)*5) + 1; z++)
//                {
//                    var v_Livro = new Livro()
//                    {
//                        Id = z*(i%3 + 1),
//                        Nome = "Livro " + z*(i%3 + 1)
//                    };
//
//                    v_ListaLivros.Add(v_Livro);
//                }
//
//                var v_Comentario = new Comentario()
//                {
//                    Id = i,
//                    Comentario = v_ListaLivros,
//                    Status = StatusDictionary()[i%4 + 1],
//                };
//
//                v_ListaComentario.Add(v_Comentario);
//            }
//
//            return v_ListaComentario;
//        }
    }
}
