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

  //Création une méthode pour avoir les données
  getDepList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/department');
  }

  //Méthode pour ajouter un department (Post)
  addDepartment(val: any) {
    return this.http.post(this.APIUrl + '/department', val);
  }

  //Méthode for updated
  updateDepartment(val: any) {
    return this.http.put(this.APIUrl + '/department', val);
  }

  //Méthode pour supprimer department
  deleteDepartment(val: any) {
    return this.http.delete(this.APIUrl + '/department', val);
  }
}
