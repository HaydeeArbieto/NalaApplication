import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
//import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

import { MyAccountComponent } from './my-account/my-account.component';
import { DashboardComponent } from './my-account/dashboard/dashboard.component';
import { OrdersComponent } from './my-account/orders/orders.component';
import { DownloadsComponent } from './my-account/downloads/downloads.component';
import { AddressesComponent } from './my-account/addresses/addresses.component';
import { PaymentsMethodsComponent } from './my-account/payments-methods/payments-methods.component';
import { AccountDetailsComponent } from './my-account/account-details/account-details.component';

import { CheckoutComponent } from './checkout/checkout.component';
import { CartComponent } from './cart/cart.component';

import { AboutComponent } from './footer/about/about.component';
import { FaqComponent } from './footer/quick-links/faq/faq.component';
import { SizeGuideComponent } from './footer/customer-care/size-guide/size-guide.component';
import { TermsConditionsComponent } from './footer/quick-links/terms-conditions/terms-conditions.component';
import { ContactComponent } from './footer/quick-links/contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MyAccountComponent,
    DashboardComponent,
    OrdersComponent,
    DownloadsComponent,
    AddressesComponent,
    PaymentsMethodsComponent,
    AccountDetailsComponent,
    CheckoutComponent,
    CartComponent,
    AboutComponent,
    FaqComponent,
    SizeGuideComponent,
    TermsConditionsComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
   
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
      {
        path: 'my-account', component: MyAccountComponent,
        children: [
          { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
          { path: 'dashboard', component: DashboardComponent },
          { path: 'orders', component: OrdersComponent },
          { path: 'downloads', component: DownloadsComponent },
          { path: 'addresses', component: AddressesComponent },
          { path: 'payment-methods', component: PaymentsMethodsComponent },
          { path: 'account-details', component: AccountDetailsComponent }
        ]
      },
      { path: 'checkout', component: CheckoutComponent },
      { path: 'cart', component: CartComponent },
      { path: 'about', component: AboutComponent },
      { path: 'order', component: FaqComponent },
      { path: 'size-guide', component: SizeGuideComponent },
      { path: 'terms-conditions', component: TermsConditionsComponent },
      { path: 'contact', component: ContactComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})

export class AppModule { }
