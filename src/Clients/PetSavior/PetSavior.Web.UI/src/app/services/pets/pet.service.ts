import { Pet } from './../../models/pet.model';
import { Injectable } from '@angular/core';
import {HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PetService {
  protected ApiBaseURL : string = "http://localhost:5000/api/v1";

  constructor(private http: HttpClient) { }

  obterPets() : Observable<Array<Pet>>{
    return this.http.get<Array<Pet>>(`${this.ApiBaseURL}/Pet`);
  }
}
