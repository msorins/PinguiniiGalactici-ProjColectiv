import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user';



@Injectable()
export class SharedService {


    constructor(
        private http: HttpClient
    ) {
    }

    uploadUsers(users: User[]): void {
        console.log(users);
    }
}
