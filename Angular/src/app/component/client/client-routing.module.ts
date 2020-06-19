import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { PaymentDetailComponent } from './payment-detail/payment-detail.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ClientComponent } from './client.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { CartComponent } from './cart/cart.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { SettingComponent } from './setting/setting.component';
import { AboutComponent } from './about/about.component';


const clientRoutes: Routes = [
    {
        path: '',
        component: ClientComponent,
        children: [
            //{ path: 'payment-detail', component: PaymentDetailComponent },
            { path: 'home', component: HomeComponent },
            { path: 'cart', component: CartComponent },
            { path: 'order', component: OrderHistoryComponent },
            { path: 'settings', component:SettingComponent },
            { path: 'about', component:AboutComponent },
            { path: 'product/:type', component: ProductListComponent},
            { path: 'product/:type/:id', component: ProductDetailComponent},
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
        ]
    },

    /* #region  Old path */
    //     path: '',
    //     component: ClientComponent, 
    //     children: [
    // { path: 'payment-detail', component: PaymentDetailComponent },
    // { path: 'home', component: HomeComponent }, 
    // { path: '', redirectTo: '/home', pathMatch: 'full' },
    // { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
    // {
    //     path: 'client',
    //     component: ClientComponent,
    //     children: [
    //         { path: 'payment-detail', component: PaymentDetailComponent },
    //         { path: 'home', component: HomeComponent }, 
    //         { path: '', redirectTo: '/home', pathMatch: 'full' },
    //         { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
    //     ]
    // }
    //   ]
    /* #endregion */
];

@NgModule({
    imports: [
        RouterModule.forChild(clientRoutes)
    ],
    exports: [
        RouterModule
    ],
    declarations: []
})
export class ClientRoutingModule { }
