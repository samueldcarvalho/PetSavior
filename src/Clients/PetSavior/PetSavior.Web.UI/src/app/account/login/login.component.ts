import { FormGroup, Validators } from '@angular/forms';
import { AccountService } from './../services/account.service';
import { ToastrService } from 'ngx-toastr';
import { LocalStorageUtils } from './../../utils/local-storage';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  localStorageUtils = new LocalStorageUtils();
  loginForm!: FormGroup;

  constructor(
    private _accountService: AccountService,
    private _formBuilder: FormBuilder,
    private _router: Router,
    private _toastr: ToastrService
  ) {}

  ngOnInit(): void {
    const token = this.localStorageUtils.getToken();

    if (token != null) {
      this._router.navigate(['/home']);
      return;
    };

    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    })
  }

  login(){
    if(!this.loginForm.valid){
      this._toastr.error("Check the fields")
      return;
    }

    this._accountService.login(this.email().value, this.password().value)
      .subscribe({
        next: (loginData) => {
          this.loginForm.reset();

          this._accountService.localStorage.saveLocalStorageUserToken(
            loginData.user,
            loginData.token
          );

          this._router.navigate(['/home']);

          const toast = this._toastr.success('Successful authentication', 'Success');
        },
        error: (err) => {
          if(typeof err.error === "string"){
            this._toastr.error(err.error);
            return;
          }

          this._toastr.error(err.error.errors)
        }
      });
  }

  email = () => this.loginForm.get("email")!;
  password = () => this.loginForm.get("password")!;
}
