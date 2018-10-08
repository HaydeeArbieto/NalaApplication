import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
//import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { MyAccountComponent } from './my-account/my-account.component';
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
      { path: 'my-account', component: MyAccountComponent },
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
