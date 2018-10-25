import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
//import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CartComponent } from './cart/cart.component';

import { LookbokComponent } from './lookbok/lookbok.component';

import { MyAccountComponent } from './my-account/my-account.component';
import { DashboardComponent } from './my-account/dashboard/dashboard.component';
import { OrdersComponent } from './my-account/orders/orders.component';
import { DownloadsComponent } from './my-account/downloads/downloads.component';
import { AddressesComponent } from './my-account/addresses/addresses.component';
import { PaymentsMethodsComponent } from './my-account/payments-methods/payments-methods.component';
import { AccountDetailsComponent } from './my-account/account-details/account-details.component';



import { AboutComponent } from './footer/about/about.component';
import { FaqComponent } from './footer/quick-links/faq/faq.component';
import { ReturnsComponent } from './footer/customer-care/returns/returns.component';
import { ShippingComponent } from './footer/customer-care/shipping-delivery/shipping-delivery.component';
import { SizeGuideComponent } from './footer/customer-care/size-guide/size-guide.component';
import { TermsConditionsComponent } from './footer/quick-links/terms-conditions/terms-conditions.component';
import { ContactComponent } from './footer/quick-links/contact/contact.component';

import { ProductsService } from './services/products.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MyAccountComponent,
    CheckoutComponent,
    CartComponent,
    LookbokComponent,
    DashboardComponent,
    OrdersComponent,
    DownloadsComponent,
    AddressesComponent,
    PaymentsMethodsComponent,
    AccountDetailsComponent,
    AboutComponent,
    FaqComponent,
    ReturnsComponent,
    ShippingComponent,
    SizeGuideComponent,
    TermsConditionsComponent,
    ContactComponent,
  
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, 
   
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
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
      { path: 'lookbok', component: LookbokComponent },
      { path: 'about', component: AboutComponent },
      { path: 'order', component: FaqComponent },
      { path: 'returns', component: ReturnsComponent },
      { path: 'shipping', component: ShippingComponent },
      { path: 'size-guide', component: SizeGuideComponent },
      { path: 'terms-conditions', component: TermsConditionsComponent },
      { path: 'contact', component: ContactComponent },
    ])
  ],
  providers: [ProductsService],
  bootstrap: [AppComponent]
})

export class AppModule { }
