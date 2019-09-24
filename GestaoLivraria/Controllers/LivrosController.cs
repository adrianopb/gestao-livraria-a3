using System;
using System.Collections.Generic;
using GestaoLivraria.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivraria.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        // GET api/livros/5

        /// <summary>
        /// Lista todos os livros
        /// </summary>
        /// <returns>Informações relativas a todos os livros</returns>
        [HttpGet]
        public IEnumerable<Livro> Get()
        {
            var v_Livro = new Livro();
            var v_ListaLivros = new List<Livro>();
            v_ListaLivros = v_Livro.ListaLivros();
            return v_ListaLivros;
        }
        
        /// <summary>
        /// Procura livro específico
        /// </summary>
        /// <param name="id">Identificador do livro</param>
        /// <returns>Informações relativas a um livro específico</returns>
        [HttpGet("{id}")]
        public Livro GetById(int id)
        {
            Livro v_Livro = new Livro();

            v_Livro = v_Livro.BuscarLivro(id);

            if (v_Livro == null) {
                throw new Exception("404 não encontrado");
            }

            return v_Livro;
        }

        // POST api/livros
        
        /// <summary>
        /// Cadastra livro
        /// </summary>
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
        
        // POST v1/livros/{id}/comentarios
        
        /// <summary>
        /// Publica comentário do livro
        /// </summary>
        [HttpPost]
        [Route("{id}/comentarios")]
        public Livro Post([FromRoute] int id,[Bind("Texto")] string texto)
        {

            Livro v_Livro = new Livro();
            v_Livro = v_Livro.BuscarLivro(id);
            
            //if (v_Livro == null)
            //{
            //  404
            //}
            
            Comentario v_Comentario = new Comentario();
            v_Livro = v_Comentario.CriarComentario(id, texto);

            return v_Livro;
        }
    }
}
