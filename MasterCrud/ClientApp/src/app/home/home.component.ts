import {Component} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  datos: any[] = [];

  constructor(private http: HttpClient) {
    http.get('/api/ciudades/').subscribe((data: any) => {
      this.datos = data;
      console.log(this.datos);
    });
  }


  /*getCity(id): void {
    http.get('/api/ciudades/').subscribe((data: any) => {
      this.datos = data;
      console.log(this.datos);
    });
  }*/
}
