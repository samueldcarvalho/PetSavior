export interface PetVaccine {
  id: number;
  petId: number;
  description: string;
  dosesRemaining: number;
  completed: boolean;
}
