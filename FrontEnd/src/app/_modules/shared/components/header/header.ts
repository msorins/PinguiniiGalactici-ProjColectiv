import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { LoggedUser } from '../../models/LoggedUser';

@Component({
    selector: 'app-header',
    templateUrl: './header.html',
    styleUrls: ['./header.css']
})
export class HeaderComponent implements OnInit {
    loggedUser: LoggedUser;

    constructor(
        private authenticationService: AuthenticationService
    ) {
        this.loggedUser = this.authenticationService.getLoggedUser();
    }
    ngOnInit() {

    }
}
