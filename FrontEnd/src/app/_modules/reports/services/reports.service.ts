import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { ApiUrl } from '../../shared/services/ApiUrls';

@Injectable()
export class ReportsService {

    constructor(private httpClient: HttpClient) {
    }

    getGroups() {
        return of(null);
    }

    getCourses() {
        return of(null);
    }
    getAttendaceReport(data) {
        const url = ApiUrl.ngRokUrl + '/reports/group-attendances/' + data.CourseID + '/' + data.TypeID + '/' + data.GroupID;
        //return this.httpClient.get(url);
        return of(null);
    }

    getAverageReport(data) {
        const url = ApiUrl.ngRokUrl + '/reports/average/' + data.CourseID + '/' + data.TypeID;
        //return this.httpClient.get(url);
        return of(null);
    }
}
