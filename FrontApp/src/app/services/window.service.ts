import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class WindowService {

  constructor() { }

  encodeURIComponent(uriComponent: string | number | boolean){
    return window.encodeURIComponent(uriComponent)
  }
}
