import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-report-page',
  templateUrl: './report-page.component.html',
  styleUrls: ['./report-page.component.scss'],
  host: {
    class: 'd-flex flex-column flex-grow-1'
  }
})
export class ReportPageComponent implements OnInit {

  public routes = [
    {
      from: "Cairo",
      to: "Congo",
      number: 128,
    },
    {
      from: "Cairo",
      to: "Congo",
      number: 112,
    },
    {
      from: "Cairo",
      to: "Congo",
      number: 97,
    },
    {
      from: "Cairo",
      to: "Congo",
      number: 85,
    },
    {
      from: "Cairo",
      to: "Congo",
      number: 81,
    },
  ]
  constructor() { }

  ngOnInit(): void {
  }

}
