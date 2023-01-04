import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css'],
})
export class ShowDepComponent implements OnInit {
  DepartmentLsit: any[] | undefined;
  constructor(private service: SharedService) {}

  ngOnInit(): void {
    //Lors de l'initialisation on va récupérer les données
    this.refreshDeptList();
  }

  //On crée une méthode qui récupère les données de shared service
  refreshDeptList() {
    this.service.getDepList().subscribe((data) => {
      this.DepartmentLsit = data;
    });
  }
}
