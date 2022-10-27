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
  public routePathCities = [ "Cairo", "Omdurman", "Darfur", "Congo", "Congo2", "Congo3", "Congo 4", "Congo 5", "Congo 6"];
  public routePathCompanies = [ "TL", "TL", "OA", "OA", "OA", "OA", "OA", "OA"];
  public isExpandedRoutePath = false;

  constructor(public dataService: DataService) { }

  ngOnInit(): void {
  }

  public ngbDateToString(date: NgbDate) {
    return date.year + "-" + date.month + "-" + date.day;
  }
}
