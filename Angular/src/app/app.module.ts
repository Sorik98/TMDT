import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { AppComponent } from './app.component';
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { OAuthModule, OAuthStorage, OAuthService } from 'angular-oauth2-oidc';
import { TokenInterceptor } from '@shared/helpers/http-handle/TokenInterceptor';
import { API_BASE_URL, CartServiceProxy, OrderServiceProxy } from '@shared/service-proxies/service-proxies';
import { AppConsts } from '@shared/const/AppConst';
import { UserService, OAuthConfigService } from '@shared/service-proxies/services';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


export function getRemoteServiceBaseUrl(): string {
  return AppConsts.remoteServiceBaseUrl;
}
@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    OAuthModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [
    //Oauth config
    OAuthConfigService,
    //user services
    UserService,
    CartServiceProxy,
    OrderServiceProxy,
    //API BASE
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl },
    //HTTP Client
    HttpClientModule,
    //HTTP interceptor
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    //use local storage instead of session storage
    { provide: OAuthStorage, useValue: localStorage },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
