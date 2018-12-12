import { Component, OnInit } from '@angular/core';
import { Course } from '../../course.interface';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';

@Component({
    selector: 'app-teacher-courses',
    templateUrl: './teacher-courses.page.html',
    styleUrls: ['./teacher-courses.page.css']
})
export class TeacherCoursesPageComponent implements OnInit {
    private courses: Course[];

    constructor(private _coursesService: TeacherCoursesService) {
    }

    ngOnInit() {
        this._coursesService.getCourses().subscribe( (data: Course[]) => {
            this.courses = data;
        })
    }

}