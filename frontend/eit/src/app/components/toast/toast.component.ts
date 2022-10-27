import {Component, TemplateRef} from '@angular/core';
import {ToastService} from 'src/app/services/toast.service';

@Component({
  selector: 'lib-toast',
  templateUrl: './toast.component.html',
  host: {'class': 'toast-container position-fixed bottom-0 end-0 p-3', 'style': 'z-index: 1200'}
})
export class ToastComponent {
  constructor(public toastService: ToastService) {}

  isTemplate(toast: any) {
    return toast.textOrTpl instanceof TemplateRef;
  }
}