import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { AdminGuard } from '@shared/guard/AdminGuard';
import { AdminComponent } from './admin.component';
import { EditPageState } from '@shared/const/AppConst';
import { ProductEditComponent } from './product/product-edit.component';
import { ProducerComponent } from './producer/producer.component';
import { ProducerEditComponent } from './producer/producer-edit.component';



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

            // Nhà sản xuất
            { path: 'producer', component: ProducerComponent },
            { path: 'producer-add', component: ProducerEditComponent, data: {editPageState: EditPageState.add} },
            { path: 'producer-edit', component: ProducerEditComponent, data: {editPageState: EditPageState.edit} },
            { path: 'producer-view', component: ProducerEditComponent, data: {editPageState: EditPageState.viewDetail} },

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
