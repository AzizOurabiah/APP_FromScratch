import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee/employee.component';
import { DepartmentComponent } from './department/department.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    component: AppComponent,
  },
  {
    path: 'employee',
    component: EmployeeComponent,
  },
  {
    path: 'department',
    component: DepartmentComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
