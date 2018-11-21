import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/Student';
import { Teacher } from '../models/Teacher';
import { AuthenticationService } from '../../shared/services/authentication.service';


@Injectable()
export class CreateUserService {

    constructor(private httpClient: HttpClient,
                private localStorage: AuthenticationService) {

    }

    saveStudent(student: Student): void {
        console.log(student);
    }

    saveTeacher(teacher: Teacher): void {
        console.log(teacher);
        console.log(this.localStorage.getLoggedUser());
    }
}
