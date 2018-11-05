import { Component } from '@angular/core';
import { ProductsService } from '../../shared/services/products.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],

})
export class HomeComponent {
  constructor(private serv: ProductsService) { }

  products:any = [];

  ngOnInit() {
    return this.serv.getProducts().map(response => response)
      .subscribe(result => this.products = result);
  }

}
