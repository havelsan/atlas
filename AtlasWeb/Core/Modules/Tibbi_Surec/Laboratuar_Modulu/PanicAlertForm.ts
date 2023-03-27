import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { LaboratoryPanicNotificationViewModel, PanicNotificationInfo } from './LaboratoryPanicNotificationViewModel';

import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemApiService } from 'Fw/Services/SystemApiService';

@Component({
    selector: "PanicAlertForm",
    templateUrl: './PanicAlertForm.html',

    providers: [SystemApiService],

})
export class PanicAlertForm extends BaseComponent<any> implements OnInit, IModal, OnDestroy  {

    laboratoryPanicNotificationViewModel: LaboratoryPanicNotificationViewModel = new LaboratoryPanicNotificationViewModel();
    PanicAlertColumns = [
        { "caption": "Onayla", width: 60, allowSorting: false, fixed: true, allowEditing: false, cellTemplate: "seenTemplate" },
        { caption: 'Adı Soyadı', dataField: 'PatientNameSurame', fixed: true, width: '200' },
        { caption: 'Kabul No', dataField: 'ProtocolNo', fixed: true, width: '100' },
        { caption: 'Açıklama', dataField: 'Description', fixed: false, width: '1000' }
        
    ]


    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService) {
        super(services);
    }

    async ngOnInit() {
        await this.loadPanicAlertViewModel();

    }

    private _inputParam: Object;
    public setInputParam(value: Object) {
        this._inputParam = value;
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }
    loadPanicAlertViewModel() {
        let that = this;
        let fullApiUrl: string = "/api/LaboratoryProcedureService/LoadLaboratoryPanicNotificationViewModel";
        this.httpService.get<LaboratoryPanicNotificationViewModel>(fullApiUrl)
            .then(response => {
                that.laboratoryPanicNotificationViewModel = response as LaboratoryPanicNotificationViewModel;
            })
            .catch(error => {
                console.log(error);
            });

    }

    public ngOnDestroy(): void {
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    UpdateSeenNotification(data: PanicNotificationInfo) {

        let that = this;

        let apiUrl: string = '/api/LaboratoryProcedureService/UpdateSeenNotification';

        this.httpService.post<any>(apiUrl, data).then(result => {

            
            this.loadPanicAlertViewModel();

        })
            .catch(error => {
                console.log(error);
            });

    }


  

    public ClosePanicNotification(): void {
        ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }
  

}
