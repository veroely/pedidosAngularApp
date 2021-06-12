import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ICliente } from '../models';


@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  apiUrl = environment.baseUrl +"api/Cliente/";
  
  constructor(private http:HttpClient) { }

  getAll():Observable<ICliente[]>{
    return this.http.get<ICliente[]>(this.apiUrl);
  }

  getClientesDropDown():Observable<any[]>{
    return this.http.get<any[]>(this.apiUrl+"getClientesDropDown");
  }
}
