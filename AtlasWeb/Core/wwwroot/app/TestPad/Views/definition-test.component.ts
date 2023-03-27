import { Component } from '@angular/core';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from "Fw/Services/SystemApiService";
import { AtlasHttpService } from "Fw/Services/AtlasHttpService";
import { Headers, RequestOptions } from "@angular/http";

@Component({
    selector: 'definition-component-test-comp',
    template: `<h2>Definition Test Component</h2>

    <button (click)='testListDefinitioni18n()'>Test List Definition i18n</button>

    <hvl-listdef-combobox [DefinitionName]="listDefName"></hvl-listdef-combobox>

    <button (click)='testDefinitionForm()'>Test Definition Form</button>
    <button (click)='testDefinitionWithServerInfo()'>Test Definition Form From Server Dynamic Component Info</button>

<div>
<comp-compose #dynComp [Info]="componentInfo" (ComponentCreated)="onComponentCreated($event)" ></comp-compose>
</div>

<div>
<atlas-definition-form ObjectDefName='MainStoreDefinition' FormDefId='5a0e4bd0-ba57-4f61-ac61-6195e77bd885'></atlas-definition-form>
</div>

 `,
    providers: [SystemApiService]
})
export class DefinitionTestComponent {
    public componentInfo: DynamicComponentInfo;

    public listDefName: string = 'PoliclinicClinicList';

    constructor(
        private http2: AtlasHttpService,
        private http: NeHttpService,
        private messageService: MessageService,
        private systemApi: SystemApiService) {

        sessionStorage.setItem('localeId', 'en');
    }

    public getDefinitionObjectList(formDefID: string): Promise<any> {
        let url = `/api/ObjectDef/GetDefinitionObjectList?formDefID=${formDefID}`;
        return this.http.get<any>(url);
    }

    public testDefinitionForm(): void {

        const that = this;
        let compInfo = new DynamicComponentInfo();
        compInfo.ComponentName = 'MainStoreDefinitionForm';
        compInfo.ModuleName = 'AnaDepoSaymanlikTanimlamaModule';
        compInfo.ModulePath = '/Modules/Saglik_Lojistik/Stok_Modulleri/Ana_Depo_Saymanlik_Tanimlama_Modulu/AnaDepoSaymanlikTanimlamaModule';

        this.componentInfo = compInfo;
    }

    public onComponentCreated(e: any): void {
        console.log(e);
    }

    public testDefinitionWithServerInfo(): void {
        const that = this;
        const objectDefName = 'MainStoreDefinition';
        const formDefId = "5a0e4bd0-ba57-4f61-ac61-6195e77bd885";
        this.systemApi.new(objectDefName, null, formDefId, null).then(res => {
            console.log(res);
            that.componentInfo = res;
        });

        this.getDefinitionObjectList(formDefId).then(res => {
            console.log(res);
        });
    }

    public testListDefinitioni18n(): void {
        const url = "api/DefinitionQuery/GetDefinitionsAll?listDefName=PoliclinicClinicList";

        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let token = sessionStorage.getItem('token');
        if (token) {
            headers.set('Authorization', `Bearer ${token}`);
        }
        const currentLocaleId = "en";
        if (currentLocaleId) {
            headers.append('Access-Control-Allow-Headers', 'CurrentCulture');
            headers.append('CurrentCulture', currentLocaleId);
        }

        const options = new RequestOptions();
        options.headers = headers;

        this.http2.get(url, options).toPromise().then(result => {
            console.log(result);
        });
    }
}
