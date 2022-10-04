import { ToastrModule } from 'ngx-toastr';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AccountRoutingModule } from './account.route';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountService } from './services/account.service';

@NgModule({
  declarations: [RegisterComponent, LoginComponent, AccountComponent],
  providers: [AccountService],
  imports: [
    CommonModule,
    RouterModule,
    AccountRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [RegisterComponent, LoginComponent],
})
export class AccountModule {}
