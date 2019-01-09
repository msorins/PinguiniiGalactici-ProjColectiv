import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable()
export class TeacherGradeService {

    constructor(private http: HttpClient) {

    }

    saveStudentGrades(data) {
        console.log(data);
    }
}
