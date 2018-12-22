import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignStudentPageComponent } from './pages/assign-student/assign-student.component';

const routes: Routes = [
    {path: '', component: AssignStudentPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class AssignStudentRoutingModule {}
