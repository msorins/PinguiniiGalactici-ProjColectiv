import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';
import { AuthenticationService } from '../../../shared/services/authentication.service';
import { Router } from '@angular/router';


@Component({
    selector: 'app-login-form',
    templateUrl: './login-form.component.html',
    styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

    email: AbstractControl;
    password: AbstractControl;
    hide = true;
    studentForm: FormGroup;
    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private loginService: AuthenticationService) {
        this.studentForm = formBuilder.group({
            email: new FormControl('', [Validators.required, Validators.email]),
            password: new FormControl('', [Validators.required])
        });
        this.email = this.studentForm.get('email');
        this.password = this.studentForm.get('password');
    }

    ngOnInit() {
    }

    getEmailErrorMessage() {
        return this.email.hasError('required') ? 'You must enter a value' :
            this.email.hasError('email') ? 'Not a valid email' :
                '';
    }

    getPasswordErrorMessage() {
        return this.password.hasError('required') ? 'You must enter a value' : '';
    }

    loginTeacher(): void {
        const teacherCredentials = {email: this.email.value, password: this.password.value};
        this.router.navigate(['/teacher/main-page']);
        //this.loginService.loginTeacher(teacherCredentials);
    }
}
