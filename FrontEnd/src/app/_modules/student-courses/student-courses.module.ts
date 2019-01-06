import { NgModule } from '@angular/core';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule, MatSidenavModule, MatAutocompleteModule, MatCheckboxModule,
         MatTableModule, MatSortModule, MatTabsModule, MatSelectModule } from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';


import { FakeBackendInterceptor, fakeBackendProvider } from '../shared/helpers/fakeBackend.interceptor';
import { StudentMainPageComponent } from './pages/student-main/student-main.page';
import { StudentsViewGradesComponent } from './components/student-view-grades/student-view-grades.component';
import { StudentCoursesRoutingModule } from './student-courses-routing.module';
import { StudentsViewAttendencesComponent } from './components/student-view-attendances/student-view-attendances.component';
import { StudentCoursesService } from './services/student-courses.service';

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
        SharedModule,
        MatSelectModule,
        StudentCoursesRoutingModule
    ],
    declarations: [
       StudentMainPageComponent,
       StudentsViewGradesComponent,
       StudentsViewAttendencesComponent
    ],
    providers: [
        fakeBackendProvider,
        StudentCoursesService
    ]
})

export class StudentCoursesModule {

}
