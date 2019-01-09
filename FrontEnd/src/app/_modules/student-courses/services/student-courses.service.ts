import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { StudentData } from '../student-data.interface.1';
import { StudentTable } from '../student-table.interface';
import { AnonymousSubject } from 'rxjs/internal/Subject';

@Injectable()
export class StudentCoursesService {

    constructor(private http: HttpClient) { }

    public getData(): Observable<StudentTable[]> {
        return this.http
        .get<StudentData[]>('http://localhost:53440/attendances/withCourses').pipe( //http://www.mocky.io/v2/5c322f253500000509caa012
            map((e: StudentData[]) => {
                var table: StudentTable[] = [];

                var mapByCourse = {};
                e.forEach(el => {

                    if( el.CourseName in mapByCourse)  {
                        mapByCourse[el.CourseName].push(el);
                    } else {
                        mapByCourse[el.CourseName] = [el];
                    }

                });

                for(var key in mapByCourse) {
                    var newCourse: StudentTable = {} as any;
                    newCourse.CourseName = mapByCourse[key][0].CourseName;
                    newCourse.TotalLabNr = mapByCourse[key][0].TotalLabNr;
                    newCourse.TotalSeminarNr = mapByCourse[key][0].TotalSeminarNr;
                    newCourse.Year = mapByCourse[key][0].Year;

                    newCourse.LabAttendances = [];
                    newCourse.LabGrades = [];
                    newCourse.SeminarAttendances = [];
                    for(var i = 0; i < 14; i++) {
                        newCourse.LabAttendances.push(false);
                        newCourse.LabGrades.push(0);
                        newCourse.SeminarAttendances.push(false);
                    }

                    mapByCourse[key].forEach(element => {
                        var elStudentData: StudentData = element;
                        if(elStudentData.TypeName == "Laborator") {
                            if(newCourse.TotalLabNr == 14) {
                                newCourse.LabAttendances[ elStudentData.WeekNr -  1 ] = true;
                                if(elStudentData.Grade != null) {
                                     newCourse.LabGrades[ elStudentData.WeekNr -  1 ] = elStudentData.Grade;
                                }
                            } 
                            if(newCourse.TotalLabNr == 7) {
                                newCourse.LabAttendances[ (elStudentData.WeekNr -  1) * 2 ] = true;
                                if(elStudentData.Grade != null) {
                                    newCourse.LabGrades[(elStudentData.WeekNr -  1) * 2  ] = elStudentData.Grade;
                                }
                            }
                        }

                        if(elStudentData.TypeName == "Seminar") {
                            if(newCourse.TotalSeminarNr == 14) {
                                newCourse.SeminarAttendances[ elStudentData.WeekNr -  1 ] = true;
                            } 

                            if(newCourse.TotalSeminarNr == 7) {
                                newCourse.SeminarAttendances[ (elStudentData.WeekNr -  1) * 2 ] = true;
                            } 
                        }
                    });

                    table.push(newCourse);
                }
                return table;
            })
          );
    }
}
