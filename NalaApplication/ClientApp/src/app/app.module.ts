import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
import { AdminModule } from './admin/admin.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';


import { AppComponent } from './app.component';
import { UserModule } from './user/user.module';
import { AdminComponent } from './admin/admin.component';
import { UserComponent } from './user/user.component';





const appRoutes: Routes = [
  { path: 'admin', component: AdminComponent },
  {
    path: 'home',
    component: UserComponent,
  },
  {
    path: '',
    redirectTo: '/home',
    pathMatch: 'full'
  },];


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule, AdminModule, UserModule, ReactiveFormsModule, FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
