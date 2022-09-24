import { ValidationFailureApiResponse } from "./validation-failure-api-response";

export interface ValidationResultApiResponse{
  isValid: boolean;
  errors: Array<ValidationFailureApiResponse>;
}
