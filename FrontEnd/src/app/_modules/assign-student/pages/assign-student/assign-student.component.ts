import { Component, OnInit, ViewChild } from '@angular/core';
import { AssignStudentService } from '../../services/assign-student.service';
import { Guid } from 'guid-typescript';

@Component({
    selector: 'app-assign-student-page',
    templateUrl: './assign-student.component.html',
    styleUrls: ['./assign-student.component.css']
})
export class AssignStudentPageComponent implements OnInit {
    coursesList: any;
    studentList: any;
    groupSelected = null;
    displayedStudents: any;
    selectedStudents = [];
    selectedCourses = [];
    groups: any;
    constructor(private assignStudentsService: AssignStudentService) {
    }

    ngOnInit() {
        this.assignStudentsService.getStudents().subscribe(students => {
            this.studentList = students;
            this.displayedStudents = students;
            console.log(students);
            this.groups = this.trimList(this.studentList.map(st => st.GroupNumber));
        });

        this.assignStudentsService.getCourses().subscribe(courses => {
            this.coursesList = courses;
            console.log(courses);
        });
    }

    toggleAssignStudents(): boolean {
        if (this.selectedStudents.length === 0 || this.selectedCourses.length === 0) {
            return true;
        }

        return false;
    }
    checkIfStudentAlreadyAssignedForACourse() {
        // will get the courses for a certain student then check if the student is assingned
        // when is pressed then an error will pe displayed in alert with the name of the student and course
    }
    assignStudentsToCourses(): void {
        console.log(this.selectedCourses);
        console.log(this.selectedStudents);
        const studentData = this.selectedStudents.map(student => student.RegistrationNumber);
        const coursesData = this.selectedCourses.map(course => course.CourseID);
        const data = [];
        for (let i = 0; i < studentData.length; i++) {
            for (let j = 0; j < coursesData.length; j++) {
                const id = Guid.create().toString();
                const obj = {
                    EnrollmentID: id,
                    StudentID: studentData[i],
                    CourseID: coursesData[i]
                };
                data.push(obj);
            }
        }
        this.selectedStudents = [];
        this.selectedCourses = [];
        alert('Students assigned');
        this.assignStudentsService.assignStudentsToCourses(data);
    }

    onGroupSelected(): void {
        if (this.groupSelected) {
            this.displayedStudents = this.studentList.filter(student => student.GroupNumber === this.groupSelected);
        }
    }

    private trimList(list) {
        const result = [];
        list.forEach(element => {
            const index = result.indexOf(element);
            if (index === -1) {
                result.push(element);
            }
        });
        return result;
    }
}
