import { Component, OnInit, OnDestroy } from '@angular/core';
import { IActivePatientService } from 'Fw/Services/IActivePatientService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Subscription } from 'rxjs';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Component({
    selector: 'serialize-test-component',
    template: `
<h2>Object Serialization</h2>

<div class="row">
    <div class="col-lg-3"><h4>Aktif Hastayı Sunucuya Http Headers ile gönder</h4></div>
    <div class="col-lg-3"><dx-button text="Send Active Patient With Http Headers" (onClick)="sendActivePatientWithHttpHeaders()"></dx-button></div>
</div>

<div class="row">
    <div class="col-lg-3"><h4>Aktif Hastayı Değiştir</h4></div>
    <div class="col-lg-3"><dx-button text="Set Active Patient" (onClick)="setActivePatient()"></dx-button></div>
    <div class="col-lg-6"><label>Geçerli Aktif Hasta:</label><code>{{activePatientID}}</code></div>
</div>
<div class="row">
    <div class="col-lg-3"><h4>Aktif Hasta Bilgileri</h4></div>
    <div class="col-lg-9">{{ActivePatient?.Name}} {{ActivePatient?.Surname}}</div>
</div>
<div class="row">
    <div class="col-lg-3"><h4>Aktif Hastayı Listesi</h4></div>
    <ol class="col-lg-5">
        <li *ngFor="let id of activePatientsIDList">{{id}}</li>
    </ol>
</div>

`
})
export class ActivePatientServiceTestComponent implements OnInit, OnDestroy {

    public DateValue: Date;

    private _activePatientChangedObservable: Subscription;
    public ActivePatient: Patient;
    private _activePatientIDList: Array<string> = ['000009c6-740c-4c5d-a8b4-ce4320b7772d',
'00019a59-49a9-46ab-8874-b3ebd053b273',
'0001b5c8-9403-4dc6-9cff-fc639e2b4158',
'00027371-2e5e-4544-9df8-2ffe6511f06c',
'0002a23a-20b6-425b-b7dc-3e93bd68b9d4',
'0003438b-7972-478b-8e83-755b259df2ee',
'00035fbc-6c7e-4fa3-8adf-0ccd64d6a0a9',
'0005152d-fcd0-4602-85c9-6659d6eaccc4',
'000515c7-a475-4216-bf0a-bc528f7608e9',
'000534c6-7e64-49f0-8673-7f06773f6d85',
'0005d4d9-6baf-4fd4-8015-21c4fe598283',
'00061a61-8135-47d3-b2ca-32f1ef65b409',
'00069ed8-4448-4827-a81e-76ee29fa9d87',
'0006b99b-26cc-447b-91c8-0800b16b6978',
'0006f587-789f-475b-ac7a-bafc7937fa4c',
'00076e6c-0207-450f-90f4-6f9dcad668d0',
'0007a035-d14e-4c23-812f-8db6f8438fb0',
'00095318-ede0-4d21-bf35-3c1c31ee0e6b',
'000957ce-6b53-4def-9322-337af18e4523',
'00097ecb-8ba2-4958-b11a-007e46a00c36',
'000b1d3c-6703-4860-8148-13ae858d0a18',
'000b85b9-3779-4200-9ad4-d9074d52747c',
'000d300d-ae61-4961-945c-97a7bd550505',
'000d8ed0-eaf7-4d54-a29b-61ae30e72829',
'00103a69-182b-452d-8cbe-670f0e0dabc7' ];

    constructor(private activePatientService: IActivePatientService, private httpService: NeHttpService) {

    }

    public get activePatientsIDList(): Array<Guid> {
        return this.activePatientService.ActivePatientIDList;
    }


    public get activePatientID(): Guid {
        return this.activePatientService.ActivePatientID;
    }


    public setActivePatient(): void {

        let index = Math.floor(Math.random() * 25);
        let patientID: Guid = new Guid(this._activePatientIDList[index]);
        this.activePatientService.setActivePatient(patientID);
    }

    ngOnInit() {
        let that = this;
        this._activePatientChangedObservable = this.activePatientService.ActivePatientChanged.subscribe(p => {
            that.ActivePatient = p;
        });
    }

    ngOnDestroy() {
        if ( this._activePatientChangedObservable != null) {
            this._activePatientChangedObservable.unsubscribe();
            this._activePatientChangedObservable = null;
        }
    }

    public sendActivePatientWithHttpHeaders() {

        let url = 'api/ObjectContext/GetTestObject';
        this.httpService.get(url).then(response => {
            let jsonResult = response;
            console.log(jsonResult);
        });

    }
}
