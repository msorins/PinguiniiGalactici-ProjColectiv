import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class AssignGroupService{

    constructor(private httpClient: HttpClient) {
    }

    createNewGroup(info) {
        //post call with body containing a new group and students assigned to it
        console.log(info);
    }

    assignToExistingGroup(info) {
        console.log(info);
        //post call same as above different function or same 
    }
}
