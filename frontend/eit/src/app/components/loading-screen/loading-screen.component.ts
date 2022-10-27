import {Component} from '@angular/core';
import {LoadingScreenService} from 'src/app/services/loading.service';

@Component({
  selector: 'lib-loading-screen',
  templateUrl: './loading-screen.component.html',
  styleUrls: ['./loading-screen.component.scss']
})
export class LoadingScreenComponent {
  constructor(public loadingScreenService: LoadingScreenService) {
  }
}