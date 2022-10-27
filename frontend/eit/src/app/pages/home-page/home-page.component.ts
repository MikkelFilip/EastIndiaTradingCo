import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
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
  constructor() { }

  ngOnInit(): void {
  }

}
