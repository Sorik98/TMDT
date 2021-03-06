import { Injectable, OnInit, ElementRef, Directive } from '@angular/core';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Subject } from 'rxjs';
import { User } from '@shared/model/Model';
import { OAuthService } from 'angular-oauth2-oidc';
import * as jwtDecode from "jwt-decode";
import { authConfig, RoleConst, AppConsts } from '@shared/const/AppConst';
import { JwksValidationHandler } from 'angular-oauth2-oidc-jwks';
import { MatSidenav } from '@angular/material/sidenav';
import { HttpClient, HttpResponseBase, HttpResponse, HttpHeaders } from '@angular/common/http';
import { ApiException, CartServiceProxy, CartItemDTO, OrderServiceProxy, OrderDTO } from './service-proxies';
import { ITS_JUST_ANGULAR } from '@angular/core/src/r3_symbols';

@Injectable()
export class UserService {

    // Observable <User> sources
    private user = new User();
    private name = new Subject<string>();
    private login_ = false;
    private cart: CartItemDTO[] = [];
    // Observable stream
    name$ = this.name.asObservable();

    constructor(private oauthService: OAuthService,
                private cartService: CartServiceProxy,
                private orderService: OrderServiceProxy,
                ) {
        this.iniUserWithTokens();
        this.addOAuthServiceEventObservable();
    }
    cartActionFinish = false;
    get Name(){
        return this.user.name;
    }
    get Email(){
        return this.user.email;
    }
    /* #region  public methods */
    get Role(){
        return this.user.role;
    }
    get UserId(){
        return this.user.id;
    }
    get Cart(){
        return this.cart;
    }
    get Address(){
       return this.user.address;
    }
    get Phone(){
        return this.user.phone;
    }
    
    isLogin(){
        return this.login_;
    }

    login() {
        this.oauthService.initCodeFlow();
        // this.cartService.getUserCart(this.UserId).subscribe(res => {
        //     this.cart = res;
        // })
        //this.oauthService.initImplicitFlow();

    }
    addToCart(item: CartItemDTO)
    {
        if(!this.cartActionFinish){
            alert("Thao tác giỏ hàng chưa thực hiện xong!");
            return;
        }
        this.cartActionFinish = false;
        var index = this.cart.findIndex(i => i.product.id == item.product.id);
        if(index == -1)
        this.cart.push(item);
        else
        this.cart[index].quantity += item.quantity;
        this.createCart(this.cart);
    }
    reloadCart(){
        this.cartService.getUserCart(this.UserId).subscribe(res => {
            this.cart = res;
        })
    }
    private initCart(){
        this.cartService.getUserCart(this.UserId).subscribe(res => {
            this.cart = res;
            this.cartActionFinish = true;
        })
    }
    private createCart(cart: CartItemDTO[]){
        var j = 0;
        for(var i=0;i<cart.length;i++)
        {
        if(cart[i].id)
        {
        this.cartService.update(cart[i]).subscribe(res => {
            if(res.result.type == 200)
            {
                console.log("success "+res.result.message);
            }
            else console.log("Error: " + res.result.message)
            if(++j == cart.length)this.initCart();
        })
        }
        else
        {
        this.cartService.create(cart[i]).subscribe(res => {
            if(res.result.type == 200)
            {
               console.log("success "+res.result.message);
             }
           else console.log("Error: " + res.result.message)
           if(++j == cart.length)this.initCart();
        })
        }
    
        }
    }
    deleteCart(ids: number[]){
       return this.cartService.deleteRange(ids);
    }
    deleteItem(id: number){
        return this.cartService.delete(id);
     }
    logout() {
        this.oauthService.logOut();
    }

    hasAdminAccessPermission(){
        return this.user.role != RoleConst.customer;
    }

    createOrder(order: OrderDTO){
       return  this.orderService.create(order);
    }
    /* #endregion */


    /* #region  private methods */


    private tokensIsValid() {
        return (this.oauthService.hasValidIdToken() && this.oauthService.hasValidAccessToken());
    }
    private iniUserWithTokens() {
        if (!this.tokensIsValid())
        return;
            
        let tokenDecode: any;
        tokenDecode = jwtDecode(this.oauthService.getIdToken())
        this.user.name = tokenDecode.name;
        this.user.email = tokenDecode.email;
        this.user.emailVerified = tokenDecode.email_verified;
        this.user.phone = tokenDecode.phone_number;
        this.user.phoneVerified = tokenDecode.phone_number_verified;
        this.user.id = tokenDecode.sub;
        this.user.address = tokenDecode.address;
        tokenDecode = jwtDecode(this.oauthService.getAccessToken())
        this.user.role = tokenDecode.role;
        //set observable stream
        this.name.next(this.user.name);

        this.login_ = true;
        this.initCart();
    }

