import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin.routing.module';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AdminSidebarComponent } from './admin-sidebar/admin-sidebar.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { ProductsHomeComponent } from './admin-products/products-home/products-home.component';
import { ProductsMenuComponent } from './admin-products/products-menu/products-menu.component';
import { ProductFormComponent } from './admin-products/product-form/product-form.component';
import { ReactiveFormsModule, FormsModule} from '@angular/forms';
import { ProductsService } from '../shared/services/products.service';
import { CategoriesService } from '../shared/services/categories.service';
import { ColorsService } from '../shared/services/colors.service';
import { SizesService } from '../shared/services/sizes.service';

@NgModule({
  imports: [
    AdminRoutingModule, BrowserModule.withServerTransition({ appId: 'ng-cli-universal' })
    , RouterModule, ReactiveFormsModule, FormsModule
  ],
  declarations: [AdminComponent, AdminDashboardComponent,
    AdminSidebarComponent, AdminProductsComponent,
    ProductsHomeComponent, ProductsMenuComponent, ProductFormComponent
    ],
  bootstrap: [],
  providers:[ProductsService, CategoriesService, ColorsService, SizesService ],
})
export class AdminModule { }
