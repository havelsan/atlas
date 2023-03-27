import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Subject, Observable } from 'rxjs';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

@Injectable()
export class AuthenticationService {

    public AuthStatusChanged: Subject<Boolean>;

    constructor(private http: Http) {
        this.AuthStatusChanged = new Subject<Boolean>();
    }

    public Login(userName: string, password: string, captchaguid: Guid): Observable<Response> {
        return this.http.post("api/AuthenticationApi/Login", {
            UserName: userName,
            Password: password
        });
    }

    public Logout(): Observable<Response> {
        return this.http.get("api/AuthenticationApi/Logout");
    }
}