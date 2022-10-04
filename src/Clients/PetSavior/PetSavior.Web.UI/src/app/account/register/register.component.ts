import { LocalStorageUtils } from './../../utils/local-storage';
import { Observable } from 'rxjs';
import { AccountService } from './../services/account.service';
import { NewUserDTO } from './../../models/users/DTOs/new-user.model';
import {
  FormGroup,
  FormBuilder,
  Validators,
  ValidatorFn,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../login/login.component.css'],
})
export class RegisterComponent implements OnInit, AfterViewInit {
  registerForm!: FormGroup;
  newUser!: NewUserDTO;
  errors: any[] = [];
  localStorageUtils = new LocalStorageUtils();
  constructor(
    private _accountService: AccountService,
    private _formBuilder: FormBuilder,
    private _router: Router
  ) {}

  ngOnInit(): void {
    const token = this.localStorageUtils.getToken();

    if (token != null) {
      this._router.navigate(['/home']);
    }

    this.registerForm = this._formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(4)]],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(15),
        ],
      ],
      repeatPassword: ['', [Validators.required]],
    });
  }

  ngAfterViewInit(): void {}

  registerUser() {
    this.errors = [];

    if (
      (this.repeatPassword().value != this.password().value &&
        this.password().dirty &&
        this.repeatPassword().dirty) ||
      !this.registerForm.valid
    )
      return;

    this.newUser = Object.assign({}, this.newUser, this.registerForm.value);

    this._accountService.register(this.newUser).subscribe({
      next: (data) => {
        this.registerForm.reset();
        this._accountService.localStorage.saveLocalStorageUserToken(
          data.user,
          data.token
        );
        this._router.navigate(['/home']);
      },
      error: (fail) => {
        this.errors = fail.error.errors;
        this.password().reset();
        this.repeatPassword().reset();
      },
    });
  }

  name = () => this.registerForm.get('name')!;
  email = () => this.registerForm.get('email')!;
  password = () => this.registerForm.get('password')!;
  repeatPassword = () => this.registerForm.get('repeatPassword')!;
}
