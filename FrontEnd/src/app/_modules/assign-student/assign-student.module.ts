import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssignStudentPageComponent } from './pages/assign-student/assign-student.component';
import { AssignStudentRoutingModule } from './assign-student-routing.module';
import { MatSidenavModule, MatToolbarModule, MatFormFieldModule,
    MatButtonModule, MatInputModule, MatCheckboxModule, MatTabsModule, MatListModule, MatSelectModule } from '@angular/material';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { AssignStudentService } from './services/assign-student.service';



@NgModule({
    imports: [
        CommonModule,
        AssignStudentRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatButtonModule,
        MatInputModule,
        MatCheckboxModule,
        MatTabsModule,
        MatListModule,
        MatSelectModule,
        FormsModule,
        SharedModule
    ],
    declarations: [
        AssignStudentPageComponent
    ],
    providers: [
        AssignStudentService
    ]
})
export class AssignStudentModule { }
