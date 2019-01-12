import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiUrl } from '../../shared/services/ApiUrls';


@Injectable()
export class AssignStudentService {

    constructor(private http: HttpClient) {
    }


    assignStudentsToCourses(studentsCourses: any): void {
        console.log(studentsCourses);
        this.http.post(ApiUrl.ngRokUrl + '/studentsCourses/insertBulk', studentsCourses).subscribe();
    }

    getStudents() {
        return this.http.get(ApiUrl.ngRokUrl + '/students');
    }

    getCourses() {
        return this.http.get(ApiUrl.ngRokUrl + '/courses');
    }
}
