import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DataTableItemModel } from '../models/datatable-item.model';


const API_DATATABLE_URL = 'api/cars';

@Injectable()
export class DataTableService {

	constructor(private http: HttpClient) {
	}

	getAllItems(): Observable<DataTableItemModel[]> {
		return this.http.get<DataTableItemModel[]>(API_DATATABLE_URL);
	}
}
