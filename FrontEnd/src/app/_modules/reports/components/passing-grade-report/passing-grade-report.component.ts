import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';
import { ExcelService } from '../../services/xls.service';
import { COURSES_DATA } from 'src/app/_modules/shared/constants';

@Component({
    selector: 'app-passing-grade-report',
    templateUrl: './passing-grade-report.component.html',
    styleUrls: ['./passing-grade-report.component.css']
})
export class PassingGradeReportComponent implements OnInit {
    // types = [{id: '63E3DF71-A7D4-4A30-9299-16A11E104536', name: 'Seminar'},
    // {id: '08AC7284-0228-4267-B3BD-A5FF5F5C9E5B', name: 'Laboratory'}, {id: 'D65D97BD-B6D1-4829-A6D3-26BD51E921FA', name: 'Course'},
    // {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Bonus'}, {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Partial'}];
    groups = [935, 934, 936];
    // courses = [{Name: 'course1', id: 1}, {Name: 'course1', id: 2}, {Name: 'course1', id: 3}];
    types: any;
    courses: any;
    excelData: any;
    selectedType: any;
    selectedCourse: any;
    columnChart = {
        data: [
            ['Group 935', 8.94],
            ['Group 936', 10.49],
            ['Group 932', 19.30],
            ['Group 934', 21.45],
          ],
        columnNames: ['Element', 'Passing Grades'],
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
    }

    ngOnInit() {
        this.getCourses();
        this.getTypes();
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

    onTypeSelected(event) {
        if (this.selectedCourse && this.selectedType) {
            this.getData();
        }
    }

    onCourseSelected(event) {
        if (this.selectedCourse && this.selectedType) {
           this.getData();
        }
    }

    exportExcell() {
        this.excellService.exportAsExcelFile(this.excelData, 'AverageGrades');
    }

    private getData() {
        const data = {
            CourseID: this.selectedCourse.CourseID,
            TypeID: this.selectedType.TypeID
        };
        this.reportsService.getPassingGradeReport(data).subscribe((info) => {
            console.log(info);
            const result = [];
            this.excelData = info;
            info.forEach(element => {
                const miniList = [];
                miniList.push('Group ' + element.GroupNumber);
                miniList.push(element.PassingGradesNumber);
                result.push(miniList);
            })
            this.columnChart.data = result;
        });
    }
}
