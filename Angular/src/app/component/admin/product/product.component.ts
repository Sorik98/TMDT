import { Component, OnInit, ViewChild, Injector, ElementRef } from '@angular/core';
import { ProductServiceProxy,ProductDTO, ProducerDTO, ProducerServiceProxy, ImageUrlDTO } from '@shared/service-proxies/service-proxies';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AdminComponentBase } from '../admin-component-base';
import { ProductType } from '@shared/const/AppConst';
import { MatSort } from '@angular/material/sort';
import { ThrowStmt } from '@angular/compiler';
import { FileService } from '@shared/service-proxies/services';

@Component({
  templateUrl: 'product.component.html',
})
export class ProductComponent extends AdminComponentBase implements OnInit {
  constructor(
              injector: Injector,
              private productService: ProductServiceProxy,
              private producerService: ProducerServiceProxy,
              private fileService: FileService
              ){
                super(injector);
  }

  displayedColumns = ['name',"image","price","desc","producerName","authStatus","createDate","createBy","authDate","authBy","lastUpdateDate","lastUpdateBy","action"];
  dataSource = new MatTableDataSource<ProductDTO>();
  productsList: ProductDTO[];
  filterInput = new ProductDTO();
  producers: ProducerDTO[];

  ProductType = ProductType;
  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  ngOnInit(){
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.initFilter();
    this.initCombobox();
    this.getProducts();
  }

  initFilter() {
    this.setDefaultFilter();
    super.initFilter();
  } 
  setDefaultFilter(){
   this.filterInput.type = null;
   this.filterInput.producerId = null;
   this.filterInput.name = null;
  }
  initCombobox(){
    this.getProducers();
  }
  getProducts(){
    this.productService.getAllAdmin().subscribe(res=>{
        this.productsList = res;
        this.dataSource.data = this.productsList;     
    });
  }
  getProducers(){
    this.producerService.getAll().subscribe(res => {
      this.producers = res;
    });
  } 
  onSearch()
  {
   this.dataSource.data = this.productsList.filter((p)=>{
              var a = (this.filterInput.type == null ||  this.filterInput.type == undefined) ? true : p.type == this.filterInput.type;
              var b = (this.filterInput.name == null ||  this.filterInput.name == undefined) ? true : (p.name.toLowerCase().includes(this.filterInput.name.toLowerCase()) ? true : false)
              var c = (this.filterInput.producerId == null ||  this.filterInput.producerId == undefined) ? true : p.producerId == this.filterInput.producerId
              return a&&b&&c;
                                  });
  }
  onAdd(){
    this.navigatePassParam("admin/product-add",null,{ filterInput: JSON.stringify(this.toCamel(this.filterInput)) })
  }
  onEdit(item: ProductDTO){
    this.navigatePassParam("admin/product-edit",{id: item.id},{ filterInput: JSON.stringify(this.toCamel(this.filterInput)) })
  }
  onViewDetail(item: ProductDTO){
    this.navigatePassParam("admin/product-view",{id: item.id},{ filterInput: JSON.stringify(this.toCamel(this.filterInput)) })
  }
  onDelete(item: ProductDTO){
    if(confirm("Are you sure to delete "+item.name)){
      this.productService.delete(item.id).subscribe(res => {
        if(res.result.type == 200)
            {
              var urls =[];
              item.imageUrls.forEach(v => {
                var split = v.url.split("/");
                urls.push(split[split.length-1]);
              });
              
              this.fileService.deleteImages(urls).subscribe(res => {
                  if(res.result.type == 200)
                  {
                    this.alert("success",res.result.message);
                    this.ngOnInit();
                  }
                  else this.alert("danger","Failed to upload image. Error: " + res.result.message)
              });
            }
            else this.alert("danger",res.result.message);
      });
    }
  }
  
}

