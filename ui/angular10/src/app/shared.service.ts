import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  //On creé les adresse de l'API et de la Photo
  readonly APIUrl = 'http:localhost:47357/api';
  readonly PhotoUrl = 'localhost:47357/Photos';

  constructor(private http: HttpClient) {}

  /**************** Méthode qui concerne Départment controller *************** */
  //Création une méthode pour avoir les données
  getDepList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Department');
  }

  //Méthode pour ajouter un department (Post)
  addDepartment(val: any) {
    return this.http.post(this.APIUrl + '/Department', val);
  }

  //Méthode for updated
  updateDepartment(val: any) {
    return this.http.put(this.APIUrl + '/Department', val);
  }

  //Méthode pour supprimer department
  deleteDepartment(val: any) {
    return this.http.delete(this.APIUrl + '/Department', val);
  }

  /**************** Méthode qui concerne Employee controller *************** */

  //Création une méthode pour avoir les données
  getEmpList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Employee');
  }

  //Méthode pour ajouter un employee (Post)
  addEmployee(val: any) {
    return this.http.post(this.APIUrl + '/Employee', val);
  }

  //Méthode for updated
  updateEmployee(val: any) {
    return this.http.put(this.APIUrl + '/Employee', val);
  }

  //Méthode pour supprimer employee
  deleteEmployee(val: any) {
    return this.http.delete(this.APIUrl + '/Employee', val);
  }

  //Méthode pour uploader photo
  uploadPhoto(val: any) {
    return this.http.post(this.APIUrl + 'Employee/SaveFile', val);
  }

  //Méthode pour avoir tout les departement
  getAllDepartmentName(): Observable<any[]> {
    return this.http.get<any[]>(
      this.APIUrl + '/Employee/GetAllDepartmentNames'
    );
  }
}
