import { Component } from '@angular/core';
import {HttpCall} from "../HttpCall";

@Component({
  selector: 'app-positions',
  templateUrl: './positions.component.html',
  styleUrls: ['./positions.component.css']
})
export class PositionsComponent {

  PositionsList:any=[];

  CurrentPossiblePositionsList:any=[]
  PossiblePositionsList:any=[]

  selectedEmployee: any;
  selectedPosition: any;

  constructor(private http:HttpCall) { }

  ngOnInit(): void {
    this.refreshEmpList();
  }

  refreshEmpList(){
    this.http.get('Employee/PossibleJobPositions').subscribe(data => {
      this.PositionsList=data.data;
      this.selectedEmployee = data.data[0];
      this.CurrentPossiblePositionsList = data.data[0].currentPossibleJobPositions;
      this.PossiblePositionsList = data.data[0].jobPositions;
      this.selectedPosition = data.data[0].jobPositions[0];
    });
  }

  changeEmployee(event: Event) {
    this.CurrentPossiblePositionsList = this.selectedEmployee.currentPossibleJobPositions;
    this.PossiblePositionsList = this.selectedEmployee.jobPositions;
  }

  addPosition(event: Event) {
    this.selectedEmployee.currentPossibleJobPositions.push(this.selectedPosition)
    this.selectedEmployee.jobPositions.forEach((value: { id: any; }, index: any)=>{
      if(value.id==this.selectedPosition.id) this.selectedEmployee.jobPositions.splice(index,1);
    });
    this.http.put('Employee/PossibleJobPositions', {id:this.selectedEmployee.employeeId,JobPosition:this.selectedPosition})
      .subscribe(data => {})
    this.selectedPosition = this.PositionsList[0].jobPositions[0];
  }

  deletePosition(dataItem: any) {
    this.selectedEmployee.currentPossibleJobPositions.forEach((value: { id: any; }, index: any)=>{
      if(value.id==dataItem.id) this.selectedEmployee.currentPossibleJobPositions.splice(index,1);
    });
    this.selectedEmployee.jobPositions.push(dataItem)
    this.http.put('Employee/PossibleJobPositionsDelete', {id:this.selectedEmployee.employeeId,JobPosition:dataItem})
      .subscribe(data => {})
  }
}
