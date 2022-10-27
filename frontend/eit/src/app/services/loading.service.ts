import { ApplicationRef, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class LoadingScreenService {
  isLoading: boolean = false;

  constructor() {}

  public show(): void {
    this.isLoading = true;
  }

  public hidden(): void {
    this.isLoading = false;
  }
}