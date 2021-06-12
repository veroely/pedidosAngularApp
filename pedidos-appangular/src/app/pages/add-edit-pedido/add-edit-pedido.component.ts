import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from "ngx-spinner";
import { ClienteService, PedidoService } from '../../core/services';
import { IPedido } from '../../core/models';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-edit-pedido',
  templateUrl: './add-edit-pedido.component.html',
  styleUrls: ['./add-edit-pedido.component.css']
})
export class AddEditPedidoComponent implements OnInit {
 title:string = "Crear Pedido";
 formPedido = new FormGroup({});
 submitted:boolean = false;
 lClientes:any[] =[];
 message:string = "";
 txt="";
 showMessage:boolean = false;
 showError:boolean = false;
 idPedido:number = 0;

 constructor(
  private spinner: NgxSpinnerService
  ,private activateRoute:ActivatedRoute 
  ,private fb:FormBuilder
  ,private srvPedido:PedidoService
  ,private srvCliente:ClienteService) {
    this.activateRoute.params.subscribe(param=>{
      this.idPedido = param["Id"];
    });
   }

  ngOnInit(): void {
    this.initForm();
    if(this.idPedido){
      this.getPedido(this.idPedido);
    }
    this.getClientes();
  }

  initForm(){
    this.formPedido = this.fb.group({
      fechaCreacion: ['', Validators.required],
      codigo:['', Validators.required],
      idCliente:['', Validators.required]
    });
  }

  get getControl()
  {
    return this.formPedido.controls;
  }

  submit(){
    this.submitted = true;
    console.log(this.formPedido.value);
    if(this.formPedido.valid){
      let pedido = this.formPedido.value as IPedido;
      pedido.idPedido = 0;
      let fechaObject = this.formPedido.value.fechaCreacion;
      pedido.fechaCreacion = new Date(fechaObject.year,fechaObject.month-1,fechaObject.day);
      pedido.fechaModificacion = new Date();
      pedido.idCliente = this.formPedido.value.idCliente.idCliente;

      console.log(pedido);
      if(this.idPedido>0){
        this.update(pedido);
      }else{
        this.crear(pedido);
      }
    }
  }

  crear(pedido:IPedido){
    this.spinner.show();
    this.srvPedido.create(pedido).subscribe(
      resp=>{
        this.showMessage = true;
        this.message = "Guardado Existosamente";
        this.formPedido.reset();
        this.spinner.hide();
      },
      err=>{
        this.showError = true;
        this.message = "Error, por favor intente nuevamente";
        console.log(err.error);
        this.spinner.hide();
      }
    );
  }

  update(pedido:IPedido){
    this.spinner.show();
    this.srvPedido.update(pedido).subscribe(
      resp=>{
        this.showMessage = true;
        this.message = "Guardado Existosamente";
        this.formPedido.reset();
        this.spinner.hide();
      },
      err=>{
        this.showError = true;
        this.message = "Error, por favor intente nuevamente";
        console.log(err.error);
        this.spinner.hide();
      }
    );
  }
  getPedido(idPedido:number){
    this.spinner.show();
    this.srvPedido.getById(idPedido).subscribe(
      resp=>{
        let fechaNac = new Date(resp.fechaCreacion);
        this.formPedido.controls['fechaCreacion'].setValue({year:fechaNac.getFullYear(),month:fechaNac.getMonth()+1, day:fechaNac.getDate()});
        this.formPedido.controls['idCliente'].setValue(resp.idCliente);
        this.formPedido.controls['codigo'].setValue(resp.codigo);
        this.spinner.hide();
      },
      err=>{
        console.log(err.error);
        this.spinner.hide();
      }
    )
  }

  getClientes(){
    this.spinner.show();
    this.srvCliente.getClientesDropDown().subscribe(
      resp=>{

        this.lClientes = resp;
        this.spinner.hide();
      },
      err=>{
        console.log("No se cargaron los clientes");
        this.spinner.hide();
      }
    )
  }
}
