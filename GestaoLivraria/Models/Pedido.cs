using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoLivraria.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public CarrinhoLivros CarrinhoLivros { get; set; }

        public Dictionary<int, string> StatusDictionary()
        {
            return new Dictionary<int, string>
            {
                {1 , "Em andamento"},
                {2 , "Aprovado"},
                {3 , "A caminho"},
                {4 , "Entregue"}
            };
        }
    
        public Pedido BuscarPedidos(int id)
        {
            var v_ListaPedidos = new List<Pedido>(ListaPedidos());

            return v_ListaPedidos.SingleOrDefault(q => q.Id == id);
        }

        public Pedido RealizarPedido(int id)
        {
            var v_ListaPedidos = new List<Pedido>(ListaPedidos());
            Pedido v_Pedido = new Pedido();

            v_Pedido = v_ListaPedidos.SingleOrDefault(q => q.Id == id);

            //Verifica se o status do pedido é possível para colocar o pedido para entrega
//            if (v_Pedido.Status != StatusDictionary()[1])
//            {
//                Não é possível entregar esse pedido
//            }

//            if (v_Pedido == null)
//            {
//                404
//            }

            v_Pedido.Status = StatusDictionary()[2];
            
            //Deletar carrinho
            
            return v_Pedido;
        }

        public IEnumerable<Pedido> ListaPedidos()
        {
            var v_ListaPedidos = new List<Pedido>();

            for (int i = 1; i <= 100; i++)
            {
                CarrinhoLivros v_CarrinhoLivros = new CarrinhoLivros();
                v_CarrinhoLivros = v_CarrinhoLivros.BuscarCarrinhoLivros(i);

                var v_Pedido = new Pedido()
                {
                    Id = i,
                    CarrinhoLivros = v_CarrinhoLivros,
                    Status = StatusDictionary()[i%4 + 1],
                };

                v_ListaPedidos.Add(v_Pedido);
            }

            return v_ListaPedidos;
        }
    }
}
