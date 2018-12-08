import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/Student';
import { Teacher } from '../models/Teacher';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { ApiUrl } from '../../shared/services/ApiUrls';


@Injectable()
export class CreateUserService {

    constructor(private httpClient: HttpClient,
                private localStorage: AuthenticationService) {

    }

    saveStudent(student: Student): void {
        this.httpClient.post(ApiUrl.insertUserUrl, student);
    }

    saveTeacher(teacher: Teacher): void {
        console.log(teacher);
        console.log(this.localStorage.getLoggedUser());
    }
}
