import {Component} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AgentServiceService} from "../agent-service.service";

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  data: any;
  city: any;
  cities: any[];
  AgentForm: FormGroup;
  submitted = false;
  EventValue: any = "Guardar";

  constructor(private AgentService: AgentServiceService) {
  }

  ngOnInit(): void {
    this.GetData();
    this.GetDataCity()

    this.AgentForm = new FormGroup({
      id: new FormControl(null),
      name: new FormControl("", [Validators.required]),
      lastName: new FormControl("", [Validators.required]),
      numId: new FormControl("", [Validators.required]),
      cityId: new FormControl("", [Validators.required]),
      //city: new FormControl("", [Validators.required]),
    })
  }

  GetData() {
    this.AgentService.getData().subscribe((data: any[]) => {
      this.data = data;
    })
  }

  GetDataCity() {
    this.AgentService.GetDataCity().subscribe((city: any[]) => {
      this.city = city;
    })
  }

  deleteData(id) {
    this.AgentService.deleteData(id).subscribe((data: any[]) => {
      this.data = data;
      this.GetData();
    })
  }

  Save() {
    this.submitted = true;

    if (this.AgentForm.invalid) {
      return;
    }
    this.AgentService.postData(this.AgentForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();

    });
  }

  Update() {
    this.submitted = true;

    if (this.AgentForm.invalid) {
      return;
    }
    this.AgentService.putData(this.AgentForm.value.id, this.AgentForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();
    })
  }

  EditData(Data) {
    this.AgentForm.controls["id"].setValue(Data.id);
    this.AgentForm.controls["name"].setValue(Data.name);
    this.AgentForm.controls["lastName"].setValue(Data.lastName);
    this.AgentForm.controls["numId"].setValue(Data.numId);
    this.AgentForm.controls["cityId"].setValue(Data.cityId);
    this.EventValue = "Actualizar";
  }

  resetFrom() {
    this.GetData();
    this.AgentForm.reset();
    this.EventValue = "Guardar";
    this.submitted = false;
  }
}
