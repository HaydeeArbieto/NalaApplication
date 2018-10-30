import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
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
import { LogoutComponent } from './my-account/logout/logout.component';

import { FooterComponent } from './footer/footer.component';
import { AboutComponent } from './footer/about/about.component';

import { FaqComponent } from './footer/quick-links/faq/faq.component';
import { FaqOrderComponent } from './footer/quick-links/faq/faq-order/faq.order.component';
import { FaqPaymentComponent } from './footer/quick-links/faq/faq-payment/faq.payment.component';
import { FaqDeliveryComponent } from './footer/quick-links/faq/faq-delivery/faq.delivery.component';
import { FaqReturnComponent } from './footer/quick-links/faq/faq-return/faq.return.component';

import { ReturnsComponent } from './footer/customer-care/returns/returns.component';
import { ShippingComponent } from './footer/customer-care/shipping-delivery/shipping-delivery.component';
import { SizeGuideComponent } from './footer/customer-care/size-guide/size-guide.component';
import { TermsConditionsComponent } from './footer/quick-links/terms-conditions/terms-conditions.component';
import { ContactComponent } from './footer/quick-links/contact/contact.component';

import { AdminMenuComponent } from './admin/admin-menu/admin-menu.component';
import { ProductsService } from './services/products.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
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
    LogoutComponent,

    FooterComponent,

    AboutComponent,
   
    ReturnsComponent,
    ShippingComponent,
    SizeGuideComponent,

    FaqComponent,
    FaqOrderComponent,
    FaqPaymentComponent,
    FaqDeliveryComponent,
    FaqReturnComponent,

    TermsConditionsComponent,
    ContactComponent,
    AdminMenuComponent,
    
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
          { path: 'account-details', component: AccountDetailsComponent },
          { path: 'customer-logout', component: LogoutComponent }
        ]
      },
      { path: 'checkout', component: CheckoutComponent },
      { path: 'cart', component: CartComponent },
      { path: 'lookbok', component: LookbokComponent },
      { path: 'about', component: AboutComponent },
      { path: 'returns', component: ReturnsComponent },
      { path: 'shipping', component: ShippingComponent },
      { path: 'size-guide', component: SizeGuideComponent },
      { path: 'terms-conditions', component: TermsConditionsComponent },
      { path: 'contact', component: ContactComponent },
      {
        path: 'order', component: FaqComponent,
        children: [
          { path: '', redirectTo: 'faq-order', pathMatch: 'full' },
          { path: 'faq-order', component: FaqOrderComponent },
          { path: 'payment', component: FaqPaymentComponent },
          { path: 'delivery', component: FaqDeliveryComponent },
          { path: 'return', component: FaqReturnComponent },
          { path: 'contact', component: ContactComponent },
        ]
      },
    ])
  ],
  providers: [ProductsService],
  bootstrap: [AppComponent]
})

export class AppModule { }
