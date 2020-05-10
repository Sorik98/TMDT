import { PaymentDetailServiceProxy,PAYMENT_DETAIL_ENTITY } from '../shared/service-proxy';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private paymentDetailService: PaymentDetailServiceProxy) { }
  
  inputModel: PAYMENT_DETAIL_ENTITY;
  paymentDetails: PAYMENT_DETAIL_ENTITY[];

  @ViewChild("form") form: NgForm;
  ngOnInit() {
    this.resetForm();
    this.refreshList();
    console.log(this);
  }
  
  resetForm() {
    if (this.form != null)
      this.form.form.reset();
    this.inputModel = {
      PM_ID: 0,
      CARD_OWNER_NAME: '',
      CARD_NUMBER: '',
      EXPIRATION_DATE: '',
      CVV: ''
    }
  }  
  
  saveInput() {
    this.paymentDetailService.postPaymentDetail(this.inputModel).subscribe(
      res => {
        this.resetForm();
        this.refreshList();
      },
      err => { console.log(err); }
    )
  }
  refreshList(){
    this.paymentDetailService.getPaymentDetails().then(res => {
      this.paymentDetails = res;
    })
  }
}
