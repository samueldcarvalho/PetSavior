import { LocalStorageUtils } from './../../utils/local-storage';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  localStorageUtils = new LocalStorageUtils();

  constructor(private _router: Router) { }

  ngOnInit(): void {
    const token = this.localStorageUtils.getToken();

    if(token != null)
      this._router.navigate(["/home"]);
  }
}
