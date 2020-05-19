import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { HeaderComponent } from './component/header&footer/header/header.component';
import { FooterComponent } from "./component/header&footer/footer/footer.component";
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import * as ApiServiceProxies from "../shared/service-proxies/service-proxies";
import { PaymentDetailComponent } from './component/payment-detail/payment-detail.component';

import { DashboardComponent } from './component/dashboard/dashboard.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { TokenInterceptor } from '@shared/helpers/http-handle/TokenInterceptor';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { AppConsts } from '@shared/const/AppConst';

export function getRemoteServiceBaseUrl(): string {
  return AppConsts.remoteServiceBaseUrl;
}
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
    AppRoutingModule,
    OAuthModule.forRoot()
  ],
  providers: [
    //Thong tin hoa don
    ApiServiceProxies.PaymentDetailServiceProxy,
   { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl },
    HttpClientModule,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
