import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginMenuComponent } from '../components/login-menu/login-menu.component';
import { PetCardComponent } from '../components/pets/pet-card/pet-card.component';
import { PetService } from '../services/pets/pet.service';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  declarations: [PetCardComponent, HomeComponent, HeaderComponent, NotFoundComponent, LoginMenuComponent],
  imports: [CommonModule, RouterModule],
  providers: [PetService],
  exports: [PetCardComponent, HomeComponent, HeaderComponent],
})
export class NavigationModule {}
