import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';

import { OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor {

/**
 * Creates an instance of TokenInterceptor.
 * @param {OAuthService} auth
 * @memberof TokenInterceptor
 */
constructor(public auth: OAuthService) {}

/**
 * Intercept all HTTP request to add JWT token to Headers
 * @param {HttpRequest<any>} request
 * @param {HttpHandler} next
 * @returns {Observable<HttpEvent<any>>}
 * @memberof TokenInterceptor
 */
intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    request = request.clone({
       setHeaders: {
           Authorization: `Bearer ${this.auth.getAccessToken()}`
       }
    });

    return next.handle(request);
  }
}