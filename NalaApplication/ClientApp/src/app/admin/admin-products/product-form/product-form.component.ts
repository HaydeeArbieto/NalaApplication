import { Component } from '@angular/core';
import { ProductsService } from '../../../shared/services/products.service';
import { CategoriesService } from '../../../shared/services/categories.service';
import { ColorsService } from '../../../shared/services/colors.service';
import { SizesService } from '../../../shared/services/sizes.service';
import { Product } from '../../../shared/models/models';


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],

})



export class ProductFormComponent {
  constructor(
    private pServ: ProductsService,
    private caServ: CategoriesService,
    private coServ: ColorsService,
    private sServ: SizesService)
  { }
  date = new Date();
  categories: any = [];
  sizes: any = [];
  colors: any = [];
  productModel = new Product('', '', '', '', this.date.toUTCString(), '', '', '', '', '');
  
  
 

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

  onFileChanged(event) {
    const file = event.target.files[0]
  }

  submitted = false;

  onSubmit() {
    this.submitted = true;
    console.log(JSON.stringify(this.productModel));
    return this.pServ.postProduct(this.productModel).subscribe(res=> console.log(res));
      
  } 
}
