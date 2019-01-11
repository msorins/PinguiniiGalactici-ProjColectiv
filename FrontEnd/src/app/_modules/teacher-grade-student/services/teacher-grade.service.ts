import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable()
export class TeacherGradeService {

    url = 'https://421fab97.ngrok.io';
    constructor(private http: HttpClient) {

    }

    saveStudentGrades(data) {
        console.log(data);
    }

    saveStudentAttendance(data) {
        console.log(data);
    }

    getCourses() {
        this.http.get(this.url + '/courses').subscribe(s => {
            console.log(s);
        });
    }
}
