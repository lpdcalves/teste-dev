import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Cliente } from 'src/app/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {
  @Input() cliente?: Cliente;
  @Output() clienteDeleted = new EventEmitter<Cliente[]>();
  @Output() clienteCreated = new EventEmitter<Cliente[]>();
  @Output() closeEditScreenEmited = new EventEmitter<Cliente[]>();

  constructor(private clienteService: ClienteService) { }

  ngOnInit(): void {
  }

  createCliente(cliente:Cliente){
    this.clienteService
      .createClientes(cliente)
      .subscribe((clientes) => this.clienteCreated.emit(clientes));
    this.closeEditScreen();
  }

  updateCliente(cliente:Cliente){
    this.clienteService.updateClientes(cliente).subscribe((clientes) => this.closeEditScreen());
  }

  deleteCliente(cliente:Cliente){
    this.clienteService
      .deleteClientes(cliente)
      .subscribe((clientes) => this.clienteDeleted.emit([cliente]))
    this.closeEditScreen();
  }

  closeEditScreen(){
    this.cliente = new Cliente();
    this.closeEditScreenEmited.emit();
  }

}
