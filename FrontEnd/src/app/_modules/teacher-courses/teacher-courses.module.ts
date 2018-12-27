import { NgModule } from '@angular/core';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule, MatSidenavModule, MatAutocompleteModule, MatCheckboxModule,
         MatTableModule, MatSortModule, MatTabsModule, MatSelectModule } from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { TeacherCoursesPageComponent } from './pages/teacher-courses/teacher-courses.page';
import { TeacherCoursesSelectComponent } from './components/teacher-courses-select/teacher-courses-select';
import { TeacherCoursesRoutingModule } from './teacher-courses-routing.module';
import { AttendancesComponent } from './components/attendances/attendances.component';
import { GradesComponent } from './components/grades/grades.component';
import { TeacherCoursesService } from './services/TeacherCoursesService';

import { FakeBackendInterceptor, fakeBackendProvider } from '../shared/helpers/fakeBackend.interceptor';

@NgModule({
    imports: [
        CommonModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        MatSidenavModule,
        MatCheckboxModule,
        MatAutocompleteModule,
        ReactiveFormsModule,
        MatTableModule,
        MatSortModule,
        MatTabsModule,
        SharedModule,
        FormsModule,
        TeacherCoursesRoutingModule,
        SharedModule,
        MatSelectModule
    ],
    declarations: [
        TeacherCoursesPageComponent,
        TeacherCoursesSelectComponent,
        AttendancesComponent,
        GradesComponent
    ],
    providers: [
        fakeBackendProvider,
        TeacherCoursesService
    ]
})
export class TeacherCoursesModule {}
