import { Component, NgZone, Input } from '@angular/core';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
//import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
//import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';

import { IActiveUserService } from 'Fw/Services/IActiveUserService';
//import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { PathologySubepisodeInfo,PathologyInfo } from './PathologyMainFormViewModel';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'AllPathologyReportsForm',
    templateUrl: './AllPathologyReportsForm.html',
    providers: [MessageService]
})

export class AllPathologyReportsForm {

    private _PatientObjectID: Guid;

    @Input() set PatientObjectID (value: Guid) {
        if (value != undefined && value != null) {
            this._PatientObjectID = value;
            this.loadPathologiesByPatientID();
        }
    }
    get PatientObjectID(): Guid {
        return this._PatientObjectID;
    }

    _PathologySubepisodes: Array<PathologySubepisodeInfo> = new  Array<PathologySubepisodeInfo>();

    //public PathologyColumns = [
    //    {
    //        "caption": "Onay Tarihi",
    //        dataField: "RequestDate",
    //        width: 100,
    //        allowSorting: true,
    //        fixed: true,
    //        dataType: 'date',
    //        format: 'dd/MM/yyyy'
    //    },
    //    {
    //        "caption": "Rapor Tarihi",
    //        dataField: "RequestDate",
    //        width: 100,
    //        allowSorting: true,
    //        fixed: true,
    //        dataType: 'date',
    //        format: 'dd/MM/yyyy'
    //    }

    //];



    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected activeUserService: IActiveUserService,
        protected ngZone: NgZone,
        protected modalService: IModalService,
        private reportService: AtlasReportService) {

    }

    setInputParam(value: ActiveIDsModel) {
        if (value != null) {
            this.PatientObjectID = value.patientId;
        
        }
    }

    loadPathologiesByPatientID() {
        let apiUrl: string = 'api/PathologyService/GetPathologyReportsByPatientID?PatientObjectID=' + this._PatientObjectID.toString();
        this.httpService.get<Array<PathologySubepisodeInfo>>(apiUrl).then(result => {
           if (result != null) {
               this._PathologySubepisodes = result;
           }
        });
    }
  

    public selectPathologyReport(row): Promise<ModalActionResult>
    {
        let reportData: DynamicReportParameters = {

            Code : 'PATOLOJISONUCRAPOR',
            ReportParams: { ObjectID: row.data.PathologyID },
            ViewerMode: true
        };
  
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PATOLOJİ SONUÇ RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    selectPathologyResultView(row)
    {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PathologyMainForm";
            componentInfo.ModuleName = "PatolojiModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule";
            componentInfo.InputParam = row.data.PathologyID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20256", "Patoloji Sonuç");
            modalInfo.Width = 1300;
            modalInfo.Height = 700;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}