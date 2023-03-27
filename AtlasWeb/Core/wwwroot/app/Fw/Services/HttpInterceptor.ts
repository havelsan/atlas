import { Injectable } from '@angular/core';
import { Request, XHRBackend, XHRConnection } from '@angular/http';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'app/environments/environment';


@Injectable()
export class ApiXHRBackend extends XHRBackend {
    createConnection(request: Request): XHRConnection {
        //Check if is development
        if (environment.target == 'dev') {
            //Check if is relative url
            if (!request.url.startsWith('http')) {
                request.url = environment.apiRoot + (request.url.startsWith('/') ? '' : '/') + request.url; // prefix base url
            }
        }
        return super.createConnection(request);
    }
}

@Injectable()
export class AtlasHttpInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        //Check if is development
        if (environment.target == 'dev') {
            //Check if is relative url
            if (!req.url.startsWith('http')) {
                const url = environment.apiRoot;
                req = req.clone({
                    url: url + (req.url.startsWith('/') ? '' : '/') + req.url
                });
            }
        }
        return next.handle(req);
    }
}