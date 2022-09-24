import { ValidationResultApiResponse } from "./validation-result-api-response";

export interface ApiResponse<TResponse> {
  result: TResponse;
  success: boolean;
  validationResult: ValidationResultApiResponse
}
