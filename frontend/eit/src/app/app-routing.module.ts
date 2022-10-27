import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmationPageComponent } from './pages/confirmation-page/confirmation-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { InformationPageComponent } from './pages/information-page/information-page.component';
import { ReportPageComponent } from './pages/report-page/report-page.component';
import { RoutePageComponent } from './pages/route-page/route-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'routes', component: RoutePageComponent },
  { path: 'information', component: InformationPageComponent },
  { path: 'confirmation', component: ConfirmationPageComponent },
  { path: 'report', component: ReportPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
