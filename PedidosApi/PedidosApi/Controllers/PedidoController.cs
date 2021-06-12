using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosApi.Data;
using PedidosApi.Models;
using PedidosApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoService servicePedido;
        public PedidoController(IPedidoService srvPedido)
        {
            this.servicePedido = srvPedido;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> getAll()
        {
            try
            {
                List<Pedido> lista = new List<Pedido>();
                lista = await servicePedido.getAll();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAllPedidoCliente")]
        public async Task<ActionResult<List<PedidoClienteViewModel>>> getAllPedidoCliente()
        {
            try
            {
                List<PedidoClienteViewModel> lista = new List<PedidoClienteViewModel>();
                lista = await servicePedido.getAllPedidoCliente();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> getById(int id)
        {
            try
            {
                Pedido item = new Pedido();
                item = await servicePedido.getById(id);

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> create(Pedido pedido)
        {
            try
            {
                await servicePedido.insert(pedido);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Pedido>> update(Pedido pedido)
        {
            try
            {
                Pedido item = new Pedido();
                item = await servicePedido.update(pedido);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            try
            {
                await servicePedido.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
