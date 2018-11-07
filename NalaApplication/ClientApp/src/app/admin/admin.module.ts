import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin.routing.module';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { AdminNewProductFormComponent } from './admin-new-product-form/admin-new-product-form.component';
import { ProductsService } from '../shared/services/products.service';
import { CategoriesService } from '../shared/services/categories.service';
import { ColorsService } from '../shared/services/colors.service';
import { SizesService } from '../shared/services/sizes.service';


@NgModule({
  imports: [
    AdminRoutingModule, BrowserModule, RouterModule,
  ],
  declarations: [AdminComponent, AdminDashboardComponent, AdminMenuComponent, AdminProductsComponent, AdminNewProductFormComponent],
  bootstrap: [],
  providers[ProductsService, CategoriesService, ColorsService, SizesService],
})
export class AdminModule { }
