import {Component, OnInit, ViewChild} from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';
import { STUDENTS_DATA_GRADES, COURSES_DATA } from 'src/app/_modules/shared/constants';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.css']
})
export class GradesComponent implements OnInit {
  students = STUDENTS_DATA_GRADES;
  displayedColumns: string[] = ['position', 'name', 'group', 'week1', 'week2', 'week3', 'week4',
    'week5', 'week6', 'week7', 'week8', 'week9', 'week11', 'week11', 'week12', 'week13', 'week14'
  ];
  courses: any;
  dataSource = new MatTableDataSource(STUDENTS_DATA_GRADES);
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
