import { Component, OnInit } from '@angular/core';
import { UserService, OAuthConfigService } from '@shared/service-proxies/services';


@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
  styleUrls: []
})

export class AppComponent implements OnInit {
  title = 'Angular';
  constructor(
              private oauthConfigService: OAuthConfigService,
              private userService: UserService,
              ) { }
  ngOnInit() {
  }
  
}
