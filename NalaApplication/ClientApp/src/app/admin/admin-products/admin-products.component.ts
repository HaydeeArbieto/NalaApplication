import { Component } from '@angular/core';
import { ProductsService } from '../../shared/services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css'],

})

export class AdminProductsComponent {
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
