//$E67F7B81
import { Component, OnInit, Input } from '@angular/core';
import { PatientHistoryFormViewModel, ProcessTitle, PopupHistory, LaboratoryData, PathologyData, TeletipInput_DVO } from './PatientHistoryFormViewModel';
import { LaboratoryWorkListSubItemDetailModel } from "../Laboratuar_Is_Listesi/LaboratoryWorkListFormViewModel";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';

import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { DrugOrderIntroduction, RadiologyTestDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { ModalInfo, IModal, ModalActionResult } from "Fw/Models/ModalInfo";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

import { IModalService } from "Fw/Services/IModalService";
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { TeletipResult_Output, TeletipImaj_Input } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
@Component({
    selector: 'PatientHistoryForm',
    templateUrl: './PatientHistoryForm.html',
    providers: [MessageService, SystemApiService]
})
export class PatientHistoryForm extends TTUnboundForm implements OnInit, IModal {

    public IsHistoryByPatient: boolean = true;//Hasta Geçmişi hasta arama ile yapılırsa true; kabulNo ile yapılırsa false olmalı
    public showRadiologyProcedures:boolean = false;
    public RadiologyDefList: Array<any> =new Array<any>();
    public selectedProcedures:[];
    public searchExp=['Name','SUTCode'];
    public PreviousStudies: Array<TeletipResult_Output> = new Array<TeletipResult_Output>();

    private _patient: string;
    @Input() set patient(value: string) {
        this._patient = value;
        if (this._patient) {
            this.patientHistoryFormViewModel.visibility = true;
            this.patientHistoryFormViewModel.LinksVisibility = true;
            this.loadForPatientHistory();
            this.IsHistoryByPatient = true;
        } else {
            this.patientHistoryFormViewModel.LinksVisibility = false;

        }
    }
    get patient(): string {
        return this._patient;
    }
    private _protocolNo: string;
    @Input() set protocolNo(value: string) {
        this._patient = value;
        if (this._patient) {
            this.patientHistoryFormViewModel.visibility = true;
            this.patientHistoryFormViewModel.LinksVisibility = true;
            this.loadForPatientHistoryByProtocolNo();
            this.IsHistoryByPatient = false;
        } else {
            this.patientHistoryFormViewModel.LinksVisibility = false;

        }
    }
    get protocolNo(): string {
        return this._patient;
    }
    private _episode: string;
    @Input() set episode(value: string) {
        this._episode = value;
        if (this._episode) {
            this.patientHistoryFormViewModel.visibility = false;
            this.loadForPatientHistoryForEpisode();
            this.patientHistoryFormViewModel.PatientActionList = null;
            this.patientHistoryFormViewModel.LinksVisibility = true;
            this.patientActionListCount = 0;
            this.componentInfo = null;
        } else {
            this.patientHistoryFormViewModel.LinksVisibility = false;

        }
    }
    get episode(): string {
        return this._episode;
    }

    private _subEpisode: string;
    @Input() set subEpisode(value: string) {
        this._subEpisode = value;
        if (this._subEpisode) {
            //this.patientHistoryFormViewModel.visibility = false;
            this.loadForPatientHistoryForSubEpisode(false);
            //this.patientHistoryFormViewModel.PatientActionList = null;
            //this.patientHistoryFormViewModel.LinksVisibility = true;
            this.patientActionListCount = 0;
            this.patientHistoryFormViewModel.CloseAllPanel = true;
            this.componentInfo = null;
        } else {
            this.patientHistoryFormViewModel.LinksVisibility = false;
            //this.patientHistoryFormViewModel.CloseAllPanel = false;

        }
    }

    public setInputParam(value: any) {
        this.patientHistoryFormViewModel.CloseAllPanel = true;

        this.patientHistoryFormViewModel._historyFilter.subEpisode = value["subEpisode"];
        this.patientHistoryFormViewModel._historyFilter.actionType = value["actionType"];
        this.patientHistoryFormViewModel._historyFilter.selectAll = false;
        this.patientHistoryFormViewModel._historyFilter.useFilter = false;
        this.patientHistoryFormViewModel._historyFilter.startDate = new Date();
        this.patientHistoryFormViewModel._historyFilter.endDate = new Date();

        this.loadForPatientHistoryForSubEpisode(false);
    }

    public setModalInfo(value: ModalInfo) {
        //this._modalInfo = value;
    }


    public PopupHistoryGridColumn = [

        {
            caption: i18n("M16650", "İstek Tarihi"),
            dataField: "RequestDate",
            dataType: "date",
            format: "dd/MM/yyyy",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16721", "İsteyen Doktor"),
            dataField: "RequesterUsr",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16722", "İsteyen Klinik"),
            dataField: "RequesterUnit",
            width: "auto",
            //cssClass: 'WrappedColumnClass',
            allowSorting: true
        },
        {
            caption: i18n("M13372", "İşlemin Durumu"),
            dataField: "CurrentState",
            width: "auto",
            allowSorting: true
        }

    ];
    public ActionTypeList = [];
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    public showPanelTestResultPopup: boolean = false;
    LaboratorySubProcedureList: Array<LaboratoryWorkListSubItemDetailModel>;

    public PanelTestProcedureColumns = [
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "TestCode",
            width: 80,
            allowSorting: true
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "LaboratoryTestName",
            width: 100,
            allowSorting: true
        },
        {
            "caption": "Barkod",
            dataField: "BarcodeID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M19543", "Numune No"),
            dataField: "SpecimenID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M22078", "Sonuç"),
            dataField: "Result",
            width: 60,
            allowSorting: true
        },
        {
            "caption": "Birim",
            dataField: "Unit",
            width: 60,
            allowSorting: true
        },
        {
            "caption": i18n("M21010", "Referans Aralığı"),
            dataField: "Reference",
            width: 100,
            allowSorting: true
        }

    ];



    /******************************/
    public patientHistoryFormViewModel: PatientHistoryFormViewModel = new PatientHistoryFormViewModel();

    private PatientHistoryForm_DocumentUrl: string = '/api/PatientHistoryService/PatientHistoryForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private objectContextService: ObjectContextService, private reportService: AtlasReportService, protected modalService: IModalService, ) {
        super('PATIENTHISTORY', 'PatientHistoryForm');
        //this._DocumentServiceUrl = this.PatientHistoryForm_DocumentUrl;
        this.uzmanlikmodeldt = new Array<any>();
        this.polmodeldt = new Array<any>();
        this.initViewModel();
        this.initFormControls();

        this.ActionTypeList = [
            {
                Text: 'Ortez Protez',
                Value: 'ORTHESISPROSTHESISREQUEST'
            }, {
                Text: 'F.T.R',
                Value: 'PHYSIOTHERAPYREQUEST'
            }];
    }


    // ***** Method declarations start *****

    public policlinicProcessCount: number = 0;
    public clinicProcessCount: number = 0;
    public surgeryCount: number = 0;
    public patientActionListCount: number = 0;
    public specialityCount: number = 0;
    public emergencyObjectCount: number = 0;
    public manipulationProcessCount: number = 0;
    public physiotherapyRequestCount: number = 0;

    public IsMultiComponent: boolean = false;
    public IsSingleComponent: boolean = false;
    public IsDiagnosisGrid: boolean = false;
    public IsRadiologyGrid: boolean = false;
    public IsLaboratoryGrid: boolean = false;
    public PathologyGrid: boolean = false;
    public DrugOrderGrid: boolean = false;
    public IsRequestedProcedureGrid: boolean = false;
    public IsTreatmentMaterialGrid: boolean = false;
    public IsDietOrdersGrid: boolean = false;

    public ActionSubEpisodeInfo: ProcessTitle;

    public SetComponentVisibility(componentName: string) {
        if (componentName == "MultiComponent") {
            this.IsMultiComponent = true;
        }
        else {
            this.IsMultiComponent = false;
        }
        if (componentName == "SingleComponent") {
            this.IsSingleComponent = true;
        }
        else {
            this.IsSingleComponent = false;
        }
        if (componentName == "DiagnosisGrid") {
            this.IsDiagnosisGrid = true;
        }
        else {
            this.IsDiagnosisGrid = false;
        }
        if (componentName == "RadiologyGrid") {
            this.IsRadiologyGrid = true;
        }
        else {
            this.IsRadiologyGrid = false;
        }
        if (componentName == "LaboratoryGrid") {
            this.IsLaboratoryGrid = true;
        }
        else {
            this.IsLaboratoryGrid = false;
        }
        if (componentName == "PathologyGrid") {
            this.PathologyGrid = true;
        }
        else {
            this.PathologyGrid = false;
        }
        if (componentName == "DrugOrderGrid") {
            this.DrugOrderGrid = true;
        }
        else {
            this.DrugOrderGrid = false;
        }
        if (componentName == "RequestedProcedureGrid") {
            this.IsRequestedProcedureGrid = true;
        }
        else {
            this.IsRequestedProcedureGrid = false;
        }
        if (componentName == "TreatmentMaterialGrid") {
            this.IsTreatmentMaterialGrid = true;
        }
        else {
            this.IsTreatmentMaterialGrid = false;
        }
        if (componentName == "DietOrdersGrid") {
            this.IsDietOrdersGrid = true;
        }
        else {
            this.IsDietOrdersGrid = false;
        }
    }

    public multipleComponent: Array<DynamicComponentInfo>;
    public multipleComponentHeader: Array<ProcessTitle>;

    public componentInfo: DynamicComponentInfo;
    public singleComponentHeader: ProcessTitle;

    //Tümünü Aç: Çoklu dinamik component seçimi
    async selectAll(value: any): Promise<void> {
        this.SetComponentVisibility("MultiComponent");

        this.multipleComponentHeader = value;

        this.multipleComponent = new Array<DynamicComponentInfo>();
        for (let item of value) {
            let _data: ProcessTitle = item as ProcessTitle;
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = this.GetMyFormDefNameByobjectDefName(_data.ObjectDefName);
            compInfo.ModuleName = "PatientHistoryModule";
            compInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule";
            compInfo.objectID = _data.ObjectID;
            this.multipleComponent.push(compInfo);
        }
    }

    //Tek dinamik component seçimi
    async select(value: any): Promise<void> {
        this.SetComponentVisibility("SingleComponent");

        this.singleComponentHeader = value;

        this.multipleComponent = new Array<DynamicComponentInfo>();
        this.componentInfo = new DynamicComponentInfo;
        let _data: ProcessTitle = value as ProcessTitle;
        this.openDynamicComponentForHistory(_data.ObjectDefName, _data.ObjectID);
    }

    GetMyFormDefNameByobjectDefName(objectDefName: any) {
        if (objectDefName == "CONSULTATION")
            return "OldConsultationsForm";
        if (objectDefName == "PATIENTEXAMINATION")
            return "OldExaminationForm";
        if (objectDefName == "INPATIENTPHYSICIANAPPLICATION")
            return "OldInpatientPhysicianAppForm";
        if (objectDefName == "SURGERY")
            return "OldSurgeryForm";
        if (objectDefName == "MEDICALINFORMATION")
            return "OldMedicalInformationForm";
        if (objectDefName == "VACCINEFOLLOWUP")
            return "OldVaccineFollowUpForm";
        if (objectDefName == "WOMANSPECIALITYOBJECT")
            return "OldWomanSpecialityForm";
        if (objectDefName == "CHILDGROWTHVISITS")
            return "OldVisitDetailsForm";
        if (objectDefName == "EYEEXAMINATION")
            return "OldEyeExaminationForm";
        if (objectDefName == "EMERGENCYSPECIALITYOBJECT")
            return "OldEmergencyForm";
        if (objectDefName == "PSYCHOLOGYBASEDOBJECT")
            return "OldPsychologyObjectForm";
        if (objectDefName == "MANIPULATION")
            return "OldManipulationForm";
        if (objectDefName == "PHYSIOTHERAPYREQUEST")
            return "OldPhysiotherapyRequestForm";
        else
            return objectDefName;
    }

    openDynamicComponentForHistory(objectDefName: any, objectID?: any) {
        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        compInfo.ComponentName = this.GetMyFormDefNameByobjectDefName(objectDefName);
        compInfo.ModuleName = "PatientHistoryModule";
        compInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule";
        compInfo.objectID = objectID;
        this.componentInfo = compInfo;
    }

    //Kabul Bazlı görünüm dinamik component
    async selectForm(value: any): Promise<void> {
        this.SetComponentVisibility("SingleComponent");

        this.multipleComponent = new Array<DynamicComponentInfo>();
        this.singleComponentHeader = value;

        let _data: ProcessTitle = value as ProcessTitle;
        this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID);
    }

    async openDynamicComponent(objectDefName: any, objectID?: any, FormDefId?: any, InputParam?: any) {
        if (objectDefName === 'DRUGORDERINTRODUCTION') {
            await this.openDrugOrderIntroduction(objectID);
        } else {
            this.componentInfo = await this.systemApiService.open(objectID, objectDefName, FormDefId, InputParam);
        }
    }

    async openDrugOrderIntroduction(objectid: Guid) {
        let drugOrderIntroduction: DrugOrderIntroduction = await this.objectContextService.getObject<DrugOrderIntroduction>(objectid, DrugOrderIntroduction.ObjectDefID);
        let episodeID: Guid = <any>drugOrderIntroduction['Episode'];
        let episode: Episode = await this.objectContextService.getObject<Episode>(episodeID, Episode.ObjectDefID);
        drugOrderIntroduction.Episode = episode;
        let patientID: Guid = <any>episode['Patient'];
        let patient: Patient = await this.objectContextService.getObject<Patient>(patientID, Patient.ObjectDefID);
        drugOrderIntroduction.Episode.Patient = patient;

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'DrugOrderIntroductionNewForm';
        componentInfo.ModuleName = 'IlacDirektifiGirisModule';
        componentInfo.ModulePath = '/Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/IlacDirektifiGirisModule';
        componentInfo.InputParam = drugOrderIntroduction;
        this.componentInfo = componentInfo;
    }

    //Tanı Gridi
    GetDiagnosisGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetDiagnosisGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";   
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.DiagnoseDataList = result;
            })
            .catch(error => {
                alert(i18n("M15205", "Hasta Gecmisi Tanı Gridi Hata=") + error);
                console.log(error);
            });

        this.SetComponentVisibility("DiagnosisGrid");
    }


    polmodeldt: Array<any>;
    poltxtChange(e) {
        if (e.value != "") {
            let excludeList: Array<any> = Array<any>();
            for (let mc of this.polmodeldt) {
                if (mc.DoctorName != null) {
                    if (mc.DoctorName.toUpperCase().includes(e.value.toUpperCase()) || mc.SpecialityName.toUpperCase().includes(e.value.toUpperCase())) {
                        excludeList.push(mc);
                    }
                }
            }
            this.patientHistoryFormViewModel.PoliclinicProcessTitle = excludeList;
        }
        else {
            this.patientHistoryFormViewModel.PoliclinicProcessTitle = this.polmodeldt;
        }
    }

    klinikmodeldt: Array<any>;
    kliniktxtChange(e) {
        if (e.value != "") {
            let excludeList: Array<any> = Array<any>();
            for (let mc of this.klinikmodeldt) {
                if (mc.DoctorName.toUpperCase().includes(e.value.toUpperCase()) || mc.SpecialityName.toUpperCase().includes(e.value.toUpperCase())) {
                    excludeList.push(mc);
                }
            }
            this.patientHistoryFormViewModel.ClinicProcessTitle = excludeList;
        }
        else {
            this.patientHistoryFormViewModel.ClinicProcessTitle = this.klinikmodeldt;
        }
    }
    uzmanlikNameDt: Array<any>;
    uzmanlikmodeldt: Array<any>;
    uzmanliktxtChange(e) {
        if (e.value != "") {
            let excludeList: Array<any> = Array<any>();
            for (let mc of this.uzmanlikmodeldt) {
                if (mc.DoctorName.toUpperCase().includes(e.value.toUpperCase())) {
                    excludeList.push(mc);
                }
            }
            this.patientHistoryFormViewModel.SpecialityTitles = excludeList;
        }
        else {
            this.patientHistoryFormViewModel.SpecialityTitles = this.uzmanlikNameDt;
        }
    }
    showDetailPopup: boolean = false;
    detail: string = "";
    SelectedAccesionNumber: number = 0;
    SelectedPatientTCNo: string = "";
    selectDetails(data) {
        this.SelectedAccesionNumber = data.selectedRowKeys[0].AccesionNumber;
        this.SelectedPatientTCNo = this.patientHistoryFormViewModel.PatientUniqueRefNo
    }


    kabulmodeldt: Array<any>;
    kabultxtChange(e) {
        if (e.value != "") {
            let excludeList: Array<any> = Array<any>();
            for (let mc of this.kabulmodeldt) {
                if (mc.DoctorName.toUpperCase().includes(e.value.toUpperCase()) || mc.SpecialityName.toUpperCase().includes(e.value.toUpperCase())) {
                    excludeList.push(mc);
                }
            }
            this.patientHistoryFormViewModel.PatientHistoryBySubEpisode = excludeList;
        }
        else {
            this.patientHistoryFormViewModel.PatientHistoryBySubEpisode = this.kabulmodeldt;
        }
    }

    manipulationmodeldt: Array<any>;
    manipulationtxtChange(e) {
        //if (e.value != "") {
        //    let excludeList: Array<any> = Array<any>();
        //    for (let mc of this.polmodeldt) {
        //        if (mc.DoctorName != null) {
        //            if (mc.DoctorName.toUpperCase().includes(e.value.toUpperCase()) || mc.SpecialityName.toUpperCase().includes(e.value.toUpperCase())) {
        //                excludeList.push(mc);
        //            }
        //        }
        //    }
        //    this.patientHistoryFormViewModel.PoliclinicProcessTitle = excludeList;
        //}
        //else {
        //    this.patientHistoryFormViewModel.PoliclinicProcessTitle = this.polmodeldt;
        //}
    }

    private async cmdReport_Click(): Promise<void> {

        let accessionNoStr: string = this.SelectedAccesionNumber.toString();
        let accessionNoPrefix: string = "";

        let numberOfZero: number = (7 - accessionNoStr.length);
        for (let i = 0; i < numberOfZero; i++) {
            accessionNoPrefix = accessionNoPrefix + "0";
        }
        let sysparam: string = (await SystemParameterService.GetParameterValue("PACSVIEWERURL", null));
        let URLLink: string = "";

        if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "EXTREME") {
            URLLink = sysparam + "?an=" + accessionNoPrefix + accessionNoStr + "&usr=extreme";

        }
        else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "COMPANY1") == "COMPANY2") {
            URLLink = sysparam + "?accession=" + accessionNoPrefix + accessionNoStr + "&patientid=" + this.SelectedPatientTCNo.toString() + "&ietab=true";
        }
        else if (await SystemParameterService.GetParameterValue("PACSCOMPANYNAME", "EXTREME") == "XXXXXX") {
            URLLink = sysparam + "&accession=" + accessionNoPrefix + accessionNoStr + "&StudyReload=1";
        }

        if (URLLink == null) {
            InfoBox.Alert(i18n("M16463", "İmaj gösterme linki bulunamadı!"));
        } else {
            let win = window.open(URLLink, '_blank');
            win.focus();
        }

    }


    async previewRadiologyReport(data) {
        let paramNewRadiologyReport: string;
        paramNewRadiologyReport = await SystemParameterService.GetParameterValue('NEWRADIOLOGYREPORT', 'FALSE');
        if (paramNewRadiologyReport == "TRUE") {

            let reportData: DynamicReportParameters = {

                Code: 'RADYOLOJISONUCRAPOR',
                ReportParams: { ObjectID: data.ObjectId },
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
            const objectIdParam = new GuidParam(data.ObjectId);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('RadiologyTestResultReport', reportParameters);
        }
    }

    public async openPanelTestResultView(row) {

        this.showPanelTestResultPopup = true;
        this.LaboratorySubProcedureList = new Array<LaboratoryWorkListSubItemDetailModel>();

        let that = this;
        let fullApiUrl: string = "api/LaboratoryWorkListService/GetPanelSubTestsInfo?LaboratoryProcedureObjectID=" + row.ObjectID.toString();
        let result = await this.httpService.get<any>(fullApiUrl, LaboratoryWorkListSubItemDetailModel) as Array<LaboratoryWorkListSubItemDetailModel>;
        if (result != null)
            this.LaboratorySubProcedureList = result;

    }



    //Radyoloji Gridi
    GetRadiologyGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetRadiologyGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        } 
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.RadiologyDataList = result;
            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("RadiologyGrid");
    }

    //Laboratuvar Gridi
    GetLaboratoryGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetLaboratoryWithPanelTestsGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.LaboratoryDataList = result;
            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("LaboratoryGrid");
    }

    //Patoloji Gridi
    GetPathologyGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetPathologyGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.PathologyDataList = result;
            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("PathologyGrid");
    }

    //İlaç Gridi
    GetDrugOrderGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetDrugOrderGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.DrugOrderDataList = result;
            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("DrugOrderGrid");
    }

    //Aşı Takvimi
    GetVaccineComponent(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetVaccineGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.VaccineProcessTitle = result;
                this.select(that.patientHistoryFormViewModel.VaccineProcessTitle);
            })
            .catch(error => {
                console.log(error);
            });
    }

    //Hizmet ve Tetkik Gridi
    GetRequestedProceduresGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetRequestedProceduresGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.RequestedProceduresList = result;
            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("RequestedProcedureGrid");
    }

    //Malzeme Sarf Gridi
    GetTreatmentMaterialsGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetTreatmentMaterialsGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.TreatmentMaterialsList = result;
            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("TreatmentMaterialGrid");
    }

    //Diyet Gridi
    GetDietOrdersGrid(id: any) {
        let fullApiUrl: string = "api/PatientHistoryService/GetDietOrdersGrid?id=" + id;
        if (this.IsHistoryByPatient == false) {
            fullApiUrl += "&subEpisodeId=" + this.patientHistoryFormViewModel.SubEpisodeId;
        } else {
            fullApiUrl += "&subEpisodeId=";
        }
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.DietOrdersList = result;

            })
            .catch(error => {
                console.log(error);
            });

        this.SetComponentVisibility("DietOrdersGrid");
    }


    //Vaka Akışı Listesi
    GetSubEpisodeItems(id: any, value: ProcessTitle) {
        this.ActionSubEpisodeInfo = value;
        let fullApiUrl: string = "api/PatientHistoryService/GetSubEpisodeItems?id=" + id;
        let that = this;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.PatientActionList = result;
                this.patientActionListCount = result.length;
            })
            .catch(error => {
                console.log(error);
            });
    }
    // *****Method declarations end *****

    isAccordionOpened: boolean = true;

    changeAcoordionCollapse() {
        let that = this;
        that.isAccordionOpened = !that.isAccordionOpened;
    }

    public initViewModel(): void {
        this.patientHistoryFormViewModel = new PatientHistoryFormViewModel();
    }

    protected loadViewModel() {
        let that = this;
        if (this.patientHistoryFormViewModel == null)
            this.patientHistoryFormViewModel = new PatientHistoryFormViewModel();

        this.patientHistoryFormViewModel.CloseAllPanel = false;

    }

    public loadForPatientHistoryForEpisode() {
        let that = this;
        this.patientHistoryFormViewModel.CloseAllPanel = false;
        let fullApiUrl: string = "api/PatientHistoryService/PatientHistoryFormByEpisode?id=" + this._episode;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.patientHistoryFormViewModel.PatientHistoryBySubEpisode = result.PatientHistoryBySubEpisode;
                that.kabulmodeldt = result.PatientHistoryBySubEpisode;

                that.patientHistoryFormViewModel.PatientActionList = null;
                this.patientActionListCount = 0;
            })
            .catch(error => {
                console.log(error);
            });
    }

    public loadForPatientHistoryForSubEpisode(_useFilter: boolean) {
        let that = this;
        that.patientHistoryFormViewModel.CloseAllPanel = true;
        //let fullApiUrl: string = "api/PatientHistoryService/PatientHistoryFormBySubEpisode?id=" + that._subEpisode + "&ActionType=" + that._actionType + "&StartDate='" + that.patientHistoryFormViewModel._historyFilter.startDate +"'"+ "&EndDate=" + that.patientHistoryFormViewModel._historyFilter.endDate + "&UseFilter=" + that.patientHistoryFormViewModel._historyFilter.useFilter;
        //this.httpService.get<any>(fullApiUrl)
        //    .then(response => {
        //        let result = response;
        //        that.patientHistoryFormViewModel.PopUpHistoryList = result.PopUpHistoryList;
        //    })
        //    .catch(error => {
        //        console.log(error);
        //    });


        that.httpService.post<PopupHistory[]>("api/PatientHistoryService/PatientHistoryFormBySubEpisode", that.patientHistoryFormViewModel._historyFilter)
            .then(response => {
                that.patientHistoryFormViewModel.PopUpHistoryList = response["PopUpHistoryList"];

                if (that.patientHistoryFormViewModel.PopUpHistoryList.length > 0 && that.patientHistoryFormViewModel.PopUpHistoryList[0] != null) {
                    let _inputParam = {};
                    if (that.patientHistoryFormViewModel.CloseAllPanel == true) {
                        _inputParam['readOnlyByCode'] = true;
                    } else {
                        _inputParam = null;
                    }
                    //that.openDynamicComponent(that.patientHistoryFormViewModel.PopUpHistoryList[0].ObjectDefName, that.patientHistoryFormViewModel.PopUpHistoryList[0].ObjectID, null, _inputParam);
                    //this.isAccordionOpened = false;
                }
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    public loadForPatientHistoryByProtocolNo() {
        let that = this;
        this.patientHistoryFormViewModel.CloseAllPanel = false;
        let fullApiUrl: string = "api/PatientHistoryService/PatientHistoryFormByProtocolNo?protocolNo=" + this.protocolNo;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;

                that.patientHistoryFormViewModel.PatientId = result.PatientId;

                that.patientHistoryFormViewModel.SubEpisodeId = result.SubEpisodeId;

                that.patientHistoryFormViewModel.PatientUniqueRefNo = result.PatientUniqueRefNo;
                //Ayaktan Hasta Geçmişi
                that.patientHistoryFormViewModel.PoliclinicProcessTitle = result.PoliclinicProcessTitle;
                that.polmodeldt = result.PoliclinicProcessTitle;
                this.policlinicProcessCount = result.PoliclinicProcessTitle.length;

                //Yatan Hasta Geçmişi
                that.patientHistoryFormViewModel.ClinicProcessTitle = result.ClinicProcessTitle;
                that.klinikmodeldt = result.ClinicProcessTitle;
                this.clinicProcessCount = result.ClinicProcessTitle.length;

                //Tani Geçmişi Sayisi
                that.patientHistoryFormViewModel.DiagnosisCount = result.DiagnosisCount;

                //Radyoloji Geçmişi Sayisi
                that.patientHistoryFormViewModel.RadiologyCount = result.RadiologyCount;

                that.patientHistoryFormViewModel.LaboratoryCount = result.LaboratoryCount;

                //Patoloji Geçmişi Sayisi
                that.patientHistoryFormViewModel.PathologyCount = result.PathologyCount;
                that.patientHistoryFormViewModel.DrugOrderCount = result.DrugOrderCount;

                //Ameliyat Geçmişi
                that.patientHistoryFormViewModel.SurgeryTitles = result.SurgeryTitles;
                this.surgeryCount = result.SurgeryTitles.length;

                //Önemli Tıbbi Bilgiler
                that.patientHistoryFormViewModel.ImportantMedicalInformation = result.ImportantMedicalInformation;

                //Aşı Geçmişi Sayisi
                that.patientHistoryFormViewModel.VaccineCount = result.VaccineCount;

                //Uzmanlık Modülleri Geçmişi
                that.uzmanlikNameDt = result.SpecialityTitles;
                that.patientHistoryFormViewModel.SpecialityTitles = result.SpecialityTitles;
                for (let spec of that.patientHistoryFormViewModel.SpecialityTitles) {
                    this.specialityCount += spec.SubTitles.length;
                    for (let titles of spec.SubTitles)
                        this.uzmanlikmodeldt.push(titles);
                }

                //Hizmet ve Tetkik
                that.patientHistoryFormViewModel.RequestedProceduresCount = result.RequestedProceduresCount;

                //Malzeme ve sarf
                that.patientHistoryFormViewModel.TreatmentMaterialsCount = result.TreatmentMaterialsCount;

                //Acil Geçmişi
                that.patientHistoryFormViewModel.EmergencyObjectTitle = result.EmergencyObjectTitle;
                this.emergencyObjectCount = result.EmergencyObjectTitle.length;

                //Diyet
                that.patientHistoryFormViewModel.DietOrdersCount = result.DietOrdersCount;

                //Manipulasyon Geçmişi
                that.patientHistoryFormViewModel.ManipulationProcessTitle = result.ManipulationProcessTitle;
                that.manipulationmodeldt = result.ManipulationProcessTitle;
                this.manipulationProcessCount = result.ManipulationProcessTitle.length;

                //Fizyoterapi Geçmişi
                that.patientHistoryFormViewModel.PhysiotherapyRequestsTitles = result.PhysiotherapyRequestsTitles;
                this.physiotherapyRequestCount = result.PhysiotherapyRequestsTitles.length;


                /////////// /////////// /////////// /////////// /////////// /////////// ///////////
                //Kabul Bazlı Poliklinik/Ayaktan Hasta Geçmişi
                that.patientHistoryFormViewModel.PatientHistoryBySubEpisode = result.PatientHistoryBySubEpisode;
                that.kabulmodeldt = result.PatientHistoryBySubEpisode;

                that.patientHistoryFormViewModel.AllProceduresLink = result.AllProceduresLink;
                that.patientHistoryFormViewModel.AllLabProceduresLink = result.AllLabProceduresLink;

                that.patientHistoryFormViewModel.PatientActionList = null;
                this.patientActionListCount = 0;
            })
            .catch(error => {
                console.log(error);
            });
    }

    public loadForPatientHistory() {
        let that = this;
        this.patientHistoryFormViewModel.CloseAllPanel = false;
        let fullApiUrl: string = "api/PatientHistoryService/PatientHistoryForm?id=" + this._patient;
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;

                that.patientHistoryFormViewModel.PatientId = result.PatientId;
                that.patientHistoryFormViewModel.PatientUniqueRefNo = result.PatientUniqueRefNo;
                //Ayaktan Hasta Geçmişi
                that.patientHistoryFormViewModel.PoliclinicProcessTitle = result.PoliclinicProcessTitle;
                that.polmodeldt = result.PoliclinicProcessTitle;
                this.policlinicProcessCount = result.PoliclinicProcessTitle.length;

                //Yatan Hasta Geçmişi
                that.patientHistoryFormViewModel.ClinicProcessTitle = result.ClinicProcessTitle;
                that.klinikmodeldt = result.ClinicProcessTitle;
                this.clinicProcessCount = result.ClinicProcessTitle.length;

                //Tani Geçmişi Sayisi
                that.patientHistoryFormViewModel.DiagnosisCount = result.DiagnosisCount;

                //Radyoloji Geçmişi Sayisi
                that.patientHistoryFormViewModel.RadiologyCount = result.RadiologyCount;

                that.patientHistoryFormViewModel.LaboratoryCount = result.LaboratoryCount;

                //Patoloji Geçmişi Sayisi
                that.patientHistoryFormViewModel.PathologyCount = result.PathologyCount;
                that.patientHistoryFormViewModel.DrugOrderCount = result.DrugOrderCount;

                //Ameliyat Geçmişi
                that.patientHistoryFormViewModel.SurgeryTitles = result.SurgeryTitles;
                this.surgeryCount = result.SurgeryTitles.length;

                //Önemli Tıbbi Bilgiler
                that.patientHistoryFormViewModel.ImportantMedicalInformation = result.ImportantMedicalInformation;

                //Aşı Geçmişi Sayisi
                that.patientHistoryFormViewModel.VaccineCount = result.VaccineCount;

                //Uzmanlık Modülleri Geçmişi
                that.uzmanlikNameDt = result.SpecialityTitles;
                that.patientHistoryFormViewModel.SpecialityTitles = result.SpecialityTitles;
                for (let spec of that.patientHistoryFormViewModel.SpecialityTitles) {
                    this.specialityCount += spec.SubTitles.length;
                    for (let titles of spec.SubTitles)
                        this.uzmanlikmodeldt.push(titles);
                }

                //Hizmet ve Tetkik
                that.patientHistoryFormViewModel.RequestedProceduresCount = result.RequestedProceduresCount;

                //Malzeme ve sarf
                that.patientHistoryFormViewModel.TreatmentMaterialsCount = result.TreatmentMaterialsCount;

                //Acil Geçmişi
                that.patientHistoryFormViewModel.EmergencyObjectTitle = result.EmergencyObjectTitle;
                this.emergencyObjectCount = result.EmergencyObjectTitle.length;

                //Diyet
                that.patientHistoryFormViewModel.DietOrdersCount = result.DietOrdersCount;

                //Manipulasyon Geçmişi
                that.patientHistoryFormViewModel.ManipulationProcessTitle = result.ManipulationProcessTitle;
                that.manipulationmodeldt = result.ManipulationProcessTitle;
                this.manipulationProcessCount = result.ManipulationProcessTitle.length;

                //Fizyoterapi Geçmişi
                that.patientHistoryFormViewModel.PhysiotherapyRequestsTitles = result.PhysiotherapyRequestsTitles;
                this.physiotherapyRequestCount = result.PhysiotherapyRequestsTitles.length;


                /////////// /////////// /////////// /////////// /////////// /////////// ///////////
                //Kabul Bazlı Poliklinik/Ayaktan Hasta Geçmişi
                that.patientHistoryFormViewModel.PatientHistoryBySubEpisode = result.PatientHistoryBySubEpisode;
                that.kabulmodeldt = result.PatientHistoryBySubEpisode;

                that.patientHistoryFormViewModel.AllProceduresLink = result.AllProceduresLink;
                that.patientHistoryFormViewModel.AllLabProceduresLink = result.AllLabProceduresLink;

                that.patientHistoryFormViewModel.PatientActionList = null;
                this.patientActionListCount = 0;
            })
            .catch(error => {
                console.log(error);
            });
    }

    async ngOnInit() {
        let that = this;
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        //this.Controls = [];

    }
    keyDownForNumericControl(event: any) {

        if (event != null && event.srcElement != null && event.srcElement.value != null && event.srcElement.value.length < 11 && !(new RegExp('[\.,]', 'g')).test(event.key)) {

        }
        else {
            event.preventDefault();
        }
    }

    public btnTeleTIP_Click() {

        if (this.patientHistoryFormViewModel.PatientUniqueRefNo != null) {
            let that = this;

            this.httpService.get<any>("api/PatientHistoryService/GetRadiologyTestDef")
            .then(response => {
                this.RadiologyDefList = response;
                this.showRadiologyProcedures = true;
            })
            .catch(error => {
                ServiceLocator.MessageService.showError("HATA KODU : " + error);
            });

            // let fullApiUrl: string = "api/PatientHistoryService/GetTeleTIPUrl?patientUniqueRefNo=" + this.patientHistoryFormViewModel.PatientUniqueRefNo;
            
            // this.httpService.get<any>(fullApiUrl)
            //     .then(response => {
            //         let result = response;
            //         this.openPersonnelLink(result);
            //     })
            //     .catch(error => {
            //         ServiceLocator.MessageService.showError("HATA KODU : " + error);
            //     });
        } else {
            ServiceLocator.MessageService.showError("Tele Tıp İstenilen Hastayı seçiniz!");
        }

    }
    public openPersonnelLink(URL: any) {

        if (URL != null) {
            window.open(URL, '_blank');
            window.focus();
        } else {
            ServiceLocator.MessageService.showError("HATA KODU : " + URL);
        }
    }

    /* POP UP HISTORY BEGIN*/
    async selectPopupGrid(value: any): Promise<void> {
        let _inputParam = {};
        _inputParam['readOnlyByCode'] = true;
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            let _data: PopupHistory = value.data as PopupHistory;
            this.loadPanelOperation(true, 'Form hazırlanıyor, lütfen bekleyiniz.');
            this.openDynamicComponent(_data.ObjectDefName, _data.ObjectID, null, _inputParam);
            this.isAccordionOpened = false;
        }

    }

    public btnSearchClicked(e: any) {
        this.patientHistoryFormViewModel._historyFilter.useFilter = true;
        this.loadForPatientHistoryForSubEpisode(true);
    }

    onActionTypeChanged(e: any): void {
        this.patientHistoryFormViewModel._historyFilter.actionType = e.value;
    }

    onSelectAllChanged(e: any): void {
        this.patientHistoryFormViewModel._historyFilter.selectAll = e.value;
    }

    public componentCreated(e: any) {
        this.loadPanelOperation(false, '');
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }


    /* POP UP HISTORY END*/

    printPathologyReport(data: PathologyData) {
        let disablePrintButton: boolean = false;
        if (data.IsApproved == true)
            disablePrintButton = true;

        let reportData: DynamicReportParameters = {

            Code: 'PATOLOJISONUCRAPOR',
            ReportParams: { ObjectID: data.ObjectID },
            ViewerMode: true,
            DisablePrintButtons: disablePrintButton
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "PATOLOJI SONUÇ RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    showPathologyInfo(pathologyObjectID: Guid): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PathologyMainForm";
            componentInfo.ModuleName = "PatolojiModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule";
            componentInfo.InputParam = pathologyObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20256", "Patoloji Rapor");
            modalInfo.Width = 1300;
            modalInfo.Height = 950;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    closePopup()
    {
        let that = this;
        if(that.selectedProcedures != null && that.selectedProcedures.length > 10)
            that.messageService.showInfo("En fazla 10 tane tetkik için sorgulama yapabilirsiniz");
        else if(that.selectedProcedures == null || that.selectedProcedures.length == 0)
            that.messageService.showInfo("En az 1 tane tetkik seçmeniz gerekmektedir");
        else
        {            
            let input_DVO = new TeletipInput_DVO();
            input_DVO.PatientCitizenId = that.patientHistoryFormViewModel.PatientUniqueRefNo;
            input_DVO.SUTCodeList = that.selectedProcedures.map(x=> x["SUTCode"]);

            that.httpService.post<Array<TeletipResult_Output>>("api/EpisodeActionService/GetTeletipHistoryWithSutCode", input_DVO)
            .then(response => {
                that.PreviousStudies = response;
                that.showRadiologyProcedures = false;
                that.selectedProcedures = [];
            })
            .catch(error => {
                that.messageService.showError(error);

            });
        }

    }

    public async openImaj(event) {
        if (event.row != null) {

            if (event.row.data != null) {
                if (event.row.data.IsStudyExist) {
                    // let apiUrl: string = 'api/EpisodeActionService/OpenTeletipImaj?OrderID='+event.row.data.OrderId;

                    // this.PreviousStudies = await this.httpService.get<any>(apiUrl);
                    let teletipImaj_Input: TeletipImaj_Input = new TeletipImaj_Input();

                    teletipImaj_Input.AccessToken = "";
                    teletipImaj_Input.PatientCitizenId = this.patientHistoryFormViewModel.PatientUniqueRefNo;
                    teletipImaj_Input.AccessionNumber = event.row.data.AccessionNumber;
                    teletipImaj_Input.DoctorCitizenId = "";

                    let apiUrl: string = 'api/EpisodeActionService/OpenTeletipImaj';
                    let result = await this.httpService.post<any>(apiUrl, teletipImaj_Input);

                    let win = window.open(result, '_blank');
                    win.focus();
                }
                else {
                    this.messageService.showInfo("Çekime ait görüntü mevcut değil");
                    return false;
                }
                
            }
        }
    }


}
