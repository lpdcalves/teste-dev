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

  public getClientes() : Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${environment.apiUrl}/${this.url}`);
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
