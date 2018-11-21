import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { LoggedUser } from '../../models/LoggedUser';

@Component({
    selector: 'app-teacher-menu',
    templateUrl: './teacher-menu.html',
    styleUrls: ['./teacher-menu.css']
})
export class TeacherMenuComponent implements OnInit {

    loggedUser: LoggedUser;
    constructor(
        private authenticationService: AuthenticationService
    ) {
        this.loggedUser = this.authenticationService.getLoggedUser();
    }
    ngOnInit() {

    }
}
