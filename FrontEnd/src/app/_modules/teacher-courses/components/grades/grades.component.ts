import {Component, OnInit, ViewChild} from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';

const STUDENTS_DATA = [
  {
    name: 'Nazarie Ciprian', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 9, 10, 8, 9, 10,
      10, 10, 10, 9, 8, 6, 8]
  },
  {
    name: 'Nechita Sebastian', email: 'a@gmail.com',
    group: 912,
    grade: [10, 10, 10, 10, 10, 10, 10,
      10, 9, 9, 9, 10, 10, 10]
  },
  {
    name: 'Mircea Sorin', email: 'a@gmail.com',
    group: 913,
    grade: [10, 10, 10, 10, 10, 9, 9, 8,
      8, 5, 6, 10, 10, 8, 9, 7, 10],
  },
  {
    name: 'Vieriu Denis', email: 'a@gmail.com',
    group: 916,
    grade: [10, 9, 9, 4, 5, 8, 9, 7,
      10, 7, 8, 9, 10, 10, 10],
  },
  {
    name: 'Mircea Madalina', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 10, 10, 9, 9, 9,
      10, 10, 10, 10, 10, 10, 10],
  },
  {
    name: 'Moisuc Naomi', email: 'a@gmail.com',
    group: 911,
    grade: [9, 10, 10, 10, 7, 8, 6,
      8, 9, 7, 8, 8, 9, 9, 9],
  },
  {
    name: 'Jugaru Robert', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 9, 10, 8, 9, 10,
      10, 10, 10, 9, 8, 6, 8]
  },
  {
    name: 'Mihalache Mihai', email: 'a@gmail.com',
    group: 912,
    grade: [10, 10, 10, 10, 10, 10, 10,
      10, 9, 9, 9, 10, 10, 10]
  },
  {
    name: 'Mihaliuc Ioana', email: 'a@gmail.com',
    group: 913,
    grade: [10, 10, 10, 10, 10, 9, 9, 8,
      8, 5, 6, 10, 10, 8, 9, 7, 10],
  },
  {
    name: 'Obreja Elena', email: 'a@gmail.com',
    group: 916,
    grade: [10, 9, 9, 4, 5, 8, 9, 7,
      10, 7, 8, 9, 10, 10, 10],
  },
  {
    name: 'Neamt Vlad', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 10, 10, 9, 9, 9,
      10, 10, 10, 10, 10, 10, 10],
  },
  {
    name: 'Dogar Alexandru', email: 'a@gmail.com',
    group: 911,
    grade: [9, 10, 10, 10, 7, 8, 6,
      8, 9, 7, 8, 8, 9, 9, 9],
  },
  {
    name: 'Nechita Ionut', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 9, 10, 8, 9, 10,
      10, 10, 10, 9, 8, 6, 8]
  },
  {
    name: 'Nemes Bianca', email: 'a@gmail.com',
    group: 912,
    grade: [10, 10, 10, 10, 10, 10, 10,
      10, 9, 9, 9, 10, 10, 10]
  },
  {
    name: 'Micu Emerson', email: 'a@gmail.com',
    group: 913,
    grade: [10, 10, 10, 10, 10, 9, 9, 8,
      8, 5, 6, 10, 10, 8, 9, 7, 10],
  },
  {
    name: 'Oltean Andrei', email: 'a@gmail.com',
    group: 916,
    grade: [10, 9, 9, 4, 5, 8, 9, 7,
      10, 7, 8, 9, 10, 10, 10],
  },
  {
    name: 'Frent George', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 10, 10, 9, 9, 9,
      10, 10, 10, 10, 10, 10, 10],
  },
  {
    name: 'Marcu Miriam', email: 'a@gmail.com',
    group: 911,
    grade: [9, 10, 10, 10, 7, 8, 6,
      8, 9, 7, 8, 8, 9, 9, 9],
  },
  {
    name: 'Pop Maria', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 9, 10, 8, 9, 10,
      10, 10, 10, 9, 8, 6, 8]
  },
  {
    name: 'Pop Ionut', email: 'a@gmail.com',
    group: 912,
    grade: [10, 10, 10, 10, 10, 10, 10,
      10, 9, 9, 9, 10, 10, 10]
  },
  {
    name: 'Muresan Alexandra', email: 'a@gmail.com',
    group: 913,
    grade: [10, 10, 10, 10, 10, 9, 9, 8,
      8, 5, 6, 10, 10, 8, 9, 7, 10],
  },
  {
    name: 'Ilie Andrei', email: 'a@gmail.com',
    group: 916,
    grade: [10, 9, 9, 4, 5, 8, 9, 7,
      10, 7, 8, 9, 10, 10, 10],
  },
  {
    name: 'Frent Tudor', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 10, 10, 9, 9, 9,
      10, 10, 10, 10, 10, 10, 10],
  },
  {
    name: 'Moldovan Alexandru', email: 'a@gmail.com',
    group: 911,
    grade: [9, 10, 10, 10, 7, 8, 6,
      8, 9, 7, 8, 8, 9, 9, 9],
  },
  {
    name: 'Balc Radu', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 9, 10, 8, 9, 10,
      10, 10, 10, 9, 8, 6, 8]
  },
  {
    name: 'David Bianca', email: 'a@gmail.com',
    group: 912,
    grade: [10, 10, 10, 10, 10, 10, 10,
      10, 9, 9, 9, 10, 10, 10]
  },
  {
    name: 'Grigorovici Monica', email: 'a@gmail.com',
    group: 913,
    grade: [10, 10, 10, 10, 10, 9, 9, 8,
      8, 5, 6, 10, 10, 8, 9, 7, 10],
  },
  {
    name: 'Balu Anca', email: 'a@gmail.com',
    group: 916,
    grade: [10, 9, 9, 4, 5, 8, 9, 7,
      10, 7, 8, 9, 10, 10, 10],
  },
  {
    name: 'Tripon Madalina', email: 'a@gmail.com',
    group: 911,
    grade: [10, 10, 10, 10, 10, 9, 9, 9,
      10, 10, 10, 10, 10, 10, 10],
  },
  {
    name: 'Rus Mihai', email: 'a@gmail.com',
    group: 911,
    grade: [9, 10, 10, 10, 7, 8, 6,
      8, 9, 7, 8, 8, 9, 9, 9],
  },
];