    private addOAuthServiceEventObservable() {
        this.oauthService.events.subscribe(event => {
            switch (event.type) {
                case "token_received":
                    this.iniUserWithTokens();
                    break;
                case "token_expires":
                    this.logout();
                    break;
                default:
                    console.warn(event);
            }
        });
    }
    /* #endregion */
}
@Injectable()
export class OAuthConfigService{

    constructor(private oauthService: OAuthService)
    {
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    //this.oauthService.loadDiscoveryDocumentAndTryLogin();
    // 0. LOAD CONFIG:
    // First we have to check to see how the IdServer is
    // currently configured:
    this.oauthService.loadDiscoveryDocument().then(() => this.oauthService.tryLoginCodeFlow());
    /* #region  old oath config */

    //this.oauthService.setupAutomaticSilentRefresh();
    // // URL of the SPA to redirect the user to after login
    // this.oauthService.redirectUri = window.location.origin + "/index.html";

    // // The SPA's id. The SPA is registerd with this id at the auth-server
    // this.oauthService.clientId = "spa";
    // // set the scope for the permissions the client should request
    // // The first three are defined by OIDC. The 4th is a usecase-specific one
    // this.oauthService.scope = "openid profile email";

    // // set to true, to receive also an id_token via OpenId Connect (OIDC) in addition to the
    // // OAuth2-based access_token
    // this.oauthService.oidc = true; // ID_Token

    // // Use setStorage to use sessionStorage or another implementation of the TS-type Storage
    // // instead of localStorage
    // this.oauthService.setStorage(sessionStorage);

    // // Discovery Document of your AuthServer as defined by OIDC
    // let url = 'https://localhost:5001/.well-known/openid-configuration';

    // // Load Discovery Document and then try to login the user
    // this.oauthService.loadDiscoveryDocument(url).then(() => {

    //   // This method just tries to parse the token(s) within the url when
    //   // the auth-server redirects the user back to the web-app
    //   // It dosn't send the user the the login page
    //   this.oauthService.tryLogin({});
    //});
    /* #endregion */
    }
}

@Injectable()
export class SidenavService {
    private sidenav: MatSidenav;

    public setSidenav(sidenav: MatSidenav) {
        this.sidenav = sidenav;
    }

    public open() {
        return this.sidenav.open();
    }


    public close() {
        return this.sidenav.close();
    }

    public toggle(): void {
    this.sidenav.toggle();
   }
   public get opened(){
       return this.sidenav.opened;
   }
}


@Injectable()
export class FileService {

    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;
    constructor(private http: HttpClient) {
       
    }

    upLoadImagesToServer(images: FileList){
        let url_ = AppConsts.remoteServiceBaseUrl + "/api/File/OnUploadImage";
        var formData = new FormData();
        
        for(var i=0;i<images.length;i++)formData.append('file', images[i]);
        let options_ : any = {
            observe: "response",
            responseType: "blob",
        };
        return this.http.post(url_, formData,options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processOnUploadImage(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processOnUploadImage(<any>response_);
                } catch (e) {
                    return <Observable<{ [key: string]: any; }>><any>_observableThrow(e);
                }
            } else
                return <Observable<{ [key: string]: any; }>><any>_observableThrow(response_);
        }));
    }

    protected processOnUploadImage(response: HttpResponseBase): Observable<{ [key: string]: any; }> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (resultData200) {
                result200 = {} as any;
                for (let key in resultData200) {
                    if (resultData200.hasOwnProperty(key))
                        result200![key] = resultData200[key];
                }
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<{ [key: string]: any; }>(<any>null);
    }
    deleteImages(body: string[] | null | undefined): Observable<{ [key: string]: any; }> {
        let url_ = AppConsts.remoteServiceBaseUrl + "/api/File/DeleteImages";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "text/plain"
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processDeleteImages(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDeleteImages(<any>response_);
                } catch (e) {
                    return <Observable<{ [key: string]: any; }>><any>_observableThrow(e);
                }
            } else
                return <Observable<{ [key: string]: any; }>><any>_observableThrow(response_);
        }));
    }

    protected processDeleteImages(response: HttpResponseBase): Observable<{ [key: string]: any; }> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (resultData200) {
                result200 = {} as any;
                for (let key in resultData200) {
                    if (resultData200.hasOwnProperty(key))
                        result200![key] = resultData200[key];
                }
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<{ [key: string]: any; }>(<any>null);
    }
      
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new ApiException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((<any>event.target).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}
