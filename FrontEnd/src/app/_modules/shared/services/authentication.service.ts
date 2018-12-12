import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Subscriber } from 'rxjs';
import { LoggedUser } from '../models/LoggedUser';
import { USE_VALUE } from '@angular/core/src/di/injector';


@Injectable()
export class AuthenticationService {
    private JWT: string;

    constructor(private http: HttpClient) { }

    // To do => refactor above functions into one
    loginStudent(info: any) {
        console.log(info);
        this.login(info['email'], info['password']);
    }

    loginTeacher(info: any) {
        console.log(info);
        this.login(info['email'], info['password']);
    }

    login(username: string, password: string) {
        console.log('Doing post');
        return this.http.post<any>(`/users/authenticate`, { username, password })
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
                console.log('User logged in', user);
                return user;
            }))
            .subscribe();
    }

    logout() {
        localStorage.removeItem('currentUser');
    }

    getLoggedUser(): LoggedUser {
        const user = JSON.parse(localStorage.getItem('currentUser'));
        console.log(user);
        if(user == null) {
            return null;
        }
        
        const loggedUser: LoggedUser = {
            Id: user.id,
            Name: user.username,
            FirstName: user.firstName,
            LastName: user.lastName,
            Admin: true
        };

        return loggedUser;
    }
}
