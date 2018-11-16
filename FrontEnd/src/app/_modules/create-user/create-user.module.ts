import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateUserPageComponent } from './pages/create-user.page';
import { CreateUserRoutingModule } from './create-user-routing.module';
import { MatSidenavModule,
        MatToolbarModule,
        MatFormFieldModule, MatInputModule, MatButtonModule, MatCheckboxModule } from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CreateUserFormComponent } from './components/create-user-form/create-user-form.component';

@NgModule({
    imports: [
        CommonModule,
        CreateUserRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        MatFormFieldModule,
        MatButtonModule,
        MatInputModule,
        MatCheckboxModule,
        ReactiveFormsModule,
        FormsModule
    ],
    declarations: [
        CreateUserPageComponent,
        CreateUserFormComponent
    ],
    providers: []
})
export class CreateUserModule {}
