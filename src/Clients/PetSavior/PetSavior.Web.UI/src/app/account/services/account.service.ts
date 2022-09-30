import { NewUserDTO } from './../../models/users/DTOs/new-user.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AccountService {
  constructor(private _httpClient : HttpClient) { }

  register(newUser: NewUserDTO){

  }

  login(email: string, password: string){

  }
}
