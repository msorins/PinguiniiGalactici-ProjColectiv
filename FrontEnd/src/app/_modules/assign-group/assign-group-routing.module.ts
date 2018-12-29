import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssignGroupPageComponent } from './pages/assign-group.page';


const routes: Routes = [
    {path: '', component: AssignGroupPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class AssignGroupRoutingModule {}
