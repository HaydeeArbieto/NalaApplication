import { Component } from '@angular/core';
import { ProductsService } from '../../../shared/services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products-home',
  templateUrl: './products-home.component.html',
  styleUrls: ['./products-home.component.css'],

})

export class ProductsHomeComponent {
  constructor(private serv: ProductsService, private router : Router) { }

  products: any = [];

  ngOnInit() {
    return this.serv.getProducts().map(response => response)
      .subscribe(result => this.products = result);
  }

  routeToNewProduct() {
    this.router.navigate(['/admin/newproduct']);
  }
}
