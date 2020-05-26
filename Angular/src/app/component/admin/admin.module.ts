import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';


import { AdminRoutingModule } from './admin-routing.module';
import * as ApiServiceProxies  from'@shared/service-proxies/service-proxies'

@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    AdminRoutingModule
  ],
  providers: [
    /* #region  service-proxies */
    //Thong tin hoa don
   // ApiServiceProxies.PaymentDetailServiceProxy,
    /* #endregion */
    
  ]
})
export class AdminModule { }
