import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { ProductsHomeComponent } from './admin-products/products-home/products-home.component';
import { ProductFormComponent } from './admin-products/product-form/product-form.component';


const routes: Routes = [
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      { path: '', component: AdminDashboardComponent },
      {
        path: 'products', component: AdminProductsComponent,
        children: [
        { path: '', component: ProductsHomeComponent },
        { path: 'newproduct', component: ProductFormComponent },
        ]
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
