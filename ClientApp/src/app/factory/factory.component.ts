import { Component, OnInit, Input } from '@angular/core';
import { factory } from '../factory';
import { FactoryService } from '../factory.service';

@Component({
  selector: 'app-factory',
  templateUrl: './factory.component.html',
  styleUrls: ['./factory.component.css']
})
export class FactoryComponent implements OnInit {
  @Input() factory: factory = new factory();
  lowerBound: number = 0;
  upperBound: number = 1;
  childCount: number = 1;
  childCountOption = Array.from({length: 16}, (x,i) => i);

  constructor(private factoryService: FactoryService) { }

  ngOnInit() {  }

  DeleteFactory() {
    this.factoryService.DeleteFactory(this.factory);
  }

  GenerateChildren() {
    if(this.lowerBound === undefined){
      alert("Please enter a lower bound")
    } else if(this.upperBound === undefined) {
      alert("Please enter an upper bound")
    } else if(this.lowerBound > this.upperBound) {
      alert("Please enter a lower bound greater than the upper bound")
    } else {
      this.factory.children = [];
      for(var i = 0; i < this.childCount; i++){
        this.factory.children.push(Math.floor(Math.random() * (this.upperBound + 1 - this.lowerBound) + this.lowerBound))
      }
      this.UpdateFactory()
    }
  }

  UpdateFactory() {
    this.factoryService.UpdateFactory(this.factory);
  }
}
