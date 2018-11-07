import { Component } from '@angular/core';
import { ProductsService } from '../../shared/services/products.service';
import { CategoriesService } from '../../shared/services/categories.service';
import { ColorsService } from '../../shared/services/colors.service';
import { SizesService } from '../../shared/services/sizes.service';
import { Product } from '../../shared/models/models';

@Component({
  selector: 'app-admin-new-product-form',
  templateUrl: './admin-new-product-form.component.html',
  styleUrls: ['./admin-new-product-form.component.css'],

})

export class AdminNewProductFormComponent {
  constructor(
    private pServ: ProductsService,
    private caServ: CategoriesService,
    private coServ: ColorsService,
    private sServ: SizesService)
  { }

  categories: any = [];
  sizes: any = [];
  colors: any = [];

  ngOnInit() {
    this.getCategories();
    this.getColors();
    this.getSizes();
  }

  getCategories() {
    return this.caServ.getCategories().map(response => response)
      .subscribe(result => this.categories = result);
  }
  getColors() {
    return this.coServ.getColors().map(response => response)
      .subscribe(result => this.colors = result);
  }

  getSizes() {
    return this.sServ.getSizes().map(response => response)
      .subscribe(result => this.sizes = result);
  }

}
