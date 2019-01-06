export interface StudentData {
    AttendanceID: string;
    EnrollmentID: string;
    WeekNr: number;
    TypeID: string;
    Grade?:  number;
    CourseID: string;
    CourseName: string;
    TotalLabNr: number;
    TotalSeminarNr: number;
    Year: number;
    TypeName: string
  }
  /*
  {
        "AttendanceID": "d450a30f-7d2d-43b2-ba20-08de77f7982d",
        "EnrollmentID": "ef64e4f2-bfbe-4f88-b088-6a0cae672215",
        "WeekNr": 10,
        "TypeID": "08ac7284-0228-4267-b3bd-a5ff5f5c9e5b",
        "Grade": 7,
        "CourseID": "80f3c166-4067-40af-bc2e-8175618bde32",
        "CourseName": "Literatura",
        "TotalLabNr": 14,
        "TotalSeminarNr": 7,
        "Year": 2,
        "TypeName": "Laborator"
    }
    */