import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { ProductServiceProxy, ProductDTO, CartItemDTO, OrderDTO, OrderDetailDTO } from '@shared/service-proxies/service-proxies';
import { ProductType } from '@shared/const/AppConst';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { finalize } from 'rxjs/operators';

@Component({
  templateUrl: './cart.component.html',
  styles: []
})
export class CartComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private modalService: NgbModal
            ) 
    {
    super(injector);console.log(this);
    }
  order: OrderDTO = new OrderDTO();
  saveBtnDisable = false;
  pageSize = 5;
  ngOnInit(): void {

  }
  get cart(){
    return this.userService.Cart;
  }
 
  onDeleteCart(){
    if(!confirm("Bạn có thực sự muốn xóa giỏ hàng?"))return;
    var ids: number[] = [];
    this.cart.forEach(v => ids.push(v.id));
    this.userService.deleteCart(ids).subscribe(res => {
      if(res.result.type == 200)
      {
        this.alert("success",res.result.message);
        this.userService.reloadCart();
      }
      else this.alert("danger","Failed to delete cart. Error: " + res.result.message)
    })
  }
  onDeleteItem(id: number){
    if(!confirm("Bạn có thực sự muốn xóa dơn hàng này?"))return;
    this.userService.deleteItem(id).subscribe(res => {
      if(res.result.type == 200)
      {
        this.alert("success",res.result.message);
        this.userService.reloadCart();
      }
      else this.alert("danger","Failed to delete cart. Error: " + res.result.message)
    })
  }


  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }

  createOrder(){
    this.saveBtnDisable = true;
    this.order.userId = this.userId;
    var list: OrderDetailDTO[] = [];
    var cart = this.cart;
    cart.forEach(v => {
      var dto = new OrderDetailDTO();
      dto.productId = v.product.id;
      dto.quantity = v.quantity;
      list.push(dto);
    })
    this.order.orderDetails = list;
    this.userService.createOrder(this.order).pipe(finalize( () => {this.saveBtnDisable = false})).subscribe(res => {
      if(res.result.type == 200)
      {
            var ids: number[] = [];
            this.cart.forEach(v => ids.push(v.id));
            this.userService.deleteCart(ids).subscribe(res => {
              if(res.result.type == 200)
              {
                this.alert("success",res.result.message);
                this.userService.reloadCart();
              }
              else this.alert("danger","Failed to delete cart. Error: " + res.result.message)
            })
      }
      else this.alert("danger","Failed to delete cart. Error: " + res.result.message)
    });
  }
  
}
