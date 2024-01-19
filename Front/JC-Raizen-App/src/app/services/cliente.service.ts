import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

import { Cliente } from '../pages/models/Clientes';
import { Endereco } from '../pages/models/Endereco';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private apiUrl = `${environment.baseApiUrl}/Cliente`
  private apiUrlCep = `${environment.baseApiUrl}/Endereco`

  constructor(private http: HttpClient) { }

  GetClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.apiUrl);
  }

  GetCliente(id: number) : Observable<Cliente> {
    return this.http.get<Cliente>(`${this.apiUrl}/${id}`);
  }

  CreateCliente(Cliente: Cliente) : Observable<Cliente> {
    return this.http.post<Cliente>(`${this.apiUrl}`, Cliente);
  }

  EditCliente(Cliente : Cliente) : Observable<Cliente[]> {
      return this.http.put<Cliente[]>(`${this.apiUrl}`, Cliente);
  }

  ExcluirCliente(id: number) : Observable<Cliente[]> {
    return this.http.delete<Cliente[]>(`${this.apiUrl}/${id}`);
  }

  BuscaCep(codigoCep : string) : Observable<Endereco> {
    return this.http.get<Endereco>(`${this.apiUrlCep}/${codigoCep}`);
}

}

