import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { LazyPageComponent } from './pages/lazy.page';
import { LazyComponent } from './components/lazy-component/lazy.component';
import { CommonModule } from '@angular/common';
import { LazyRoutingModule } from './lazy-routing.module';


@NgModule({
    imports: [
        CommonModule,
        LazyRoutingModule
    ],
    declarations: [
        LazyPageComponent,
        LazyComponent
    ],
    providers: [
    ]
})
export class LazyModule { }
