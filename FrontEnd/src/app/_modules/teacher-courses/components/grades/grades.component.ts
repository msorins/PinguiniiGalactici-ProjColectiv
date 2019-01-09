import {Component, OnInit, ViewChild} from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';

const STUDENTS_DATA = [
  {
    name: 'Nazarie Ciprian', email: 'a@gmail.com',
    group: 911,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1]
  },
  {
    name: 'Nechita Sebastian', email: 'a@gmail.com',
    group: 912,
    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1]
  },
  {
    name: 'Mircea Sorin', email: 'a@gmail.com',
    group: 913,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Vieriu Denis', email: 'a@gmail.com',
    group: 916,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Mircea Madalina', email: 'a@gmail.com',
    group: 911,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Moisuc Naomi', email: 'a@gmail.com',
    group: 911,
    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Nazarie Ciprian', email: 'a@gmail.com',
    group: 923,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Nechita Sebastian', email: 'a@gmail.com',
    group: 912,
    grade: [1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Mircea Sorin', email: 'a@gmail.com',
    group: 913,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Vieriu Denis', email: 'a@gmail.com',
    group: 914,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Mircea Madalina', email: 'a@gmail.com',
    group: 916,
    grade: [1, 1, 1, 1, 1, 1, 1, 1,
      1, 1, 1, 1, 1, 1, 1],
  },
  {
    name: 'Moisuc Naomi', email: 'a@gmail.com',
    group: 914,
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
  students = STUDENTS_DATA;
  displayedColumns: string[] = ['position', 'name', 'group', 'week1', 'week2', 'week3', 'week4',
    'week5', 'week6', 'week7', 'week8', 'week9', 'week11', 'week11', 'week12', 'week13', 'week14'
  ];
  courses = [{id: 1, name: 'Limbaje formale si tehnici de compilare'}, {id: 2, name: 'Programare paralela si distribuita'}];
  dataSource = new MatTableDataSource(STUDENTS_DATA);
  inputValue: number;
  changes = false;
  groups = [];
  selectedCourse = null;
  types = ['Seminar', 'Laboratory', 'Course'];
  selectedType = null;
  constructor(private teacherService: TeacherCoursesService) {
  }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.groups = this.trimResult(this.students.map(student => student.group));
    this.dataSource.sort = this.sort;
    this.inputValue = 1;
  }


  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim();
  }

  somethingChanged(element, position: number, e): void {
    let grade = e.target.value;

    console.log(element, position, grade);
    if (grade > 10) {
      alert('Grade cannot be greater than 10!');
      e.target.value = 10;
      grade = 10;
    }
    element.grade[position] = parseInt(grade, 10);
    const index = this.students.indexOf(element);
    if (index > -1) {
      this.students[index].grade[position] = parseInt(grade, 10);
    }
    this.changes = true;


  }

  saveChanges(): void {
     const data = {
       students: this.dataSource.data,
       courseId: this.selectedCourse,
       type: this.selectedType
     };
     this.teacherService.saveGrades(data);
     this.changes = false;
  }

  toggleSaveChanges(): boolean {
    if (this.changes && this.selectedCourse !== null && this.selectedType !== null) {
      return false;
    }

    return true;
  }

  onCourseChanged(event) {
    //call care sa aduca notele pentru studenti la cursul respectiv
    //dupa care pentru fiecare student modificam array-ul de grades corespunzator cursurilor
  }

  onGroupChanged(event) {
    console.log(event.value);
    const filtered = this.students.filter(student => student.group === event.value);
    this.dataSource =  new MatTableDataSource(filtered);
  }

  private trimResult(data) {
    const result = [];
    data.forEach(element => {
       const index = result.indexOf(element);
       if (index === -1) {
         result.push(element);
       }
    });
    return result;
  }

}
