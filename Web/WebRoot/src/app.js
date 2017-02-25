import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class App {

  

  constructor(http) { 
    http.configure(config => {
      config
        .withBaseUrl('/api/');
    });
    this.http = http;
    this.shipNames = [];
    this.getSingleName();
  }

  getSingleName() {
    this.http.fetch('name/?_t=' + new Date().getTime())
      .then(response => response.json())
      .then(data => {
        this.shipNames.unshift(data);
      });
  }
}
