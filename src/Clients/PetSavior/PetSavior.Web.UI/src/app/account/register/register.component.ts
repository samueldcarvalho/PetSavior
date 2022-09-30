import { CustomFormsModule, CustomValidators } from 'ngx-custom-validators/public_api';
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
  private _registerForm: FormGroup = {} as FormGroup;
  private _newUser: NewUserDTO = {} as NewUserDTO;

  private _validationMessages: ValidationMessages = {};
  private _genericValidator: GenericFormValidator = new GenericFormValidator(this._validationMessages);
  private _displayMessages: DisplayMessage = {};

  private _errors: string[] = [];

  @ViewChildren(FormControlName, {read: ElementRef})
  formInputElements: ElementRef[] = new Array<ElementRef>();

  constructor(
    private _accountService: AccountService,
    private _formBuilder: FormBuilder
  ) {
    this._validationMessages = {
      name: {
        required: 'Name is required',
        name: 'Invalid name',
      },
      email: {
        required: 'E-mail is required',
        email: 'Invalid e-mail',
      },
      password: {
        required: 'Password is required',
        rangeLength: 'Password must have between 6 and 15 characters',
      },
      repeatPassword: {
        required: 'Retype the password',
        rangeLength: 'Password must have between 6 and 15 characters',
        equalTo: "The password must be the same"
      },
    };

  }

  ngOnInit(): void {
    this._registerForm = this._formBuilder.group({
      name: ['', [Validators.required,Validators.minLength(5)]],
      email: ['', [Validators.required, Validators.email]],
      password: ['',[Validators.required,Validators.minLength(6), Validators.maxLength(15)]],
      repeatPassword: ['',[Validators.required,Validators.minLength(6), Validators.maxLength(15)]],
    });
  }

  ngAfterViewInit(): void {
    let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, "blur"));

      merge(...controlBlurs).subscribe(() => {
        this._displayMessages = this._genericValidator.generateErrors(this._registerForm);
      });
  }

  registerNewAccount() {
    if (!this._registerForm?.dirty || !this._registerForm.valid) return;

    this._newUser = Object.assign({}, this._newUser, this._registerForm.value);

    this._accountService.register(this._newUser);
  }
}
