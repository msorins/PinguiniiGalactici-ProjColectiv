import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiUrl } from '../../shared/services/ApiUrls';


@Injectable()
export class AssignStudentService {

    constructor(private http: HttpClient) {
    }


    assignStudentsToCourses(studentsCourses: any): void {
        console.log(studentsCourses);
        this.http.post(ApiUrl.assingStudentUrl, studentsCourses).subscribe();
    }
}
