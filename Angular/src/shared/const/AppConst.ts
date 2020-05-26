import { AuthConfig } from 'angular-oauth2-oidc';

export class AppConsts {
    static remoteServiceBaseUrl = "http://localhost:5000"; 
    static identityServerUrl = "http://localhost:5001";
    static baseUrl = "http://localhost:4200";
  }

 export const authConfig: AuthConfig = {
    issuer: AppConsts.identityServerUrl,
    redirectUri: AppConsts.baseUrl + "/home",
    postLogoutRedirectUri: AppConsts.baseUrl + "/home",
    clientId: "spa",
    scope: 'openid profile email address phone coreapi',
    showDebugInformation: true,
    responseType: 'code',

  }
  export class RoleConst{
    static admin = "Admin";
    static manager = "Manager";
    static customer = "Customer";
  }