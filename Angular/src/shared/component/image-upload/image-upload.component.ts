import { Component, Output, EventEmitter, Input, ElementRef, ViewChild } from '@angular/core';
import { ImageSnippet } from '@shared/model/Model';
import { repeat } from 'rxjs/operators';

  
@Component({
    selector: 'bwm-image-upload',
    templateUrl: 'image-upload.component.html',
    styleUrls: ['image-upload.component.scss']
  })
  export class ImageUploadComponent {
  
    imgList: ImageSnippet[] = [];
    pending: boolean = false;
    @ViewChild("imageModal")imageModal: ElementRef;

    @Output() ImageSnippets = new EventEmitter<ImageSnippet[]>();
    @Output() files = new EventEmitter<FileList>();
    @Input() disable: boolean = false;
    constructor(){console.log(this)}
  
    // private onSuccess() {
    //   this.selectedFile.pending = false;
    //   this.selectedFile.status = 'ok';
    // }
  
    // private onError() {
    //   this.selectedFile.pending = false;
    //   this.selectedFile.status = 'fail';
    //   this.selectedFile.src = '';
    // }
  
    setImages(imgList: ImageSnippet[]){
      this.imgList = imgList;
    }

    processFile(images: FileList) {
      this.imgList = [];
      this.files.emit(images);
      if(images.length == 0) return;

      for(var i=0;i<images.length;i++)
      {
        this.imgList.push(new ImageSnippet("", images[i].name));
        this.imgList[i].pending = true;
      }
      var reader = new FileReader();
      reader.addEventListener('load', (event: any) => {
        this.imgList[i].src = event.target.result;
        this.imgList[i].pending = false;
        if(i<images.length-1)reader.readAsDataURL(images[++i]);
      });
      i = 0;
      reader.readAsDataURL(images[i]);
    }
    showModal(event: any){

      this.imageModal.nativeElement.style.display = "block";
      this.imageModal.nativeElement.children[0].src = event.target.style.backgroundImage.split("\"")[1];
    }
    closeModal(){
      this.imageModal.nativeElement.style.display = "none";
    }
  }