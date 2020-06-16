import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { SidenavService } from '@shared/service-proxies/services';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  templateUrl: './admin.component.html',
})
export class AdminComponent implements OnInit,AfterViewInit {

  constructor(private sidenavService: SidenavService
    ) { }
  @ViewChild('sidenav') private sidenav: MatSidenav;
  
  ngOnInit(): void {
  }
  ngAfterViewInit(){
    this.sidenavService.setSidenav(this.sidenav);
  }
  toggleSidenav() {
    this.sidenav.toggle();
 }
}
