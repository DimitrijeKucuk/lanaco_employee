import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import {EmployeesComponent} from './employees/employees.component';
import {PositionsComponent} from "./positions/positions.component";
import {SalariesComponent} from "./salaries/salaries.component";


const routes: Routes = [
   {path:'employees',component:EmployeesComponent},
   {path:'positions',component:PositionsComponent},
  {path:'salaries',component:SalariesComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
