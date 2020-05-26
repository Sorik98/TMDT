import { PaymentDetailServiceProxy,PaymentDetailDTO } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NotifierService } from 'angular-notifier';

@Component({
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private paymentDetailService: PaymentDetailServiceProxy,
              private notifierService: NotifierService) { }
  
  inputModel: PaymentDetailDTO;
  paymentDetails: PaymentDetailDTO[];

  @ViewChild("form") form: NgForm;
  ngOnInit() {
    this.resetForm();
    this.refreshList();
    console.log(this);
  }
  
  resetForm() {
    if (this.form != null)
      this.form.form.reset();
      this.initPaymentDetailDTO();
  }  
  initPaymentDetailDTO()
  {
    this.inputModel = new PaymentDetailDTO;
    this.inputModel.paymentId = 0;
    this.inputModel.cardNumber = '';
    this.inputModel.cardOwnerName = '';
    this.inputModel.expirationDate = '';
    this.inputModel.paymentId = 0;
  }
  
  saveInput() {
    this.paymentDetailService.create(this.inputModel).subscribe(
      res => {
        this.resetForm();
        this.refreshList();
      },
      err => { 
        this.notifierService.notify(
          "error",
          "Error: An unexpected server error occurred",
          "error_message"
      );
        setTimeout(()=>{
          this.notifierService.hide("error_message");
        },10000)
      }
    )
  }
  refreshList(){
    this.paymentDetailService.getAll().subscribe(res => {
     // console.log(res);
      this.paymentDetails = res;
    })
  }
}
