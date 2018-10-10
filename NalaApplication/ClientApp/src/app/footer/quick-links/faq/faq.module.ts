import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

//import { AboutComponent } from './footer/about/about.component';
import { FaqOrderComponent } from './faq-order/faq.order.component';
import { FaqPaymentComponent } from './faq-payment/faq.payment.component';


@NgModule({
  declarations: [
    //AppComponent,
    FaqOrderComponent,
    FaqPaymentComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
   
    RouterModule.forRoot([
      { path: 'order1', component: FaqOrderComponent },
      { path: 'payment1', component: FaqPaymentComponent },
    ])
  ],
  providers: [],
  //bootstrap: [AppComponent]
})

export class AppModule { }
