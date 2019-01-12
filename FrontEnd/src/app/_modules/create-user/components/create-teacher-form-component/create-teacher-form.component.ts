import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators, FormGroup, AbstractControl } from '@angular/forms';
import { Teacher } from '../../models/Teacher';
import { CreateUserService } from '../../services/create-user.service';
import { Guid } from 'guid-typescript';

@Component({
    selector: 'app-create-teacher-form',
    templateUrl: './create-teacher-form.component.html',
    styleUrls: ['./create-teacher-form.component.css']
})
export class CreateTeacherFormComponent implements OnInit {

    createTeacher: FormGroup;
    name: AbstractControl;
    email: AbstractControl;
    constructor(private formBuilder: FormBuilder,
                private createUserService: CreateUserService ) {
        this.createTeacher = formBuilder.group({
            name: new FormControl('', Validators.required),
            email: new FormControl('', Validators.required)
        });

        this.name = this.createTeacher.get('name');
        this.email = this.createTeacher.get('email');
    }

    ngOnInit() {
    }

    getUser(){
        const id = Guid.create().toString();
        const teacher = {
            TeacherID: id,
            Name: this.name.value,
            Password: 'pass',
            Email: this.email.value
        };
        return teacher;
    }

    saveTeacher(): void {
        const teacher = this.getUser();

        this.createUserService.saveTeacher(teacher);
    }


}
