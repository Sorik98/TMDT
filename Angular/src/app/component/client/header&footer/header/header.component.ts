import { Component, OnInit } from '@angular/core';
import { UserService } from '@shared/service-proxies/services';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  constructor(private userService: UserService) { }
  user:any = {};

 // userClaim: any;
 name:string = "sdsd";
  ngOnInit(): void {
  }
  login() {
    this.userService.login();
     //this.oauthService.initImplicitFlow();
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
}
  
