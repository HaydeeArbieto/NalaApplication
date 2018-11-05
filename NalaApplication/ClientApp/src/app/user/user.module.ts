import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MyAccountComponent } from './my-account/my-account.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CartComponent } from './cart/cart.component';
import { LookbokComponent } from './lookbok/lookbok.component';
import { DashboardComponent } from './my-account/dashboard/dashboard.component';
import { OrdersComponent } from './my-account/orders/orders.component';
import { DownloadsComponent } from './my-account/downloads/downloads.component';
import { AddressesComponent } from './my-account/addresses/addresses.component';
import { PaymentsMethodsComponent } from './my-account/payments-methods/payments-methods.component';
import { AccountDetailsComponent } from './my-account/account-details/account-details.component';
import { LogoutComponent } from './my-account/logout/logout.component';
import { FooterComponent } from './footer/footer.component';
import { AboutComponent } from './footer/about/about.component';
import { ReturnsComponent } from './footer/customer-care/returns/returns.component';
import { ShippingComponent } from './footer/customer-care/shipping-delivery/shipping-delivery.component';
import { SizeGuideComponent } from './footer/customer-care/size-guide/size-guide.component';
import { FaqComponent } from './footer/quick-links/faq/faq.component';
import { FaqOrderComponent } from './footer/quick-links/faq/faq-order/faq.order.component';
import { FaqPaymentComponent } from './footer/quick-links/faq/faq-payment/faq.payment.component';
import { FaqDeliveryComponent } from './footer/quick-links/faq/faq-delivery/faq.delivery.component';
import { FaqReturnComponent } from './footer/quick-links/faq/faq-return/faq.return.component';
import { TermsConditionsComponent } from './footer/quick-links/terms-conditions/terms-conditions.component';
import { ContactComponent } from './footer/quick-links/contact/contact.component';
import { BrowserModule } from '@angular/platform-browser';
import { ProductsService } from '../shared/services/products.service';
import { RouterModule } from '@angular/router';
import { UserComponent } from './user.component';
import { UserRoutingModule } from './user.routing.module';

@NgModule({
  declarations: [
 
    UserComponent,
    HomeComponent,
    NavMenuComponent,
    FooterComponent,
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

  ],
  imports: [
    BrowserModule, RouterModule, UserRoutingModule

  ],
  providers: [ProductsService],
  bootstrap: [],
})
export class UserModule { }



