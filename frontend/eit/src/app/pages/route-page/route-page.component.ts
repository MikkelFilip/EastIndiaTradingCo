import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-route-page',
  templateUrl: './route-page.component.html',
  styleUrls: ['./route-page.component.scss']
})
export class RoutePageComponent implements OnInit {

  public selectedSortBy = "Cheapest";
  public selectedRoute?: any;
  
  public sortByOptions = [
    "Cheapest", "Fastest"
  ];
  public routes = [
    {
      id: "1",
      duration: 12,
      price: 100,
      segments: [
        "A", "B", "C", "D"
      ],
      isCollapsed: true,
    },
    {
      id: "2",
      duration: 15,
      price: 90,
      segments: [
        "A", "B", "C", "D"
      ],
      isCollapsed: true,
    },
    {
      id: "3",
      duration: 8,
      price: 80,
      segments: [
        "A", "B", "C", "D"
      ],
      isCollapsed: true,
    },
    {
      id: "4",
      duration: 5,
      price: 200,
      segments: [
        "A", "B", "C", "D"
      ],
      isCollapsed: true,
    }
  ]

  public routePathCities = [ "Cairo", "Omdurman", "Darfur", "Congo"];
  public routePathCompanies = [ "TL", "TL", "OA"];

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.sortRoute()
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
