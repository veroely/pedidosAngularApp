using Microsoft.EntityFrameworkCore;
using PedidosApi.Data;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Services
{
    public class PedidoService:IPedidoService
    {
        private PedidosDBContext ctx;

        public PedidoService(PedidosDBContext context)
        {
            this.ctx = context;
        }

        public async Task<List<Pedido>> getAll()
        {

            try
            {
                List<Pedido> lista = new List<Pedido>();
                lista = await ctx.Pedido.ToListAsync();

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PedidoClienteViewModel>> getAllPedidoCliente()
        {

            try
            {
                List<PedidoClienteViewModel> lista = new List<PedidoClienteViewModel>();
                lista = await (from pedido in ctx.Pedido
                               join cliente in ctx.Cliente on pedido.IdCliente equals cliente.IdCliente
                               select new PedidoClienteViewModel
                               {
                                   IdPedido = pedido.IdPedido,
                                   FechaCreacion = pedido.FechaCreacion,
                                   Codigo = pedido.Codigo,
                                   IdCliente = cliente.IdCliente,
                                   Cliente = cliente.Apellidos + " " + cliente.Nombres,
                                   Dni = cliente.Dni
                               }).ToListAsync();

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> getById(int id)
        {

            try
            {
                Pedido item = new Pedido();
                item = await ctx.Pedido.FindAsync(id);

                return item;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> insert(Pedido pedido)
        {

            try
            {
                Pedido itemBusqueda = await ctx.Pedido.Where(w => w.Codigo == pedido.Codigo).FirstOrDefaultAsync();
                if (itemBusqueda != null)
                {
                    throw new Exception("El código del pedido ya existe");
                }
                else
                {
                    Cliente cliente = new Cliente();
                    cliente = await ctx.Cliente.FindAsync(pedido.IdCliente);
                    if (cliente != null)
                    {
                        await ctx.Pedido.AddAsync(pedido);
                        await ctx.SaveChangesAsync();
                    }
                    else {
                        throw new Exception("El cliente no existe");
                    }
                }

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> update(Pedido pedido)
        {

            try
            {
                Pedido itemBusqueda = await ctx.Pedido.Where(w => w.IdPedido == pedido.IdPedido).FirstOrDefaultAsync();
                if (itemBusqueda != null)
                {
                    itemBusqueda.Codigo = pedido.Codigo;
                    itemBusqueda.FechaCreacion = pedido.FechaCreacion;
                    itemBusqueda.IdCliente = pedido.IdCliente;
                    itemBusqueda.FechaModificacion = DateTime.Now;
                    ctx.Update(itemBusqueda);
                    await ctx.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El pedido no esta registrado");
                }

                return itemBusqueda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task delete(int id)
        {

            try
            {
                Pedido itemBusqueda = await ctx.Pedido.Where(w => w.IdPedido == id).FirstOrDefaultAsync();
                if (itemBusqueda != null)
                {
                    ctx.Pedido.Remove(itemBusqueda);
                    await ctx.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El cliente no existe");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
