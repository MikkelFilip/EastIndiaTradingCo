import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-information-page',
  templateUrl: './information-page.component.html',
  styleUrls: ['./information-page.component.scss']
})
export class InformationPageComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  public submit() {
    this.router.navigateByUrl("/confirmation");
  }
}
