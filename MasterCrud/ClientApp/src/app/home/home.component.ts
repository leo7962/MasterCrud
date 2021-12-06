import {Component} from '@angular/core';
import {ContextServiceService} from "../context-service.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  data: any;
  CityForm: FormGroup;
  submitted = false;
  EventValue: any = "Guardar";

  constructor(private CityService: ContextServiceService) {
  }

  ngOnInit(): void {
    this.GetData();

    this.CityForm = new FormGroup({
      id: new FormControl(null),
      description: new FormControl("", [Validators.required]),
    })
  }

  GetData() {
    this.CityService.getData().subscribe((data: any[]) => {
      this.data = data;
    })
  }

  deleteData(id) {
    this.CityService.deleteData(id).subscribe((data: any[]) => {
      this.data = data;
      this.GetData();
    })
  }

  Save() {
    this.submitted = true;

    if (this.CityForm.invalid) {
      return;
    }
    this.CityService.postData(this.CityForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();

    })
  }

  Update() {
    this.submitted = true;

    if (this.CityForm.invalid) {
      return;
    }
    this.CityService.putData(this.CityForm.value.id, this.CityForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();
    })
  }

  EditData(Data) {
    this.CityForm.controls["id"].setValue(Data.id);
    this.CityForm.controls["description"].setValue(Data.description);
    this.EventValue = "Actualizar";
  }

  resetFrom() {
    this.GetData();
    this.CityForm.reset();
    this.EventValue = "Guardar";
    this.submitted = false;
  }
}
