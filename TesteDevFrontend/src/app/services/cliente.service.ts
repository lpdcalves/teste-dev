import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private url = "Clientes"

  constructor(private http: HttpClient) { }

  public getClientes(cliente: Cliente = new Cliente()) : Observable<Cliente[]> {
    let queryString = "";
    let queryTarget = {
      cpf: "",
      nome: "",
      dataNascimento: "",
      sexo: "",
      endereco: "",
      estado: "",
      cidade: "",
    };
    queryTarget.cpf = cliente.cpf ? cliente.cpf : "";
    queryTarget.nome = cliente.nome ? cliente.nome : "";
    queryTarget.dataNascimento = cliente.dataNascimento ? cliente.dataNascimento.toDateString() : "";
    queryTarget.sexo = cliente.sexo ? cliente.sexo.toString() : "";
    queryTarget.endereco = cliente.endereco ? cliente.endereco : "";
    queryTarget.estado = cliente.estado ? cliente.estado : "";
    queryTarget.cidade = cliente.cidade ? cliente.cidade : "";
    
    if(Object.keys(queryTarget).length){
      queryString = '?' + new URLSearchParams(queryTarget).toString();
    }
    
    return this.http.get<Cliente[]>(`${environment.apiUrl}/${this.url}${queryString}`);
  }

  public updateClientes(cliente: Cliente) : Observable<Cliente[]> {
    return this.http.put<Cliente[]>(`${environment.apiUrl}/${this.url}/${cliente.id}`, cliente);
  }

  public createClientes(cliente: Cliente) : Observable<Cliente[]> {
    return this.http.post<Cliente[]>(`${environment.apiUrl}/${this.url}`, cliente);
  }

  public deleteClientes(cliente: Cliente) : Observable<Cliente[]> {
    return this.http.delete<Cliente[]>(`${environment.apiUrl}/${this.url}/${cliente.id}`);
  }
}
