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
        // GET v1/pedidos/5
        /// <summary>
        /// Consulta pedido para ver status e detalhes
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(int id)
        {
            Pedido v_Pedido = new Pedido();
            v_Pedido = v_Pedido.BuscarPedidos(id);

            if (v_Pedido == null)
            {
                return NotFound();
            }

            return Ok(v_Pedido);
        }

        // POST v1/pedidos
        /// <summary>
        /// Confirma o pedido
        /// </summary>
        [HttpPost]
        public ActionResult<Pedido> Post([Bind("Id,CarrinhoLivros,Status")] Pedido Pedido)
        {
            return Ok(new Pedido()
            {
                Id = Pedido.Id,
                CarrinhoLivros = Pedido.CarrinhoLivros,
                Status = Pedido.StatusDictionary()[2]
            });
        }

        // PUT v1/pedidos/5
        /// <summary>
        /// Envia o pedido para entrega
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult<Pedido> Put(int id)
        {
            Pedido v_Pedido = new Pedido();
            
            return Ok(v_Pedido.RealizarPedido(id));
        }
    }
}
