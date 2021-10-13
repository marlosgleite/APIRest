using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaPedidosController : ControllerBase
    {
        bancotesteContext db = new bancotesteContext();

        [HttpGet]
        public List<Encomendum> Get(int pagina,string token)
        {
            
            Encomendum Pedido = new Encomendum();
            List<Encomendum> ListaPedido = new List<Encomendum>();

            if (db.Clientes.Where(x => x.Token == token).FirstOrDefault() == null)
            {
                Pedido.condToken = "token inválido";
                ListaPedido.Add(Pedido);
                return ListaPedido;
            }            

            try
            {
                var Lista = (from e in db.Encomenda
                               join r in db.RelEncomendaProdutos on e.Id equals r.IdEncomenda
                               join ent in db.Entregadors on r.IdEntregador equals ent.Id
                               select new Encomendum()
                               {
                                   DateCreate = e.DateCreate,
                                   DateDelivery = e.DateDelivery,
                                   Endereco = e.Endereco,
                                   produto = (from p in db.Produtos
                                              join rel in db.RelEncomendaProdutos on p.Id equals r.IdProduto
                                              where rel.Id == r.Id
                                              select new Produto()
                                              {
                                                  Nome = p.Nome,
                                                  Descricao = p.Descricao,
                                                  Valor = p.Valor
                                              }).ToList(),
                                   entregador = {Nome = ent.Nome, Descricao = ent.Descricao, Placa = ent.Placa},
                                   
                               }).ToList().OrderByDescending(x => x.DateCreate);

                var ListaTake = Lista.Skip((pagina - 1) * 20).Take(20);

                var totalLista = Lista.Count();

                foreach (var item in ListaTake)
                {
                    Pedido.DateCreate = item.DateCreate;
                    Pedido.DateDelivery = item.DateDelivery;
                    Pedido.totalPedidos = totalLista;
                    Pedido.Endereco = item.Endereco;
                    Pedido.produto = item.produto;
                    Pedido.entregador = item.entregador;

                    ListaPedido.Add(Pedido);
                }                

                return ListaPedido;
                
            }
            catch(Exception e)
            {
                Pedido.erroInterno = e.Message;
                ListaPedido.Add(Pedido);
                return ListaPedido;
            }            
            
            
        }
    }
}
