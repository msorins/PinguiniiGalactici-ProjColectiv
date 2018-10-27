import { NgModule } from '@angular/core';
import { TeacherLoginRoutingModule } from './teacher-login-routing.module';
import { TeacherLoginPageComponent } from './pages/teacher-login.page';
import { LoginFormComponent } from './components/teacher-login-form/login-form.component';
import { MatToolbarModule, MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule } from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        CommonModule,
        TeacherLoginRoutingModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        ReactiveFormsModule,
        SharedModule,
        FormsModule
    ],
    declarations: [
        TeacherLoginPageComponent,
        LoginFormComponent
    ],
    providers: []
})
export class TeacherLoginModule {}
