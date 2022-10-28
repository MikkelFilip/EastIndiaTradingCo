import { formatDate } from '@angular/common';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from 'src/app/services/dataService';
import { LoadingScreenService } from 'src/app/services/loading.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class HomePageComponent implements OnInit {
  public form!: FormGroup;

  public locationOptions: any[] = [
    // "Cargo", "Congo", "Sahara", "Obama",
  ]

  public sortByOptions = [
    "Cheapest", "Fastest"
  ]

  public cargoTypeOptions = [
    {
      id: 1,
      name: "Weapons"
    },
    {
      id: 2,
      name: "Live animals"
    },
    {
      id: 3,
      name: "Refrigerated goods"
    },
    {
      id: 4,
      name: "Other"
    }
  ]

  public cargoSizeOptions = [
    {
      value: "Small package",
      label: "Small package (25x25x25)",
    },
    {
      value: "Box",
      label: "Box (40x40x40)",
    },
    {
      value: "Crate",
      label: "Crate (200x200x200)",
    }
  ]
  constructor(
    private router: Router,
    private fb: FormBuilder,
    private dataService: DataService,
    private http: HttpClient,
    private toastService: ToastService,
    private loadingService: LoadingScreenService,
  ) {}

  ngOnInit(): void {
    this.initLocations();
    this.initForm();
  }

  public initLocations() {
    this.loadingService.show();
    this.http.get("https://wa-eit-dk1.azurewebsites.net/getCities").subscribe({
      next: (result: any) => {
        this.locationOptions = result;
      },
      error: (err: HttpErrorResponse) => {
        this.toastService.show("Error: " + err.message, { classname: 'bg-danger text-light', delay: 5000 });
      }
    })
      .add(() => { this.loadingService.hidden() });
  }

  public initForm() {
    var today = new Date();
    var ngbDate: NgbDateStruct = {
      day: today.getDate(),
      month: today.getMonth() + 1,
      year: today.getFullYear()
    }

    this.form = this.fb.group({
      from: [null, Validators.required],
      to: [null, Validators.required],
      date: [ngbDate, [Validators.required]],
      cargoType: [this.cargoTypeOptions[0], Validators.required],
      cargoSize: [this.cargoSizeOptions[0], Validators.required],
      weight: [0, Validators.required],
      sortBy: [this.sortByOptions[0], Validators.required],
    });
  }

  public search() {
    this.dataService.searchingParameters = {
      ...this.form.value
    }

    //TODO: Mock, remove after has Api
    this.dataService.possiableRoutes = [
      {
        id: "1",
        duration: 12,
        price: 100,
        cities: [
          "Cairo", "Omdurman", "Darfur", "Congo"
        ],
        companies: [
          "TL", "TL", "OA"
        ],
        isExpanded: true,
      },
      {
        id: "2",
        duration: 15,
        price: 90,
        cities: [
          "Cairo", "Omdurman", "Darfur", "Congo"
        ],
        companies: [
          "TL", "TL", "OA"
        ],
        isExpanded: true,
      },
      {
        id: "3",
        duration: 8,
        price: 80,
        cities: [
          "Cairo", "Omdurman", "Darfur", "Congo"
        ],
        companies: [
          "TL", "TL", "OA"
        ],
        isExpanded: true,
      },
      {
        id: "4",
        duration: 5,
        price: 200,
        cities: [
          "Cairo", "Omdurman", "Darfur", "Congo"
        ],
        companies: [
          "TL", "TL", "OA"
        ],
        isExpanded: true,
      }
    ]

    const params = new HttpParams()
      .append('fromCityId', this.form.value.from.cityId)
      .append('toCityId', this.form.value.to.cityId);
    this.loadingService.show();
    this.http.get('https://wa-eit-dk1.azurewebsites.net/PossibleRoutes', { params: params })
      .subscribe({
        next: (result: any) => {
          result.forEach((route: any) => {
            route.cities = this.routeToCities(route);
            route.isCollapsed = true;
          })
          console.log(result);
          this.dataService.possiableRoutes = result;
          this.router.navigateByUrl("/routes");
        },
        error: (err: HttpErrorResponse) => {
          this.toastService.show("Error: " + err.message, { classname: 'bg-danger text-light', delay: 5000 });
        }
      })
      .add(() => { this.loadingService.hidden() });


    // console.log(this.form.value);
    // this.toastService.show("Hello", {classname: 'bg-danger text-light', delay: 5000});
    // this.loadingService.show();
  }

  public isFormControlInvalid(formControlName: string): boolean {
    return this.form.controls[formControlName].invalid
      && (this.form.controls[formControlName].dirty
        || this.form.controls[formControlName].touched);
  }

  public isFormControlHasError(formControlName: string, errorName: string): boolean {
    return this.form.controls[formControlName].errors?.[errorName];
  }

  private routeToCities(route: any): string[] {
    var cities: string[] = [];
    route.path.forEach((edge: any, index: number) => {
      cities.push(edge.source);
      console.log(index + 1, route.path.length)
      if (index + 1 == route.path.length) {
        cities.push(edge.target);
      }
    });
    return cities.map(cityId => this.convertCityIdToCityName(cityId));
  }

  private convertCityIdToCityName(cityId: string): string {
    return this.locationOptions.find(location => location.cityId == cityId)!.name;
  }
}
