import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './lading-page/landing-page.component';
import { SharedModule } from './_modules/shared/shared.module';

const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent
    },
    {
        path: 'login/student',
        loadChildren: '../app/_modules/student-login-module/student-login.module#StudentLoginModule'
    },
    {
        path: 'login/teacher',
        loadChildren: '../app/_modules/teacher-login-module/teacher-login.module#TeacherLoginModule'
    },
    {
        path: 'lazy',
        loadChildren: '../app/_modules/lazy-module/lazy.module#LazyModule'
    }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes, {enableTracing: true}),
    ],
    exports: [
        RouterModule
    ],
    providers: []

})
export class AppRoutingModule {}
