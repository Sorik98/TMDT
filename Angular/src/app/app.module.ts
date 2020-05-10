import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";

import { AppComponent } from './app.component';
import { HttpClientModule } from "@angular/common/http";
import * as ApiServiceProxies from "./shared/service-proxy";
import { PaymentDetailComponent } from './payment-detail/payment-detail.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    AppComponent,
    PaymentDetailComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ApiServiceProxies.PaymentDetailServiceProxy,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
