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
    this.addOAuthServiceEventObservable();
  }
  login() {
    this.oauthService.initCodeFlow();
     //this.oauthService.initImplicitFlow();
    }

  logout() {
        this.oauthService.logOut();
    }
  private tokensIsValid(){
    return (this.oauthService.hasValidIdToken() && this.oauthService.hasValidAccessToken());
  }
  private iniUserWithTokens(){
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
  private addOAuthServiceEventObservable()
  {
    this.oauthService.events.subscribe(event => {
      switch(event.type)
      {
        case "token_received":
          this.iniUserWithTokens();
          break;
        case "token_expires":
          this.logout();
          break;
        default:
          console.warn(event);
      }
    });
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
