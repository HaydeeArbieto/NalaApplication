import { Component, OnInit } from '@angular/core';
import { enableProdMode } from '@angular/core';
import { CheckoutJS } from './checkout';
import { Countries} from 'angular-countries';

@Component({
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent {

  public show: boolean = false;
  public buttonName: any = 'Yes';

  display = 'none';

  ngOnInit() { }

  toggle() {
    this.show = !this.show;

    // Change the name of buttom
    if (this.show)
      this.buttonName = "No";
    else
      this.buttonName = "Yes";
  }

  //constructor() { };

  openModal() {
    this.display = 'block';
  }

  onCloseHandled() {
    this.display = 'none';
  }

}
 
 


