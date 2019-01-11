import { OnInit, Component } from '@angular/core';
import { debug } from 'util';
import { TeacherGradeService } from '../../services/teacher-grade.service';
import { STUDENTS_DATA_ATTENDANCES, COURSES_DATA } from 'src/app/_modules/shared/constants';

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
    allStudents = STUDENTS_DATA_ATTENDANCES;
    displayedStudents: any[];
    selectedStudents: any;
    groups: any;
    // courses = [{id: 1, name: 'Some Course'}, {id: 2, name: 'Some other course'}];
    courses = COURSES_DATA;
    weeks = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14];
    types = [{id: 1, name: 'Seminar'}, {id: 2, name: 'Laboratory'}, {id: 3, name: 'Course'}];
    selectedWeek: any;
    selectedType: any;
    selectedCourse: any;
    constructor(private teacherService: TeacherGradeService) {
        this.displayedStudents = this.allStudents;
        this.groups = this.trimResult(this.displayedStudents.map(s => s.GroupNumbers));
    }

    ngOnInit() {
        this.teacherService.getCourses();
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
        debugger;
        if (value && value !== '') {
            this.displayedStudents = this.allStudents.filter(s => {
                const index = s.Name.indexOf(value);
                if (index > -1) {
                    return true;
                }
                return false;
            });
            console.log(this.displayedStudents);
            debugger;
        } else {
            debugger;
            this.displayedStudents = this.allStudents;
        }
    }

    toggleSaveChanges(): boolean {
        if (this.selectedWeek && this.selectedStudents.length > 0) {
            return false;
        }
        return true;
    }

    saveChanges(): void {
        console.log(this.selectedStudents);
        const data = {
            students: this.selectedStudents,
            week: this.selectedWeek,
        };
       this.teacherService.saveStudentAttendance(data);
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
