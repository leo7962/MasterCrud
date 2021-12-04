import {Component} from '@angular/core';
import {ContextServiceService} from "../context-service.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AgentServiceService} from "../agent-service.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  data: any;
  CityForm: FormGroup;
  submitted = false;
  EventValue: any = "Save";

  constructor(private CityService: ContextServiceService, private AgentService: AgentServiceService) {
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

  Update(Data) {
    this.submitted = true;
    this.CityForm.controls["id"].setValue(Data.id);
    this.CityForm.controls["description"].setValue(Data.description);

    if (this.CityForm.invalid) {
      return;
    }
    this.CityService.putData(this.CityForm.value.id, this.CityForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();
    })
  }

  resetFrom() {
    this.GetData();
    this.CityForm.reset();
    this.EventValue = "Save";
    this.submitted = false;
  }
}
