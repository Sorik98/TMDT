import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UserService } from '@shared/service-proxies/services';
import { RoleConst, AppConsts } from '@shared/const/AppConst';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LoginUser, UserServiceProxy } from '@shared/service-proxies/service-proxies';
import { Validators } from '@angular/forms';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  constructor(private userService: UserService,
              private modalService: NgbModal,
              private appUserService: UserServiceProxy) { }
  user:any = {};
  logoUrl = AppConsts.remoteServiceBaseUrl + "/Other/" + "logo.png";
 // userClaim: any;
  
  inputModel: LoginUser = new LoginUser();
  saveBtnDisable = false;
  ngOnInit(): void {
    console.log(this);
  }
  login() {
    this.userService.login();
     //this.oauthService.initImplicitFlow();
    }
  isManager(){
    return this.userService.Role != RoleConst.customer;
    }
  logout() {
      this.userService.logout();
    }
  get userName(){
  
    return this.userService.Name;
  }
  isLogin(){
  
    return this.userService.isLogin();
  }
  cartItemsNum(){
    return this.userService.Cart.length == 0? null : this.userService.Cart.length;
  }
  open(content: any)
  {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }
  inputIsValid(){
    if(this.inputModel.name.length < 3)
    {
    alert("Tên user không được dưới 3 ký tự");
    return false;
    }
    else if(!this.inputModel.email.includes("@") || this.inputModel.email.length <3)
   { alert("Email không hợp lệ");return false;}
    else if (this.inputModel.phoneNumber.length == 0)
    {alert("SĐT không hợp lệ"); return false;}
    else if (this.inputModel.address.length == 0)
   { alert("Địa chỉ không hợp lệ"); return false}
    else if (this.inputModel.password.length == 0)
    {alert("Password không hợp lệ"); return false;}
    return true;
  }
  signUp(){
    if(!this.inputIsValid()) return;
    this.saveBtnDisable = true;
    this.appUserService.create(this.inputModel).pipe(finalize(()=>{ this.saveBtnDisable = false;})).subscribe(res =>{
      console.log(res);
    })
    alert("Tạo user thành công")
  }
}
  
