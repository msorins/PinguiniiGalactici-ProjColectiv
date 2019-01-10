import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';

const STUDENTS_DATA = [
  {name: 'Nazarie Ciprian', email: 'a@gmail.com',
    group: 911,
   attendance: [false, true, false, false, true, true, true, false,
     false, false, false, true, true, true, false]
  },
  { name: 'Nechita Sebastian', email: 'a@gmail.com',
  group: 912,
    attendance: [false, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Sorin', email: 'a@gmail.com',
  group: 913,
    attendance: [false, true, false, false, true, true, true, false,
      false, false, false, true, false, true, true, true, false]
  },
  {name: 'Vieriu Denis', email: 'a@gmail.com',
  group: 916,
    attendance: [true, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  { name: 'Mircea Madalina', email: 'a@gmail.com',
  group: 911,
    attendance: [false, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Moisuc Naomi', email: 'a@gmail.com',
  group: 911,
    attendance: [false, false, false, true, true, true, false,
      false, true, false, false, true, true, true, false]
  },
  { name: 'Nazarie Ciprian', email: 'a@gmail.com',
  group: 923,
   attendance: [false, true, false, false, true, true, true, false,
     false, false, false, true, true, true, false]
  },
  {name: 'Nechita Sebastian', email: 'a@gmail.com',
  group: 912,
    attendance: [false, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Sorin', email: 'a@gmail.com',
  group: 913,
    attendance: [false, true, false, false, true, true, true, false,
      false, false, false, true, false, true, true, true, false]
  },
  {name: 'Vieriu Denis', email: 'a@gmail.com',
  group: 914,
    attendance: [true, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  {name: 'Mircea Madalina', email: 'a@gmail.com',
  group: 916,
    attendance: [false, true, false, false, true, true, true, false,
      false, false, false, true, true, true, false]
  },
  { name: 'Moisuc Naomi', email: 'a@gmail.com',
  group: 914,
    attendance: [false, false, false, true, true, true, false,
      false, true, false, false, true, true, true, false]
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
  selector: 'app-attendances',
  templateUrl: './attendances.component.html',
  styleUrls: ['./attendances.component.css']
})
export class AttendancesComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'group', 'week1', 'week2', 'week3', 'week4',
  'week5', 'week6', 'week7', 'week8', 'week9', 'week10', 'week11', 'week12', 'week13', 'week14'
  ];
  dataSource = new MatTableDataSource(STUDENTS_DATA);
  selectedCourse = null;
  groups = [];
  courses : any;
  types = ['Seminar', 'Laboratory', 'Course'];
  selectedType = null;
  changes = false;
  constructor(private teacherCourseService: TeacherCoursesService) { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.groups = this.trimResult(STUDENTS_DATA.map(student => student.group));
    this.getCourses();
  }

  applyFilter(filterValue: string) {
    //todo: add custom filter only by name
    this.dataSource.filter = filterValue.trim();
  }

  onChecked(element, position): void {
    return;
    console.log(element, position);
    const index = STUDENTS_DATA.indexOf(element);
    if (index > -1) {
      const oldValue = STUDENTS_DATA[index].attendance[position];
      if (oldValue) {
        STUDENTS_DATA[index].attendance[position] = false;
      } else {
        STUDENTS_DATA[index].attendance[position] = true;
      }
    }
    this.changes = true;
  }

  onCourseChanged(event): void {
    console.log("Course: ",event.value);
  }

  onGroupChanged(event): void {
    console.log(event.value);
    const filtered = STUDENTS_DATA.filter(student => student.group === event.value);
    this.dataSource =  new MatTableDataSource(filtered);
  }

  toggleSaveChanges(): boolean {
    if (this.changes && this.selectedCourse !== null && this.selectedType !== null) {
      return false;
    }

    return true;
  }

  saveChanges(): void {
    const data = {
      students: this.dataSource.data,
      courseId: this.selectedCourse,
      type: this.selectedType
    };
    this.teacherCourseService.saveAttendance(data);
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
    this.teacherCourseService.getCourses().subscribe(
      (apidata) => this.courses = apidata,
      error => this.courses = COURSES_DATA
    )
  } 

}
