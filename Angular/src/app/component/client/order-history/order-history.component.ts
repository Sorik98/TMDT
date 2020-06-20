import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { OrderServiceProxy, OrderDTO } from '@shared/service-proxies/service-proxies';
import { OrderStatus, AppConsts } from '@shared/const/AppConst';


@Component({
  templateUrl: './order-history.component.html',
  styles: []
})
export class OrderHistoryComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private orderService: OrderServiceProxy
  ) {
    super(injector);
    console.log(this);
   }
  orders: OrderDTO[];
  displayList: OrderDTO[]=[];
  pageSize = 5;
  OrderStatus = OrderStatus;
  filterInput = {
    status: null,
    fromDate: null,
    toDate: null
  };
  orderEmptyUrl = AppConsts.remoteServiceBaseUrl + "/Other/" + "order_emty.png";
  ngOnInit(): void {
    this.getOrders()

  }
  getOrders(){
      this.orderService.getUserOrders(this.userId).subscribe(res => {
          this.orders = res;
          this.displayList = this.orders;
      });
  }
  cancellable(order: OrderDTO){
    return order.status == OrderStatus.Sent;
  }
  cancelOrder(id: number){
      this.orderService.cancelOrder(id,this.userId).subscribe(res => {
        if(res.result.type == 200){
          this.alert("success",res.result.message);
          this.ngOnInit();
        }
        else this.alert("danger","Failed cancel order. Error: " + res.result.message)
      })
  }
  onSearch()
  {
   this.displayList = this.orders.filter((p)=>{
              var a = (this.filterInput.status == null ||  this.filterInput.status == undefined) ? true : p.status == this.filterInput.status;
              var b = (this.filterInput.fromDate == null ||  this.filterInput.fromDate == undefined) ? true : p.createDate.isAfter(this.filterInput.fromDate);
              var c = (this.filterInput.toDate == null ||  this.filterInput.toDate == undefined) ? true : p.createDate.isBefore(this.filterInput.toDate);
              return a&&b&&c;
                                  });
  }
}
