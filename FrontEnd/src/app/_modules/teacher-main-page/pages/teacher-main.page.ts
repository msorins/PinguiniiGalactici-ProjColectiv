import { Component, OnInit } from '@angular/core';
import { FormBuilder, AbstractControl, FormControl, FormGroup } from '@angular/forms';


@Component({
    selector: 'app-teacher-main-page',
    templateUrl: './teacher-main.page.html',
    styleUrls: ['./teacher-main.page.css']
})
export class TeacherMainPageComponent implements OnInit{
    username: AbstractControl;
    password: AbstractControl;
    createUser: FormGroup;
    panelOpenState = false;
    
    constructor(private formBuilder: FormBuilder) {

        this.createUser = formBuilder.group({
            username: new FormControl(''),
            password: new FormControl('')
        });
        this.username = this.createUser.get('username');
        this.username.patchValue('hello');
        console.log(this.username);
        this.password = this.createUser.get('password');

    }

    ngOnInit() {
    }
}