const COURSES_DATA = [
  {
    CourseID: "0d223c71-6ddf-41e2-b266-25585f5b25f3",
    Name: "Object Oriented Programming",
    DepartmentID: "95366cea-de83-4c47-b004-cee1056540d4",
    Year: 1,
    TotalLabNr: 14,
    TotalSeminarNr: 14
  },
  {
    CourseID: "ba889e1a-0ec5-4089-b702-3c9bf80e5bab",
    Name: "Algebra",
    DepartmentID: "83604cf3-bc0a-4f59-aabe-841b14b12a17",
    Year: 1,
    TotalLabNr: 14,
    TotalSeminarNr: 14
  },
  {
    CourseID: "f1647dfe-bdb0-4987-b0ac-45c7a7d80b4d",
    Name: "Web Programming",
    DepartmentID: "83604cf3-bc0a-4f59-aabe-841b14b12a17",
    Year: 3,
    TotalLabNr: 7,
    TotalSeminarNr: 0
  },
  {
    CourseID: "b0094904-b0a7-4c66-a7d3-6c313d5d193a",
    Name: "Mobile Applications",
    DepartmentID: "83604cf3-bc0a-4f59-aabe-841b14b12a17",
    Year: 3,
    TotalLabNr: 7,
    TotalSeminarNr: 0
  },
  {
    CourseID: "80f3c166-4067-40af-bc2e-8175618bde32",
    Name: "Fundamentals of Programming",
    DepartmentID: "dabf09a2-7e02-4941-9ff3-5a6a36d61d16",
    Year: 2,
    TotalLabNr: 14,
    TotalSeminarNr: 7
  },
  {
    CourseID: "80f3c166-4067-40af-bc2e-8175618bde32",
    Name: "Artificial Intelligence",
    DepartmentID: "dabf09a2-7e02-4941-9ff3-5a6a36d61d16",
    Year: 2,
    TotalLabNr: 14,
    TotalSeminarNr: 7
  },
  {
    CourseID: "80f3c166-4067-40af-bc2e-8175618bde32",
    Name: "Logical and Functional Programming",
    DepartmentID: "dabf09a2-7e02-4941-9ff3-5a6a36d61d16",
    Year: 2,
    TotalLabNr: 14,
    TotalSeminarNr: 7
  }
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
  courses: any;
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
    this.getCourses();
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

  private getCourses() {
    this.teacherService.getCourses().subscribe(
      (apidata) => this.courses = apidata,
      error => this.courses = COURSES_DATA
    )
  } 

}
