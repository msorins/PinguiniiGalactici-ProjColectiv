import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of, Observable } from 'rxjs';
import { ApiUrl } from '../../shared/services/ApiUrls';

@Injectable()
export class ReportsService {

    constructor(private httpClient: HttpClient) {
    }

    public getCourses(): Observable<any[]> {
        return this.httpClient
        .get<any[]>(ApiUrl.url + '/courses');
    }
    

    public getTypes(): Observable<any[]> {
        return this.httpClient
        .get<any[]>(ApiUrl.url + '/gradeTypes');
    }

    public getGroups(): Observable<any[]> {
        return this.httpClient
        .get<any[]>(ApiUrl.url + '/groups');
    }

    getAttendaceReport(data) {
        const url = ApiUrl.url + '/reports/group-attendances/' + data.CourseID + '/' + data.TypeID + '/' + data.GroupID;
        return this.httpClient.get(url);
    }

    getAverageReport(data):  Observable<any[]> {
        const url = ApiUrl.url + '/reports/average/' + data.CourseID + '/' + data.TypeID;
        return this.httpClient.get<any[]>(url);
    }

    getPassingGradeReport(data):  Observable<any[]> {
        const url = ApiUrl.url + '/reports/passing-grades/' + data.CourseID + '/' + data.TypeID;
        return this.httpClient.get<any[]>(url);
    }
}
