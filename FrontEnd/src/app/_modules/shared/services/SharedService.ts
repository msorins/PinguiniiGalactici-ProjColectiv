import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiUrl } from './ApiUrls';




@Injectable()
export class SharedService {


    constructor(
        private http: HttpClient
    ) {
    }

    uploadUsers(users): void {
        this.http.post(ApiUrl.ngRokUrl + '/students/upload', users).subscribe(data => {
            console.log(data);
            if (data == null) {
                alert('Data has been uploaded');
            }
        });
        console.log(users);
        alert('Data has been uploaded');
    }
}
