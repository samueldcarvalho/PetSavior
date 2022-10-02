import { HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { throwError } from "rxjs";

export abstract class BaseService {
  protected UrlService: string = "https://localhost:5001/api/v1";

  protected getHeaderJson(){
    return {
      headers: new HttpHeaders({
        'content-type': 'application/json'
      })
    }
  }

  protected serviceError(response: Response | any) {
    let customError: string[] = [];

    if(response instanceof HttpErrorResponse)
    {
      if(response.statusText === "Unknown Error"){
        customError.push("Unknown error");
        response.error.errors = customError;
      }
    }
    console.error(response);
     return throwError(response);
  }
}
