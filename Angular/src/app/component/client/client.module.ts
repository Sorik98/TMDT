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
import { UserService } from '@shared/service-proxies/services';
import { SharedModule } from '@shared/component/shared.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import {  NgbCarouselModule, NgbModalModule, NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { MatButton, MatButtonModule } from '@angular/material/button';
import { CartComponent } from './cart/cart.component';
import {MatBadgeModule} from '@angular/material/badge';
import { MatInput, MatInputModule } from '@angular/material/input';
import { OrderHistoryComponent } from './order-history/order-history.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatSelectModule } from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatMomentDateModule } from "@angular/material-moment-adapter";
import { SettingComponent } from './setting/setting.component';
import { AboutComponent } from './about/about.component';
@NgModule({
  declarations: [
    //PaymentDetailComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    ProductListComponent,
    ProductDetailComponent,
    CartComponent,
    OrderHistoryComponent,
    SettingComponent,
    AboutComponent,
    PageNotFoundComponent,
    ClientComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ClientRoutingModule,
    SharedModule,
    MatButtonModule,
    NgbCarouselModule,
    NgbModalModule,
    MatButtonModule,
    MatBadgeModule,
    MatInputModule,
    MatExpansionModule,
    NgbPaginationModule,
    MatSelectModule,
    MatDatepickerModule,
    MatMomentDateModule 
  ],
  providers: [
    /* #region  service-proxies */
    // San pham
    ApiServiceProxies.ProductServiceProxy,

    // Nha san xuat
    ApiServiceProxies.ProducerServiceProxy,

    // User
    ApiServiceProxies.UserServiceProxy,
    //Gio hang
    
    //Thong tin hoa don
    //ApiServiceProxies.PaymentDetailServiceProxy,
    /* #endregion */
    
  ]
})
export class ClientModule { }
