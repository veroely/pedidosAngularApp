using PedidosApi.Data;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Services
{
    public interface IPedidoService
    {
        public Task<List<Pedido>> getAll();

        public Task<List<PedidoClienteViewModel>> getAllPedidoCliente();
        public Task<Pedido> getById(int id);

        public Task<Pedido> insert(Pedido pedido);

        public Task<Pedido> update(Pedido pedido);

        public Task delete(int id);
    }
}
