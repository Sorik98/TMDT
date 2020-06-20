import { Component, OnInit, Injector } from '@angular/core';
import {   ProducerServiceProxy, ProducerDTO } from '@shared/service-proxies/service-proxies';

import { AdminComponentBase } from '../admin-component-base';
import { EditPageState, AuthStatus, } from '@shared/const/AppConst';


@Component({
  templateUrl: 'producer-edit.component.html',
})
export class ProducerEditComponent extends AdminComponentBase implements OnInit {
  constructor(
              injector: Injector,
              private producerService: ProducerServiceProxy
              ){
                super(injector);
                console.log(this);
  }
  
  filterInput: ProducerDTO;
  EditPageState = EditPageState;
  editPageState: EditPageState;

  inputModel: ProducerDTO = new ProducerDTO();


 
  ngOnInit(){
    this.editPageState=this.getRouteData('editPageState'); 
    this.initFilter();
 
    this.initInputModel();
    if(this.editPageState != EditPageState.add)this.getProducer(this.getRouteParam("id"));
  }
  initInputModel(){
    
  }
  getProducer(id: number){
   if(!id)return;
    this.producerService.getByAdmin(id).subscribe(res =>{
      this.inputModel = res;
    })
  }
  
  vailidateInput(){
    if(!(this.inputModel.name.length > 4 && this.inputModel.name.length < 30 ))
    {
        this.alert("warning","Tên nhà sản xuất hợp lệ phải từ 4 đến 30 ký tự")
        return false;
    }
    if(!(this.inputModel.desc.length > 30 && this.inputModel.name.length < 1000 ))
    {
        this.alert("warning","Tên nhà sản xuất hợp lệ phải từ 30 đến 1000 ký tự")
    }
    return true;
  }
  onSave(){
    if(!this.vailidateInput())return;
    if(this.editPageState != EditPageState.viewDetail)
    {
    if(this.editPageState == EditPageState.add)
    this.onCreate();
    else
    this.onUpdate();
    }
  }
  onCreate(){
    this.inputModel.createBy = this.userEmail;
    
    this.producerService.create(this.inputModel).subscribe(res => {
        if(res.result.type == 200)
        {
        this.alert("success",res.result.message);
        }
        else this.alert("danger",res.result.message);
    });
  }
  onUpdate(){
    this.inputModel.lastUpdateBy = this.userEmail;
    
      this.producerService.update(this.inputModel).subscribe(res => {
        if(res.result.type == 200)
          {
            this.alert("success",res.result.message);
            this.ngOnInit();
          }
          else this.alert("danger",res.result.message);
      });

  }
  onApprove(){
    this.producerService.approve(true,this.inputModel.producerId,this.userEmail).subscribe(res => {
       if(res.result.type == 200)
       {
         this.alert("success",res.result.message);
         this.ngOnInit();
       }
      else this.alert("danger","Failed to upload image. Error: " + res.result.message)
  });
  }
  onReject(){
    this.producerService.approve(false,this.inputModel.producerId,this.userEmail).subscribe(res => {
      if(res.result.type == 200)
      {
         this.alert("success",res.result.message);
         this.ngOnInit();
       }
     else this.alert("danger","Failed to upload image. Error: " + res.result.message)
  });
  }
  
  isView(){
    return this.editPageState == EditPageState.viewDetail
  }
  isApprovable(){
    return this.isView() && this.isAdmin() && this.inputModel.authStatus == AuthStatus.Submitted;
  }
   goBack() {
    this.navigatePassParam('/admin/producer',null, { filterInput: JSON.stringify(this.toCamel(this.filterInput)) });
  } 
  
}

