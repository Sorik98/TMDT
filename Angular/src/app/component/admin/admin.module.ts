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
import { SidenavService, FileService } from '@shared/service-proxies/services';
import { ProductEditComponent } from './product/product-edit.component';
import { SharedModule } from '@shared/component/shared.module';
import {MatRippleModule} from '@angular/material/core';
import {MatInputModule} from '@angular/material/input';
import {MatMenuModule} from '@angular/material/menu';
import {MatSelectModule} from '@angular/material/select';
import {MatSortModule} from '@angular/material/sort';

@NgModule({
  declarations: [
    ProductEditComponent,
    ProductComponent,
    AdminComponent,
    SideNavigationComponent,
    DateTimeFormatPipe,
    MoneyFormatPipe,
  ],
  imports: [
    AdminRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatIconModule,
    ScrollingModule,
    MatTooltipModule,
    MatSidenavModule,
    MatButtonToggleModule,
    SharedModule,
    MatRippleModule,
    MatInputModule,
    MatMenuModule,
    MatSelectModule,
    MatSortModule
    
  ],
  providers: [
    /* #region  service-proxies */
    //San pham
    ApiServiceProxies.ProductServiceProxy,
    // Nha cung cap
    ApiServiceProxies.ProducerServiceProxy,
    //Thong tin hoa don
   // ApiServiceProxies.PaymentDetailServiceProxy,
    /* #endregion */
    SidenavService,
    FileService,
  ]
})
export class AdminModule { }
