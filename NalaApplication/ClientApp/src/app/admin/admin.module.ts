import { NgModule } from '@angular/core';
import { AdminRoutingModule } from './admin.routing.module';
import { AdminComponent } from './admin.component';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminMenuComponent } from './admin-menu/admin-menu.component';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';


@NgModule({
  imports: [
    AdminRoutingModule, BrowserModule, RouterModule,
  ],
  declarations: [ AdminComponent, AdminDashboardComponent, AdminMenuComponent],
  bootstrap: [],
})
export class AdminModule { }
