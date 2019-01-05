import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class TeacherCoursesService {

    constructor(private http: HttpClient) { }

    public getCourses(): Observable<any[]> {
        return this.http
        .get<any[]>('http://www.mocky.io/v2/5c114cee2e0000940a55ba49')
    }

    saveGrades(data) {
        console.log(data);
    }
}
