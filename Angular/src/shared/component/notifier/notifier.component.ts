import { Component, ElementRef, ViewChild, AfterViewInit } from '@angular/core';

@Component({
    selector: 'custom-notifier',
    templateUrl: './notifier.component.html',
    styles: []
})
export class CustomNotifier implements AfterViewInit{


  private notifierSuccess: any;
  private notifierWarning: any;
  private notifierDanger: any;
  @ViewChild("notifierContainer") notifierContainer:ElementRef


  public ngAfterViewInit(){    
    this.notifierSuccess = this.notifierContainer.nativeElement.children[0];
    this.notifierWarning = this.notifierContainer.nativeElement.children[1];
    this.notifierDanger = this.notifierContainer.nativeElement.children[2]
  }

  public alert(type: string, message: string){
    this.clearNotifier();
      switch(type)
      {
          case "success":
            this.notifierSuccess.hidden = false;
            this.notifierSuccess.children[1].innerText = message;
            break;
          case "warning":
            this.notifierWarning.hidden = false;
            this.notifierWarning.children[1].innerText = message;
            break;
          case "danger":
            this.notifierDanger.hidden = false;
            this.notifierDanger.children[1].innerText = message;
            break;
      }
  }
  public clearNotifier(){
    this.notifierSuccess.hidden = true;
    this.notifierWarning.hidden = true;
    this.notifierDanger.hidden = true;
  }
}
