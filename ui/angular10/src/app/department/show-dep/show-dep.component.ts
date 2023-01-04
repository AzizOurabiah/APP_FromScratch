import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css'],
})
export class ShowDepComponent implements OnInit {
  DepartmentLsit: any[] | undefined;

  ModalTitle: string | undefined;

  ActivateAddEditDepComp: boolean = false;

  dep: any;

  constructor(private service: SharedService) {}

  ngOnInit(): void {
    //Lors de l'initialisation on va récupérer les données
    this.refreshDeptList();
  }

  addClick() {
    this.dep = {
      DepartmentId: 0,
      DepartmentName: '',
    };
    this.ModalTitle = 'Add Department';
    this.ActivateAddEditDepComp = true;
  }

  closeClick() {
    this.ActivateAddEditDepComp = false;
    this.refreshDeptList();
  }

  //On crée une méthode qui récupère les données de shared service
  refreshDeptList() {
    this.service.getDepList().subscribe((data) => {
      this.DepartmentLsit = data;
    });
  }
}
