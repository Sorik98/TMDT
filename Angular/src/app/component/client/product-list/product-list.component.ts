import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { ProductServiceProxy, ProductDTO } from '@shared/service-proxies/service-proxies';
import { ProductType } from '@shared/const/AppConst';

@Component({
  templateUrl: './product-list.component.html',
  styles: []
})
export class ProductListComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private productService: ProductServiceProxy,
  ) {
    super(injector);
   }
   ProductType = ProductType;
   products: ProductDTO[];
  ngOnInit(): void {
      console.log(this)
      this.getProducts(this.getRouteParam("type"));
  }

  getProducts(type: ProductType ){
    
    this.productService.getAll(type).subscribe(res => {
      this.products = res;
    });
  }
}
