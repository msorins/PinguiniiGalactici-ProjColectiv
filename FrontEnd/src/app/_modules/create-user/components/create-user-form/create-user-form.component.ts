import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Student } from '../../models/Student';
import { CreateUserService } from '../../services/create-user.service';
import { validateNumber } from 'src/app/_modules/shared/validators/validators';

@Component({
    selector: 'app-create-user-form',
    templateUrl: './create-user-form.component.html',
    styleUrls: ['./create-user-form.component.css']
})
export class CreateUserFormComponent implements OnInit {

    createUser: FormGroup;
    name: AbstractControl;
    email: AbstractControl;
    registration: AbstractControl;
    group: AbstractControl;
    isErasmus = false;
    invalidForm = true;
    constructor(private formBuilder: FormBuilder,
                private createService: CreateUserService) {
        this.createUser = formBuilder.group({
            name: new FormControl('', Validators.required),
            email: new FormControl('', Validators.required),
            registration: new FormControl('', [Validators.required]),
            group: new FormControl(''),

        });
        this.name = this.createUser.get('name');
        this.email = this.createUser.get('email');
        this.registration = this.createUser.get('registration');
        this.group = this.createUser.get('group');
    }

    ngOnInit() {
        console.log(this.group);
    }

    onCheckChange(event): void {
        if (event.checked) {
            this.group.disable();
            this.isErasmus = true;
        } else {
            this.group.enable();
            this.isErasmus = false;
        }

    }

    getUser(): Student {
        const student: Student = {
            Id: -1,
            Name: this.name.value,
            Email: this.email.value,
            Registration: this.registration.value,
            Group: 0,
            Erasmus: this.isErasmus
        };
        if (!this.isErasmus) {
            student.Group = this.group.value;
        }
        return student;
    }

    saveUser(): void {
        const student = this.getUser();
        this.createService.saveStudent(student);
    }
}
