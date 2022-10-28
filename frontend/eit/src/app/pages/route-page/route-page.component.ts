import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/dataService';

@Component({
  selector: 'app-route-page',
  templateUrl: './route-page.component.html',
  styleUrls: ['./route-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class RoutePageComponent implements OnInit {

  public selectedSortBy = "Cheapest";
  public selectedRoute?: any;

  public sortByOptions = [
    "Cheapest", "Fastest"
  ];
  public routes: any[] = [];

  constructor(
    private router: Router,
    private dataService: DataService,
  ) {}

  ngOnInit(): void {
    this.routes = this.dataService.possiableRoutes;
    this.selectedSortBy = this.dataService.searchingParameters.sortBy;
    console.log(this.selectedSortBy);
    this.sortRoute();
  }

  public sortRoute() {
    if (this.selectedSortBy == "Cheapest") {
      this.sortRouteByPrice();
    } else {
      this.sortRouteByDuration();
    }
  }

  public selectRoute(route: any) {
    this.selectedRoute = route;
  }

  public submit() {
    this.dataService.selectedRoute = this.selectedRoute;
    this.router.navigateByUrl("/information");
  }

  private sortRouteByPrice() {
    this.routes.sort((route1, route2) => {
      if (route1.price > route2.price) {
        return 1
      } else if (route1.price == route2.price) {
        return 0
      } else {
        return -1;
      }
    });
  }

  private sortRouteByDuration() {
    this.routes.sort((route1, route2) => {
      if (route1.duration > route2.duration) {
        return 1
      } else if (route1.duration == route2.duration) {
        return 0
      } else {
        return -1;
      }
    });
  }
}
