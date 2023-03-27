import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class MessengerService {
	API_URL: any = 'api';
	API_ENDPOINT: any = '/messenger';

	constructor(private http: HttpClient) {}

	public getData(): Observable<any> {
		return this.http
			.get(this.API_URL + this.API_ENDPOINT);
	}
}
