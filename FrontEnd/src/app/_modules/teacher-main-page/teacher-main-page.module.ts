import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeacherMainPageRoutingModule } from './teacher-main-page-routing.module';
import { TeacherMainPageComponent } from './pages/teacher-main.page';
import { MatSidenavModule, MatToolbarModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatTableModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AttendancesComponent } from './components/attendances/attendances.component';

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
        MatTableModule,
    ],
    declarations: [
        TeacherMainPageComponent,
        AttendancesComponent
    ],
    providers: []
})
export class TeacherMainPageModule {}
