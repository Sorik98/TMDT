import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChoCamComponent } from './cho-cam/cho-cam.component';
import { AdminGuard } from '@shared/guard/AdminGuard';



    const adminRoutes: Routes = [
        {path: '',component:ChoCamComponent, canActivate: [AdminGuard]}
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
