
import { Component, OnInit, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { UserService, SidenavService } from '@shared/service-proxies/services';

@Component({
    selector: 'side-nav',
    templateUrl: 'side-nav.component.html',
  })
export class SideNavigationComponent implements OnInit,AfterViewInit {
  constructor(private userService: UserService,
              private sidenav: SidenavService 
    ){}
   readonly pages = {
      product: {
          productList: 0,
          productDetail: 1
      }
  }
  currentPage= this.pages.product.productList;
  ngOnInit(){
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

