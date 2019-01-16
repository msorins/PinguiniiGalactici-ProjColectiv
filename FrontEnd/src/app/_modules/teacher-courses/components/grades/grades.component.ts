import {Component, OnInit, ViewChild} from '@angular/core';
import { MatTableDataSource, MatCheckboxModule, MatSort} from '@angular/material';
import { TeacherCoursesService } from '../../services/TeacherCoursesService';
import {  COURSES_DATA, STUDENTS_DATA_GRADES } from 'src/app/_modules/shared/constants';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.css']
})
export class GradesComponent implements OnInit {
  students = [];
  displayedColumns: string[] = ['position', 'name', 'group', 'week1', 'week2', 'week3', 'week4',
    'week5', 'week6', 'week7', 'week8', 'week9', 'week11', 'week11', 'week12', 'week13', 'week14'
  ];
  courses: any = [];
  dataSource;
  backupData = [];
  inputValue: number;
  changes = false;
  groups = [];
  selectedCourse = null;
  types = ['Seminar', 'Laboratory', 'Course'];
  selectedType = 'Seminar';
  constructor(private teacherService: TeacherCoursesService) {
  }

  @ViewChild(MatSort) sort: MatSort;

  ngOnInit() {
    this.inputValue = 1;
    this.getCourses();
  }


  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim();
  }

  saveChanges(): void {
     const data = {
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
    console.log(this.selectedCourse);
    this.getStudents();
  }

  onGroupChanged(event) {
    console.log(event.value);
    if (event.value === "All") {
      this.dataSource =  new MatTableDataSource(this.backupData);
      return;
    }
    const filtered = this.backupData.filter(student => student.GroupNumber === event.value);
    this.dataSource =  new MatTableDataSource(filtered);
  }

  onTypeChanged(event) {
    if (event.value === 'Seminar') {
      this.dataSource.data.forEach(element => {
        element.Grade = element.SeminarGrade;
      });
    } else if (event.value === 'Laboratory') {
      this.dataSource.data.forEach(element => {
        element.Grade = element.LabGrade;
      });
    } else {
      this.dataSource.data.forEach(element => {
        element.Grade = element.CourseGrade;
      });
    }
    const changed = this.dataSource.data;
    this.dataSource =  new MatTableDataSource(changed);
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
    );
  } 

  private getStudents() {
    this.teacherService.getStudents(this.selectedCourse).subscribe (
      (apidata) => {
        this.students = apidata
        console.log(this.students);
        this.groups = this.trimResult(this.students.map(student => student.GroupNumber));
        this.getAttendances();
      },
      (error) => this.students = STUDENTS_DATA_GRADES
    );
  }

  private getAttendances() {
    console.log("in attendances",this.students);
    console.log("course id: ", this.selectedCourse);
    this.dataSource = new MatTableDataSource([]);
    
    this.students.forEach(student => {
      let seminarGrades = [];
      let labGrades = [];
      let courseGrades = [];
      
      this.teacherService.getAttendances(this.selectedCourse, student.RegistrationNumber).subscribe (
        (apidata) => {
          console.log(student.Name, " my grades: ", apidata);
          apidata.forEach(data => {
            if (data){
              if (data.TypeName == "Seminar") {
                seminarGrades[data.WeekNr] = data.Grade;
              } else if (data.TypeName == "Laborator") {
                labGrades[data.WeekNr] = data.Grade;
              } else {
                courseGrades[data.WeekNr] = data.Grade;
              }
            }
          });
          
          
        }
      );
      if(this.selectedType == "Seminar") {
        this.dataSource.data.push(
          {
            Name: student.Name,
            GroupNumber: student.GroupNumber,
            SeminarGrade: seminarGrades,
            LabGrade: labGrades,
            CourseGrade: courseGrades,
            Grade: seminarGrades
          }
        );
      } else if(this.selectedType == "Laboratory") {
        this.dataSource.data.push(
          {
            Name: student.Name,
            GroupNumber: student.GroupNumber,
            SeminarGrade: seminarGrades,
            LabGrade: labGrades,
            CourseGrade: courseGrades,
            Grade: labGrades
          }
        );
      } else {
        this.dataSource.data.push(
          {
            Name: student.Name,
            GroupNumber: student.GroupNumber,
            SeminarGrade: seminarGrades,
            LabGrade: labGrades,
            CourseGrade: courseGrades,
            Grade: courseGrades
          }
        );
      }
      
      this.backupData = this.dataSource.data;
    });
    this.dataSource.sort = this.sort;
    console.log("data", this.dataSource);
  }

}
