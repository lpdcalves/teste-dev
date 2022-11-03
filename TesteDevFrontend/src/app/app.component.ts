import { Component } from '@angular/core';
import { Cliente } from './models/cliente';
import { ClienteService } from './services/cliente.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'TesteDevFrontend';
  clientes: Cliente[] = [];
  clienteEditar?: Cliente;
  page: number = 1;

  constructor(private clienteService: ClienteService) {}

  ngOnInit() : void{
    this.clienteService.getClientes().subscribe((result: Cliente[]) => this.clientes = result);
  }

  closeEditScreenEvent(){
    this.clienteEditar = undefined;
  }
  
  clienteCreatedRefresh(clientes: Cliente[]){
    this.clientes = this.clientes.concat(clientes);
  }

  clienteDeletedRefresh(clientes: Cliente[]){
    this.clientes.forEach((element,index)=>{
    if(element.id == clientes[0].id) this.clientes.splice(index,1);
    });
    this.clienteEditar = undefined;
  }

  clienteFilteredRefresh(clientes: Cliente[]){
    this.clientes = clientes;
  }

  initNewCliente(){
    this.clienteEditar = new Cliente();
  }

  editCliente(cliente: Cliente){
    this.clienteEditar = cliente;
  }

  deleteCliente(cliente: Cliente){
    this.clienteService.deleteClientes(cliente)
    .subscribe((result: Cliente[]) => this.clienteDeletedRefresh([cliente]));
  }
}
