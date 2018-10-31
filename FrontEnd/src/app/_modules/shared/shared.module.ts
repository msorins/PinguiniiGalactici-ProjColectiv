import { NgModule, ModuleWithProviders } from '@angular/core';
import { LoginService } from './services/login.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [
        HttpClientModule
    ],
    exports: [
    ],
    declarations: [
    ]
})
export class SharedModule {

    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [LoginService]
        }
    }
}
