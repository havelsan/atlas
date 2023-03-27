import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { IndustrialAccidentReportFormViewModel } from './IndustrialAccidentReportFormViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IModalService } from 'app/Fw/Services/IModalService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';


@Component({
    selector: "IndustrialAccidentReportForm",
    templateUrl: './IndustrialAccidentReportForm.html',
    providers: [MessageService]

})
export class IndustrialAccidentReportForm extends BaseComponent<any> implements OnInit, OnDestroy {
    industrialAccidentReportFormViewModel: IndustrialAccidentReportFormViewModel = new IndustrialAccidentReportFormViewModel();
    //SelectedClinicID: Guid;
    //SelectedClinics: Array<ReportBaseModel> = new Array<ReportBaseModel>();
    //SelectedSpecialities: Array<ReportBaseModel> = new Array<ReportBaseModel>();
    //InpatiensColumns = [
    //    { caption: 'Adı Soyadı', dataField: 'PatientNameSurame', fixed: true, width: '200' },
    //    { caption: 'TC No', dataField: 'UniqueRefNo', fixed: true, width: '100' },
    //    { caption: 'Yatış Tarihi', dataField: 'ClinicInpatientDate', fixed: true, width: '110' },
    //    { caption: 'Çıkış Tarihi', dataField: 'ClinicDischargeDate', width: '110' },
    //    { caption: 'Tanılar', dataField: 'Diagnosis', width: '350' },
    //    { "caption": "", width: 40, allowSorting: false, allowEditing: false, cellTemplate: "medicinesTemplate" }
    //]

    //DiagnosisColumns = [
    //    { caption: 'Tanı Kodu', dataField: 'Code', fixed: true, width: '50' },
    //    { caption: 'Tanı Adı', dataField: 'Name', fixed: true, width: 'auto' },

    //]

    //ProcedureColumns = [
    //    { caption: 'İşlem Kodu', dataField: 'Code', fixed: true, width: '50' },
    //    { caption: 'İşlem Adı', dataField: 'Name', fixed: true, width: 'auto' },

    //]

    //RadiologyTestColumns = [
    //    { caption: 'Kodu', dataField: 'Code', fixed: true, width: '100' },
    //    { caption: 'Tetkik Adı', dataField: 'Name', fixed: true, width: '580' },
    //    { caption: 'İşlem Durumu', dataField: 'CurrentStateName', fixed: true, width: '150' },
    //    { "caption": "", width: 40, allowSorting: false, allowEditing: false, cellTemplate: "reportTemplate" }

    //]


    //_InpatientList: Array<InPatientListForStatisticReport> = new Array<InPatientListForStatisticReport>();
    //_DiagnosisList: Array<DiagnosisAndProcedureBaseModel> = new Array<DiagnosisAndProcedureBaseModel>();
    //_ProcedureList: Array<DiagnosisAndProcedureBaseModel> = new Array<DiagnosisAndProcedureBaseModel>();
    //_Medicines: string = "";
    //_MedicinePopUpVisible: boolean = false;
    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService, protected modalService: IModalService, private reportService: AtlasReportService) {
        super(services);
    }
    
    async ngOnInit() {

        await this.loadIndustrialAccidentReportModel();
    }

    clientPostScript(state: String) {

    }
    _EpisodeActionID: Guid = Guid.Empty;
    public setInputParam(value: ActiveIDsModel) {
        if (value != null) {
            this._EpisodeActionID = value.episodeActionId;
        }
    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

    loadIndustrialAccidentReportModel() {
        let that = this;
        let fullApiUrl: string = "/api/IndustrialAccidentReportService/LoadIndustrialAccidentReportModel?EpisodeActionID=" + this._EpisodeActionID.toString();
        this.httpService.get<IndustrialAccidentReportFormViewModel>(fullApiUrl)
            .then(response => {
                that.industrialAccidentReportFormViewModel = response as IndustrialAccidentReportFormViewModel;
            })
            .catch(error => {
                console.log(error);
            });

    }
    CloseForm() {

    }


    SaveForm() {
        let fullApiUrl: string = "/api/IndustrialAccidentReportService/SaveIndustrialAccidentReportModel";
        this.httpService.post<any>(fullApiUrl, this.industrialAccidentReportFormViewModel)
            .then(response => {
                this.messageService.showSuccess("Rapor Kaydedildi.");
               
            })
            .catch(error => {
                console.log(error);
            });
    }

    PrepareReport() {

        let that = this;
        let reportData: DynamicReportParameters = {

            Code: 'ISKAZASIRAPORU',
            ReportParams: { SubEpisodeID: this.industrialAccidentReportFormViewModel.SubepisodeID },
            ViewerMode: true

        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İŞ KAZASI RAPORU"

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