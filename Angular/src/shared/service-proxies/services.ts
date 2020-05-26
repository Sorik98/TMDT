import { Injectable, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { User } from '@shared/model/User';
import { OAuthService } from 'angular-oauth2-oidc';
import * as jwtDecode from "jwt-decode";
import { authConfig, RoleConst } from '@shared/const/AppConst';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
@Injectable()
export class UserService {

    // Observable <User> sources
    private user = new User();
    private name = new Subject<string>();
    private login_ = false;
    // Observable stream
    name$ = this.name.asObservable();

    constructor(private oauthService: OAuthService) {
        this.iniUserWithTokens();
        this.addOAuthServiceEventObservable();
    }

    get Name(){
        return this.user.name;
    }
    /* #region  public methods */
    
    isLogin(){
        return this.login_;
    }

    login() {
        this.oauthService.initCodeFlow();
        //this.oauthService.initImplicitFlow();
    }

    logout() {
        this.oauthService.logOut();
    }

    hasAdminAccessPermission(){
        return this.user.role != RoleConst.customer;
    }
    /* #endregion */


    /* #region  private methods */


    private tokensIsValid() {
        return (this.oauthService.hasValidIdToken() && this.oauthService.hasValidAccessToken());
    }
    private iniUserWithTokens() {
        if (!this.tokensIsValid()) return;
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
        //set observable stream
        this.name.next(this.user.name);

        this.login_ = true;
    }

    private addOAuthServiceEventObservable() {
        this.oauthService.events.subscribe(event => {
            switch (event.type) {
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
    /* #endregion */
}
@Injectable()
export class OAuthConfigService{

    constructor(private oauthService: OAuthService)
    {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    //this.oauthService.loadDiscoveryDocumentAndTryLogin();
    // 0. LOAD CONFIG:
    // First we have to check to see how the IdServer is
    // currently configured:
    this.oauthService.loadDiscoveryDocument().then(() => this.oauthService.tryLoginCodeFlow());
    /* #region  old oath config */

    //this.oauthService.setupAutomaticSilentRefresh();
    // // URL of the SPA to redirect the user to after login
    // this.oauthService.redirectUri = window.location.origin + "/index.html";

    // // The SPA's id. The SPA is registerd with this id at the auth-server
    // this.oauthService.clientId = "spa";
    // // set the scope for the permissions the client should request
    // // The first three are defined by OIDC. The 4th is a usecase-specific one
    // this.oauthService.scope = "openid profile email";

    // // set to true, to receive also an id_token via OpenId Connect (OIDC) in addition to the
    // // OAuth2-based access_token
    // this.oauthService.oidc = true; // ID_Token

    // // Use setStorage to use sessionStorage or another implementation of the TS-type Storage
    // // instead of localStorage
    // this.oauthService.setStorage(sessionStorage);

    // // Discovery Document of your AuthServer as defined by OIDC
    // let url = 'https://localhost:5001/.well-known/openid-configuration';

    // // Load Discovery Document and then try to login the user
    // this.oauthService.loadDiscoveryDocument(url).then(() => {

    //   // This method just tries to parse the token(s) within the url when
    //   // the auth-server redirects the user back to the web-app
    //   // It dosn't send the user the the login page
    //   this.oauthService.tryLogin({});
    //});
    /* #endregion */
    }
}