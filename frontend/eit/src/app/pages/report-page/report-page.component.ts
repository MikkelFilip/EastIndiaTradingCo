import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoadingScreenService } from 'src/app/services/loading.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-report-page',
  templateUrl: './report-page.component.html',
  styleUrls: ['./report-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class ReportPageComponent implements OnInit {

  public routes: any[] = []
  constructor(
    private http: HttpClient,
    private toastService: ToastService,
    private loadingService: LoadingScreenService,
  ) { }

  ngOnInit(): void {
    this.loadingService.show()
    this.http.get("https://localhost:7022/BookingHistory/GetMostUsedRoutes").subscribe({
      next: (result: any) => {
        this.routes = result;
      },
      error: (err: HttpErrorResponse) => {
        this.toastService.show("Error: " + err.message, { classname: 'bg-danger text-light', delay: 5000 });
      }
    })
      .add(() => { this.loadingService.hidden() });
  }

}
