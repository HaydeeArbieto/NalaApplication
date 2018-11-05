import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin.routing.module';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  imports: [
    AdminRoutingModule, BrowserModule, RouterModule, BrowserAnimationsModule,
  ],
  declarations: [ AdminComponent, AdminDashboardComponent, AdminMenuComponent, AdminProductsComponent],
  bootstrap: [],
})
export class AdminModule { }
