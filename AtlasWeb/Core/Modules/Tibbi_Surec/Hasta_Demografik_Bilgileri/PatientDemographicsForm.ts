//$6CAD7A47
import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { PatientDemographicsViewModel, DynamicComponentInfoDVO, PatientDetailsViewModel, AllergyTypesDetails } from './PatientDemographicsViewModel';
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { MedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { IModalService } from "Fw/Services/IModalService";

import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";

import { NeHttpService } from "Fw/Services/NeHttpService";

import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';

@Component({
    selector: "patient-demographics-form",
    inputs: ['patientDemographicsViewModel'],
    templateUrl: './PatientDemographicsForm.html',
    outputs: ['PatientDemographicInfoLoaded']
})


export class PatientDemographicsForm extends TTUnboundForm implements OnInit {
    patientDemographicsViewModel: PatientDemographicsViewModel;
    constructor(protected httpService: NeHttpService, private modalService: IModalService, private sideBarMenuService: ISidebarMenuService
    ) {
        super("", "");
    }
    clientPostScript(state: String) {

    }

    public _ClearModel: boolean = false;
    @Input() set ClearModel(value: boolean) {
        this._ClearModel = value;
        if (this._ClearModel)
            this.ClearLoadedViewModel();

    }

    private _ShowFromResource: boolean = false;
    @Input() set ShowFromResource(value: boolean) {
        this._ShowFromResource = value;
    }

    public _AddButtonShowable: boolean = false;
    @Input() set AddButtonShowable(value: boolean) {
        this._AddButtonShowable = value;
    }

    public _showAllergyInfo: boolean = true;
    @Input() set ShowAllergyInfo(value: boolean) {
        this._showAllergyInfo = value;
    }

    private _actionId: string;
    @Input() set actionId(value: string) {
        this._actionId = value;
        if (this._actionId) {
            this.GetInfo(this._actionId);
            this.GetDetailsInfo(this._actionId);
        }
    }
    get actionId(): string {
        return this._actionId;
    }

    private _admissionId: string;
    @Input() set admissionId(value: string) {
        this._admissionId = value;
        if (this._admissionId) {
            this.GetInfoByPatientAdmissionId(this._admissionId);
        }
    }
    get admissionId(): string {
        return this._admissionId;
    }


    private _PatientId: string;
    @Input() set PatientId(value: string) {
        this._PatientId = value;
        if (this._PatientId) {
            this.GetInfoByPatientId(this._PatientId);
        }

        
    }
    get PatientId(): string {
        return this._PatientId;
    }

    async ngOnInit() {
        if (this.ObjectID) {
            await this.GetInfo(this.ObjectID.toString());
        }
        this.AddHelpMenu();

    }
    PatientDemographicInfoLoaded: EventEmitter<any> = new EventEmitter<any>();


    private async CalculateAge(birthDate: Date): Promise<number> {
        let age: number = Convert.ToInt32(new Date().getFullYear()) - Convert.ToInt32(birthDate.getFullYear());
        if (new Date().getMonth() < birthDate.getMonth()) {
            age = age - 1;
        }
        return age;
    }

    ClearLoadedViewModel() {
        this.patientDemographicsViewModel.name = null;
        this.patientDemographicsViewModel.surname = null;
        this.patientDemographicsViewModel.fatherName = null;
        this.patientDemographicsViewModel.age = null;
        this.patientDemographicsViewModel.refNo = null;
        this.patientDemographicsViewModel.payerName = null;
        this.patientDemographicsViewModel.policlinicName = null;
        this.patientDemographicsViewModel.admissionDate = null;
        this.patientDemographicsViewModel.admissionType = null;
        this.patientDemographicsViewModel.provisionNo = null;
        this.patientDemographicsViewModel.hospitalProtocolNo = null;
        this.patientDemographicsViewModel.profilPhotoPath = null;
        this.patientDemographicsViewModel.gender = null;
        this.patientDemographicsViewModel.admissionDoctor = null;
        this.patientDemographicsViewModel.patientGuidID = null;
        this.patientDemographicsViewModel.medicalInformationGuidID = null;
        this.patientDemographicsViewModel.hasMedicalInformation = null;
        this.patientDemographicsViewModel.isPregnant = null;
        this.patientDemographicsViewModel.pregnancyWeekInfo = null;
        this.patientDemographicsViewModel.isHighRiskPregnant = null;
        this.patientDemographicsViewModel.Pandemic = null;
        this.patientDemographicsViewModel.inpatientClinicDate = null;
        this.patientDemographicsViewModel.responsibleNurse = null;
        this.patientDemographicsViewModel.SubEpisodeProtocolNo = null;
        this.patientDemographicsViewModel.PoliclinicProtocolNo = null;

        this.patientDemographicsViewModel.PatientClassGroup = null;
        this.patientDemographicsViewModel.ApplicationReason = null;

        this.patientDemographicsViewModel.ShowType = null;

        this.patientDemographicsViewModel.InpatientClinicDischargeDate = null;
        this.patientDemographicsViewModel.InpatientDay = null;
        this.patientDemographicsViewModel.InpatientType = null;
        this.patientDemographicsViewModel.IsInpatientTypeDischarge = null;
        this.patientDemographicsViewModel.ClinicProtocolNo = null;
        this.patientDemographicsViewModel.RoomGroup = null;
        this.patientDemographicsViewModel.Room = null;
        this.patientDemographicsViewModel.Bed = null;
        this.patientDemographicsViewModel.MedulaSigortaTuru = null;
        this.patientDemographicsViewModel.PatientType = null;
        this.patientDemographicsViewModel.HasAirborneContactIsolation = null;
        this.patientDemographicsViewModel.HasContactIsolation = null;
        this.patientDemographicsViewModel.HasDropletIsolation = null;
        this.patientDemographicsViewModel.HasFallingRisk = null;
        this.patientDemographicsViewModel.HasTightContactIsolation = null;


    }
    public showimportantPatientInfo = false;
    public showPandemiWarning = false;
    public pandemiInfoString = "";

    public showPregnancyWeekInfo = false;

    async loadViewModel(result) {
        this._ClearModel = false;

        this.patientDemographicsViewModel.name = result.name;
        this.patientDemographicsViewModel.surname = result.surname;
        this.patientDemographicsViewModel.fatherName = result.fatherName;
        this.patientDemographicsViewModel.age = result.age;
        this.patientDemographicsViewModel.importantPatientInfo = result.importantPatientInfo;
        this.patientDemographicsViewModel.refNo = result.refNo;
        this.patientDemographicsViewModel.payerName = result.payerName;
        this.patientDemographicsViewModel.policlinicName = result.policlinicName;
        this.patientDemographicsViewModel.admissionDate = result.admissionDate;
        this.patientDemographicsViewModel.admissionType = result.admissionType;
        this.patientDemographicsViewModel.provisionNo = result.provisionNo;
        this.patientDemographicsViewModel.hospitalProtocolNo = result.hospitalProtocolNo;
        this.patientDemographicsViewModel.profilPhotoPath = result.profilPhotoPath;
        this.patientDemographicsViewModel.gender = result.gender;
        this.patientDemographicsViewModel.admissionDoctor = result.admissionDoctor;
        this.patientDemographicsViewModel.patientGuidID = result.patientGuidID;
        this.patientDemographicsViewModel.medicalInformationGuidID = result.medicalInformationGuidID;
        this.patientDemographicsViewModel.hasMedicalInformation = result.hasMedicalInformation;
        this.patientDemographicsViewModel.isPregnant = result.isPregnant;
        this.patientDemographicsViewModel.pregnancyWeekInfo = result.pregnancyWeekInfo;
        this.patientDemographicsViewModel.isHighRiskPregnant = result.isHighRiskPregnant;
        this.patientDemographicsViewModel.Pandemic = result.Pandemic;
        this.patientDemographicsViewModel.inpatientClinicDate = result.inpatientClinicDate;
        this.patientDemographicsViewModel.responsibleNurse = result.responsibleNurse;
        this.patientDemographicsViewModel.SubEpisodeProtocolNo = result.SubEpisodeProtocolNo;
        this.patientDemographicsViewModel.PoliclinicProtocolNo = result.PoliclinicProtocolNo;

        this.patientDemographicsViewModel.PatientClassGroup = result.PatientClassGroup;
        this.patientDemographicsViewModel.ApplicationReason = result.ApplicationReason;

        this.patientDemographicsViewModel.ShowType = result.ShowType;

        this.patientDemographicsViewModel.InpatientClinicDischargeDate = result.InpatientClinicDischargeDate;
        this.patientDemographicsViewModel.InpatientDay = result.InpatientDay;
        this.patientDemographicsViewModel.InpatientType = result.InpatientType;
        this.patientDemographicsViewModel.IsInpatientTypeDischarge = result.IsInpatientTypeDischarge;
        this.patientDemographicsViewModel.ClinicProtocolNo = result.ClinicProtocolNo;
        this.patientDemographicsViewModel.RoomGroup = result.RoomGroup;
        this.patientDemographicsViewModel.Room = result.Room;
        this.patientDemographicsViewModel.Bed = result.Bed;
        this.patientDemographicsViewModel.MedulaSigortaTuru = result.MedulaSigortaTuru;
        this.patientDemographicsViewModel.IsPatientAllergic = result.IsPatientAllergic;

        if (this.patientDemographicsViewModel.Pandemic == true) {
            this.pandemiInfoString = " Bu Hasta da Covid-19 şüphesi mevcuttur. Lütfen Gerekli tedbirleri alınız";
            this.showPandemiWarning = true;
        }

        if (this.patientDemographicsViewModel.IsPatientAllergic == true) {
            this.IsAllergicAlertShown = true;
            await this.getPatientAllergies(this.patientDemographicsViewModel.patientGuidID);
            /*  if (this._showAllergyInfo == true)
                  TTVisual.InfoBox.Alert("HASTANIN ALERJİSİ VAR!");  */
        }
        this.patientDemographicsViewModel.PatientType = result.PatientType;
        this.patientDemographicsViewModel.HasAirborneContactIsolation = result.HasAirborneContactIsolation;
        this.patientDemographicsViewModel.HasContactIsolation = result.HasContactIsolation;
        this.patientDemographicsViewModel.HasDropletIsolation = result.HasDropletIsolation;
        this.patientDemographicsViewModel.HasFallingRisk = result.HasFallingRisk;
        this.patientDemographicsViewModel.HasTightContactIsolation = result.HasTightContactIsolation;
        this.patientDemographicsViewModel.bloodGroup = result.bloodGroup;
        this.patientDemographicsViewModel.archiveNo = result.archiveNo;
        this.PatientDemographicInfoLoaded.emit(result);

        if (result.importantPatientInfo != null && result.importantPatientInfo != "") {
            this.showimportantPatientInfo = true;
            // TTVisual.InfoBox.Alert(this._ViewModel.returnMessage);
        }
        if (result.pregnancyWeekInfo != null && result.pregnancyWeekInfo != "") {
            this.showPregnancyWeekInfo = true;
        }
        this.getPatientDocsCount(this.patientDemographicsViewModel.patientGuidID);
        this._AddButtonShowable = true;
    }

    public patientDocumentCount: number = 0;
    public getPatientDocsCount(patientId) {
        let apiURL: string = "api/PatientDocumentsService/GetPatientDocumentCount";
        let param: GetDocumentCount_Input = new GetDocumentCount_Input();
        param.patientID = patientId;
        this.httpService.post<number>(apiURL, param).then(
            x => {
                this.patientDocumentCount = x;
            });
    }

    public foodBool = false;
    public drugBool = false;
    public showWarning: boolean = false;
    public FoodAllergyDetail: string = "";
    public DrugAllergyDetail: string = "";
    public writeAllergyWarning(model: PatientDemographicsViewModel) {
        if (model.IsPatientAllergic == true) {
            if (this._showAllergyInfo == true) {

                if (model.allergyDetail.drugAllergies != null) {
                    this.DrugAllergyDetail = " Hastanın " + model.allergyDetail.drugAllergies + " etken maddesine alerjisi vardır.";
                    this.drugBool = true;
                }
                if (model.allergyDetail.foodAllergies != null) {
                    this.FoodAllergyDetail = " Hastanın " + model.allergyDetail.foodAllergies + " gıda maddesine alerjisi vardır.";
                    this.foodBool = true;

                }
                /* TTVisual.InfoBox.Alert( " Hastanın "+
                 model.allergyDetail.drugAllergies + " etken maddesine alerjisi vardır. " + "                            <i style=\"color:#e06b6b;float:right;margin-right:20px\" class=\"fa fa-exclamation-triangle fa-2x\" data-toggle=\"tooltip\" data-placement=\"bottom\" ></i>"+ "<br>" +" Hastanın "+ model.allergyDetail.foodAllergies+ " gıda maddesine alerjisi vardır.");*/
                if (this.drugBool == false && this.foodBool == false) {
                    this.showWarning = false;
                }
                else {
                    this.showWarning = true;
                }
            }
        }
    }


    public allergyModel: AllergyTypesDetails;
    public async getPatientAllergies(patientId: string) {

        this.allergyModel = new AllergyTypesDetails();

        let apiUrlForPASearchUrl: string = '/api/PatientDemographicsService/loadPatientAllergyDetail?patientObjectId=' + patientId;
        await this.httpService.get<AllergyTypesDetails>(apiUrlForPASearchUrl).then(response => {
            this.patientDemographicsViewModel.allergyDetail = response;
            this.writeAllergyWarning(this.patientDemographicsViewModel);
        });

    }



    public async GetInfoByPatientAdmissionId(admissionId: string) {

        this.patientDemographicsViewModel = new PatientDemographicsViewModel();

        let fullApiUrl: string = "api/PatientDemographicsService/GetMyPatientDemographicInfoByPatientAdmission?patientAdmissionObjectId=" + admissionId;
        let response = await this.httpService.get<PatientDemographicsViewModel>(fullApiUrl);
        this.loadViewModel(response);
    }

    public async GetInfoByPatientId(patientId: string) {

        this.patientDemographicsViewModel = new PatientDemographicsViewModel();

        let fullApiUrl: string = "api/PatientDemographicsService/GetMyPatientDemographicInfoByPatient?patientObjectId=" + patientId;
        let response = await this.httpService.get<PatientDemographicsViewModel>(fullApiUrl);
        this.loadViewModel(response);
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let patientDetails = new DynamicSidebarMenuItem();
        patientDetails.key = 'patientDetails';
        patientDetails.label = 'Hasta Detay Bilgisi';
        patientDetails.icon = 'ai ai-hasta-detay';
        patientDetails.componentInstance = this;
        patientDetails.clickFunction = this.showPatientDetails;
        this.sideBarMenuService.addMenu('YardimciMenu', patientDetails);

    }
    private RemoveMenuFromHelpMenu() {
        this.sideBarMenuService.removeMenu('patientDetails');
    }

    public async GetInfo(actionId: string) {

        this.patientDemographicsViewModel = new PatientDemographicsViewModel();

        let fullApiUrl: string = "api/PatientDemographicsService/GetMyPatientDemographicInfo?actionId=" + actionId + "&_ShowFromResource=" + this._ShowFromResource;
        let response = await this.httpService.get<PatientDemographicsViewModel>(fullApiUrl);
        this.loadViewModel(response);
    }

    showPatientDetailsPopup: boolean = false;
    showPatientDetails() {
        this.showPatientDetailsPopup = true;
    }
    patientDetailsViewModel: PatientDetailsViewModel;
    public async GetDetailsInfo(actionId: string) {

        this.patientDetailsViewModel = new PatientDetailsViewModel();

        let fullApiUrl: string = "api/PatientDemographicsService/GetMyPatientDetailsInfo?actionId=" + actionId + "&_ShowFromResource=" + this._ShowFromResource;
        this.patientDetailsViewModel = await this.httpService.get<PatientDetailsViewModel>(fullApiUrl);
    }

    openMedicalInfo(): void {
        this.showMedicalInformation().then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result == DialogResult.OK) {
                let obj = result.Param as MedicalInformation;
            }
        });
        this.IsAllergicAlertShown = false;
    }

    private async showMedicalInformation(): Promise<ModalActionResult> {
        let that = this;
        if (that.patientDemographicsViewModel.medicalInformationGuidID == null || that.patientDemographicsViewModel.medicalInformationGuidID == "") {
            let fullApiUrl: string = "api/PatientDemographicsService/GetMedicalInformationId?patientID=" + this.patientDemographicsViewModel.patientGuidID;
            that.patientDemographicsViewModel.medicalInformationGuidID = await this.httpService.get<any>(fullApiUrl);
        }

        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MedicalInformationForm";
            componentInfo.ModuleName = "OnemliTibbiBilgilerModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Onemli_Tibbi_Bilgiler/OnemliTibbiBilgilerModule";
            //if (this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode.Patient["MedicalInformation"] != null)
            if (that.patientDemographicsViewModel.medicalInformationGuidID != null && that.patientDemographicsViewModel.medicalInformationGuidID != "") {
                componentInfo.objectID = that.patientDemographicsViewModel.medicalInformationGuidID;
            }
            componentInfo.InputParam = new DynamicComponentInputParam(null, new ActiveIDsModel(null, null, new Guid(that.patientDemographicsViewModel.patientGuidID)));//that.patientDemographicsViewModel.patientGuidID.toString(); // yeni medical info oluşturursa

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20020", "Önemli Tıbbi Bilgiler");
            modalInfo.Width = 800;
            modalInfo.Height = 700;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    patientDocumentDownload() {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PatientDocumentDownloadForm';
            componentInfo.ModuleName = "HastaDokumantasyonModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Dokumantasyon_Modulu/HastaDokumantasyonModule';
            componentInfo.InputParam = this.patientDemographicsViewModel.patientGuidID;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15180", "Hasta Dosyalarını Görüntüle");
            modalInfo.Width = 1000;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public IsAllergicAlertShown: boolean = false;
}

export class GetDocumentCount_Input {
    patientID: Guid;
}
