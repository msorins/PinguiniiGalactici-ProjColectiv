import {Component, OnInit, ViewChild} from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';

export interface Student {
  name: string;
  email: string;
  grade: number[];
}

const STUDENTS_DATA: Student[] = [
  {
    name: 'Nazarie Ciprian', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1]
  },
  {
    name: 'Nechita Sebastian', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1]
  },
  {
    name: 'Mircea Sorin', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Vieriu Denis', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Mircea Madalina', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Moisuc Naomi', email: 'a@gmail.com',

    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Nazarie Ciprian', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Nechita Sebastian', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Mircea Sorin', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Vieriu Denis', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Mircea Madalina', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Moisuc Naomi', email: 'a@gmail.com',
    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1],
  },
];
@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.css']
})
export class GradesComponent implements OnInit {

  students: Student[];
  displayedColumns: string[] = ['position', 'name', 'week1', 'week2', 'week3', 'week4',
    'week5', 'week6', 'week7', 'week8', 'week9', 'week11', 'week11', 'week12', 'week13', 'week14'
  ];
  dataSource = new MatTableDataSource(STUDENTS_DATA);
  inputValue: number;

  constructor() {
  }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.students = STUDENTS_DATA;
    this.dataSource.sort = this.sort;
    this.inputValue = 1;
  }


  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim();
  }

  somethingChanged(element, position: number, e): void {
    const grade = e.target.value;

    console.log(element, position, grade);
    if (grade > 10) {
      alert('Grade cannot be greater than 10!');
      e.target.value = 10;
    }


  }

  onChecked(element, position): void {
    // element.grade[position] = !element.grade[position]
    console.log('Here');
    console.log(element, position);
  }

}
