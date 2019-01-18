import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/Student';
import { Teacher } from '../models/Teacher';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { ApiUrl } from '../../shared/services/ApiUrls';
import { debug } from 'util';


@Injectable()
export class CreateUserService {

    constructor(private httpClient: HttpClient,
                private localStorage: AuthenticationService) {

    }

    saveStudent(student: Student): void {
        this.httpClient.post(ApiUrl.url + '/students', student).subscribe((data: any) =>  {
            console.log("Done");
            console.log(data);
        });
        //this.httpClient.post(ApiUrl.ngRokUrl + '/students', student).subscribe();
    }

    saveTeacher(teacher): void {
        this.httpClient.post(ApiUrl.url + '/teachers', teacher).subscribe((data: any) => {
            console.log(data);
        });
    }
}
