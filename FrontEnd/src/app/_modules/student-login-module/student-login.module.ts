import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentLoginPageComponent } from './pages/student-login.page';
import { StundentLoginRoutingModule } from './student-login-routing.module';
import {  MatToolbarModule, MatFormFieldModule, MatInputModule, MatIconModule, MatButtonModule } from '@angular/material';
import { MenuComponent } from './components/menu-component/menu.component';
import { LoginFormComponent } from './components/login-form-component/login-form.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        CommonModule,
        StundentLoginRoutingModule,
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
        StudentLoginPageComponent,
        MenuComponent,
        LoginFormComponent
    ],
    providers: [
    ]
})
export class StudentLoginModule {

}
