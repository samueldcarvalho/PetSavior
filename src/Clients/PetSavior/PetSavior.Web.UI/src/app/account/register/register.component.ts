import { LocalStorageUtils } from './../../utils/local-storage';
import { AccountService } from './../services/account.service';
import { NewUserDTO } from './../../models/users/DTOs/new-user.model';
import {
  FormGroup,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../login/login.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  newUser!: NewUserDTO;
  errors: any[] = [];
  localStorageUtils = new LocalStorageUtils();

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

        const toast = this._toastr.success("Success", "User was been created");

        if(toast)
          toast.onHidden.subscribe(() => {
            this._router.navigate(['/home']);
          });
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
