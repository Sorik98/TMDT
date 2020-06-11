import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';

//import { PaymentDetailComponent } from './payment-detail/payment-detail.component';
import { HomeComponent } from './home/home.component';
import { ClientRoutingModule } from './client-routing.module';
import * as ApiServiceProxies  from'@shared/service-proxies/service-proxies'
import { ClientComponent } from './client.component';
import { HeaderComponent } from './header&footer/header/header.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { FooterComponent } from './header&footer/footer/footer.component';
import { NotifierModule } from "angular-notifier";

@NgModule({
  declarations: [
    //PaymentDetailComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    PageNotFoundComponent,
    ClientComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ClientRoutingModule,
    NotifierModule,
  ],
  providers: [
    /* #region  service-proxies */
    //Thong tin hoa don
    //ApiServiceProxies.PaymentDetailServiceProxy,
    /* #endregion */
    
  ]
})
export class ClientModule { }
