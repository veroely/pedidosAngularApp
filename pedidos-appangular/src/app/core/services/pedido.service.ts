import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { IPedido, IPedidoCliente } from '../models';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {
  apiUrl = environment.baseUrl +"api/Pedido/";

  constructor(private http:HttpClient) { }

  getAll():Observable<IPedido[]>{
    return this.http.get<IPedido[]>(this.apiUrl);
  }

  getAllPedidoCliente():Observable<IPedidoCliente[]>{
    return this.http.get<IPedidoCliente[]>(this.apiUrl+"getAllPedidoCliente");
  }

  getById(id:number):Observable<IPedido>{
    return this.http.get<IPedido>(this.apiUrl+id);
  }

  create(pedido:IPedido):Observable<IPedido>{
    return this.http.post<IPedido>(this.apiUrl,pedido);
  }

  update(pedido:IPedido):Observable<IPedido>{
    return this.http.put<IPedido>(this.apiUrl,pedido);
  }

  delete(id:number):Observable<any>{
    return this.http.delete(this.apiUrl+id);
  }
}
