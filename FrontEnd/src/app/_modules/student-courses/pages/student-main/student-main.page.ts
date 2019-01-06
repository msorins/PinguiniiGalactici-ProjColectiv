import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/Course';
import { StudentCoursesService } from '../../services/student-courses.service';
import { StudentData } from '../../student-data.interface.1';
import { StudentTable } from '../../student-table.interface';

@Component({
    selector: 'app-student-main',
    templateUrl: './student-main.page.html',
    styleUrls: ['./student-main.page.css']
})
export class StudentMainPageComponent implements OnInit {
    private data: StudentTable[] = [];

    constructor(private _studentService: StudentCoursesService) {
    }

    ngOnInit() {
        this._studentService.getData().subscribe( (data: StudentTable[]) => {
            this.data = data;
            console.log(data);
        });
    }

}