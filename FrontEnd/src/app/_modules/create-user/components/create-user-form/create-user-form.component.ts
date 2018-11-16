import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
    selector: 'app-create-user-form',
    templateUrl: './create-user-form.component.html',
    styleUrls: ['./create-user-form.component.css']
})
export class CreateUserFormComponent implements OnInit {

    createUser: FormGroup;
    checked = false;
    name: AbstractControl;
    email: AbstractControl;
    registration: AbstractControl;
    group: AbstractControl;
    constructor(formBuilder: FormBuilder) {
        this.createUser = formBuilder.group({
            name: new FormControl('', Validators.required),
            email: new FormControl('', Validators.required),
            registration: new FormControl('', Validators.required),
            group: new FormControl(''),

        });
        this.name = this.createUser.get('name');
        this.email = this.createUser.get('email');
        this.registration = this.createUser.get('registration');
        this.group = this.createUser.get('group');
    }

    ngOnInit() {

    }
}
