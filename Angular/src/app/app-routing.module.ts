import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PaymentDetailComponent } from './payment-detail/payment-detail.component';

    const routes: Routes = [
        { path: '', component: DashboardComponent },
        { path: 'payment-detail', component: PaymentDetailComponent },
    ];

    @NgModule({
        imports: [
            RouterModule.forRoot(routes)
        ],
        exports: [
            RouterModule
        ],
        declarations: []
    })
    export class AppRoutingModule { }
