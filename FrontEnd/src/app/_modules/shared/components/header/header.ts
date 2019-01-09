import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { LoggedUser } from '../../models/LoggedUser';
import { Router } from '@angular/router';

@Component({
    selector: 'app-header',
    templateUrl: './header.html',
    styleUrls: ['./header.css']
})
export class HeaderComponent implements OnInit {
    loggedUser: LoggedUser;

    constructor(
        private authenticationService: AuthenticationService,
        private router: Router
    ) {
        this.loggedUser = this.authenticationService.getLoggedUser();
    }
    ngOnInit() {

    }

    logout() {
        this.router.navigate(['/']);
    }
}
