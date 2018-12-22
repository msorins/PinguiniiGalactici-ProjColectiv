
export class ApiUrl {

    static readonly basePrefix = '/api';
    static readonly userUrl = '/User';
    static readonly adminUrl = '/Admin';
    // link for the call
    static readonly insertUserUrl = ApiUrl.basePrefix + ApiUrl.userUrl + '/Insert';
    static readonly assingStudentUrl = ApiUrl.basePrefix + ApiUrl.adminUrl + '/Assign';

}

