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
    public class PedidosController : ControllerBase
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

        // GET v1/pedidos/5
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            Pedido v_Pedido = new Pedido();
            v_Pedido = v_Pedido.BuscarPedidos(id);
            
            //if (v_Pedido == null)
            //{
            //falta gerar a exceção
            //}

            return v_Pedido;
        }

        // POST v1/pedidos
        [HttpPost]
        public Pedido Post([Bind("Id,CarrinhoLivros,Status")] Pedido Pedido)
        {
            //if (value.Id <= 100)
            //{
            //  falta gerar a exceção
            //}
            
            return new Pedido()
            {
                Id = Pedido.Id,
                CarrinhoLivros = Pedido.CarrinhoLivros,
                Status = Pedido.StatusDictionary()[2]
            };
        }

        // PUT v1/pedidos/5
        [HttpPut("{id}")]
        public Pedido Put(int id)
        {
            //if (value.Id <= 100)
            //{
            //  falta gerar a exceção
            //}
            
            Pedido Pedido = new Pedido();
            return Pedido.RealizarPedido(id);
        }
    }
}
