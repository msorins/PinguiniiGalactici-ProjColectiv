import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiUrl } from '../../shared/services/ApiUrls';
import { Student } from '../../create-user/models/Student';
import { Attendance } from 'src/app/models/Attendance';

@Injectable()
export class TeacherCoursesService {

    constructor(private http: HttpClient) { }    

    public getCourses(): Observable<any[]> {
        return this.http
        .get<any[]>(ApiUrl.url + '/courses');
    }

    public getStudents(courseId: string): Observable<any[]> {
        return this.http.get<any[]>(ApiUrl.url + '/students/fromCourse/' + courseId);
    }

    public getAttendances(courseID: string, studentID: number): Observable<Attendance[]> {
        return this.http.get<Attendance[]>(ApiUrl.url + '/attendances/withCourseAndStudent/' + courseID + '/' + studentID);
    }

    saveGrades(data) {
        console.log(data);
    }

    saveAttendance(data) {
        console.log(data);
    }
}
