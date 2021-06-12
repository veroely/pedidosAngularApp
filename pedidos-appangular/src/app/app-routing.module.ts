import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditPedidoComponent } from './pages/add-edit-pedido/add-edit-pedido.component';
import { ListPedidoComponent } from './pages/list-pedido/list-pedido.component';

const routes: Routes = [
  {path: '', redirectTo : 'listar', pathMatch:'full'},
  {path:"listar", component:ListPedidoComponent},
  {path:"crear", component:AddEditPedidoComponent},
  {path:"editar/:Id", component:AddEditPedidoComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
