import { Injector, ViewChild, ElementRef, OnInit, AfterViewInit } from '@angular/core';
import { UserService } from '@shared/service-proxies/services';


import { RoleConst, ProductType, AuthStatus } from '@shared/const/AppConst';
import { Router, NavigationExtras, ActivatedRoute } from '@angular/router';
import { CustomNotifier } from '@shared/component/notifier/notifier.component';
import { kMaxLength } from 'buffer';
import { PromiseType } from 'protractor/built/plugins';



export abstract class ClientComponentBase{
  protected  userService: UserService;

  protected router: Router;
  protected activedRoute: ActivatedRoute;
  constructor(injector: Injector){
                this.userService = injector.get(UserService);
                this.router = injector.get(Router);
                this.activedRoute = injector.get(ActivatedRoute);

                
  }
  itemsPerPage = [5,10,15];
  toolTip = {
      position: "after",
      showDelay: 2700,
      hideDelay: 300
  };
  saving = false;
  AuthStatus = AuthStatus;
  get userName() {
      return this.userService.Name;
  }
  get userEmail() {
    return this.userService.Email;
  }
  get userId(){
    return this.userService.UserId;
  }
  isManager(){
    return this.userService.Role != RoleConst.customer;
  }
  @ViewChild(CustomNotifier) notifier: CustomNotifier;


 
  alert(type: string,message: string){
    this.notifier.alert(type,message);
  }
  
  objectToString(obj: Object,separator: string, callback: (key:string,value:any)=>string){
    var str = []
    for(var p in obj)
    {
      str.push(callback(p,obj[p]));
    }
    return str.join(separator);
  }
  navigatePassParam(url: string, params: any, deepParams: any, skipLocationChange: boolean = true) {
    var array = [url];
    if (params) {
        array.push(params);
        url += ';' + this.objectToString(params,"&&",(k,v)=> k+"="+v.toString());
    }
    this.router.navigate(array, { queryParams: deepParams, skipLocationChange: skipLocationChange });
    window.history.pushState('', '', url);
  }
  getRouteData(key: string): any {
    return (this.activedRoute.data as any).value[key];
  } 
  getRouteParam(key: string): any {
    return (this.activedRoute.params as any).value[key];
  }
 
   reloadPage(){
    window.location.reload();
   }
    
    
    getObjectKeys(data: any): Array<string> {
      var keys = Object.keys(data);
      
      return keys;
     }
     toCamel(o) {
      var newO, origKey, newKey, value
      if (o instanceof Array) {
        return o.map(function(value) {
            if (typeof value === "object") {
              value = this.toCamel(value)
            }
            return value
        })
      } else {
        newO = {}
        for (origKey in o) {
          if (o.hasOwnProperty(origKey)) {
            newKey = (origKey.charAt(0).toLowerCase() + origKey.slice(1) || origKey).toString()
            value = o[origKey]
            if (value instanceof Array || (value !== null && value.constructor === Object)) {
              value = this.toCamel(value)
            }
            newO[newKey] = value
          }
        }
      }
      return newO
    }
}