import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';


import { AdminRoutingModule } from './admin-routing.module';
import * as ApiServiceProxies  from'@shared/service-proxies/service-proxies'
import { ProductComponent } from './product/product.component';
import { AdminComponent } from './admin.component';
import { DateTimeFormatPipe } from '@shared/pipe/date-time-format.pipe';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import {ScrollingModule} from '@angular/cdk/scrolling';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MoneyFormatPipe } from '@shared/pipe/money-format.pipe';
import { SideNavigationComponent } from './side-nav/side-nav.component';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import { SidenavService, NotifierService } from '@shared/service-proxies/services';
import { ProductEditComponent } from './product/product-edit.component';

@NgModule({
  declarations: [
    ProductEditComponent,
    ProductComponent,
    AdminComponent,
    SideNavigationComponent,
    DateTimeFormatPipe,
    MoneyFormatPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    AdminRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    ScrollingModule,
    MatTooltipModule,
    MatSidenavModule,
    MatButtonToggleModule
  ],
  providers: [
    /* #region  service-proxies */
    //San pham
    ApiServiceProxies.ProductServiceProxy,
    //Thong tin hoa don
   // ApiServiceProxies.PaymentDetailServiceProxy,
    /* #endregion */
    SidenavService,
    NotifierService
    
  ]
})
export class AdminModule { }
