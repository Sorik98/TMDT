import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { ProductServiceProxy,ProductDTO, ImageUrlDTO, ProducerServiceProxy, ProducerDTO } from '@shared/service-proxies/service-proxies';

import { AdminComponentBase } from '../admin-component-base';
import { EditPageState, AppConsts, AuthStatus, ProductType } from '@shared/const/AppConst';
import { ImageSnippet } from '@shared/model/Model';
import { HttpClient } from '@angular/common/http';
import { FileService } from '@shared/service-proxies/services';
import { ImageUploadComponent } from '@shared/component/image-upload/image-upload.component';
import { finalize } from 'rxjs/operators';

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
  producers: ProducerDTO[];
  @ViewChild(ImageUploadComponent)imageUploader: ImageUploadComponent;

  ngOnInit(){
    this.editPageState=this.getRouteData('editPageState'); 
    this.initFilter();
    this.initCombobox();
    this.getProduct(this.getRouteParam("id"));
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
  onSave(){
    this.onCreate();
  }
  onCreate(){
    this.upLoadImagesToServer(this.imageFiles);
  }
  onUpdate(){

  }
  onApprove(){

  }
  onSelectFiles(files: FileList)
  {
    this.imageFiles = files;
  }
  upLoadImagesToServer(images: FileList){
    if(!images) return;
    this.saving = true;
    this.fileService.upLoadImagesToServer(images).pipe(finalize(() => { this.saving = false; })).subscribe(res =>{
      if(res.result.type == 200)this.alert("success",res.result.message);
      else this.alert("danger",res.result.message);
    });

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

