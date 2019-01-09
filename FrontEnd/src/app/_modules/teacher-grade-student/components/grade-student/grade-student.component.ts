import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { TeacherGradeService } from '../../services/teacher-grade.service';
import { group } from '@angular/animations';


@Component({
    selector: 'app-grade-student',
    templateUrl: './grade-student.component.html',
    styleUrls: ['./grade-student.component.css']
})
export class GradeStudentComponent implements OnInit {

    allStudents = [{id: 1, name: 'John12', group: 911}, {id: 2, name: 'John3', group: 912}, {id: 3, name: 'John4', group: 913},
    {id: 4, name: 'John6', group: 914},
    {id: 5, name: 'John4141', group: 915}, {id: 6, name: 'John1312', group: 916}, {id: 7, name: 'John656', group: 921},
    {id: 8, name: 'John5', group: 931},
    {id: 9, name: 'John5543534', group: 941}, {id: 10, name: 'John432423', group: 951},
    {id: 11, name: 'John42342', group: 961}, {id: 12, name: 'John', group: 931}];
    studentsDisplayed: any[];
    courses = [{id: 1, name: 'Some Course'}, {id: 2, name: 'Some other course'}];
    weeks = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14];
    types = [{id: 1, name: 'Seminar'}, {id: 2, name: 'Laboratory'}, {id: 3, name: 'Course'}];
    groups: any;
    selectedStudents = [];
    selectedCourse: any;
    selectedWeek: any;
    selectedType: any;

    gradeFormGroup: FormGroup;
    grade: AbstractControl;
    constructor(private builder: FormBuilder,
                private teacherService: TeacherGradeService) {
        this.gradeFormGroup = builder.group({
            grade: new FormControl('', Validators.required),
        });

        this.grade = this.gradeFormGroup.get('grade');
    }

    ngOnInit() {
        this.studentsDisplayed = this.allStudents;
        this.groups = this.trimResult(this.allStudents.map(s => s.group));
        console.log(this.groups);
    }

    onCourseChanged(event): void {
        console.log(this.selectedCourse);
    }

    onTypeChanged(event): void {
        console.log(this.selectedType);
    }

    onWeekChanged(event): void {
        console.log(this.selectedWeek);
    }

    onGroupChange(event): void {
        debugger;
        if (event.value) {
            this.studentsDisplayed = this.allStudents.filter(s => s.group === event.value);
        } else {
            this.studentsDisplayed = this.allStudents;
        }
    }

    toggleSaveChanges(): boolean {
        if (this.selectedCourse && this.selectedStudents && this.selectedType && this.selectedWeek && this.grade.value !== ''
        && this.selectedStudents.length > 0) {
            if (parseInt(this.grade.value, 10) && parseInt(this.grade.value, 10) >= 1 && parseInt(this.grade.value, 10) <= 10 ) {
                return false;
            } else {
                return true;
            }
        }
        return true;
    }

    saveChanges(): void {
        console.log(this.selectedStudents);
        const data = {
            students: this.selectedStudents,
            course: this.selectedCourse,
            type: this.selectedType,
            week: this.selectedWeek,
            grade: parseFloat(this.grade.value)
        };
       this.teacherService.saveStudentGrades(data);
    }

    applyFilter(value): void {
        console.log(value);
        if (value && value !== '') {
            this.studentsDisplayed = this.allStudents.filter(s => {
                const index = s.name.indexOf(value);
                if (index > -1) {
                    return true;
                }
                return false;
            });
        } else {
            this.studentsDisplayed = this.allStudents;
        }
    }

    private trimResult(groups): any[] {
        const result = [];
        groups.forEach(st => {
            const index = result.indexOf(st);
            if (index === -1) {
                result.push(st);
            }
        });
        return result;
    }
}
