/*
Fecha Creación: 11/06/2020,
Tipo:Tabla
Nombre: Cliente
Observaciones:Tabla para almacenar datos del cliente, el idCliente es autoincrementable
*/

CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](13) NOT NULL,
	[nombres] [varchar](32) NOT NULL,
	[apellidos] [varchar](32) NOT NULL,
	[fechaNacimiento] [datetime] NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](16) NOT NULL,
	[email] [varchar](32) NOT NULL,
	[fechaCreacion] [datetime] NULL,
	[fechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


