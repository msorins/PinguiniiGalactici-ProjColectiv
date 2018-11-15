import { NgModule, ModuleWithProviders } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { HttpClientModule } from '@angular/common/http';

import {
    MatInputModule,
    MatExpansionModule,
    MatListModule,
    MatIconModule,
} from '@angular/material';
import { TeacherMenuComponent } from './teacher-menu/teacher-menu';

@NgModule({
    imports: [
        HttpClientModule,
        MatExpansionModule,
        MatListModule,
        MatIconModule,
        MatInputModule,
        MatExpansionModule,
        MatListModule,
        MatIconModule,
    ],
    exports: [
        TeacherMenuComponent
    ],
    declarations: [
        TeacherMenuComponent
    ]
})
export class SharedModule {

    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [AuthenticationService]
        }
    }
}
