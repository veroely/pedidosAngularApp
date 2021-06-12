using Microsoft.EntityFrameworkCore;
using PedidosApi.Data;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Services
{

    public class ClienteService:IClienteService
    {
        private PedidosDBContext ctx;

        public ClienteService(PedidosDBContext context)
        {
            this.ctx = context;
        }


        public async Task<List<Cliente>> getAll() {

            try
            {
                List<Cliente> lista = new List<Cliente>();
                lista = await ctx.Cliente.ToListAsync();

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClienteViewModel>> getClientesDropDown()
        {

            try
            {
                List<ClienteViewModel> lista = new List<ClienteViewModel>();
                lista = await (from cliente in ctx.Cliente
                               select new ClienteViewModel
                               {
                                   IdCliente = cliente.IdCliente,
                                   NombreCliente = cliente.Dni + " - " + cliente.Apellidos + " - " + cliente.Nombres
                               }).ToListAsync();

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> getById(int id)
        {

            try
            {
                Cliente  item = new Cliente();
                item = await ctx.Cliente.FindAsync(id);

                return item;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> insert(Cliente cliente)
        {

            try
            {
                Cliente itemBusqueda = await ctx.Cliente.Where(w => w.Dni == cliente.Dni).FirstOrDefaultAsync();
                if (itemBusqueda != null)
                {
                    throw new Exception("El número de cédula ya esta registrado");
                }
                else {
                    await ctx.Cliente.AddAsync(cliente);
                    await ctx.SaveChangesAsync();
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> update(Cliente cliente)
        {

            try
            {
                Cliente itemBusqueda = await ctx.Cliente.Where(w => w.IdCliente == cliente.IdCliente).FirstOrDefaultAsync();
                if (itemBusqueda != null)
                {
                    itemBusqueda.Nombres = cliente.Nombres;
                    itemBusqueda.Apellidos = cliente.Apellidos;
                    itemBusqueda.FechaNacimiento = cliente.FechaNacimiento;
                    itemBusqueda.Direccion = cliente.Direccion;
                    itemBusqueda.Telefono = cliente.Telefono;
                    itemBusqueda.Email = cliente.Email;
                    itemBusqueda.FechaModificacion = DateTime.Now;

                    ctx.Update(itemBusqueda);
                    await ctx.SaveChangesAsync();
                }
                else
                {
                    

                    throw new Exception("El cliente no se encuentra registrado");
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
                Cliente itemBusqueda = await ctx.Cliente.Where(w => w.IdCliente == id).FirstOrDefaultAsync();
                if (itemBusqueda != null)
                {
                    ctx.Cliente.Remove(itemBusqueda);
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
