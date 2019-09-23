using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLivraria.Models
{
    public class CarrinhoLivros
    {
        public int Id  { get; set; }
        public List<Livro> Livros  { get; set; }

        public CarrinhoLivros BuscarCarrinhoLivros(int p_Id)
        {
            CarrinhoLivros v_CarrinhoLivros = new CarrinhoLivros();
            List<CarrinhoLivros> v_CarrinhosLivros = new List<CarrinhoLivros>();

            v_CarrinhosLivros = CarrinhoLivros.GerarCarrinhoLivros();
            v_CarrinhoLivros = v_CarrinhosLivros.SingleOrDefault(q => q.Id == p_Id);
            
//            if (v_CarrinhoLivros == null)
//            {
//                404
//            }

            return v_CarrinhoLivros;
        }

        public static List<CarrinhoLivros> GerarCarrinhoLivros()
        {
            List<CarrinhoLivros> v_CarrinhosLivros = new List<CarrinhoLivros>();

            for (int i = 1; i <= 100; i++)
            {
                List<Livro> v_ListLivros = new List<Livro>();
                
                for (int z = 1; z <= ((i%5)*5) + 1; z++)
                {
                    var v_Livro = new Livro()
                    {
                        Id = z*(i%3 + 1),
                        Nome = "Livro " + z*(i%3 + 1)
                    };
                    
                    v_ListLivros.Add(v_Livro);
                }
                
                var v_CarrinhoLivros = new CarrinhoLivros()
                {
                    Id = i,
                    Livros = v_ListLivros,
                };
                
                v_CarrinhosLivros.Add(v_CarrinhoLivros);
            }

            return v_CarrinhosLivros;
        }

//        public IEnumerable<CarrinhoLivros> ListaCarrinhoLivros()
//        {
//            var v_ListaCarrinhoLivros = new List<CarrinhoLivros>();
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
//                var v_CarrinhoLivros = new CarrinhoLivros()
//                {
//                    Id = i,
//                    CarrinhoLivros = v_ListaLivros,
//                    Status = StatusDictionary()[i%4 + 1],
//                };
//
//                v_ListaCarrinhoLivros.Add(v_CarrinhoLivros);
//            }
//
//            return v_ListaCarrinhoLivros;
//        }
    }
}
