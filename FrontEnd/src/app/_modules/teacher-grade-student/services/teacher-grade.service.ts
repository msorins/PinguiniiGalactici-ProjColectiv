import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrl } from '../../shared/services/ApiUrls';


@Injectable()
export class TeacherGradeService {

    url = 'http://localhost:53440';
    constructor(private http: HttpClient) {

    }

    saveStudentGrades(data) {
       this.http.put(ApiUrl.url + '/attendances/UpdateOrInsert', data).subscribe();
    }

    saveStudentAttendance(data) {
        this.http.put(ApiUrl.url + '/attendances/UpdateOrInsert', data).subscribe();
    }

    getCourses() {
        return this.http.get(ApiUrl.url + '/courses');
    }

    getStudents() {
        return this.http.get(ApiUrl.url + '/students');
    }

    getEnrollments() {
        return this.http.get(ApiUrl.url + '/studentsCourses');
    }

    getAttendances() {
        return this.http.get(ApiUrl.url + '/attendances');
    }
}
