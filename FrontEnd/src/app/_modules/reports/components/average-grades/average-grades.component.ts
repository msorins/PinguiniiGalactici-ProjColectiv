import { Component, OnInit } from '@angular/core';
import { ReportsService } from '../../services/reports.service';
import { ExcelService } from '../../services/xls.service';

@Component({
    selector: 'app-average-grades',
    templateUrl: './average-grades.component.html',
    styleUrls: ['./average-grades.component.css']
})
export class AverageGradesComponent implements OnInit {
    types = [{id: '63E3DF71-A7D4-4A30-9299-16A11E104536', name: 'Seminar'},
    {id: '08AC7284-0228-4267-B3BD-A5FF5F5C9E5B', name: 'Laboratory'}, {id: 'D65D97BD-B6D1-4829-A6D3-26BD51E921FA', name: 'Course'},
    {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Bonus'}, {id: 'A9AD4E26-3611-4A32-B72F-D4A35B88AD14', name: 'Partial'}];
    groups = [935, 934, 936];
    courses = [{Name: 'course1', id: 1}, {Name: 'course1', id: 2}, {Name: 'course1', id: 3}];
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
        columnNames: ['Element', 'Average Grades'],
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
        // this.reportsService.getCourses().subscribe(courses => {
        //     this.courses = courses;
        //     this.selectedCourse = this.courses [0];
        // });
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
        this.reportsService.getAverageReport(data).subscribe(info => {
            //this.excelData = info;
            this.excelData = [{GroupNumber: 935, AverageGrade: 10}, {GroupNumber: 936, AverageGrade: 9},{GroupNumber: 934, AverageGrade: 8}]
            const result = [];
            this.excelData.forEach(element => {
                const miniList = [];
                miniList.push('Group ' + element.GroupNumber);
                miniList.push(element.AverageGrade);
                result.push(miniList);
            });
            this.columnChart.data = result;
        });
    }
}
