import {Component, OnInit, NgZone} from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-landing-page',
    templateUrl: './landing-page.component.html',
    styleUrls: ['./landing-page.component.css']
})

export class LandingPageComponent implements OnInit {

    studentHovered = false;
    teacherHovered = false;
    constructor(
        private router: Router
    ) {
    }

    ngOnInit() {
    }

    toggleStudent(event): void {
        this.studentHovered = !this.studentHovered;
    }

    toggleTeacher(event): void {
        this.teacherHovered = !this.teacherHovered;
    }

    goToLoginStudent(): void {
        this.router.navigate(['/login/student']);
    }

    goToLoginTeacher(): void {
        this.router.navigate(['/login/teacher']);
    }
}
