using Microsoft.AspNetCore.Mvc;
using PedidosApi.Data;
using PedidosApi.Models;
using PedidosApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService serviceCliente;
        public ClienteController(IClienteService srvCliente)
        {
            this.serviceCliente = srvCliente;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> getAll() {
            try
            {
                List<Cliente> lista = new List<Cliente>();
                lista = await serviceCliente.getAll();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("getClientesDropDown")]
        public async Task<ActionResult<List<ClienteViewModel>>> getClientesDropDown()
        {
            try
            {
                List<ClienteViewModel> lista = new List<ClienteViewModel>();
                lista = await serviceCliente.getClientesDropDown();

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> getById(int id)
        {
            try
            {
                Cliente item = new Cliente();
                item = await serviceCliente.getById(id);

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> create(Cliente cliente)
        {
            try
            {
                await serviceCliente.insert(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Cliente>> update(Cliente cliente)
        {
            try
            {
                Cliente item = new Cliente();
                item = await serviceCliente.update(cliente);
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
                await serviceCliente.delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
