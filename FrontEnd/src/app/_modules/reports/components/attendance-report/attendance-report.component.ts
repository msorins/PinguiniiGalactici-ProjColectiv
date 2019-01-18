import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';
import { ExcelService } from '../../services/xls.service';
import { COURSES_DATA } from 'src/app/_modules/shared/constants';

@Component({
    selector: 'app-attendance-report',
    templateUrl: './attendance-report.component.html',
    styleUrls: ['./attendance-report.component.css']
})

export class AttendacenReportComponent implements OnInit {

    // types = [{id: '63E3DF71-A7D4-4A30-9299-16A11E104536', name: 'Seminar'},
    // {id: '08AC7284-0228-4267-B3BD-A5FF5F5C9E5B', name: 'Laboratory'}, {id: 'D65D97BD-B6D1-4829-A6D3-26BD51E921FA', name: 'Course'},
    // {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Bonus'}, {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Partial'}];
    // groups = [935, 934, 936];
    // courses = [{Name: 'course1', id: 1}, {Name: 'course1', id: 2}, {Name: 'course1', id: 3}];
    types: any[];
    groups: any[];
    courses: any[];
    selectedType: any;
    selectedCourse: any;
    selectedGroup: any;
    excelData: any;
    columnChart = {
        type: 'ComboChart',
        data: [
          ['Week1', 8.94],
          ['Week2', 10.49],
          ['Week3', 19.30],
          ['Week4', 21.45],
          ['Week5', 21.45],
          ['Week6', 21.45],
          ['Week7', 21.45],
          ['Week8', 21.45],
          ['Week9', 21.45],
          ['Week10', 21.45],
          ['Week11', 21.45],
          ['Week12', 21.45],
          ['Week13', 0],
          ['Week14', 0],
        ],
        columnNames: ['Element', 'Attendances'],
        options: {
          animation: {
            duration: 250,
            easing: 'ease-in-out',
            startup: true
          }
        }
      };
    constructor(private reportsService: ReportsService,
        private excellService: ExcelService) {
        this.selectedCourse = null;
        this.selectedGroup = null;
        this.selectedType = null;
    }

    ngOnInit() {
        this.getCourses();
        this.getTypes();
        this.getGroups();
        // this.reportsService.getGroups().subscribe(groups => {
        //     this.groups = groups;
        //     this.selectedGroup = this.groups[0];
        // });

        // this.reportsService.getCourses().subscribe(courses => {
        //     this.courses = courses;
        //     this.selectedCourse = this.courses [0];
        // });
    }

    private getCourses() {
        this.reportsService.getCourses().subscribe(
            (apidata) => {
                this.courses = apidata,
                console.log(this.courses)
            },
            error => this.courses = COURSES_DATA
        );
    } 

    private getTypes() {
        this.reportsService.getTypes().subscribe(
            (apidata) => {
                this.types = apidata,
                console.log(apidata)
            },
            // error => this.courses = COURSES_DATA
        );
    } 

    private getGroups() {
        this.reportsService.getGroups().subscribe(
            (apidata) => {
                this.groups = apidata,
                console.log(apidata)
            },
            // error => this.courses = COURSES_DATA
        );
    } 

    onCourseSelected(event) {
        if (this.selectedCourse && this.selectedGroup && this.selectedType) {
           this.getData();
        }
    }

    onGroupSelected(event) {
        if (this.selectedCourse && this.selectedGroup && this.selectedType) {
            this.getData();
        }
    }

    onTypeSelected(event) {
        if (this.selectedCourse && this.selectedGroup && this.selectedType) {
            this.getData();
        }
    }

    exportExcell() {
        this.excellService.exportAsExcelFile(this.excelData, 'Attendances');
    }

    private getData() {
        const data = {
            CourseID: this.selectedCourse.CourseID,
            GroupID: this.selectedGroup.GroupNumber,
            TypeID: this.selectedType.TypeID
        };
        this.reportsService.getAttendaceReport(data).subscribe(info => {
            this.excelData = info;
            const result = [];
            this.excelData.forEach(element => {
                const miniList = [];
                miniList.push('Week' + element.WeekNr);
                miniList.push(element.AttendancesCount);
                result.push(miniList);
            });
            this.columnChart.data = result;
        });
    }
}
