import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeacherMainPageRoutingModule } from './teacher-main-page-routing.module';
import { TeacherMainPageComponent } from './pages/teacher-main.page';
import { MatSidenavModule, MatToolbarModule, MatFormFieldModule, MatButtonModule, MatInputModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        TeacherMainPageRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatButtonModule,
        MatInputModule,
        SharedModule
    ],
    declarations: [
        TeacherMainPageComponent
    ],
    providers: []
})
export class TeacherMainPageModule {}
