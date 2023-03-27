//$4E3CF7AF
import { Injectable } from '@angular/core';
import { Http, ConnectionBackend, RequestOptions, Response, RequestOptionsArgs, Request, Headers } from '@angular/http';
import { MessageService } from 'Fw/Services/MessageService';
import { Observable } from 'rxjs';
import { ServiceContainer } from './ServiceContainer';
import {catchError} from 'rxjs/operators';


const Error403Message: string  = i18n("M12084", "Bu işlem için yetkiniz yoktur.");
const Error401Message: string = i18n("M15721", "Henüz giriş yapılmamış.");

@Injectable()
export class HvlHttp extends Http {

    constructor(backend: ConnectionBackend,
        defaultOptions: RequestOptions,
        private container: ServiceContainer,
        private messageService: MessageService) {

        super(backend, defaultOptions);
    }

    request(url: string | Request, options?: RequestOptionsArgs): Observable<Response> {
        return this.intercept(super.request(url, options));
    }

    get(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.intercept(super.get(url, options));
    }

    post(url: string, body: any, options?: RequestOptionsArgs): Observable<Response> {
        if (!body) {
            body = {};
        }
        return this.intercept(super.post(url, body, this.getRequestOptionArgs(options)));
    }

    put(url: string, body: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.intercept(super.put(url, body, this.getRequestOptionArgs(options)));
    }

    delete(url: string, options?: RequestOptionsArgs): Observable<Response> {
        return this.intercept(super.delete(url, options));
    }

    getRequestOptionArgs(options?: RequestOptionsArgs): RequestOptionsArgs {
        //ozel request headerlari buraya
        if (options == null) {
            options = new RequestOptions();
        }
        if (options.headers == null) {
            options.headers = new Headers();
        }
        options.headers.append('Content-Type', 'application/json');
        let token = sessionStorage.getItem('token');
        if (token) {
            options.headers.append('Authorization', `Bearer ${token}`);
        }
        return options;
    }

    intercept(observable: Observable<Response>): Observable<Response> {
        let that = this;
        return observable.pipe(catchError((err, source) => {

            if (err.status != 200) {
                this.container.Globals.Busy.next(false);
                if (err.status === 403) {
                    that.messageService.showError(Error403Message);
                    throw Observable.throw(Error403Message);

                } else if (err.status === 401) {
                    that.messageService.showError(Error401Message);
                    throw Observable.throw(Error401Message);
                } else {
                    if (err.json) {
                        let result = err.json();
                        this.container.Notifier.notify(result.Message || "Hata", "error");
                    }
                }
            }
            return new Observable<Response>(() => {

            });
        }));
    }
}