import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Course } from '../course.interface';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class TeacherCoursesService {

    constructor(private http: HttpClient) { }

    public getCourses() : Observable<Course[]> {
        return this.http
        .get<Course[]>('http://www.mocky.io/v2/5c114cee2e0000940a55ba49')
    }
}