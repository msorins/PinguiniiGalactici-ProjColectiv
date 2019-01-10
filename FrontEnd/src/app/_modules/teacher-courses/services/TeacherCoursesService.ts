import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class TeacherCoursesService {

    constructor(private http: HttpClient) { }

    public getCourses(): Observable<any[]> {
        return this.http
        .get<any[]>('http://localhost:53440/courses')
    }

    saveGrades(data) {
        console.log(data);
    }

    saveAttendance(data) {
        console.log(data);
    }
}
