import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent} from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { AppRoutingModule } from './app-routing.module';
import { LandingPageComponent } from './lading-page/landing-page.component';
import { SharedModule } from './_modules/shared/shared.module';


// Interceptors
import { JwtInterceptor } from './_modules/shared/helpers/jwt.interceptor';
import { ErrorInterceptor } from './_modules/shared/helpers/error.interceptor';
import { FakeBackendInterceptor, fakeBackendProvider } from './_modules/shared/helpers/fakeBackend.interceptor';
import { MatToolbarModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatToolbarModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule.forRoot()
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    fakeBackendProvider
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
