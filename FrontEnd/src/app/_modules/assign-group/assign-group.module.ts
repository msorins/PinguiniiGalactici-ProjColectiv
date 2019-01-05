import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssignGroupPageComponent } from './pages/assign-group.page';
import { AssignGroupRoutingModule } from './assign-group-routing.module';
import { MatSidenavModule, MatToolbarModule, MatButtonModule, MatInputModule, MatCheckboxModule, MatTabsModule, MatListModule, MatSelectModule } from '@angular/material';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AssignGroupService } from './services/assign-group.service';





@NgModule({
    imports: [
        CommonModule,
        AssignGroupRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        SharedModule,
        MatButtonModule,
        MatInputModule,
        MatCheckboxModule,
        MatTabsModule,
        MatListModule,
        MatSelectModule,
        ReactiveFormsModule,
        FormsModule,
    ],
    declarations: [
        AssignGroupPageComponent
    ],
    providers: [
        AssignGroupService
    ]
})
export class AssignGroupModule { }
