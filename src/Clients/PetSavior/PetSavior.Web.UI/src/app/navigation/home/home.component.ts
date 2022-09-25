import { Component, OnInit } from '@angular/core';
import { Pet } from 'src/app/models/pet.model';
import { PetService } from 'src/app/services/pets/pet.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public pets : Array<Pet> = new Array<Pet>();

  constructor(private petService : PetService) { }

  ngOnInit(): void {
    this.petService.getPets(1, 5).subscribe({
      next: (response) => {
        this.pets = response.result;
        console.log(this.pets)
      },
    });
  }
}
