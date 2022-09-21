import { Injectable } from '@angular/core';
import {HttpClient } from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class PetService {
  protected ApiBaseURL : string = "http://localhost:5000/api/v1";

  constructor(private http: HttpClient) { }

  obterPets(){
    this.http.get(`${this.ApiBaseURL}/Pet`)
  }
}
