import { AuthConfig } from 'angular-oauth2-oidc';
import { InjectionToken } from '@angular/core';

export enum AppConsts {
     remoteServiceBaseUrl = "http://localhost:5000",
     identityServerUrl = "http://localhost:5001",
     baseUrl = "http://localhost:4200",
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
  export enum RoleConst{
     admin = "Admin",
     manager = "Manager",
     customer = "Customer",
  }

  export enum EditPageState{
    add = "Add",
    edit = "Edit",
    viewDetail = "ViewDetail",
}
export enum AuthStatus{
  Submitted = "Submitted",
  Approved = "Approved",
  Rejected = "Rejected",
}

export enum ProductType{
  Laptop = "Laptop",
  Keyboard = "Keyboard",
  Mouse = "Mouse",
  Others = "Others"
}
export enum ServerFolder{
    Image = "Image",
}