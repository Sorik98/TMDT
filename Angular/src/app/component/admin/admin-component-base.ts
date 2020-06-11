import { Injector, ViewChild, ElementRef } from '@angular/core';
import { UserService, NotifierService } from '@shared/service-proxies/services';


import { RoleConst } from '@shared/const/AppConst';
import { Router, NavigationExtras, ActivatedRoute } from '@angular/router';



export abstract class AdminComponentBase {
  protected  userService: UserService;
  protected  notifierService: NotifierService;
  protected router: Router;
  protected activedRoute: ActivatedRoute;
  
  constructor(injector: Injector){
                this.userService = injector.get(UserService);
                this.notifierService = injector.get(NotifierService);
                this.router = injector.get(Router);
                this.activedRoute = injector.get(ActivatedRoute);
                console.log(this);
  }
  itemsPerPage = [5,10,15];
  toolTip = {
      position: "after",
      showDelay: 2700,
      hideDelay: 300
  };
  

  get userName() {
      return this.userService.Name;
  }

  isAdmin()
  {
    return this.userService.Role == RoleConst.admin;
  }
  alert(type: string,message: string){
    this.notifierService.alert(type,message);
  }
  navigatePassParam(url: string,  deepParams: any) {
    var urlArray = [url]
      let navigationExtras: NavigationExtras = {
          queryParams: deepParams,
          skipLocationChange: true
      }
      this.router.navigate(urlArray, navigationExtras);
      window.history.pushState('', '', url);
  }
  getRouteData(key: string): any {
    return (this.activedRoute.data as any).value[key];
  } 
    onGetFilter(filterInput) {

    }

    getFilterInputInRoute(getFilterInput): any {
        this.activedRoute.queryParams.subscribe(response => {
            var str = response['filterInput'];
            if (getFilterInput) {
                getFilterInput(str);
            }
        })
    }

    initFilter() {
        this.getFilterInputInRoute((filterJson) => {
            if (filterJson) {
                (this as any).filterInput = JSON.parse(filterJson);
                this.onGetFilter((this as any).filterInput);
            }
        });
    }
}