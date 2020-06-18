import { Component, OnInit, ViewChild, Injector, ElementRef } from '@angular/core';
import { ProductServiceProxy,ProductDTO, ImageUrlDTO, ProducerServiceProxy, ProducerDTO } from '@shared/service-proxies/service-proxies';

import { AdminComponentBase } from '../admin-component-base';
import { EditPageState, AppConsts, AuthStatus, ProductType, ServerFolder } from '@shared/const/AppConst';
import { ImageSnippet } from '@shared/model/Model';
import { HttpClient } from '@angular/common/http';
import { FileService } from '@shared/service-proxies/services';
import { ImageUploadComponent } from '@shared/component/image-upload/image-upload.component';
import { finalize, map } from 'rxjs/operators';
import { MatInputCommifiedDirective } from '@shared/directives/mat-input-conmmified';
import { url } from 'inspector';

@Component({
  templateUrl: 'product-edit.component.html',
})
export class ProductEditComponent extends AdminComponentBase implements OnInit {
  constructor(
              injector: Injector,
              private productService: ProductServiceProxy,
              private producerService: ProducerServiceProxy,
              private fileService: FileService
              ){
                super(injector);
                console.log(this);
  }
  
  filterInput: ProductDTO;
  EditPageState = EditPageState;
  editPageState: EditPageState;
  ProductType = ProductType;
  inputModel: ProductDTO = new ProductDTO();
  imageFiles: FileList;
  private readonly  stockMax = 10000;

  producers: ProducerDTO[];
  @ViewChild(ImageUploadComponent)imageUploader: ImageUploadComponent;
  @ViewChild("moneyInput",{read: MatInputCommifiedDirective}) moneyInput: MatInputCommifiedDirective;
  ngOnInit(){
    this.editPageState=this.getRouteData('editPageState'); 
    this.initFilter();
    this.initCombobox();
    this.initInputModel();
    if(this.editPageState != EditPageState.add)this.getProduct(this.getRouteParam("id"));
  }
  initInputModel(){
    this.inputModel.imageUrls= [];
  }
  getProduct(id: number){
   if(!id)return;
    this.productService.getByAdmin(id).subscribe(res =>{
      this.inputModel = res;
      this.setImageSnippet(res.imageUrls);
    })
  }
  getProducers(){
      this.producerService.getAll().subscribe(res => {
        this.producers = res;
      });
  }
  initCombobox(){
    this.getProducers();
  }
  setImageSnippet(imageUrls: ImageUrlDTO[]){
    let images: ImageSnippet[] = [];
      imageUrls.forEach(img =>{
        var split = img.url.split('/');  
        images.push(new ImageSnippet(img.url,split[split.length-1]));
      });
      this.imageUploader.setImages(images);
  }
  vailidateInput(){
    if( !(this.inputModel.sale >= 0 && this.inputModel.sale <= 90) )
    {
      this.alert("warning","Sale value is limited between 0 and 90")
      return false;
    }
    if( !(this.inputModel.stock >= 0 && this.inputModel.stock <= this.stockMax) )
    {
      this.alert("warning","Stock value is limited between 0 and "+this.stockMax)
      return false;
    }
    return true
  }
  onSave(){
    if(!this.vailidateInput())return;
    if(this.editPageState != EditPageState.viewDetail)
    {
    this.inputModel.originalPrice = parseFloat(this.moneyInput.value);
    if(this.editPageState == EditPageState.add)
    this.onCreate();
    else
    this.onUpdate();
    }
  }
  onCreate(){
    this.inputModel.createBy = this.userEmail;
    this.inputModel.imageUrls = [];
    for(var i=0;i<this.imageFiles.length;i++) 
    { 
      var dto = new ImageUrlDTO();
      dto.url = AppConsts.remoteServiceBaseUrl + "/" + ServerFolder.Image + "/" + this.imageFiles[i].name;
      this.inputModel.imageUrls.push(dto);
    }
    this.productService.create(this.inputModel).subscribe(res => {
        if(res.result.type == 200)
        {
          this.upLoadImagesToServer(this.imageFiles).subscribe(res => {
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
  onUpdate(){
    this.inputModel.lastUpdateBy = this.userEmail;
    if(this.imageFiles)
    {
        var deleteUrls = [];
        this.inputModel.imageUrls.forEach(v => {
            var split = v.url.split("/");
            deleteUrls.push(split[split.length-1]);
        });
        
        this.inputModel.imageUrls = [];
        for(var i=0;i<this.imageFiles.length;i++) 
        { 
          var dto = new ImageUrlDTO();
          dto.url = AppConsts.remoteServiceBaseUrl + "/" + ServerFolder.Image + "/" + this.imageFiles[i].name;
          this.inputModel.imageUrls.push(dto);
        }
        
        this.productService.update(this.inputModel).subscribe(res => {
          if(res.result.type == 200)
            {
              this.fileService.deleteImages(deleteUrls).subscribe(res => {
                if(res.result.type == 200)
                {
                  this.upLoadImagesToServer(this.imageFiles).subscribe(res => {
                      if(res.result.type == 200){
                        this.alert("success",res.result.message);
                        this.ngOnInit();
                      }
                      else this.alert("danger","Failed to upload image. Error: " + res.result.message)
                  });
                }
                else this.alert("danger",res.result.message);
              });
            }
            else this.alert("danger",res.result.message);
        })
    } 
    else 
    {
      this.productService.update(this.inputModel).subscribe(res => {
        if(res.result.type == 200)
          {
            this.alert("success",res.result.message);
            this.ngOnInit();
          }
          else this.alert("danger",res.result.message);
      })
    }
  }
  onApprove(){
    this.productService.approve(true,this.inputModel.id,this.userEmail).subscribe(res => {
       if(res.result.type == 200)
       {
         this.alert("success",res.result.message);
         this.ngOnInit();
       }
      else this.alert("danger","Failed to upload image. Error: " + res.result.message)
  });
  }
  onReject(){
    this.productService.approve(false,this.inputModel.id,this.userEmail).subscribe(res => {
      if(res.result.type == 200)
      {
         this.alert("success",res.result.message);
         this.ngOnInit();
       }
     else this.alert("danger","Failed to upload image. Error: " + res.result.message)
  });
  }
  onSelectFiles(files: FileList)
  {
    this.imageFiles = files;
  }
  onSaleInputChange(){
    var price = parseFloat(this.moneyInput.value);
    this.inputModel.price = Math.round(price - (price * this.inputModel.sale / 100));
  }
  upLoadImagesToServer(images: FileList){
    if(!images) return;
    this.saving = true;
    return this.fileService.upLoadImagesToServer(images);

  }
  isView(){
    return this.editPageState == EditPageState.viewDetail
  }
  isApprovable(){
    return this.isView() && this.isAdmin() && this.inputModel.authStatus == AuthStatus.Submitted;
  }
   goBack() {
    this.navigatePassParam('/admin/product',null, { filterInput: JSON.stringify(this.toCamel(this.filterInput)) });
  } 
  
}

