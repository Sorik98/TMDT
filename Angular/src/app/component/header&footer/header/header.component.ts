import { Component, OnInit } from '@angular/core';
import { OAuthService, OAuthErrorEvent, OAuthEvent, EventType} from 'angular-oauth2-oidc';
import  * as jwtDecode  from "jwt-decode";
import { HttpEventType } from '@angular/common/http';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  constructor(private oauthService: OAuthService) { }
  
  user: any = {};
 // userClaim: any;
  ngOnInit(): void {
    console.log(this);
    this.iniUserWithTokens();
    this.oauthService.events.subscribe(event => {
      var ev: EventType = "token_received";
      if (event.type == ev) {
        this.iniUserWithTokens();
      } else {
        console.warn(event);
      }
    });
  }
  login() {
    this.oauthService.initCodeFlow();
     //this.oauthService.initImplicitFlow();
    }

  logout() {
        this.oauthService.logOut();
    }
  tokensIsValid(){
    return (this.oauthService.hasValidIdToken() && this.oauthService.hasValidAccessToken());
  }
  iniUserWithTokens(){
    if(!this.tokensIsValid())return;
    let tokenDecode: any;
    tokenDecode = jwtDecode(this.oauthService.getIdToken())
    this.user.name = tokenDecode.name;
    this.user.email = tokenDecode.email;
    this.user.emailVerified = tokenDecode.email_verified;
    this.user.phone = tokenDecode.phone_number;
    this.user.phoneVerified = tokenDecode.phone_number_verified;
    this.user.id = tokenDecode.sub;
    tokenDecode = jwtDecode(this.oauthService.getAccessToken())
    this.user.role = tokenDecode.role;
  }

  //  Role(){
  //   var token = this.oauthService.getAccessToken();
  //   var decode = jwtDecode(token);
  //   var decode_ = jwtDecode(this.oauthService.getIdToken());
  //   //var role = decode.role;
  // } 
  // get userName() {
  //       let userClaim = this.oauthService.getIdentityClaims();
  //       if (!userClaim) return null;
  //       return userClaim['name'];
  //   }
}
