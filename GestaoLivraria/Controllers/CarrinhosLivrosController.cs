using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GestaoLivraria.Models;
using GestaoLivraria.Util.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class CarrinhosLivrosController : ControllerBase
    {
        // POST v1/carrinhosLivros/{id_carrinhosLivros}/livros/{id_livros}
        /// <summary>
        /// Adiciona livro ao carrinho
        /// </summary>
        [HttpPost]
        [Route("{idCarrinhosLivros:int}/livros/{idLivros:int}")]
        public ActionResult<CarrinhoLivros> Post([FromRoute] int idCarrinhosLivros, [FromRoute] int idLivros)
        {
            //Limpar código
            CarrinhoLivros v_CarrinhoLivrosAdicionar = new CarrinhoLivros();
            v_CarrinhoLivrosAdicionar = v_CarrinhoLivrosAdicionar.BuscarCarrinhoLivros(idCarrinhosLivros);

            if (v_CarrinhoLivrosAdicionar == null)
            {
                return NotFound();
            }

            Livro v_LivroAdicionar = new Livro();
            v_LivroAdicionar = v_LivroAdicionar.BuscarLivro(idLivros);

            if (v_LivroAdicionar == null)
            {
                return NotFound();
            }

            v_CarrinhoLivrosAdicionar.Livros.Add(v_LivroAdicionar);
            return v_CarrinhoLivrosAdicionar;
        }

        // DELETE v1/carrinhosLivros/{id_carrinhosLivros}/livros/{id_livros}
        /// <summary>
        /// Remove livro do carrinho
        /// </summary>
        [HttpDelete]
        [Route("{idCarrinhosLivros}/livros/{idLivros}")]
        public ActionResult<CarrinhoLivros> Delete([FromRoute] int idCarrinhosLivros, [FromRoute] int idLivros)
        {
            CarrinhoLivros v_CarrinhoLivrosRemover = new CarrinhoLivros();
            v_CarrinhoLivrosRemover = v_CarrinhoLivrosRemover.BuscarCarrinhoLivros(idCarrinhosLivros);

            if (v_CarrinhoLivrosRemover == null)
            {
                return NotFound();
            }
            
            Livro v_LivroRemover = new Livro();
            v_LivroRemover = v_LivroRemover.BuscarLivroNoCarrinho(idCarrinhosLivros, idLivros);

            if (v_LivroRemover == null)
            {
                return NotFound();
            }
            
            v_CarrinhoLivrosRemover.Livros.RemoveAll(q => q.Id == v_LivroRemover.Id);
            
            return Ok(v_CarrinhoLivrosRemover);
        }
    }
}
