import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class AgentServiceService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getData() {
    return this.http.get(this.baseUrl + 'vendedores'); //https://localhost:5001/api/vendedores
  }

  postData(formData) {
    return this.http.post(this.baseUrl + 'vendedores', formData);
  }

  putData(id, formData) {
    return this.http.put(this.baseUrl + 'vendedores/' + id, formData);
  }

  deleteData(id) {
    return this.http.delete(this.baseUrl + 'vendedores/' + id);
  }

  GetDataCity() {
    return this.http.get(this.baseUrl + 'ciudades'); //https://localhost:5001/api/vendedores
  }
}
