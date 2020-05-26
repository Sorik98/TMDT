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
  count = 0;
  count2 = 0;
 // userClaim: any;
 name:string = "sdsd";
  ngOnInit(): void {
    console.log(this);
  }
  login() {
    this.userService.login();
     //this.oauthService.initImplicitFlow();
    }

  logout() {
      this.userService.logout();
    }
  get userName(){
    console.log(++this.count);
    return this.userService.Name;
  }
  isLogin(){
    console.log(++this.count2);
    return this.userService.isLogin();
  }
}
  
