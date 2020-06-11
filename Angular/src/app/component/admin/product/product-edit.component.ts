import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { ProductServiceProxy,ProductDTO } from '@shared/service-proxies/service-proxies';

import { AdminComponentBase } from '../admin-component-base';
import { EditPageState } from '@shared/const/AppConst';

@Component({
  templateUrl: 'product-edit.component.html',
})
export class ProductEditComponent extends AdminComponentBase implements OnInit {
  constructor(
              injector: Injector,
              private productService: ProductServiceProxy,
              
              ){
                super(injector);
                console.log(this);
  }
  
  filterInput: ProductDTO;
  EditPageState = EditPageState;
  editPageState: EditPageState;
  ngOnInit(){
    this.editPageState=this.getRouteData('editPageState'); 
    this.initFilter();
  }
   goBack() {
    this.navigatePassParam('/admin/product', { filterInput: JSON.stringify(this.filterInput) });
  } 
  
}

