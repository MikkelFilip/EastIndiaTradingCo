import { ApplicationRef, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class DataService {
  public searchingParameters: any;
  public possiableRoutes : any[] = [];
  public selectedRoute : any;
  public bookedShipment: any;

  constructor() {}
}