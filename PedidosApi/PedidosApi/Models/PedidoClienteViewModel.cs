using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Models
{
    public class PedidoClienteViewModel
    {
        public int IdPedido { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdCliente { get; set; }
        public string Dni { get; set; }
        public string Cliente { get; set; }
    }
}
