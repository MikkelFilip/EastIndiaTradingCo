import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from 'src/app/services/dataService';
import { LoadingScreenService } from 'src/app/services/loading.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-information-page',
  templateUrl: './information-page.component.html',
  styleUrls: ['./information-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class InformationPageComponent implements OnInit {
  public form!: FormGroup;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    private dataService: DataService,
    private http: HttpClient,
    private toastService: ToastService,
    private loadingService: LoadingScreenService,
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null, Validators.required],
      email: [null, {
        validators: [Validators.required, Validators.email],
        updateOn: 'blur'
      }],
    });
  }

  public submit() {
    var searchingParameters = this.dataService.searchingParameters;
    var selectedRoute = this.dataService.selectedRoute;
    
    this.loadingService.show();
    this.http.post("https://wa-eit-dk1.azurewebsites.net/BookingHistory", {
      fromCityId: searchingParameters.from.cityId,
      toCityId: searchingParameters.to.cityId,
      date: this.ngbDateToString(searchingParameters.date),
      duration: selectedRoute.duration,
      price: selectedRoute.price,
      contentTypeId: searchingParameters.cargoType.id,
      packageType: searchingParameters.cargoSize.value,
      customerName: this.form.value.name,
      customerEmail: this.form.value.email,
    })
      .subscribe({
        next: (result) => {
          this.dataService.bookedShipment = result;
          this.router.navigateByUrl("/confirmation");
        },
        error: (err: HttpErrorResponse) => {
          this.toastService.show("Error: " + err.message, { classname: 'bg-danger text-light', delay: 5000 });
        }
      })
      .add(() => { this.loadingService.hidden() });

  }

  public isFormControlInvalid(formControlName: string): boolean {
    return this.form.controls[formControlName].invalid
      && (this.form.controls[formControlName].dirty
        || this.form.controls[formControlName].touched);
  }

  public isFormControlHasError(formControlName: string, errorName: string): boolean {
    return this.form.controls[formControlName].errors?.[errorName];
  }

  private ngbDateToString(date: NgbDate) {
    return date.year + "-" + date.month + "-" + date.day;
  }
}
