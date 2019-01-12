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
    Name: AbstractControl;
    Email: AbstractControl;
    RegistrationNumber: AbstractControl;
    GroupNumber: AbstractControl;
    
    isErasmus = false;
    invalidForm = true;
    constructor(private formBuilder: FormBuilder,
                private createService: CreateUserService) {
                    
        this.createUser = formBuilder.group({
            Name: new FormControl('', Validators.required),
            Email: new FormControl('', Validators.required),
            RegistrationNumber: new FormControl('', [Validators.required]),
            GroupNumber: new FormControl(''),
        });

        this.Name = this.createUser.get('Name');
        this.Email = this.createUser.get('Email');
        this.RegistrationNumber = this.createUser.get('RegistrationNumber');
        this.GroupNumber = this.createUser.get('GroupNumber');
    }

    ngOnInit() {
        console.log(this.GroupNumber);
    }

    onCheckChange(event): void {
        if (event.checked) {
            this.GroupNumber.disable();
            this.isErasmus = true;
        } else {
            this.GroupNumber.enable();
            this.isErasmus = false;
        }

    }

    getUser(): Student {
        const student: Student = {
            RegistrationNumber: this.RegistrationNumber.value,
            Name: this.Name.value,
            Email: this.Email.value,
            GroupNumber: this.GroupNumber.value,
            Erasmus: this.isErasmus
        };
        if (!this.isErasmus) {
            student.GroupNumber = this.GroupNumber.value;
        }
        return student;
    }

    saveUser(): void {
        const student = this.getUser();
        console.log(student);
        this.createService.saveStudent(student);
    }
}
