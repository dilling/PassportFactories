import { Component } from '@angular/core';
import { factory } from '../factory';
import { FactoryService } from '../factory.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private factoryService: FactoryService) { }

  AddFactory() {
    this.factoryService.AddFactory();
  }

  GetFactories() {
    return this.factoryService.factories;
  }
}
