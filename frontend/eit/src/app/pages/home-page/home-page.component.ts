import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class HomePageComponent implements OnInit {

  public locationOptions = [
    "A", "B", "C", "D",
  ]

  public sortByOptions = [
    "Cheapest", "Fastest"
  ]

  public cargoTypeOptions = [
    "Luggage", "Other"
  ]

  public cargoSizeOptions = [
    "Small package (25x25x25)",
    "Box (40x40x40)",
    "Crate (200x200x200)",
  ]
  constructor(private router: Router) {}

  ngOnInit(): void {
  }

  public search() {
    this.router.navigateByUrl("/routes");
  }

}
