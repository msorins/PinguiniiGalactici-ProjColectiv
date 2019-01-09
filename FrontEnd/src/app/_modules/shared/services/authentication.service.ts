import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Subscriber, Subscription, Observable, of } from 'rxjs';
import { LoggedUser } from '../models/LoggedUser';
import { USE_VALUE } from '@angular/core/src/di/injector';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from 'src/app/models/user';

@Injectable()
export class AuthenticationService {
    private JWT: string;
    private mocked: boolean = false;

    constructor(private http: HttpClient) { }

    // To do => refactor above functions into one
    loginStudent(info: any): Observable<LoggedUser> {
        console.log(info);
        return this.login(info['email'], info['password']);
    }

    loginTeacher(info: any): Observable<LoggedUser> {
        console.log(info);
        return this.login(info['email'], info['password']);
    }

    login(username: string, password: string): Observable<LoggedUser> {
        const headerDict = {
            'username': username,
            'password': password,
        }
          
          const requestOptions = {                                                                                                                                                                                 
            headers: new HttpHeaders(headerDict), 
          };
        
        if(this.mocked) {
            let usr = new LoggedUser();
            usr.Id = 1;
            usr.Admin = true;
            usr.FirstName = usr.LastName = usr.Name = "Admin";
            usr.Token = "1234";

            localStorage.setItem('currentUser', JSON.stringify(usr));
            return of(usr);
        }

        return this.http.get<any>(`http://localhost:53440/token`, requestOptions)
            .pipe(map(token => {
                // login successful if there's a jwt token in the response
                if (token) {  
                    // Decode the token
                    const helper = new JwtHelperService();
                    const decodedToken = helper.decodeToken(token);

                    // Form User Object
                    var user = new LoggedUser();
                    user.Token = token;
                    user.Name = decodedToken.unique_name;
                    user.FirstName = user.Name;
                    user.LastName = user.Name;

                    localStorage.setItem('currentUser', JSON.stringify(user));
                    console.log("Login was successful: ", JSON.stringify(user));
                    return user;
                }
            
                return null;
            }));
    }

    logout() {
        localStorage.removeItem('currentUser');
    }

    getLoggedUser(): LoggedUser {
        const loggedUser = JSON.parse(localStorage.getItem('currentUser'));
        return loggedUser;
    }
}
