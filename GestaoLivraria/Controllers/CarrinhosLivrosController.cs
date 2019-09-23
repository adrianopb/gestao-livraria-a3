using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GestaoLivraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CarrinhosLivrosController : ControllerBase
    {
        // POST v1/carrinhosLivros/{id_carrinhosLivros}/livros/{id_livros}
        [HttpPost]
        [Route("{idCarrinhosLivros:int}/livros/{idLivros:int}")]
        public CarrinhoLivros Post([FromRoute] int idCarrinhosLivros, [FromRoute] int idLivros)
        {
            //Limpar código
            CarrinhoLivros v_CarrinhoLivrosAdicionar = new CarrinhoLivros();
            v_CarrinhoLivrosAdicionar = v_CarrinhoLivrosAdicionar.BuscarCarrinhoLivros(idCarrinhosLivros);

//            if (v_CarrinhoLivrosAdicionar == null)
//            {
//                404 (carrinho não encontrado)
//            }

            Livro v_Livro = new Livro();
            IEnumerable<Livro> v_LivroAdicionar = new List<Livro>();
            v_LivroAdicionar = v_Livro.BuscarLivros(idLivros);

//            if (v_LivroAdicionar == null)
//            {
//                404 (livro não encontrado)
//            }

            v_Livro = v_LivroAdicionar.First();
            v_CarrinhoLivrosAdicionar.Livros.Add(v_Livro);
            return v_CarrinhoLivrosAdicionar;
        }

        // DELETE v1/carrinhosLivros/{id_carrinhosLivros}/livros/{id_livros}
        [HttpDelete]
        [Route("{idCarrinhosLivros}/livros/{idLivros}")]
        public CarrinhoLivros Delete([FromRoute] int idCarrinhosLivros, [FromRoute] int idLivros)
        {
            CarrinhoLivros v_CarrinhoLivrosRemover = new CarrinhoLivros();
            v_CarrinhoLivrosRemover = v_CarrinhoLivrosRemover.BuscarCarrinhoLivros(idCarrinhosLivros);
            
            Livro v_LivroRemover = new Livro();
            v_LivroRemover = v_LivroRemover.BuscarLivroNoCarrinho(idCarrinhosLivros, idLivros);
            
            v_CarrinhoLivrosRemover.Livros.RemoveAll(q => q.Id == v_LivroRemover.Id);
            
            return v_CarrinhoLivrosRemover;
        }
    }
}
