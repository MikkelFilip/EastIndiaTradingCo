import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-route-path',
  templateUrl: './route-path.component.html',
  styleUrls: ['./route-path.component.scss']
})
export class RoutePathComponent implements OnInit {
  @Input() cities: string[] = [];
  @Input() companies: string[] = [];
  constructor() { }

  ngOnInit(): void {
  }
}
