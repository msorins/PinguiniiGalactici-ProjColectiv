import { Component, OnInit } from '@angular/core';
import { FormControl, AbstractControl, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { AssignGroupService } from '../services/assign-group.service';
import { Guid } from 'guid-typescript';

@Component({
    selector: 'app-assign-group',
    templateUrl: './assign-group.page.html',
    styleUrls: ['./assign-group.page.css']
})
export class AssignGroupPageComponent implements OnInit {

    createGroup: FormGroup;
    createCourse: FormGroup;
    group: AbstractControl;
    course: AbstractControl;
    year: AbstractControl;
    labnr: AbstractControl;
    seminarsnr: AbstractControl;
    studentList = [{id: 1, name: 'John', group: undefined}, {id: 2, name: 'Mary', group: undefined},
    {id: 3, name: 'Alex', group: undefined}, {id: 4, name: 'Dan', group: 911}, {id: 5, name: 'Arnold', group: 911},
    {id: 6, name: 'Xavi', group: 915}, {id: 7, name: 'Xavier', group: 912}, {id: 8, name: 'Jean', group: 913},
    {id: 1, name: 'John', group: undefined}, {id: 2, name: 'Mary', group: undefined},
    {id: 3, name: 'Alex', group: undefined}, {id: 4, name: 'Dan', group: 911}, {id: 5, name: 'Arnold', group: 911},
    {id: 6, name: 'Xavi', group: 915}, {id: 7, name: 'Xavier', group: 912}, {id: 8, name: 'Jean', group: 913},
    {id: 1, name: 'John', group: undefined}, {id: 2, name: 'Mary', group: undefined},
    {id: 3, name: 'Alex', group: undefined}, {id: 4, name: 'Dan', group: 911}, {id: 5, name: 'Arnold', group: 911},
    {id: 6, name: 'Xavi', group: 915}, {id: 7, name: 'Xavier', group: 912}, {id: 8, name: 'Jean', group: 913}];
    displayedStudents = [];
    existingGroups = [];
    selectedStudents = [];
    groupSelected: number;
    constructor(private formBuilder: FormBuilder,
        private assignGroupService: AssignGroupService) {
        this.createGroup = formBuilder.group({
           group: new FormControl('', Validators.required),
        });

        this.createCourse = formBuilder.group({
            course: new FormControl('', Validators.required),
            labnr: new FormControl('', Validators.required),
            year: new FormControl('', Validators.required),
            seminarsnr: new FormControl('', Validators.required)
        });

        this.group = this.createGroup.get('group');
        this.course = this.createCourse.get('course');
        this.year = this.createCourse.get('year');
        this.labnr = this.createCourse.get('labnr');
        this.seminarsnr = this.createCourse.get('seminarsnr');
    }

    ngOnInit() {
       this.onRefresh();
    }

    toggleCreateGroup(): boolean {

        if (this.selectedStudents.length === 0 || this.group.value === '' || isNaN(this.group.value)) {
            return true;
        }

        return false;
    }

    toggleAssignToExistingGroup(): boolean {
        if (this.selectedStudents.length === 0  || this.groupSelected === undefined) {
            return true;
        }

        return false;
    }

    // onAssignToExistingGroup() {
    //     const selectedInfo = this.selectedStudents.map(el => el.id);
    //     const groupNr = this.groupSelected;
    //     const info = {
    //         students: selectedInfo,
    //         group: groupNr
    //     };
    //     this.assignGroupService.assignToExistingGroup(info);
    //     this.onRefresh();
    // }

    onCreateNewGroup() {
        const selectedInfo = this.selectedStudents.map(el => el.id);
        const groupNr = parseInt(this.group.value, 10);
        const info = {
            students: selectedInfo,
            group: groupNr
        };
        this.assignGroupService.createNewGroup(info);
        this.onRefresh();
    }

    onRefresh() {
        // get call to the server first
        this.displayedStudents = this.studentList.filter(student => student.group === undefined);
        this.existingGroups = this.trimResult(this.studentList.filter(student => student.group !== undefined)
        .map(student => student.group));
    }

    toggleSaveGroup() {
        if (this.group.value === '' || isNaN(this.group.value)) {
            return true;
        }
        return false;
    }

    toggleSaveCourse() {
        if (this.course.value === '' || isNaN(this.labnr.value) || isNaN(this.seminarsnr.value) ||
        parseInt(this.labnr.value, 10) > 14 || parseInt(this.labnr.value, 10) < 0 ||
        parseInt(this.seminarsnr.value, 10) > 14 || parseInt(this.seminarsnr.value, 10) < 0) {
            return true;
        }
        return false;
    }

    saveGroup() {
        const id = Guid.create();
        const data = {
            GroupNumber: parseInt(this.group.value, 10),
            DepartmentID: '83604CF3-BC0A-4F59-AABE-841B14B12A17'
        };

        this.assignGroupService.createNewGroup(data);
    }

    saveCourse() {
      const id = Guid.create();
      console.log(id.toString());
      const data = {
          CourseID: id.toString(),
          Name: this.course.value,
          DepartmentID: '83604CF3-BC0A-4F59-AABE-841B14B12A17',
          Year: this.year.value,
          TotalLabNr: parseInt(this.labnr.value, 10),
          TotalSeminarNr: parseInt(this.seminarsnr.value, 10)
      };
      this.assignGroupService.createCourse(data);
    }

    private trimResult(groups) {
        const result = [];
        groups.forEach(el => {
            const index = result.indexOf(el, 0);
            if (index === -1) {
                result.push(el);
            }
        });
        return result;
    }
}
