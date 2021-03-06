import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { LoggedUser } from '../../models/LoggedUser';
import { StudentUser } from '../../models/StudentUser';
import { Student } from 'src/app/_modules/create-user/models/Student';
import { SharedService } from '../../services/SharedService';

@Component({
    selector: 'app-teacher-menu',
    templateUrl: './teacher-menu.html',
    styleUrls: ['./teacher-menu.css']
})
export class TeacherMenuComponent implements OnInit {

    loggedUser: LoggedUser;
    readUsers: any;
    constructor(
        private authenticationService: AuthenticationService,
        private sharedService: SharedService
    ) {
        this.loggedUser = this.authenticationService.getLoggedUser();
        console.log(this.loggedUser);
    }
    ngOnInit() {

    }

    importFile(event): void {
        if (event && event.srcElement && event.srcElement.files.length > 0) {
            const fileName = event.srcElement.files[0];
            const reader = new FileReader();
            reader.readAsText(fileName);
            reader.onload = () => {
                this.readUsers = reader.result;
                this.parseFileContent(this.readUsers);
            };
        }
    }

    parseFileContent(content: string): void {
        const lines = content.split('\n');
        const users = [];
        console.log(lines);
        lines.forEach(line => {
            const tokens = line.split(',');
            if (tokens.length !== 6) {
                const index = lines.indexOf(line);
                alert('Invalid student format at line:' + index);
            } else {
                const user: StudentUser = new StudentUser();
                if (tokens[4] === '1' ) {
                    user.GroupNumber = 123;
                } else {
                    const y = 0;
                    user.GroupNumber = parseInt(tokens[3], 10);
                }

                user.Name = tokens[0];
                user.Email = tokens[1];
                user.Password = tokens[5];
                user.RegistrationNumber = parseInt(tokens[2], 10);
                users.push(user);
            }
        });
        this.sharedService.uploadUsers(users);
    }
}
