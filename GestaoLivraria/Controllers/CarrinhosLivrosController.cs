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
        // GET v1/pedidos
        [HttpGet]
        //        public ActionResult<IEnumerable<Pedido>> Get()
        //        {
        //            Pedido v_Pedido = new Pedido();
        //            
        //            List<Pedido> v_
        //            
        //            return new string[] { "value1", "value2" };
        //        }
        
        // POST v1/carrinhosLivros/{id_carrinhosLivros}/livro/{id_livros}
        [HttpPost]
        public CarrinhoLivros Post([Bind("Id")] CarrinhoLivros p_CarrinhoLivros, [Bind("Id")] Livro p_Livro)
        {
            //Limpar código
            CarrinhoLivros v_CarrinhoLivrosAdicionar = new CarrinhoLivros();
            v_CarrinhoLivrosAdicionar = v_CarrinhoLivrosAdicionar.BuscarCarrinhoLivros(p_CarrinhoLivros.Id);

//            if (v_CarrinhoLivrosAdicionar == null)
//            {
//                404
//            }

            Livro v_Livro = new Livro();
            IEnumerable<Livro> v_LivroAdicionar = new List<Livro>();
            v_LivroAdicionar = v_Livro.BuscarLivros(p_Livro.Id);

//            if (v_LivroAdicionar == null)
//            {
//                404
//            }

            v_Livro = v_LivroAdicionar.First();
            v_CarrinhoLivrosAdicionar.Livros.Add(v_Livro);
            return v_CarrinhoLivrosAdicionar;
        }

        // DELETE v1/carrinhosLivros/{id_carrinhosLivros}/livro/{id_livros}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
