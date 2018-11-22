import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeacherMainPageRoutingModule } from './teacher-main-page-routing.module';
import { TeacherMainPageComponent } from './pages/teacher-main.page';
import { MatSidenavModule, MatToolbarModule, MatFormFieldModule, MatButtonModule,
     MatInputModule, MatTableModule, MatCheckboxModule, MatSort, MatSortModule} from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { AttendancesComponent } from './components/attendances/attendances.component';
import { GradesComponent } from './components/grades/grades.component';

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
        MatCheckboxModule,
        MatSortModule,
        SharedModule,
        
    ],
    declarations: [
        TeacherMainPageComponent,
        AttendancesComponent,
        GradesComponent
    ],
    providers: []
})
export class TeacherMainPageModule {}
