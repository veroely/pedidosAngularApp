import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { Router } from '@angular/router';
import { IPedidoCliente } from '../../core/models';
import { PedidoService } from '../../core/services';

@Component({
  selector: 'app-list-pedido',
  templateUrl: './list-pedido.component.html',
  styleUrls: ['./list-pedido.component.css']
})
export class ListPedidoComponent implements OnInit {
  title:string ="Lista de Pedidos"
  lPedidos:IPedidoCliente[] = [];
  lPedidosFilter:IPedidoCliente[] = [];

  constructor(
    private router:Router
    ,private spinner: NgxSpinnerService
    ,private srvPedido:PedidoService) { }

  ngOnInit(): void {
    this.getAllPedidos();
  }

  getAllPedidos(){
    this.spinner.show();
    this.srvPedido.getAllPedidoCliente().subscribe(
      resp=>{
        this.lPedidos = resp;
        this.lPedidosFilter = resp;
        this.spinner.hide();
      },
      err=>{
        console.log(err.error);
        this.spinner.hide();
      });
  }

  edit(idPedido:number){
    this.router.navigate(['editar/', idPedido]);
  }

  delete(idPedido:number){
    this.spinner.show();
    this.srvPedido.delete(idPedido).subscribe(
      resp=>{
        this.spinner.hide();
        this.getAllPedidos();
      },
      err=>{
        this.spinner.hide();
        console.log(err.error);
      }
    )
  }

  search(event: any) {
    let itembuscado = event.target.value as string;
    if (itembuscado) {
      this.lPedidos = this.lPedidosFilter.filter(f => f.dni.includes(itembuscado)
        || f.cliente.toLocaleUpperCase().includes(itembuscado.toLocaleUpperCase())
        || f.codigo.toLocaleUpperCase().includes(itembuscado.toLocaleUpperCase())
      );
    } else {
      this.lPedidos = this.lPedidosFilter;
    }
  }
}
