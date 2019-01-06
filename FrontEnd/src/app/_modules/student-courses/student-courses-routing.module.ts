import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentMainPageComponent } from './pages/student-main/student-main.page';


const routes: Routes = [
    {path: '', component: StudentMainPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class StudentCoursesRoutingModule {
}
