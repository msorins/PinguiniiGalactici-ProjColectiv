import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'lazy',
        loadChildren: '../app/_modules/lazy-module/lazy.module#LazyModule'
    }
];
@NgModule({
    imports: [
        RouterModule.forRoot(routes),
    ],
    exports: [
        RouterModule
    ],
    providers: []

})
export class AppRoutingModule {}
