import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//import { PaymentDetailComponent } from './payment-detail/payment-detail.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ClientComponent } from './client.component';


const clientRoutes: Routes = [
    {
        path: '',
        component: ClientComponent,
        children: [
            //{ path: 'payment-detail', component: PaymentDetailComponent },
            { path: 'home', component: HomeComponent },
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
