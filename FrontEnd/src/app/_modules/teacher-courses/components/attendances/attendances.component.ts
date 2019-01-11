import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';
import { STUDENTS_DATA_ATTENDANCES, COURSES_DATA } from 'src/app/_modules/shared/constants';

@Component({
  selector: 'app-attendances',
  templateUrl: './attendances.component.html',
  styleUrls: ['./attendances.component.css']
})
export class AttendancesComponent implements OnInit {

  displayedColumns: string[] = ['position', 'name', 'group', 'week1', 'week2', 'week3', 'week4',
  'week5', 'week6', 'week7', 'week8', 'week9', 'week10', 'week11', 'week12', 'week13', 'week14'
  ];
  dataSource = new MatTableDataSource(STUDENTS_DATA_ATTENDANCES);
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
    this.groups = this.trimResult(STUDENTS_DATA_ATTENDANCES.map(student => student.GroupNumber));
    this.getCourses();
  }

  applyFilter(filterValue: string) {
    //todo: add custom filter only by name
    this.dataSource.filter = filterValue.trim();
  }

  onChecked(element, position): void {
    return;
    // console.log(element, position);
    // const index = STUDENTS_DATA.indexOf(element);
    // if (index > -1) {
    //   const oldValue = STUDENTS_DATA[index].attendance[position];
    //   if (oldValue) {
    //     STUDENTS_DATA[index].attendance[position] = false;
    //   } else {
    //     STUDENTS_DATA[index].attendance[position] = true;
    //   }
    // }
    // this.changes = true;
  }

  onCourseChanged(event): void {
    console.log("Course: ",event.value);
  }

  onGroupChanged(event): void {
    console.log(event.value);
    const filtered = STUDENTS_DATA_ATTENDANCES.filter(student => student.GroupNumber === event.value);
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
