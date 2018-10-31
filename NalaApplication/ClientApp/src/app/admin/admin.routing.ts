import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminComponent } from './admin/admin.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },

  { path: 'admin', component: AdminComponent },
];
 



export const routing = RouterModule.forRoot(routes);
