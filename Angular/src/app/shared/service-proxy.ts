//import { PaymentDetail } from './payment-detail.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PaymentDetailServiceProxy {
  readonly rootURL = 'http://localhost:5000/api';
  

  constructor(private http: HttpClient) { }

  postPaymentDetail(input: PAYMENT_DETAIL_ENTITY) {
    return this.http.post(this.rootURL + '/PaymentDetail', input);
  }
  putPaymentDetail(input: PAYMENT_DETAIL_ENTITY) {
    return this.http.put(this.rootURL + '/PaymentDetail/'+ input.PM_ID, input);
  }
  deletePaymentDetail(id: number) {
    return this.http.delete(this.rootURL + '/PaymentDetail/'+ id);
  }
  async getPaymentDetails(): Promise<PAYMENT_DETAIL_ENTITY[]>{
    var result: PAYMENT_DETAIL_ENTITY[];
    await this.http.get(this.rootURL + '/PaymentDetail')
    .toPromise()
    .then(res => {
      result = res as PAYMENT_DETAIL_ENTITY[];
    });
    return result;
  }
  
}

export class PAYMENT_DETAIL_ENTITY {
  PM_ID :number;
  CARD_OWNER_NAME: string;
  CARD_NUMBER: string;
  EXPIRATION_DATE: string;
  CVV: string;
}
