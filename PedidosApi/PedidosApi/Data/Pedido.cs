using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PedidosApi.Data
{
    public partial class Pedido
    {
        public int IdPedido { get; set; }
        public string Codigo { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
    }
}
