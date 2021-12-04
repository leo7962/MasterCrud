import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ContextServiceService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getData() {
    return this.http.get(this.baseUrl + 'ciudades'); //https://localhost:5001/api/ciudades
  }

  postData(formData) {
    return this.http.post(this.baseUrl + 'ciudades', formData);
  }

  putData(id, formData) {
    return this.http.put(this.baseUrl + 'ciudades/' + id, formData);
  }

  deleteData(id) {
    return this.http.delete(this.baseUrl + 'ciudades/' + id);
  }
}
