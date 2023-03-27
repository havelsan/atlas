import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { InpatientStatisticReportViewModel, ReportBaseModel, InPatientListForStatisticReport, RadiologyTestInfo, DiagnosisAndProcedureBaseModel } from './InPatientWorkListViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicReportParameters } from '../../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from '../../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from '../../../../wwwroot/app/Fw/Models/ModalInfo';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { GuidParam } from '../../../../wwwroot/app/NebulaClient/Mscorlib/GuidParam';
import { IModalService } from '../../../../wwwroot/app/Fw/Services/IModalService';
import { AtlasReportService } from '../../../../wwwroot/app/Report/Services/AtlasReportService';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from "devextreme/data/data_source";

@Component({
    selector: "InpatientStatisticReport",
    templateUrl: './InpatientStatisticReport.html',
    providers: [MessageService]

})
export class InpatientStatisticReport extends BaseComponent<any> implements OnInit, OnDestroy {
    inpatientStatisticReportViewModel: InpatientStatisticReportViewModel = new InpatientStatisticReportViewModel();
    SelectedClinicID: Guid;
    SelectedClinics: Array<ReportBaseModel> = new Array<ReportBaseModel>();
    SelectedSpecialities: Array<ReportBaseModel> = new Array<ReportBaseModel>();
    InpatiensColumns = [
        { caption: 'Adı Soyadı', dataField: 'PatientNameSurame', fixed: true, width: '200' },
        { caption: 'TC No', dataField: 'UniqueRefNo', fixed: true, width: '100' },
        { caption: 'Yatış Tarihi', dataField: 'ClinicInpatientDate', fixed: true, width: '110' },
        { caption: 'Çıkış Tarihi', dataField: 'ClinicDischargeDate', width: '110' },
        { caption: 'Tanılar', dataField: 'Diagnosis', width: '350' },
        { "caption": "", width: 40, allowSorting: false, allowEditing: false, cellTemplate: "medicinesTemplate" }
    ]

    DiagnosisColumns = [
        { caption: 'Tanı Kodu', dataField: 'Code', fixed: true, width: '50' },
        { caption: 'Tanı Adı', dataField: 'Name', fixed: true, width: 'auto' },
   
    ]

    ProcedureColumns = [
        { caption: 'İşlem Kodu', dataField: 'Code', fixed: true, width: '50' },
        { caption: 'İşlem Adı', dataField: 'Name', fixed: true, width: 'auto' },

    ]

    RadiologyTestColumns = [
        { caption: 'Kodu', dataField: 'Code', fixed: true, width: '100' },
        { caption: 'Tetkik Adı', dataField: 'Name', fixed: true, width: '580' },
        { caption: 'İşlem Durumu', dataField: 'CurrentStateName', fixed: true, width: '150' },
        { "caption": "", width: 40, allowSorting: false, allowEditing: false, cellTemplate: "reportTemplate" }
        
    ]


