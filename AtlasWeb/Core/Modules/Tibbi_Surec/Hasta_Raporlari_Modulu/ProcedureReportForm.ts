
import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { ProcedureAdditionalInfo } from './ProcedureReportFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: "procedurereportform",
    templateUrl: './ProcedureReportForm.html',
    providers: [MessageService]

})
export class ProcedureReportForm extends BaseComponent<any> implements OnInit, OnDestroy {

    _ProcedureGridColumns = [{ caption: 'Kabul Tarihi', fixed: true, dataField: 'SubepisodeOpeningDate', width: '110' },
        { caption: 'Kabul No', fixed: true, dataField: 'ProtocolNo', width: '85' },
        { caption: 'Eklenme Tarihi', fixed: true, dataField: 'CreationDate', width: '110' },
        { caption: 'Doktor Adı', fixed: true, dataField: 'DoctorName', width: '150' },
        { caption: 'İşlem Kodu', fixed: true, dataField: 'ProcedureCode', width: '80' },
        { caption: 'İşlem Adı', dataField: 'ProcedureName', width: '100%' },
        {
            caption: "",
            width: 20,
            allowSorting: false,
            cellTemplate: "linkResultTemplate",
        },
        {
            caption: "",
            width: 20,
            allowSorting: false,
            cellTemplate: "linkReportTemplate",
        }];

    _ProceduresArray: Array<ProcedureAdditionalInfo> = [];
    _PatientID: Guid;
    _showReportPopup: boolean = false;
    _AdditionalReport: Object;
   _BaseAdditionalApplicationObjectID:Guid = Guid.Empty;
  

    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService, protected modalService: IModalService) {
        super(services);
    }

    async ngOnInit() {
        await this.loadProceduresFromPatientID();
       
    }

    private async loadProceduresFromPatientID(): Promise<any> {
        let apiUrl: string = 'api/PatientExaminationService/GetProceduresWithAdditionalInfo?PatientID=' + this._PatientID;
       
        this.httpService.get<Array<ProcedureAdditionalInfo>>(apiUrl).then(result => {

            this._ProceduresArray = result;

        }).catch(error => {
                this.messageService.showError(error);
         });
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

    setInputParam(value: ActiveIDsModel) {

        this._PatientID = value.patientId;
    }
    showAdditionalInfoForm(row) {
        this._showReportPopup = true;
        this._BaseAdditionalApplicationObjectID = row.data.BaseAdditionalApplicationObjectID;
        let apiUrl: string = 'api/PatientExaminationService/GetAdditionalInfoReport?AdditionalInfoObjectID=' + row.data.ObjectID;

        this.httpService.get<Object>(apiUrl).then(result => {

            this._AdditionalReport = result;

        }).catch(error => {
            this.messageService.showError(error);
        });
        
    }

    printAdditionalInfoReport() {
        let reportData: DynamicReportParameters = {

            Code: 'ISLEMRAPORU',
            ReportParams: { ObjectID: this._BaseAdditionalApplicationObjectID.toString() },
            ViewerMode: true
        };
        this.openReport(reportData);

        
    }

    showAdditionalInfoReport(row) {
        let reportData: DynamicReportParameters = {

            Code: 'ISLEMRAPORU',
            ReportParams: { ObjectID: row.data.BaseAdditionalApplicationObjectID.toString() },
            ViewerMode: true
        };
        this.openReport(reportData);
    }

    openReport(reportData:DynamicReportParameters){
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = new ActiveIDsModel(null,null,null);
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, activeIDsModel);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İşlem Raporu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}