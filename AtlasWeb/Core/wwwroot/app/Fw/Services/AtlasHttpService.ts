import {Injectable} from '@angular/core';
import {Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers} from '@angular/http';
import {Observable} from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class AtlasHttpService extends Http {

  constructor (backend: XHRBackend, options: RequestOptions) {
    let token = sessionStorage.getItem('token'); // your custom token getter function here
    if ( token ) {
    options.headers.set('Authorization', `Bearer ${token}`);
    }
    super(backend, options);
  }

  request(url: string|Request, options?: RequestOptionsArgs): Observable<Response> {
    let token = sessionStorage.getItem('token');
    if (typeof url === 'string') { // meaning we have to add the token to the options, not in url
      if (!options) {
        // let's make option object
        options = {headers: new Headers()};
      }
      options.headers.set('Authorization', `Bearer ${token}`);
    } else {
    // we have to add the token to the url object
      url.headers.set('Authorization', `Bearer ${token}`);
    }
    return super.request(url, options).pipe(catchError(this.catchAuthError(this)));
  }

  private catchAuthError (self: AtlasHttpService) {
    // we have to pass HttpService's own instance here as `self`
    return (res: Response) => {
      console.log(res);
      if (res.status === 401 || res.status === 403) {
        // if not authenticated
        console.log(res);
      }
      return Observable.throw(res);
    };
  }
}