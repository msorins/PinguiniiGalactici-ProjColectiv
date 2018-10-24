import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentLoginPageComponent } from './pages/student-login.page';
import { StundentLoginRoutingModule } from './student-login-routing.module';
import {  MatToolbarModule, MatFormFieldModule, MatInputModule, MatIconModule } from '@angular/material';
import { MenuComponent } from './components/menu-component/menu.component';
import { LoginFormComponent } from './components/login-form-component/login-form.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        StundentLoginRoutingModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        ReactiveFormsModule,
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
