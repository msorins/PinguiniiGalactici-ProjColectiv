import { OnInit, Component } from '@angular/core';
import { debug } from 'util';
import { TeacherGradeService } from '../../services/teacher-grade.service';
import { STUDENTS_DATA_ATTENDANCES, COURSES_DATA } from 'src/app/_modules/shared/constants';
import { Guid } from 'guid-typescript';

@Component({
    selector: 'app-attend-student',
    templateUrl: './attend-student.component.html',
    styleUrls: ['./attend-student.component.css']
})
export class AttendStudentComponent implements OnInit {
    // allStudents = [{id: 1, name: 'John12', group: 911}, {id: 2, name: 'John3', group: 912}, {id: 3, name: 'John4', group: 913},
    // {id: 4, name: 'John6', group: 914},
    // {id: 5, name: 'John4141', group: 915}, {id: 6, name: 'John1312', group: 916}, {id: 7, name: 'John656', group: 921},
    // {id: 8, name: 'John5', group: 931},
    // {id: 9, name: 'John5543534', group: 941}, {id: 10, name: 'John432423', group: 951},
    // {id: 11, name: 'John42342', group: 961}, {id: 12, name: 'John', group: 931}];
    allStudents: any;
    displayedStudents: any;
    selectedStudents: any;
    groups: any;
    // courses = [{id: 1, name: 'Some Course'}, {id: 2, name: 'Some other course'}];
    courses: any;
    weeks = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14];
    types = [{id: '63E3DF71-A7D4-4A30-9299-16A11E104536', name: 'Seminar'},
    {id: '08AC7284-0228-4267-B3BD-A5FF5F5C9E5B', name: 'Laboratory'}, {id: 'D65D97BD-B6D1-4829-A6D3-26BD51E921FA', name: 'Course'},
    {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Bonus'}, {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Partial'}];
    selectedWeek: any;
    selectedType: any;
    selectedCourse: any;
    enrollments: any;
    constructor(private teacherService: TeacherGradeService) {
        // this.displayedStudents = this.allStudents;
        // this.groups = this.trimResult(this.displayedStudents.map(s => s.GroupNumbers));
    }

    ngOnInit() {
        this.teacherService.getStudents().subscribe(students => {
            this.allStudents = students;
            this.displayedStudents = students;
            this.groups = this.trimResult(this.allStudents.map(s => s.GroupNumber));
        });
        this.teacherService.getCourses().subscribe(courses => {
            this.courses = courses;
        });
        this.teacherService.getEnrollments().subscribe(enrl => {
            this.enrollments = enrl;
        });
    }

    onWeekChanged(event): void {
        console.log(event.value);
    }

    onGroupChange(event): void {
        if (event.value && event.value !== '') {
            this.displayedStudents = this.allStudents.filter(s => s.GroupNumber === event.value);
            console.log(this.displayedStudents);
        } else {
            this.displayedStudents = this.allStudents;
        }
    }

    applyFilter(value): void {
        if (value && value !== '') {
            this.displayedStudents = this.allStudents.filter(s => {
                const index = s.Name.indexOf(value);
                if (index > -1) {
                    return true;
                }
                return false;
            });
            console.log(this.displayedStudents);
        } else {
            this.displayedStudents = this.allStudents;
        }
    }

    onCourseChanged(event) {
        const course = event.value;
        const studentsIds = this.enrollments.filter(std => std.CourseID === course).map(std => std.StudentID);
        console.log(this.enrollments);
        console.log('ids');
        console.log(studentsIds);
        console.log(course);
        console.log(this.allStudents);
        const result = [];
        for (let i = 0; i < studentsIds.length; i++) {
            for (let j = 0; j < this.allStudents.length; j++) {
                console.log(this.allStudents[j]);
                if (studentsIds[i] === this.allStudents[j].RegistrationNumber) {
                    result.push(this.allStudents[j]);
                }
            }
        }
        console.log('result');
        console.log(result);
        this.displayedStudents = this.trimResult(result);
    }

    toggleSaveChanges(): boolean {
        if (this.selectedWeek && this.selectedStudents.length > 0) {
            return false;
        }
        return true;
    }

    saveChanges(): void {
        console.log(this.selectedStudents);
        for (let i = 0; i < this.selectedStudents.length; i++) {
            const id = Guid.create().toString();
            const data = {
                StudentID: this.selectedStudents[i].RegistrationNumber,
                TypeID: this.selectedType.id,
                WeekNr: this.selectedWeek,
                CourseID: this.selectedCourse
            };
            this.teacherService.saveStudentAttendance(data);
            console.log('entered');
        }
        this.selectedStudents = [];
        this.selectedCourse = null;
        this.selectedType = null;
        this.selectedWeek = null;
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
