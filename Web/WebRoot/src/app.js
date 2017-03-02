import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class App {

  shipNames = [];
  patterns = ['v A N', 'T v A N', 'A N', 'T N', 'V T A N', 'A V', 'V A', 'T N [of] N'];
  limit = 4;
  count = 1;
  length = 22;
  alliterate = false;
  showOptions = false;

  constructor(http) {
    http.configure(config => {
      config
        .withBaseUrl('/api/');
    });
    this.http = http;
    this.getSingleName();
  }

  activate() {
    window.addEventListener('keypress', this.handleKeyInput, false);
  }

  deactivate() {
    window.removeEventListener('keypress', this.handleKeyInput);
  }

  handleKeyInput = (event) => {
    if (event.code == 'KeyB' && event.ctrlKey) {
      this.showOptions = !this.showOptions;
      ga('send', {
        hitType: 'event',
        eventCategory: 'Options',
        eventAction: 'toggle',
        eventLabel: 'Toggle options'
      });
    }
  }

  getSingleName() {

    this.http.fetch(`names/${this.count}/${this.length}/${this.limit}/${this.alliterate}/${this.patterns}/?_t=${new Date().getTime()}`)
      .then(response => response.json())
      .then(data => {

        if (Array.isArray(data)) {
          data.forEach(function (element) {
            this.shipNames.unshift(element);
          }, this);
        }
        else {
          this.shipNames.unshift(data);
        }
      });

    ga('send', {
      hitType: 'event',
      eventCategory: 'Names',
      eventAction: 'request',
      eventLabel: 'Name request'
    });
  }

}
