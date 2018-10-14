import { NgModule } from '@angular/core';
import {
    MatButtonModule,
    MatCheckboxModule,
    MatSnackBarModule,
} from '@angular/material';

@NgModule({
    imports: [
        MatButtonModule,
        MatCheckboxModule,
        MatSnackBarModule,
    ],
    exports: [
        MatButtonModule,
        MatCheckboxModule,
        MatSnackBarModule,
    ]
})

export class MaterialModule {
}
