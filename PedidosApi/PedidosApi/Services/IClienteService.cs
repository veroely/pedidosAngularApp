using PedidosApi.Data;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Services
{
    public interface IClienteService
    {
        public Task<List<Cliente>> getAll();
        public Task<List<ClienteViewModel>> getClientesDropDown();

        public Task<Cliente> getById(int id);

        public Task<Cliente> insert(Cliente cliente);

        public Task<Cliente> update(Cliente cliente);

        public Task delete(int id);
    }
}
