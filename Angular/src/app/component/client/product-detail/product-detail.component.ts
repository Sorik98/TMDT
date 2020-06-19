import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { ProductServiceProxy, ProductDTO, CartServiceProxy, CartItemDTO } from '@shared/service-proxies/service-proxies';
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
    console.log(this);

   }
   ProductType = ProductType;
   product: ProductDTO = new ProductDTO();
   Quantity = 1;
   private readonly QuantityMax = 50;
  ngOnInit(): void {

      this.getProducts(this.getRouteParam("id"));
  }

  getProducts(id: number ){
    
    this.productService.getBy(id).subscribe(res => {
      this.product = res;
    });
  }
  addToCart(num: number){
    var item = new CartItemDTO();
    item.product = this.product;
    item.quantity = num;
    item.userId = this.userId;
    this.userService.addToCart(item);
  }
  quantityChange(){
    if(this.Quantity >this.QuantityMax)this.Quantity = this.QuantityMax;
    else if (this.Quantity < 1)this.Quantity = 1;
    this.product.price = this.Quantity * Math.round(this.product.originalPrice - (this.product.originalPrice*this.product.sale/100));
  }
}
