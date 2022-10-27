import { NgModule } from '@angular/core';
import { NgSelectModule } from '@ng-select/ng-select';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { RoutePageComponent } from './pages/route-page/route-page.component';
import { InformationPageComponent } from './pages/information-page/information-page.component';
import { ConfirmationPageComponent } from './pages/confirmation-page/confirmation-page.component';
import { ReportPageComponent } from './pages/report-page/report-page.component';
import { RoutePathComponent } from './components/route-path/route-path.component';
import { LoadingScreenComponent } from './components/loading-screen/loading-screen.component';
import { ToastComponent } from './components/toast/toast.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    HomePageComponent,
    RoutePageComponent,
    InformationPageComponent,
    ConfirmationPageComponent,
    ReportPageComponent,
    RoutePathComponent,
    LoadingScreenComponent,
    ToastComponent,
    LoadingScreenComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    NgSelectModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
