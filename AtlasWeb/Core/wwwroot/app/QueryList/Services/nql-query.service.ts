import { Injectable } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { QueryParams } from '../Models/QueryParams';
import { GridQueryResult } from '../Models/GridQueryResult';

@Injectable()
export class NqlQueryService {

    private GetQueryResultUri = '/api/List/GetQueryResult';

    constructor(private http: NeHttpService) {
    }

    runNQL(queryParams: QueryParams): Promise<GridQueryResult> {

        let input = {
            QueryName: queryParams.QueryName
            , ObjectDefID: queryParams.ObjectDefID
            , QueryDefID: queryParams.QueryDefID
            , Parameters: queryParams.Parameters
        };

        return new Promise<GridQueryResult>((resolve, reject) => {
            this.http.post(this.GetQueryResultUri, input).then(result => {
                let gridQueryResult = result as GridQueryResult;
                resolve(gridQueryResult);
            }).catch(error => {
                reject(error);
            });

        });

    }
}

