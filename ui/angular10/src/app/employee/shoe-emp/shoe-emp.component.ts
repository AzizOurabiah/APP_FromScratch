import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-shoe-emp',
  templateUrl: './shoe-emp.component.html',
  styleUrls: ['./shoe-emp.component.css'],
})
export class ShoeEmpComponent implements OnInit {
  EmployeeList: any[] | undefined;

  constructor(private service: SharedService) {}

  ngOnInit(): void {
    //initialisé empList dès l'initialisation
    this.refreshData();
  }

  //On crée une méthode pour checher les données
  refreshData() {
    this.service.getEmpList().subscribe((data) => {
      this.EmployeeList = data;
    });
  }
}
