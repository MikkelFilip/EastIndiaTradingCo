import { ApplicationRef, Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class DataService {
  public possiableRoutes : any[] = [];
  public bookedShipment? : any;

  constructor() {}
}