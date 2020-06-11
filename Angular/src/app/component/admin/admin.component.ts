import { Component, OnInit, AfterViewInit, ViewChild, ElementRef } from '@angular/core';
import { SidenavService, NotifierService } from '@shared/service-proxies/services';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  templateUrl: './admin.component.html',
})
export class AdminComponent implements OnInit,AfterViewInit {

  constructor(private sidenavService: SidenavService,
              private notifierService: NotifierService
    ) { }
  @ViewChild('sidenav') private sidenav: MatSidenav;
  @ViewChild('notifierSuccess') private notifierSuccess: ElementRef;
  @ViewChild('notifierWarning') private notifierWarning: ElementRef;
  @ViewChild('notifierDanger') private notifierDanger: ElementRef;
  ngOnInit(): void {
  }
  ngAfterViewInit(){
    this.sidenavService.setSidenav(this.sidenav);
    this.notifierService.setNotifier(this.notifierSuccess,this.notifierWarning,this.notifierDanger)
  }
  toggleSidenav() {
    this.sidenav.toggle();
 }
}
