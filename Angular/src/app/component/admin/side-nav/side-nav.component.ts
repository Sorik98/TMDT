
import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { UserService, SidenavService } from '@shared/service-proxies/services';
import { ActivatedRoute } from '@angular/router';

export enum pages  {
    
  productList,
  productDetail,
  producerList,

}

@Component({
    selector: 'side-nav',
    templateUrl: 'side-nav.component.html',
  })
export class SideNavigationComponent implements OnInit,AfterViewInit {
  constructor(private userService: UserService,
              private sidenav: SidenavService,
              private activedRoute: ActivatedRoute
    ){}
   
  pages = pages;
  currentPage= pages.productList;
  ngOnInit(){
    console.log(this);
  }
  ngAfterViewInit(){
  }
  isCurrentPage(page: number)
  {
    return this.currentPage == page;
  }
  onToggleBtnValueChange(value: number)
  {
      this.currentPage = value;
  }
  logout(){
      this.userService.logout();
  }
  toggleSidenav() {
    this.sidenav.toggle();
 }
 get userName() {
      return this.userService.Name;
  }
}

