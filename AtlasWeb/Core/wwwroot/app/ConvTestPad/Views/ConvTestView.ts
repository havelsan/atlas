import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { SystemApiService } from 'Fw/Services/SystemApiService';

@Component({
    selector: 'ConvTestPad',
    inputs: ['Model'],
    templateUrl: './ConvTestView.html',
    providers: [SystemApiService]
})
export class ConvTestView  {
    constructor(public systemApiService: SystemApiService,
        private http: Http) {
    }
}