import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentLoginPageComponent } from './pages/student-login.page';

const routes: Routes = [
    {path: '', component: StudentLoginPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class StundentLoginRoutingModule {
}
