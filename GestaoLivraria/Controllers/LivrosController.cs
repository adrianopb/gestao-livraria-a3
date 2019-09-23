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
    public class LivrosController : ControllerBase
    {
        // GET api/livros
        [HttpGet]
        //        public ActionResult<IEnumerable<Livro>> Get()
        //        {
        //            Livro v_Livro = new Livro();
        //            
        //            List<Livro> v_
        //            
        //            return new string[] { "value1", "value2" };
        //        }

        // GET api/livros/5
        [HttpGet("{id}")]
        public IEnumerable<Livro> Get(int? id)
        {
            Livro v_Livro = new Livro();
            IEnumerable<Livro> v_ListaLivros = new List<Livro>();

            v_ListaLivros = v_Livro.BuscarLivros(id);

            //if (v_ListaLivros == null)
            //{
                //falta gerar a exceção
            //}

            return v_ListaLivros;
        }

        // POST api/livros
        [HttpPost]
        public Livro Post([Bind("Id,Nome")] Livro Livro)
        {
            //if (value.Id <= 100)
            //{
            //  falta gerar a exceção
            //}

            return new Livro()
            {
                Id = Livro.Id,
                Nome = Livro.Nome
            };
        }

        // PUT api/livros/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/livros/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
