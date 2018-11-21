import { NgModule } from '@angular/core';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule, MatSidenavModule } from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { TeacherCoursesPageComponent } from './pages/teacher-courses/teacher-courses.page';
import { TeacherCoursesSelectComponent } from './components/teacher-courses-select/teacher-courses-select';
import { TeacherCoursesRoutingModule } from './teacher-courses-routing.module';

@NgModule({
    imports: [
        CommonModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        MatSidenavModule,
        ReactiveFormsModule,
        SharedModule,
        FormsModule,
        TeacherCoursesRoutingModule,
        SharedModule
    ],
    declarations: [
        TeacherCoursesPageComponent,
        TeacherCoursesSelectComponent
    ],
    providers: []
})
export class TeacherCoursesModule {}
