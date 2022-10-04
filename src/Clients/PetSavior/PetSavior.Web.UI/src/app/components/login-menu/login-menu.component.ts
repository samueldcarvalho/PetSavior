import { Router } from '@angular/router';
import { LocalStorageUtils } from './../../utils/local-storage';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/users/DTOs/user.model';

@Component({
  selector: 'app-login-menu',
  templateUrl: './login-menu.component.html',
  styleUrls: ['./login-menu.component.css'],
})
export class LoginMenuComponent {
  user: User | null = null;
  token: string | null = null;
  userFirstName: string = "";
  localStorageUtils: LocalStorageUtils = new LocalStorageUtils();

  constructor(private router: Router) { }

  verifyUserIsLogged(): boolean{
    this.user = this.localStorageUtils.getUser();
    this.token = this.localStorageUtils.getToken();

    if(this.user !== null)
      this.userFirstName = `Hello, ${this.user.name.split(' ')[0]}!`;

    return this.token !== null;
  }

  logout(){
    this.localStorageUtils.clearLocalStorageUserToken();
    this.router.navigate(["/home"]);
  }
}
