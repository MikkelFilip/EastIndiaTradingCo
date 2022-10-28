import { Component, OnInit } from '@angular/core';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { DataService } from 'src/app/services/dataService';

@Component({
  selector: 'app-confirmation-page',
  templateUrl: './confirmation-page.component.html',
  styleUrls: ['./confirmation-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class ConfirmationPageComponent implements OnInit {
  public routePathCities = this.dataService.selectedRoute.cities;
  public routePathCompanies = this.dataService.selectedRoute.companies;
  public isExpandedRoutePath = false;

  constructor(public dataService: DataService) { }

  ngOnInit(): void {
    console.log(this.dataService);
  }

  public ngbDateToString(date: NgbDate) {
    return date.year + "-" + date.month + "-" + date.day;
  }
}
