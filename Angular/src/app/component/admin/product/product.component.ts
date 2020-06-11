import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { ProductServiceProxy,ProductDTO } from '@shared/service-proxies/service-proxies';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AdminComponentBase } from '../admin-component-base';

@Component({
  templateUrl: 'product.component.html',
})
export class ProductComponent extends AdminComponentBase implements OnInit {
  constructor(
              injector: Injector,
              private productService: ProductServiceProxy,
              
              ){
                super(injector);
  }
  
  displayedColumns = ['name',"image","price","desc","producer-name","auth-status","create-date","create-by","auth-date","auth-by","last-update-date","last-update-by","action"];
  dataSource = new MatTableDataSource<ProductDTO>();
  filterInput = new ProductDTO();
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  ngOnInit(){
    this.getProducts();
    this.dataSource.paginator = this.paginator;
    this.initFilter();
    console.log(this.filterInput);
  }
  
  getProducts(){
    this.productService.getAllAdmin("Laptop").subscribe(res=>{
        this.dataSource.data = res;
        
    });
  }
  
  onAdd(){
    this.navigatePassParam("admin/product-add",{ filterInput: JSON.stringify(this.dataSource.data[0]) })
  }
  onEdit(){

  }
  onViewDetail(){

  }
  onDeleta(){

  }
}

