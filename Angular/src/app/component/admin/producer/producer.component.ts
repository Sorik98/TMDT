import { Component, OnInit, ViewChild, Injector, ElementRef } from '@angular/core';
import { ProducerDTO, ProducerServiceProxy, ImageUrlDTO } from '@shared/service-proxies/service-proxies';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AdminComponentBase } from '../admin-component-base';

import { MatSort } from '@angular/material/sort';
import { ThrowStmt } from '@angular/compiler';
import { FileService } from '@shared/service-proxies/services';
import * as moment from 'moment'

@Component({
  templateUrl: 'producer.component.html',
})
export class ProducerComponent extends AdminComponentBase implements OnInit {
  constructor(
              injector: Injector,
              private producerService: ProducerServiceProxy,
              private fileService: FileService
              ){
                super(injector);
  }

  displayedColumns = ['name',"desc","authStatus","createDate","createBy","authDate","authBy","lastUpdateDate","lastUpdateBy","action"];
  dataSource = new MatTableDataSource<ProducerDTO>();
  producersList: ProducerDTO[];
  filterInput = new ProducerDTO();
  producers: ProducerDTO[];

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  ngOnInit(){
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.initFilter();
    this.getProducers();
    this.initSortColumn();
  }
  initSortColumn(){
    this.dataSource.sortingDataAccessor = (item, property) => {
      switch (property) {
        case 'createDate': return  moment(item.createDate);
        case 'authDate': return  moment(item.authDate);
        case 'lastUpdateDate': return  moment(item.lastUpdateDate);
        default: return item[property];
      }
    };
  }
  initFilter() {
    this.setDefaultFilter();
    super.initFilter();
  } 
  setDefaultFilter(){
   
   this.filterInput.name = null;
  }
  
  getProducers(){
    this.producerService.getAllAdmin().subscribe(res=>{
        this.producersList = res;
        this.dataSource.data = this.producersList;     
    });
  }
  
  onSearch()
  {
   this.dataSource.data = this.producersList.filter((p)=>{
              var a = (this.filterInput.name == null ||  this.filterInput.name == undefined) ? true : (p.name.toLowerCase().includes(this.filterInput.name.toLowerCase()) ? true : false)
            
              return a;
                                  });
  }
  onAdd(){
    this.navigatePassParam("admin/producer-add",null,{ filterInput: JSON.stringify(this.toCamel(this.filterInput)) })
  }
  onEdit(item: ProducerDTO){
    this.navigatePassParam("admin/producer-edit",{id: item.producerId},{ filterInput: JSON.stringify(this.toCamel(this.filterInput)) })
  }
  onViewDetail(item: ProducerDTO){
    this.navigatePassParam("admin/producer-view",{id: item.producerId},{ filterInput: JSON.stringify(this.toCamel(this.filterInput)) })
  }
  onDelete(item: ProducerDTO){
    if(confirm("Are you sure to delete "+item.name)){
      this.producerService.delete(item.producerId).subscribe(res => {
        if(res.result.type == 200)
            {
             
            this.alert("success",res.result.message);
            this.ngOnInit();
            
            }
            else this.alert("danger",res.result.message);
      });
    }
  }
  
}

