import { FormGroup } from "@angular/forms";

export class GenericFormValidator {
  constructor(private validationMessages: ValidationMessages) { }

  generateErrors(container: FormGroup): { [key: string]: string}{
    let messages: any = {};
    for(let controlKey in container.controls){
      if(container.controls.hasOwnProperty(controlKey)){
        let c = container.controls[controlKey];

        if(c instanceof FormGroup){
          let childMessages = this.generateErrors(c);
          Object.assign(messages, childMessages);
        }else{
          if(this.validationMessages[controlKey]){
            messages[controlKey] = "";
            if((c.dirty || c.touched) && c.errors){
              Object.keys(c.errors).map(messageKey => {
                if(this.validationMessages[controlKey][messageKey]){
                  messages[controlKey] += this.validationMessages[controlKey][messageKey]
                }
              });
            }
          }
        }
      }
    }
    return messages;
  }
}

export interface DisplayMessage {
  [key:string]: string;
}

export interface ValidationMessages {
  [key: string]: {[key:string]: string}
}
