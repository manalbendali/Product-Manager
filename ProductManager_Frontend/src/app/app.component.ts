import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProductManager';
  actions : Array<any> = [
    {title:"Home","route":"/home" , icon:"house"},
    {title:"Products","route":"/products" , icon:"shop"},
    {title:"New Product","route":"/new-products" , icon:"bag"}
  ];

  currentAction : any;

  setCurrentAction(action : any){
    this.currentAction = action;
  }
}
