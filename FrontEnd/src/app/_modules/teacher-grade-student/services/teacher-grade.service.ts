import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrl } from '../../shared/services/ApiUrls';


@Injectable()
export class TeacherGradeService {

    url = 'https://421fab97.ngrok.io';
    constructor(private http: HttpClient) {

    }

    saveStudentGrades(data) {
       this.http.put(ApiUrl.ngRokUrl + '/attendances/UpdateOrInsert', data).subscribe();
    }

    saveStudentAttendance(data) {
        this.http.put(ApiUrl.ngRokUrl + '/attendances/UpdateOrInsert', data).subscribe();
    }

    getCourses() {
        return this.http.get(ApiUrl.ngRokUrl + '/courses');
    }

    getStudents() {
        return this.http.get(ApiUrl.ngRokUrl + '/students');
    }

    getEnrollments() {
        return this.http.get(ApiUrl.ngRokUrl + '/studentsCourses');
    }

    getAttendances() {
        return this.http.get(ApiUrl.ngRokUrl + '/attendances');
    }
}
