import { AccountService } from './../services/account.service';
import { NewUserDTO } from './../../models/users/DTOs/new-user.model';
import { FormGroup, FormBuilder, Validators, FormControl, ValidatorFn, FormControlName } from '@angular/forms';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { DisplayMessage, GenericFormValidator, ValidationMessages } from 'src/app/utils/generic-form-validation';
import { fromEvent, merge, Observable } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../login/login.component.css'],
})
export class RegisterComponent implements OnInit, AfterViewInit {
  registerForm!: FormGroup;
  newUser!: NewUserDTO;

  constructor(
    private _accountService: AccountService,
    private _formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
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
      repeatPassword: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(15),
        ],
      ],
    });
  }

  name = () => this.registerForm.get('name')!;
  email = () => this.registerForm.get('email')!;
  password = () => this.registerForm.get('password')!;
  repeatPassword = () => this.registerForm.get('repeatPassword')!;

  ngAfterViewInit(): void {}

  registerUser() {
    console.log(this.registerForm.value);

    this.newUser = Object.assign({}, this.newUser, this.registerForm.value);
  }
}
