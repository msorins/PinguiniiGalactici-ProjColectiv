import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Subscriber } from 'rxjs';


@Injectable()
export class AuthenticationService {
    private JWT: string;

    constructor(private http: HttpClient) { }

    // To do => refactor above functions into one
    loginStudent(info: any){
        console.log(info);
        this.login(info["email"], info["password"]);
    }

    loginTeacher(info: any){
        console.log(info);
        this.login(info["email"], info["password"]);
    }

    login(username: string, password: string) {
        console.log("Doing post");
        return this.http.post<any>(`/users/authenticate`, { username, password })
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
                console.log("User logged in", user)
                return user;
            }))
            .subscribe();
    }

    logout() {
        localStorage.removeItem('currentUser');
    }
}
