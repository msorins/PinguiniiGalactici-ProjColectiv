export class ApiUrl {

    static readonly basePrefix = '/api';
    static readonly userUrl = '/User';
    static readonly adminUrl = '/Admin';
    static readonly coursesUrl = '/courses';
    static readonly url = 'http://localhost:53440';

    // link for the call
    static readonly insertUserUrl = ApiUrl.url + "/students";
    static readonly assingStudentUrl = ApiUrl.basePrefix + ApiUrl.adminUrl + '/Assign';
    static readonly getTokenUrl = ApiUrl.url + '/token';

    static apiexaple = 'controller/....';
    static urlCourses = '/courses';
    // http://localhost:3000/students

    static ngRokUrl = 'https://421fab97.ngrok.io';
}
