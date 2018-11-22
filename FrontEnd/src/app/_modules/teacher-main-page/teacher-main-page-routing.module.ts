import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TeacherMainPageComponent} from './pages/teacher-main.page';
import {AttendancesComponent} from './components/attendances/attendances.component';
import {GradesComponent} from './components/grades/grades.component';


const routes: Routes = [
  {path: '', component: TeacherMainPageComponent},
  {path: 'grades', component: GradesComponent},
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class TeacherMainPageRoutingModule {
}
