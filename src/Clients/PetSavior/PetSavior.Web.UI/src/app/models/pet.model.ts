import { PetTemperament } from './pet-temperament.model';
import { PetVaccine } from './pet-vaccines.model';
import { PetBreed } from './pet-breed.model';

export interface Pet {
  id: number;
  name: string;
  description: string;
  careTip: string;
  weight: number;
  breed: PetBreed;
  userId: number;
  pedigree: boolean;
  vaccines: Array<PetVaccine>;
  temperament: Array<PetTemperament>;
  sex: string;
}
