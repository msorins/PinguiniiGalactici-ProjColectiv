import { FormControl, AbstractControl } from '@angular/forms';


export function validateNumber(control: AbstractControl) {
    const numberRegex = new RegExp('^[1-9][0-9]*');
    return numberRegex.test(control.value) ? {validateNumber: {
        invalid: false
    }} : {
        validateNumber: {
            invalid: true
        }
    };
}



