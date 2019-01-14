import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class TeacherCoursesService {

    constructor(private http: HttpClient) { }    

    public getCourses(): Observable<any[]> {
        const headerDict = {
            access_token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InJhcmVzQDEyMy5jb20iLCJjZXJ0cHVibGlja2V5IjoiaFBPZi9iejUzUDVjQlpHV29pT1h4QXhmMGJ6YW1mb2plS01ONnc1cEMwSlhvT0NMK1FCMXZKRjEwRzVhRy9Cd3V2UmVuNGxjV3g4ZkRxdVdGVDZETUFqSW5qdldVWE5MbVVldnU5dVIvY21hakFqVFJVTGdkVm9UUEhOR2lNZ01jVC9uNVQ5L2Q4eGx5b3NNdmxGZURGMnEyUmN3d2VBNURCL0wzN2FaVURRPSIsInJvbGUiOiJUZWFjaGVyIiwibmJmIjoxNTQ3MjA0MTY3LCJleHAiOjE1NDcyMDUzNjcsImlhdCI6MTU0NzIwNDE2N30.8e5KsoLADMgko-edZwlR2dgqjwMxSivbOG66nJF6iyM",
        }
          
        const requestOptions = {                                                                                                                                                                                 
        headers: new HttpHeaders(headerDict), 
        };

        return this.http
        .get<any[]>('http://localhost:53440/courses', requestOptions);
    }

    saveGrades(data) {
        console.log(data);
    }

    saveAttendance(data) {
        console.log(data);
    }
}
