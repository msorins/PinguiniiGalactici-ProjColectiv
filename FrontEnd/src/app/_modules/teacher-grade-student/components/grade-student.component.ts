import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators, AbstractControl } from '@angular/forms';


@Component({
    selector: 'app-grade-student',
    templateUrl: './grade-student.component.html',
    styleUrls: ['./grade-student.component.css']
})
export class GradeStudentComponent implements OnInit {

    studentsDisplayed: any[] = [{id: 1, name: 'John'}, {id: 2, name: 'John'}, {id: 3, name: 'John'}, {id: 4, name: 'John'}];
    courses = [{id: 1, name: 'Some Course'}, {id: 2, name: 'Some other course'}];
    weeks = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14];
    types = [{id: 1, name: 'Seminar'}, {id: 2, name: 'Laboratory'}, {id: 3, name: 'Course'}];
    selectedStudents = [];
    selectedCourse: any;
    selectedWeek: any;
    selectedType: any;

    gradeFormGroup: FormGroup;
    grade: AbstractControl;
    constructor(private builder: FormBuilder) {
        this.gradeFormGroup = builder.group({
            grade: new FormControl('', Validators.required),
        });

        this.grade = this.gradeFormGroup.get('grade');
    }

    ngOnInit() {
    }

    onCourseChanged(event): void {
        console.log(event);
    }

    onTypeChanged(event): void {
        console.log(event);
    }

    onWeekChanged(event): void {
        console.log(event);
    }
}
