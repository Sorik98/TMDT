import { Component, OnInit, Injector } from '@angular/core';
import { UserService } from '@shared/service-proxies/services';
import { ClientComponentBase } from '../client-component-base';
import { UserServiceProxy, ApplicationUser, LoginUser } from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './setting.component.html',
  styles: []
})
export class SettingComponent extends ClientComponentBase implements OnInit {

  constructor(
    injector: Injector,
    private appUserService: UserServiceProxy
  ) { 
      super(injector);
  }
  inputModel: LoginUser = new LoginUser();
  changePasswordPress = false;
  ngOnInit(): void {
    this.inputModel.name = this.userName;
    this.inputModel.email = this.userEmail;
    this.inputModel.address = this.userService.Address;
    this.inputModel.phoneNumber = this.userService.Phone;
    this.inputModel.role = this.userService.Role;

  }
  validateInput(){
      if(this.changePasswordPress)
      {
          if(this.inputModel.name == "" || this.inputModel.address == "" || this.inputModel.phoneNumber == "")
          {
              this.alert("warning","Input không hợp lệ");
              return false;
          }
      }
      else{
          if(this.inputModel.password == "")
          {
            this.alert("warning","Input không hợp lệ");
            return false
          }
      }
  }
  onSave(){
      this.appUserService.edit(this.userId,this.inputModel).subscribe(res => {
          console.log(res);
         this.userService.login();
      })
  }
  changePassWord(){
     this.ngOnInit();
     this.appUserService.edit(this.userId,this.inputModel).subscribe(res => {
        console.log(res);
       this.userService.login();
    })
  }
}
