import { LoginUser } from './../../models/users/DTOs/login-user.model';
import { catchError, map, Observable } from 'rxjs';
import { NewUserDTO } from './../../models/users/DTOs/new-user.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from './base.service';

@Injectable()
export class AccountService extends BaseService {
  constructor(private _httpClient: HttpClient) {
    super();
  }

  register(newUser: NewUserDTO): Observable<LoginUser> {
    const response = this._httpClient
      .post(`${this.UrlService}/Auth/register`, newUser, this.getHeaderJson())
      .pipe(
        map((result: any) => {
          return result as LoginUser;
        }),
        catchError(this.serviceError));

    return response;
  }

  login(email: string, password: string): Observable<LoginUser> {
    const response = this._httpClient
      .post(`${this.UrlService}/Auth/login`, {email, password}, this.getHeaderJson())
      .pipe(
        map((result: any) => {
          return result as LoginUser
        }),
        catchError(this.serviceError));

    return response;
  }
}
