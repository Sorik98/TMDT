import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { ProductServiceProxy, ProductDTO } from '@shared/service-proxies/service-proxies';
import { ProductType } from '@shared/const/AppConst';

@Component({
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private productService: ProductServiceProxy,
  ) {
    super(injector);
   }

   ProductType = ProductType;
   products: ProductDTO[] = [];
   productNum = 10;

  ngOnInit(): void {
    this.getLatestProducts();
  }

  getLatestProducts(){
    this.productService.getLatestProducts(15).subscribe(res => {
      this.products = res;
    })
  }

}
