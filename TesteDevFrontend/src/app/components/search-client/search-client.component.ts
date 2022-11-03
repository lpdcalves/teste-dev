import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Cliente } from 'src/app/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-search-client',
  templateUrl: './search-client.component.html',
  styleUrls: ['./search-client.component.css']
})
export class SearchClientComponent implements OnInit {
  @Output() clienteFiltered = new EventEmitter<Cliente[]>();

  cliente = new Cliente();

  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
  }

  filterClients(cliente: Cliente){
    this.clienteService.getClientes(cliente).subscribe((clientes) => this.clienteFiltered.emit(clientes));
  }

  cleanClientFilters(){
    this.cliente = new Cliente();
    this.clienteService.getClientes().subscribe((clientes) => this.clienteFiltered.emit(clientes));
  }

}
