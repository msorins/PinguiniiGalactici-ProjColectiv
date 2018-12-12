import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Student } from "../../create-user/models/Student";
import { HttpClient } from "@angular/common/http";
import { ApiUrl } from "./ApiUrls";
import { Course } from "src/app/models/Course";

@Injectable()
export class ConfigService {

    constructor(private http: HttpClient) { 
        console.log("in services");
        this.getAllStudents().subscribe(
            data => {
                console.log("students", data)
            },
            error => {
                console.log("error")
            }
        );
        this.getAllCourses().subscribe(
            data => {
                console.log("courses: ", data);
            },
            error => {
                console.log("error")
            }
        )
    }

    getAllStudents(): Observable<Array<Student>> {
        return this.http.get<Array<Student>>("http://localhost:3000/students");
    }

    getAllCourses() : Observable<Array<Course>> {
        return this.http.get<Array<Course>>("http://localhost:3000/courses");
    }
}