import { Component, OnInit, Injector } from '@angular/core';
import { ClientComponentBase } from '../client-component-base';
import { ProductServiceProxy, ProductDTO, ProducerServiceProxy, ProducerDTO } from '@shared/service-proxies/service-proxies';
import { ProductType } from '@shared/const/AppConst';

@Component({
  templateUrl: './product-list.component.html',
  styles: []
})
export class ProductListComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private productService: ProductServiceProxy,
    private producerService: ProducerServiceProxy
  ) {
    super(injector);
   }
   ProductType = ProductType;
   products: ProductDTO[];
   displayList: ProductDTO[]=[];
   producers: ProducerDTO[];
   filterInput = {
    producerId: null,
    name: null,
    option: null
  };
  ngOnInit(): void {
      console.log(this)
      this.getProducts(this.getRouteParam("type"));
      this.initFilter()
      this.initCombobox()
  }
  initCombobox(){
    this.getProducers();
  }
  getProducers(){
    this.producerService.getAll().subscribe(res => {
      this.producers = res;
    });
  } 
  getProducts(type: ProductType ){
    
    this.productService.getAll(type).subscribe(res => {
      this.products = res;
      this.displayList = this.products;
    });
  }
  initFilter(){
     
  }
  onSearch()
  {
   this.displayList = this.products.filter((p)=>{
              var b = (this.filterInput.name == null ||  this.filterInput.name == undefined) ? true : (p.name.toLowerCase().includes(this.filterInput.name.toLowerCase()) ? true : false)
              var c = (this.filterInput.producerId == null ||  this.filterInput.producerId == undefined) ? true : p.producerId == this.filterInput.producerId
              return b&&c;
                                  });
  
  switch(this.filterInput.option)
  {
    case 0:
      this.displayList.sort((a,b)=> b.sold - a.sold);
      break;
    case 1:
      this.displayList.sort((a,b)=> a.sold - b.sold)
      break;
  }
  }
   
}
