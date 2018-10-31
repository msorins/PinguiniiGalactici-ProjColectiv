import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeacherLoginPageComponent } from './pages/teacher-login.page';

const routes: Routes = [
    {path: '', component: TeacherLoginPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class TeacherLoginRoutingModule {
}
