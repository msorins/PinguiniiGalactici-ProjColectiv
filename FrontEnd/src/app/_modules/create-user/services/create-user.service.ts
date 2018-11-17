import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/Student';


@Injectable()
export class CreateUserService {

    constructor(private httpClient: HttpClient) {

    }

    saveStudent(student: Student): void {
        console.log(student);
    }
}
