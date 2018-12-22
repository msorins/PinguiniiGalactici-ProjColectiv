import { Component, OnInit, ViewChild } from '@angular/core';
import { AssignStudentService } from '../../services/assign-student.service';

@Component({
    selector: 'app-assign-student-page',
    templateUrl: './assign-student.component.html',
    styleUrls: ['./assign-student.component.css']
})
export class AssignStudentPageComponent implements OnInit {
    coursesList = [{id: 1, name: 'Mpp'}, {id: 1, name: 'Mpp'}, {id: 1, name: 'Mpp'},
    {id: 1, name: 'Mpp'}, {id: 1, name: 'Mpp'}, {id: 1, name: 'Mpp'}];
    studentList = [{id: 1, name: 'John', group: 911}, {id: 1, name: 'Mary', group: 911}, {id: 1, name: 'Ran', group: 911},
     {id: 1, name: 'Xaxa', group: 911}, {id: 1, name: 'Ich', group: 911}, {id: 1, name: 'Rin', group: 911},
    {id: 1, name: 'ddas', group: 911}, {id: 1, name: 'user2', group: 912}, {id: 1, name: 'user3', group: 913},
    {id: 1, name: 'student1', group: 913}, {id: 1, name: 'student3', group: 911}, {id: 1, name: 'student 4', group: 912}];
    groupSelected = null;
    displayedStudents = [];
    selectedStudents = [];
    selectedCourses = [];
    groups = [911, 912, 913, 914, 915];
    constructor(private assignStudentsService: AssignStudentService) {
        this.displayedStudents = this.studentList;
    }

    ngOnInit() {
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
        const studentData = this.selectedStudents.map(student => student.id);
        const coursesData = this.selectedCourses.map(course => course.id);
        const data = {
            students: studentData,
            courses: coursesData
        };
        this.selectedStudents = [];
        this.selectedCourses = [];
        alert('Students assigned');
        this.assignStudentsService.assignStudentsToCourses(data);
    }

    onGroupSelected(): void {
        if (this.groupSelected) {
            this.displayedStudents = this.studentList.filter(student => student.group === this.groupSelected);
        }
    }
}
