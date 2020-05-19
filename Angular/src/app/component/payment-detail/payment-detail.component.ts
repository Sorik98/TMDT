import { PaymentDetailServiceProxy,PaymentDetailDTO } from '@shared/service-proxies/service-proxies';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  constructor(private paymentDetailService: PaymentDetailServiceProxy) { }
  
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
      err => { console.log(err); }
    )
  }
  refreshList(){
    this.paymentDetailService.getAll().subscribe(res => {
      this.paymentDetails = res;
    })
  }
}