    _InpatientList: Array<InPatientListForStatisticReport> = new Array<InPatientListForStatisticReport>();
    _DiagnosisList: Array<DiagnosisAndProcedureBaseModel> = new Array<DiagnosisAndProcedureBaseModel>();
    _ProcedureList: Array<DiagnosisAndProcedureBaseModel> = new Array<DiagnosisAndProcedureBaseModel>();
    _Medicines: string = "";
    _MedicinePopUpVisible: boolean = false;
    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService, protected modalService: IModalService, private reportService: AtlasReportService) {
        super(services);
    }

    async ngOnInit() {

        await this.loadInpatientReportModel();
        this.LoadAllDiagnosisDefinitions();
        this.LoadAllProcedureDefinitions();

    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

    loadInpatientReportModel() {
        let that = this;
        let fullApiUrl: string = "/api/InPatientWorkListService/LoadInpatientReportViewModel";
        this.httpService.get<InpatientStatisticReportViewModel>(fullApiUrl)
            .then(response => {
                that.inpatientStatisticReportViewModel = response as InpatientStatisticReportViewModel;
            })
            .catch(error => {
                console.log(error);
            });

    }

    ClinicChanged(data) {
        let that = this;
        let clinic: ReportBaseModel = data.value;
        that.SelectedClinicID = clinic.ObjectID;
    }

    SpecialityChanged(event) { //Branş seçildikçe servis filtreleniyor

        let that = this;
        let fullApiUrl: string = "/api/InPatientWorkListService/FilterClinicsBySelectedSpecialities";
        let input = { "SelectedSpecialities": this.SelectedSpecialities };



        this.httpService.post<Array<ReportBaseModel>>(fullApiUrl, input)
            .then(response => {
                this.inpatientStatisticReportViewModel.ClinicList = response as Array<ReportBaseModel>;
                this.SelectedClinics = new Array<ReportBaseModel>(); 

            })
            .catch(error => {
                console.log(error);
            });
    }
  

  
    ListInpatients() {
        let that = this;
        let fullApiUrl: string = "/api/InPatientWorkListService/ListInpatientsForStatisticReport";


        let input = {"InpatientStartDate": that.inpatientStatisticReportViewModel.InpatientStartDate,
            "InpatientEndDate": that.inpatientStatisticReportViewModel.InpatientEndDate,
            "DischargeStartDate": that.inpatientStatisticReportViewModel.DischargeStartDate,
            "DischargeEndDate": that.inpatientStatisticReportViewModel.DischargeEndDate,
            "DiagnosisList": this._DiagnosisList,
            "SelectedClinics": this.SelectedClinics,
            "ProcedureList": this._ProcedureList
        };

   

        this.httpService.post<Array<InPatientListForStatisticReport>>(fullApiUrl, input)
            .then(response => {
                that._InpatientList = response as Array<InPatientListForStatisticReport>;


            })
            .catch(error => {
                console.log(error);
            });
    }

    OpenMedicines(data: InPatientListForStatisticReport) {
        let that = this;
      
        this._MedicinePopUpVisible = true;
        this._Medicines = data.Medicines;
          

       
    }

    async OpenRadiologyReport(data: RadiologyTestInfo) {
        let paramNewRadiologyReport: string;
        paramNewRadiologyReport = await SystemParameterService.GetParameterValue('NEWRADIOLOGYREPORT', 'FALSE');
        if (paramNewRadiologyReport == "TRUE") {

            let reportData: DynamicReportParameters = {

                Code: 'RADYOLOJISONUCRAPOR',
                ReportParams: { ObjectID: data.ObjectID },
                ViewerMode: true

            };

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = reportData;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "RADYOLOJI SONUÇ RAPORU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {

                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        } else {


            let that = this;
            const objectIdParam = new GuidParam(data.ObjectID);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('RadiologyTestResultReport', reportParameters);
        }
    }

    PrepareReport() {

        let that = this;
        let reportData: DynamicReportParameters = {

            Code: 'YATANHASTAISTATISTIKRAPORU',
            ReportParams: { MasterResourceID: this.SelectedClinicID, SelectedDate: that.inpatientStatisticReportViewModel.ReportDate},
            ViewerMode: true

        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "YATAN HASTA ISTATISTIK RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public DiagnosisArray: any;
    public async LoadAllDiagnosisDefinitions() {
        let filterString: string = 'ISLEAF=1';


        this.DiagnosisArray = new DataSource({
            store: new CustomStore({
                key: "Code",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                },
                byKey: (key: any) => {
                    let loadOptions: any = new Object();
                    loadOptions.Params = {
                        searchText: key,
                        definitionName: 'DiagnosisListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }
    public async diagnosisSelection_ValueChanged(data: any) {
        let that = this;
        if (data != null) { //data.objectID
            let diagnosis: DiagnosisAndProcedureBaseModel = new DiagnosisAndProcedureBaseModel();
            diagnosis.ObjectID = data.ObjectID;
            diagnosis.Code = data.Code;
            diagnosis.Name = data.Name;
            this._DiagnosisList.push(diagnosis);
        }
    }

    public ProcedureArray: any;
    public async LoadAllProcedureDefinitions() {
        let filterString: string = '';


        this.ProcedureArray = new DataSource({
            store: new CustomStore({
                key: "Code",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'ProcedureListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                },
                byKey: (key: any) => {
                    let loadOptions: any = new Object();
                    loadOptions.Params = {
                        searchText: key,
                        definitionName: 'ProcedureListDefinition',
                        injectionFilter: filterString
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    if (String.isNullOrEmpty(loadOptions.searchValue)) {
                        return null;
                    } else {
                        return this.httpService.post<any>("/api/DefinitionQuery/DevExtremePagingQueryForDefList", loadOptions);
                    }
                }
            }),
            paginate: true,
            pageSize: 10
        });
    }


    public async procedureSelection_ValueChanged(data: any) {
        let that = this;
        if (data != null) { 
            let procedure: DiagnosisAndProcedureBaseModel = new DiagnosisAndProcedureBaseModel();
            procedure.ObjectID = data.ObjectID;
            procedure.Code = data.Code;
            procedure.Name = data.Name;
            this._ProcedureList.push(procedure);
        }
    }

}