import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import { TeacherGradeStudentPageComponent } from './pages/teacher-grade-student.page';



const routes: Routes = [
  {path: '', component: TeacherGradeStudentPageComponent},
  // {path: 'grades', component: GradesComponent},
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class TeacherGradeStudentRoutingModule {
}
