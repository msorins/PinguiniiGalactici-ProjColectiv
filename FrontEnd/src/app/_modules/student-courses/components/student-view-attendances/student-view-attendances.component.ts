import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';

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

@Component({
  selector: 'app-student-attendances',
  templateUrl: './student-view-attendances.component.html',
  styleUrls: ['./student-view-attendances.component.css']
})
export class StudentsViewAttendencesComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'group', 'week1', 'week2', 'week3', 'week4',
  'week5', 'week6', 'week7', 'week8', 'week9', 'week10', 'week11', 'week12', 'week13', 'week14'
  ];
  dataSource = new MatTableDataSource(STUDENTS_DATA);
  selectedCourse = null;
  groups = [];
  courses = [{id: 1, name: 'Limbaje formale si tehnici de compilare'}, {id: 2, name: 'Programare paralela si distribuita'}];
  changes = false;
  constructor() { }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.dataSource.sort = this.sort;
    this.groups = this.trimResult(STUDENTS_DATA.map(student => student.group));
  }


  applyFilter(filterValue: string) {
    //todo: add custom filter only by name
    this.dataSource.filter = filterValue.trim();
  }

  onChecked(element, position): void {
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
    console.log(event.value);
  }

  onGroupChanged(event): void {
    console.log(event.value);
    const filtered = STUDENTS_DATA.filter(student => student.group === event.value);
    this.dataSource =  new MatTableDataSource(filtered);
  }

  toggleSaveChanges(): boolean {
    if (this.changes && this.selectedCourse !== null) {
      return false;
    }

    return true;
  }

  saveChanges(): void {
    const data = {
      students: this.dataSource.data,
      courseId: this.selectedCourse
    };
    // this.teacherCourseService.saveAttendance(data);
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
