import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';



    const adminRoutes: Routes = [
        // { path: 'payment-detail', component: PaymentDetailComponent },
        // { path: 'home', component: HomeComponent }, 
    ];

    @NgModule({
        imports: [
            RouterModule.forChild(adminRoutes)
        ],
        exports: [
            RouterModule
        ],
        declarations: []
    })
    export class AdminRoutingModule { }
