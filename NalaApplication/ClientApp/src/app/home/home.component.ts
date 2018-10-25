import { Component } from '@angular/core';
import { ProductsService } from '../services/products.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  product: any = {};
  constructor(private serv: ProductsService) {
  }

  ngOnInit() {
    this.getProduct();
  }

  getProduct() {
    this.product = {};
    this.serv.getProduct().subscribe((data: {}) => {
      console.log(data);
      this.product = data;
    });
  }
}


