import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

import { MyAccountComponent } from './my-account/my-account.component';

import { DashboardComponent } from './my-account/dashboard/dashboard.component';
import { OrdersComponent } from './my-account/orders/orders.component';
import { DownloadsComponent } from './my-account/downloads/downloads.component';
import { AddressesComponent } from './my-account/addresses/addresses.component';
import { PaymentsMethodsComponent } from './my-account/payments-methods/payments-methods.component';
import { AccountDetailsComponent } from './my-account/account-details/account-details.component';
import { LogoutComponent } from './my-account/logout/logout.component';

import { CheckoutComponent } from './checkout/checkout.component';
import { CartComponent } from './cart/cart.component';

import { AboutComponent } from './footer/about/about.component';

import { ReturnsComponent } from './footer/customer-care/returns/returns.component';
import { SizeGuideComponent } from './footer/customer-care/size-guide/size-guide.component';

import { FaqComponent } from './footer/quick-links/faq/faq.navbar.component';
import { FaqOrderComponent } from './footer/quick-links/faq/faq-order/faq.order.component';
import { FaqPaymentComponent } from './footer/quick-links/faq/faq-payment/faq.payment.component';
import { FaqDeliveryComponent } from './footer/quick-links/faq/faq-delivery/faq.delivery.component';
import { FaqReturnComponent } from './footer/quick-links/faq/faq-return/faq.return.component';
import { UserComponent } from './user.component';

import { TermsConditionsComponent } from './footer/quick-links/terms-conditions/terms-conditions.component';
import { ContactComponent } from './footer/quick-links/contact/contact.component';


const routes: Routes = [
  {
    path: '',
    component: UserComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'home', component: HomeComponent },
      { path: 'checkout', component: CheckoutComponent },
      { path: 'cart', component: CartComponent },
      { path: 'about', component: AboutComponent },
      { path: 'returns', component: ReturnsComponent },
      { path: 'size-guide', component: SizeGuideComponent },
      { path: 'terms-conditions', component: TermsConditionsComponent },
      { path: 'contact', component: ContactComponent },
      {
        path: 'my-account', component: MyAccountComponent,
        children: [
          { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
          { path: 'dashboard', component: DashboardComponent, 
            children: [
              //{ path: '', redirectTo: 'my-account', pathMatch: 'full' },
              { path: 'account-details', component: AccountDetailsComponent },
              { path: 'orders', component: OrdersComponent },
              { path: 'addresses', component: AddressesComponent },
            ]
          },
          { path: 'orders', component: OrdersComponent },
          { path: 'downloads', component: DownloadsComponent },
          { path: 'addresses', component: AddressesComponent },
          { path: 'payment-methods', component: PaymentsMethodsComponent },
          { path: 'account-details', component: AccountDetailsComponent },
          { path: 'customer-logout', component: LogoutComponent }
        ]
      },
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
    }

    ]
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
