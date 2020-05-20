import { Component } from '@angular/core';
import { OAuthService,AuthConfig, NullValidationHandler} from 'angular-oauth2-oidc';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { AppConsts } from '@shared/const/AppConst';

const authConfig: AuthConfig = {
  issuer: AppConsts.identityServerUrl,
  redirectUri: AppConsts.baseUrl,
  postLogoutRedirectUri: AppConsts.baseUrl,
  clientId: "spa",
  scope: 'openid profile email address phone coreapi',
  showDebugInformation: true,
  responseType: 'code',
  
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})

export class AppComponent {
  title = 'Angular';
  
  constructor(private oauthService: OAuthService) {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    //this.oauthService.loadDiscoveryDocumentAndTryLogin();
    // 0. LOAD CONFIG:
    // First we have to check to see how the IdServer is
    // currently configured:
    this.oauthService.loadDiscoveryDocument().then(() => this.oauthService.tryLoginCodeFlow());

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

  }
}
