import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';




    const routes: Routes = [
        //lazy loading
        {
            path: 'admin',
            loadChildren: () => import('./component/admin/admin.module').then(m => m.AdminModule)
        },
        {
            path: '',
            loadChildren: () => import('./component/client/client.module').then(m => m.ClientModule)
        },
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
