import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { ProductServiceProxy, ProductDTO } from '@shared/service-proxies/service-proxies';
import { ProductType } from '@shared/const/AppConst';

@Component({
  templateUrl: './product-detail.component.html',
  styles: []
})
export class ProductDetailComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private productService: ProductServiceProxy,
  ) {
    super(injector);
   }
   ProductType = ProductType;
   product: ProductDTO = new ProductDTO();
  ngOnInit(): void {
      console.log(this)
      this.getProducts(this.getRouteParam("id"));
  }

  getProducts(id: number ){
    
    this.productService.getBy(id).subscribe(res => {
      this.product = res;
    });
  }
}
