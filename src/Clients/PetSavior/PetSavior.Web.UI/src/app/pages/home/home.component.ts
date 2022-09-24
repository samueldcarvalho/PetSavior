import { Component, OnInit } from '@angular/core';
import { Pet } from 'src/app/models/pet.model';
import { PetService } from 'src/app/services/pets/pet.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private _pets : Array<Pet> = new Array<Pet>();

  constructor(private petService : PetService) { }

  ngOnInit(): void {
    this.petService.obterPets().subscribe({
      next: (pets) => {
        this._pets = pets;
        console.log(pets);
        console.log(pets);
      }
    });
  }
}
