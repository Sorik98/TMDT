import { CanActivate, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { UserService } from '@shared/service-proxies/services';
@Injectable({
    providedIn: 'root'
})
export class AdminGuard implements CanActivate,CanActivateChild{
    constructor(
                private userService: UserService,
                private router: Router
                ){}
    canActivate( route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot){
            if(!this.userService.isLogin())return false;
            return this.userService.hasAdminAccessPermission();
    }
    canActivateChild( route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot){
            return this.canActivate(route,state);
    }
}