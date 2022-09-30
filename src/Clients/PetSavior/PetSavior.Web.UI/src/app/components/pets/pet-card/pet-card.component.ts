import { Component, Input, OnInit } from '@angular/core';
import { Pet } from 'src/app/models/pets/pet.model';

@Component({
  selector: 'app-pet-card',
  templateUrl: './pet-card.component.html',
  styleUrls: ['./pet-card.component.css']
})
export class PetCardComponent implements OnInit {
  @Input()
  public pet: Pet | undefined;

  constructor() { }

  ngOnInit(): void {}

}
