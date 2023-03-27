import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component } from '@angular/core';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { SystemParameterService } from 'NebulaClient/Services/ObjectService/SystemParameterService';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Component({
    selector: 'json-test-component',
    template: `
    <h1>Server Side Message Test</h1>
<dx-button text="Server Side Web.Api Call Json Result" (onClick)="testJsonResult()"></dx-button>

<br/><code>{{JsonResult  | json}}</code>

<dx-button text="Server Side Web.Api Call Dictionary Result" (onClick)="testDictionaryResult()"></dx-button>

<dx-button text="System Parameter Test" (onClick)="testSystemParameter()"></dx-button>

    `
})
export class JsonTestComponent {
    public JsonResult: any;
    public DictionaryResult: any;

    constructor(private http: NeHttpService) {
    }

    public testJsonResult() {
        let that = this;
        let objectID = new Guid('ae1456dd-40d9-4259-b9bf-aaeb74660ee1');
        const url = `/api/Test/LoadInPatient/${objectID.valueOf()}`;
        this.http.post(url, objectID).then((result: NeResult<any>) => {
            if ( result.IsSuccess ) {
                that.JsonResult = result.Result;
            }
            console.log(result);
        });
    }

    public testDictionaryResult() {
        let that = this;
        const url = `/api/Test/GetDictionary`;
        this.http.get(url).then((neResult: NeResult<any>) => {
            if ( neResult.IsSuccess ) {
                that.DictionaryResult = neResult.Result;
                console.log(neResult.Result);
                let keys = Object.keys(neResult.Result);
                console.log(keys);
                for (let itemKey of keys) {
                    let itemValue = neResult.Result[itemKey];
                    console.log(`${itemKey} - ${itemValue}`);
                }
            }
        });
    }

    public testSystemParameter() {
        SystemParameterService.GetParameterValue('MERNISUSERNAME', '').then(r => {
            console.log(r);
        }).catch(err => {
            console.log(err);
        });
    }
}
