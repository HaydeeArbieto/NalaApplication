import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css'],
})
export class CheckoutComponent {

  public show: boolean = false;
  public buttonName: any = 'Yes';

  ngOnInit() { }

  toggle() {
    this.show = !this.show;

    // Change the name of buttom
    if (this.show)
      this.buttonName = "No";
    else
      this.buttonName = "Yes";
  }
}
