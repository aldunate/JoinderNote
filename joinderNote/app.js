import 'zone.js/lib/browser/zone-microtask';
import 'reflect-metadata';

import "babel-register";

import { Component, View, bootstrap } from 'angular2/angular2';
import { HelloComponent } from './hello.component';

@Component({
  selector: 'hello-app'
})
@View({
  directives: [HelloComponent],
  template: `
    <div>
      <hello-component></hello-component>
    </div>
  `
})
class HelloApp { }

bootstrap(HelloApp, []);