import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { HeaderComponent } from './header&footer/header/header.component';
import { FooterComponent } from "./header&footer/footer/footer.component";
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule } from "@angular/common/http";
import * as ApiServiceProxies from "./shared/service-proxy";
import { PaymentDetailComponent } from './payment-detail/payment-detail.component';

import { DashboardComponent } from './dashboard/dashboard.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    PaymentDetailComponent,
    DashboardComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [
    ApiServiceProxies.PaymentDetailServiceProxy,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
