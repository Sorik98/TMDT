import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { AdminGuard } from '@shared/guard/AdminGuard';
import { AdminComponent } from './admin.component';
import { EditPageState } from '@shared/const/AppConst';
import { ProductEditComponent } from './product/product-edit.component';



    const adminRoutes: Routes = [
        {
        path: '',
        component: AdminComponent,
        canActivate: [AdminGuard],
        children: [
            // Sản phẩm
            { path: 'product', component: ProductComponent },
            { path: 'product-add', component: ProductEditComponent, data: {editPageState: EditPageState.add} },
            { path: 'product-edit', component: ProductEditComponent, data: {editPageState: EditPageState.edit} },
            { path: 'product-view', component: ProductEditComponent, data: {editPageState: EditPageState.viewDetail} },



            { path: '', redirectTo: 'product', pathMatch: 'full' },
            // { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
        ]
        }
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
