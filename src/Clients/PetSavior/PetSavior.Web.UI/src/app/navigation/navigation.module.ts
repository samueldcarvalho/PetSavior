import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { PetCardComponent } from '../components/pets/pet-card/pet-card.component';
import { PetService } from '../services/pets/pet.service';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [PetCardComponent, HomeComponent, HeaderComponent],
  imports: [CommonModule, RouterModule],
  providers: [PetService],
  exports: [PetCardComponent, HomeComponent, HeaderComponent],
})
export class NavigationModule {}
