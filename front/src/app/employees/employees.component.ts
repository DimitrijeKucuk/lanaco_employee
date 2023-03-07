import { Component } from '@angular/core';
import {HttpCall} from '../HttpCall'
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent {

  EmployeeList:any=[];

  constructor(private http:HttpCall) { }

  ngOnInit(): void {
    this.refreshEmpList();
  }

  refreshEmpList(){
    this.http.get('Employee').subscribe(data => {
      this.EmployeeList=data.data;
    });
  }

}
