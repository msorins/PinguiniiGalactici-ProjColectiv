import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportsPageComponent } from './pages/reports.page';
import { ReportsRoutingModule } from './reports-routing.module';
import { MatTabGroup, MatSidenavModule, MatToolbarModule, MatTabsModule, MatSelectModule, MatButtonModule } from '@angular/material';
import { SharedModule } from '../shared/shared.module';
import { AttendacenReportComponent } from './components/attendance-report/attendance-report.component';
import { jwtProvider } from '../shared/helpers/jwt.interceptor';
import { ReportsService } from './services/reports.service';
import {GoogleChartsModule} from 'angular-google-charts';
import { AverageGradesComponent } from './components/average-grades/average-grades.component';
import { ExcelService } from './services/xls.service';
@NgModule({
    imports: [
        CommonModule,
        ReportsRoutingModule,
        MatSidenavModule,
        MatToolbarModule,
        MatTabsModule,
        SharedModule,
        MatSelectModule,
        MatButtonModule,
        GoogleChartsModule.forRoot(),
    ],
    declarations: [
        ReportsPageComponent,
        AttendacenReportComponent,
        AverageGradesComponent
    ],
    providers: [
        jwtProvider,
        ReportsService,
        ExcelService
    ]
})
export class ReportsModule {

}
