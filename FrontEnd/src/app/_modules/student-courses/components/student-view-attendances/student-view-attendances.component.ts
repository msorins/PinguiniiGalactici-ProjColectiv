import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { StudentTable } from '../../student-table.interface';

const DATA: StudentTable[] = [
  {
    CourseName: "ASC",
    Year: 1,
    SeminarAttendances:  [false, false, false, true, true, true, true, true, true, true, true, true, true, true],
    LabAttendances: [false, false, false, true, true, true, true, true, true, true, true, true, true, true],
    LabGrades: [9, 9, 9, 10, 10, 9, 10, 10, 10, 10, 10, 10, 10, 5],
    TotalLabNr: 14,
    TotalSeminarNr: 14
  },
  {
    CourseName: "Geometry",
    Year: 1,
    SeminarAttendances:  [false, false, false, false, true, true, true, false, true, true, true, true, true, true],
    LabAttendances: [true, false, false, true, true, true, false, true, false, true, true, true, true, true],
    LabGrades: [4, 4, 4, 10, 3, 9, 10, 10, 4, 7, 8, 2, 10, 5],
    TotalLabNr: 14,
    TotalSeminarNr: 14
  }
];

@Component({
  selector: 'app-student-attendances',
  templateUrl: './student-view-attendances.component.html',
  styleUrls: ['./student-view-attendances.component.css']
})
export class StudentsViewAttendencesComponent implements OnInit {
  data = DATA;
  displayedColumns: string[] = ['position', 'course', 'year', 'week1', 'week2', 'week3', 'week4',
    'week5', 'week6', 'week7', 'week8', 'week9', 'week11', 'week11', 'week12', 'week13', 'week14'
  ];

  dataSource = new MatTableDataSource(this.data);
  @ViewChild(MatSort) sort: MatSort;

  constructor() { 
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
  }
}
