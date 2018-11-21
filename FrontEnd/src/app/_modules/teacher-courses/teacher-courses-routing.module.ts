import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeacherCoursesPageComponent } from './pages/teacher-courses/teacher-courses.page';


const routes: Routes = [
    {path: '', component: TeacherCoursesPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class TeacherCoursesRoutingModule {
}
