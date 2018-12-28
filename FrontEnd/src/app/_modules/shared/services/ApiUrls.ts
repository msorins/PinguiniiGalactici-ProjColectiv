export class ApiUrl {

    static readonly basePrefix = '/api';
    static readonly userUrl = '/User';
    static readonly adminUrl = '/Admin';
    static readonly coursesUrl = '/courses';

    // link for the call
    static readonly insertUserUrl = ApiUrl.basePrefix + ApiUrl.userUrl + '/Insert';
    static readonly assingStudentUrl = ApiUrl.basePrefix + ApiUrl.adminUrl + '/Assign';

    static apiexaple = 'controller/....';
    static url = 'http://localhost:3000';
    static urlStudents = '/students';
    static urlCourses = '/courses';
    // http://localhost:3000/students
}
