import { Component } from '@angular/core';
import {HttpCall} from "../HttpCall";

@Component({
  selector: 'app-salaries',
  templateUrl: './salaries.component.html',
  styleUrls: ['./salaries.component.css']
})
export class SalariesComponent {

  SalariesList:any=[];

  constructor(private http:HttpCall) { }

  ngOnInit(): void {
    this.refreshEmpList();
  }

  refreshEmpList(){
    this.http.get('SalaryChanges').subscribe(data => {
      this.SalariesList=data.data;
    });
  }

}
