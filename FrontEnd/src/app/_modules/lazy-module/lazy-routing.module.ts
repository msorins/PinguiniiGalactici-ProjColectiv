import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LazyPageComponent } from './pages/lazy.page';

const routes: Routes = [
    {path: '', component: LazyPageComponent}
];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule
    ]
})
export class LazyRoutingModule {}
