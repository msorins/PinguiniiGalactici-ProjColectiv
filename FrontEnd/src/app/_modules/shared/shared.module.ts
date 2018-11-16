import { NgModule, ModuleWithProviders } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { HttpClientModule } from '@angular/common/http';

import {
    MatInputModule,
    MatExpansionModule,
    MatListModule,
    MatIconModule,
    MatToolbarModule,
} from '@angular/material';
import { TeacherMenuComponent } from './components/teacher-menu/teacher-menu';
import { HeaderComponent } from './components/header/header';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        HttpClientModule,
        ReactiveFormsModule,
        FormsModule,
        MatExpansionModule,
        MatListModule,
        MatIconModule,
        MatInputModule,
        MatExpansionModule,
        MatListModule,
        MatIconModule,
        MatToolbarModule
    ],
    exports: [
        TeacherMenuComponent,
        HeaderComponent
    ],
    declarations: [
        TeacherMenuComponent,
        HeaderComponent
    ]
})
export class SharedModule {

    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [AuthenticationService]
        };
    }
}
