import { Pet } from 'src/app/models/pets/pet.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Observable } from 'rxjs';
import { ApiResponse } from '../_generics/api-response';

@Injectable({
  providedIn: 'root',
})
export class PetService {
  protected ApiBaseURL: string = 'http://localhost:5000/api/v1';

  constructor(private http: HttpClient) {}

  getPets(
    paginationNumber: number,
    limit: number
  ): Observable<ApiResponse<Array<Pet>>> {
    return this.http.get<ApiResponse<Array<Pet>>>(`${this.ApiBaseURL}/Pet`, {
      params: {
        paginationNumber,
        limit,
      },
    });
  }
}
