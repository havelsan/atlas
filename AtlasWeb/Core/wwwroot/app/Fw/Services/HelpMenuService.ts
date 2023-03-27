//$A594DBE2
import { Injectable, EventEmitter } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

//Yard�mc� ��lemler i�in
import { MedicalInformation, CreatingEpicrisis, HemodialysisInstruction, FollowingPatients, PatientFollowingTypeEnum, SafeSurgeryCheckList } from 'NebulaClient/Model/AtlasClientModel';

import { NeHttpService } from "Fw/Services/NeHttpService";
import { IModalService } from "Fw/Services/IModalService";
import { MessageService } from "Fw/Services/MessageService";
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { EpisodeActionHelper } from "app/Helper/EpisodeActionHelper";
import { VaccineFollowUp } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';

import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { Surgery, SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { MultiSelectForm } from 'NebulaClient/Visual/MultiSelectForm';

import { Consultation } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection, EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { InpatientTreatmentBarcodeInfo } from 'app/Barcode/Models/InpatientTreatmentBarcodeInfo';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';

import { ConsultationRequestFormResourceInfo } from 'Modules/Tibbi_Surec/Konsultasyon_Modulu/ConsultationRequestFormViewModel';
import { PathologyRequest } from 'NebulaClient/Model/AtlasClientModel';

import { RegularObstetric } from 'NebulaClient/Model/AtlasClientModel';
import { HemodialysisRequest } from 'NebulaClient/Model/AtlasClientModel';

import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ForensicMedicalReport } from 'NebulaClient/Model/AtlasClientModel';

import { componentName } from 'devexpress-dashboard/model/index.metadata';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { AppointmentFormViewModel } from 'Modules/Tibbi_Surec/Randevu_Modulu/AppointmentFormViewModel';
import { GiveAppointmentModel, ActiveIDsModel, ConsultationRequestParametersModel, ClickFunctionParams } from '../Models/ParameterDefinitionModel';
import { DynamicReportParameters } from '../Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { InpatientWristBarcodeInfo } from 'app/Barcode/Models/InpatientWristBarcodeInfo';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { InputObject } from 'Modules/Tibbi_Surec/Evde_Saglik_Hizmetleri_Modulu/EvdeSaglikBasvuruSorgulaSilForm';
import { PatientArchieveBarcodeInfo } from '../../Barcode/Models/PatientBarcodeInfo';
import { LaboratoryWorkListItemMasterModel, ProcedureInfoInputDVO, TubeInformation, ProcedureInfoOutputDVO } from 'Modules/Tibbi_Surec/Laboratuar_Is_Listesi/LaboratoryWorkListFormViewModel';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { DatePipe } from '@angular/common';
import { LaboratoryBarcodeInfo } from 'app/Barcode/Models/LaboratoryBarcodeInfo';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { MHRS_YesilListeSorgula_OutPut } from '../../../../Modules/Tibbi_Surec/Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';

@Injectable()
export class HelpMenuService implements IDestroyEvent {
    ///YARDIMCI ��LEMLER ���N FONKS�YONLAR
    constructor(protected httpService: NeHttpService, protected modalService: IModalService, protected messageService: MessageService, protected episodeActionHelper: EpisodeActionHelper, protected objectContextService: ObjectContextService, private reportService: AtlasReportService, private barcodePrintService: IBarcodePrintService) {

    }
    OnDestroy: EventEmitter<any> = new EventEmitter<any>();

    onMedicalInformationOpen(data: any) {
        this.showMedicalInformation(data).then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result == DialogResult.OK) {
                let obj = result.Param as MedicalInformation;
            }
        });
    }
    showMedicalInformation(patientID): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MedicalInformationForm";
            componentInfo.ModuleName = "OnemliTibbiBilgilerModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Onemli_Tibbi_Bilgiler/OnemliTibbiBilgilerModule";
            componentInfo.objectID = patientID.toString();

            componentInfo.InputParam = patientID.toString();


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20020", "Önemli Tıbbi Bilgiler");
            modalInfo.Width = 800;
            modalInfo.Height = 950;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onVaccineFollowUpOpen(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episode = model.episodeId;
        this.episodeActionHelper.getNewEpisodeAction(VaccineFollowUp.ObjectDefID, episode, VaccineFollowUp.VaccineFollowUpStates.New).then(result => {

            let vaccinefollowup: VaccineFollowUp = result as VaccineFollowUp;

            //vaccinefollowup.ProcedureDoctor = this._ChildGrowthVisits.PhysicianApplication.ProcedureDoctor;


            this.showVaccineFollowUp(vaccinefollowup, data).then(result => {
                let modalActionResult = result as ModalActionResult;
                if (modalActionResult.Result == DialogResult.OK) {
                    let obj = result.Param as VaccineFollowUp;
                }
            });
        }).catch(err => {
            this.messageService.showError(err);
        });
    }


    showVaccineFollowUp(data: VaccineFollowUp, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "VaccineFollowUpForm";
            componentInfo.ModuleName = "AsiTakipModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Asi_Takip_Modulu/AsiTakipModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M11213", "Aşı Takip");
            modalInfo.Width = 1300;
            modalInfo.Height = 750;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public onSendENabizMessageOpen(data: ClickFunctionParams): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();

            componentInfo.ComponentName = "SendMessageToPatientForm";
            componentInfo.ModuleName = "NabizHBYSModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Nabiz_HBYS_Modulu/NabizHBYSModule";
            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15272", "Hasta Mesaj Gönder");
            modalInfo.Width = 500;
            modalInfo.Height = 300;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public showPatientENabizInfo(data: ClickFunctionParams) {
        let that = this;
        let model: ActiveIDsModel = data.Params;
        let episodeActionId = model.episodeActionId;
        let patientId = model.patientId;
        let apiUrl: string = '/api/PatientExaminationService/ShowPatientENabizInfo?episodeActionObjectID=' + episodeActionId + '&patientObjectID=' + patientId;

        that.httpService.get<string>(apiUrl)
            .then(response => {
                let result = response;
                if (result != "") {
                    let nabizURL = "http://xxxxxx.com/DoktorErisim/home?Token=" + result;
                    let win = window.open(nabizURL, '_blank');
                    win.focus();
                }
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    //<Manipulasyon İstek
    public openManipulationRequest(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let that = this;
        if (model.episodeId != null) {
            this.objectContextService.getNewObject<ManipulationRequest>(ManipulationRequest.ObjectDefID, ManipulationRequest).then(result => {
                let manipulationRequest: ManipulationRequest = result;
                that.showManipulationRequest(manipulationRequest, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as ManipulationRequest;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError('Tıbbi/Cerrahi Uygulama isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }
    }

    //<Ortez İstek
    public openOrthesisProcedure(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        if (model.episodeId != null) {
            this.objectContextService.getNewObject<OrthesisProsthesisRequest>(OrthesisProsthesisRequest.ObjectDefID, OrthesisProsthesisRequest).then(result => {
                let orthesis: OrthesisProsthesisRequest = result;
                this.startOrthesisProcedure(orthesis, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as OrthesisProsthesisRequest;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError('Ortez/Protez isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }
    }
    private startOrthesisProcedure(data: OrthesisProsthesisRequest, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'OrthesisProsthesisRequestForm';
            componentInfo.ModuleName = 'OrtezProtezModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Ortez_Protez_Modulu/OrtezProtezModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M19778", "Ortez Protez İstek");
            modalInfo.Width = 1300;
            modalInfo.Height = 770;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Ortez İstek>

    //Renkli Reçete
    public async openColorPrescription(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let that = this;
        let episodeActionID = model.episodeActionId;
        let episodeAction: EpisodeAction = await this.objectContextService.getObject<EpisodeAction>(episodeActionID, EpisodeAction.ObjectDefID);
        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSON';
        let input = { 'SubEpisodeObjectID': episodeAction.SubEpisode };
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    public async openColorPrescriptionForApproval_Ecz() {
        let that = this;

        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSONForApproval';
        let input = { 'kullaniciTipi': '3' };
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    public async openColorPrescriptionForApproval_Ehu() {
        let that = this;

        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSONForApproval';
        let input = { 'kullaniciTipi': '2' };
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    //LIS Tetkik Bilgileri getirme
    public async getLISTestDefinitions() {

        let that = this;
        let fullApiUrl: string = "api/LaboratoryWorkListService/ReadTestDefinitionInfoFromLIS";
        let result = await this.httpService.get(fullApiUrl);
    }



    public showManipulationRequest(data: ManipulationRequest, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ManipulationRequestForm';
            componentInfo.ModuleName = 'ManipulasyonModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Manipulasyon_Modulu/ManipulasyonModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Tıbbi/Cerrahi Uygulama İstek';
            modalInfo.Width = 1300;
            modalInfo.Height = 770;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Manipulasyon İstek>

    //<MHRS Yeşil Listeye Ekle
    public async addMHRSGreenList(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeActionID = model.episodeActionId;
        try {
            if (episodeActionID != null) {
                let minorSpecialities = <SpecialityDefinition[]>await this.httpService.get('/api/PatientExaminationService/getMinorSpecialities');

                let multiSelectForm: MultiSelectForm = new MultiSelectForm();
                for (let item of minorSpecialities) {
                    multiSelectForm.AddMSItem((<SpecialityDefinition>item).Name, (<SpecialityDefinition>item).Name, (<SpecialityDefinition>item));
                }
                let mkey: string = await multiSelectForm.GetMSItem(this, i18n("M24269", "Yandal Seçiniz"), true);
                //alert(mkey);
                //console.log(mkey);
                //console.log(multiSelectForm.MSSelectedItemObject);
                let specialityDefinition: SpecialityDefinition;
                specialityDefinition = multiSelectForm.MSSelectedItemObject as SpecialityDefinition;


                if (specialityDefinition.IsMinorSpeciality == true && specialityDefinition.MHRSClinicCode != null) {
                    let result = <boolean>await this.httpService.get('/api/PatientExaminationService/addMHRSGreenList?MHRSCode=' + specialityDefinition.MHRSClinicCode + '&episodeActionObjectID=' + episodeActionID);
                    if (result == true)
                        this.messageService.showInfo(' Hasta Yeşil Listede onaylandı');
                    else
                        this.messageService.showError(i18n("M11834", "Bir hata oluştu"));
                }
                else {
                    this.messageService.showError(i18n("M21573", "Seçtiğiniz branş MHRS'ye bildirilmemiştir"));
                }
            }
            else
                this.messageService.showError('MHRS Yeşil Liste bildirimi ancak bir muayene üzerinden gerçekleştirilebilir');
        }
        catch (ex) {
            this.messageService.showError(ex);
        }
    }

    public async addMHRSGreenList_New(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeActionID = model.episodeActionId;
        try {
            if (episodeActionID != null) {
                let minorSpecialities = <SpecialityDefinition[]>await this.httpService.get('/api/PatientExaminationService/getMinorSpecialities');

                let multiSelectForm: MultiSelectForm = new MultiSelectForm();
                for (let item of minorSpecialities) {
                    multiSelectForm.AddMSItem((<SpecialityDefinition>item).Name, (<SpecialityDefinition>item).Name, (<SpecialityDefinition>item));
                }
                let mkey: string = await multiSelectForm.GetMSItem(this, i18n("M24269", "Yandal Seçiniz"), true);
                //alert(mkey);
                //console.log(mkey);
                //console.log(multiSelectForm.MSSelectedItemObject);
                let specialityDefinition: SpecialityDefinition;
                specialityDefinition = multiSelectForm.MSSelectedItemObject as SpecialityDefinition;


                if (specialityDefinition.IsMinorSpeciality == true && specialityDefinition.MHRSClinicCode != null) {
                    let result = <boolean>await this.httpService.get('/api/PatientExaminationService/AddMHRSGreenList_New?specialityDefinitionObjectID=' + specialityDefinition.ObjectID + '&episodeActionObjectID=' + episodeActionID);
                    if (result == true)
                        this.messageService.showInfo(' Hasta Yeşil Listede onaylandı');
                    else
                        this.messageService.showError(i18n("M11834", "Bir hata oluştu"));
                }
                else {
                    this.messageService.showError(i18n("M21573", "Seçtiğiniz branş MHRS'ye bildirilmemiştir"));
                }
            }
            else
                this.messageService.showError('MHRS Yeşil Liste bildirimi ancak bir muayene üzerinden gerçekleştirilebilir');
        }
        catch (ex) {
            this.messageService.showError(ex);
        }
    }

    public async searchMHRSGreenList_New(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeActionID = model.episodeActionId;
        try {
            if (episodeActionID != null) {
                let minorSpecialities = <SpecialityDefinition[]>await this.httpService.get('/api/PatientExaminationService/getMinorSpecialities');

                let multiSelectForm: MultiSelectForm = new MultiSelectForm();
                for (let item of minorSpecialities) {
                    multiSelectForm.AddMSItem((<SpecialityDefinition>item).Name, (<SpecialityDefinition>item).Name, (<SpecialityDefinition>item));
                }
                let mkey: string = await multiSelectForm.GetMSItem(this, i18n("M24269", "Yandal Seçiniz"), true);

                let specialityDefinition: SpecialityDefinition;
                specialityDefinition = multiSelectForm.MSSelectedItemObject as SpecialityDefinition;


                if (specialityDefinition.IsMinorSpeciality == true && specialityDefinition.MHRSClinicCode != null) {
                    let result = await this.httpService.get('/api/PatientExaminationService/SearchMHRSGreenList_New?specialityDefinitionObjectID=' + specialityDefinition.ObjectID + '&episodeActionObjectID=' + episodeActionID) as MHRS_YesilListeSorgula_OutPut;
                    if (result.yesilListeDurum == 1) {

                        let result1: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Onayla,&Vazgeç', 'O,V', i18n("M23735", "Uyarı"), '',result.result );
                        if (result1 === 'O') {
                           //Onayla

                            let approveResult = <boolean> await this.httpService.get('/api/PatientExaminationService/ApproveMHRSGreenList_New?specialityDefinitionObjectID=' + specialityDefinition.ObjectID + '&episodeActionObjectID=' + episodeActionID);

                            if (approveResult)
                                this.messageService.showInfo("Yeşil Liste Onaylandı.");
                        }
                        


                    } else {
                        this.messageService.showInfo(result.result);
                    }
                }
                else {
                    this.messageService.showError(i18n("M21573", "Seçtiğiniz branş MHRS'ye bildirilmemiştir"));
                }
            }
            else
                this.messageService.showError('MHRS Yeşil Liste bildirimi ancak bir muayene üzerinden gerçekleştirilebilir');
        }
        catch (ex) {
            this.messageService.showError(ex);
        }
    }
    //<MHRS Yeşil Liste Sorgula/Ekle/Onayla
    public async searchAddAproveMHRSGreenList(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            try {
                let result = <boolean>await this.httpService.get('/api/PatientExaminationService/searchAddAproveMHRSGreenList?episodeActionObjectID=' + episodeAction);
                if (result == true)
                    this.messageService.showInfo(' Hasta Yeşil Listede onaylandı');
                else
                    this.messageService.showError(i18n("M11834", "Bir hata oluştu"));
            }
            catch (ex) {
                this.messageService.showError(ex);
            }
        }
        else {
            this.messageService.showError('MHRS Yeşil Liste Bildirimi ancak bir muayene üzerinden gerçekleştirilebilir');
        }
    }

    //<Ameliyat �stek
    public openSurgery(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        if (model.episodeId != null) {
            let that = this;
            this.objectContextService.getNewObject<Surgery>(Surgery.ObjectDefID, Surgery).then(result => {
                let surgery: Surgery = result;
                that.showSurgery(surgery, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as Surgery;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError(i18n("M10817", "Ameliyat istemi ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir"));
        }
    }
    private showSurgery(data: Surgery, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SurgeryRequestForm';
            componentInfo.ModuleName = 'AmeliyatModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M10815", "Ameliyat İstek");
            modalInfo.Width = 1300;
            modalInfo.Height = 770;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Ameliyat �stek>

    public openConsultationWithResourceInfo(data: ClickFunctionParams) {
        let consultationRequestParametersModel: ConsultationRequestParametersModel = data.Params;
        if (consultationRequestParametersModel.episodeId != null) {
            let that = this;
            //this.episodeActionHelper.getNewEpisodeAction(Consultation.ObjectDefID, consultationRequestParametersModel.episodeId, Consultation.ConsultationStates.NewRequest).then(result => {
            this.episodeActionHelper.getNewEpisodeActionByMasterEpisodeAction(Consultation.ObjectDefID, consultationRequestParametersModel.masterAction, Consultation.ConsultationStates.NewRequest).then(result => {
                let consultation: Consultation = result as Consultation;
                consultationRequestParametersModel.consultation = consultation;

                that.showConsultation(consultationRequestParametersModel, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as Consultation;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError(i18n("M17762", "Konsültasyon istemi ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir"));
        }

    }
    private showConsultation(data: ConsultationRequestParametersModel, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ConsultationRequestForm';
            componentInfo.ModuleName = 'KonsultasyonModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Konsultasyon_Modulu/KonsultasyonModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M17754", "Konsültasyon İstek");
            modalInfo.Width = 1300;
            modalInfo.Height = 770;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Konsultasyon Istek



    //<Yatan Hasta Bilgileri
    public openInpatientAdmission(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;

        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;

            that.httpService.get<InpatientAdmission>('/api/EpisodeActionService/GetInpatientAdmissionBayActiveEpisodeAction?episodeActionObjectID=' + episodeAction, InpatientAdmission)
                .then(response => {
                    let inpatientAdmission: InpatientAdmission = response;

                    if (inpatientAdmission == null) {
                        this.messageService.showError('Hasta yatış bilgileri ancak geçerli bir yatan hasta işlemi üzerinden görülebilir');
                        return;
                    }
                    that.showInpatientAdmission(inpatientAdmission, data).then(result => {
                        let modalActionResult = result as ModalActionResult;
                        if (modalActionResult.Result === DialogResult.OK) {
                            // tslint:disable-next-line:no-unused-variable
                            let obj = result.Param as InpatientAdmission;
                        }
                    }).catch(error => {
                        this.messageService.showError(error);

                    });
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        } else {
            this.messageService.showError('Hasta yatış bilgileri ancak geçerli bir yatan hasta işlemi üzerinden görülebilir');
        }
    }

    private showInpatientAdmission(data: InpatientAdmission, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InPatientAdmissionClinicProcedure';
            componentInfo.ModuleName = 'YatanHastaModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.objectID = data.ObjectID.toString();
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Hasta Yatış Bilgileri';
            modalInfo.Width = 1300;
            modalInfo.Height = 770;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Yatan Hasta Bilgileri>

    public openEpicrisisScreen(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;

        let episodeAction = model.episodeActionId;

        let that = this;

        let epicrisis = null;

        that.showEpicrisisReportScreen(epicrisis, data).then(result => {
            let modalActionResult = result as ModalActionResult;
            if (modalActionResult.Result === DialogResult.OK) {
                // tslint:disable-next-line:no-unused-variable
                let obj = result.Param as InpatientAdmission;
            }
        })



    }

    private showEpicrisisReportScreen(data: CreatingEpicrisis, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'CreatingEpicrisisForm';
            componentInfo.ModuleName = 'EpikrizModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Epikriz_Modulu/EpikrizModule';
            if (data != null) {
                componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
                componentInfo.objectID = data.ObjectID.toString();
            }
            else
                componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            componentInfo.DestroyComponentOnSave = false;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Epikriz Giriş Ekranı';
            /*    modalInfo.Width = 1300;
                modalInfo.Height = 770; */
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    //<Yatan Hasta Klinik İşlemleri
    public openInpatientTreatmentClinicApp(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;

            that.httpService.get<InPatientTreatmentClinicApplication>('/api/EpisodeActionService/GetInPatientTreatmentClinicAppByActiveEpisodeAction?episodeActionObjectID=' + episodeAction, InPatientTreatmentClinicApplication)
                .then(response => {
                    let inpatientTreatmentClinicApp: InPatientTreatmentClinicApplication = response;

                    if (inpatientTreatmentClinicApp == null) {
                        that.messageService.showError('Yatan Hasta Klinik İşlemleri ancak geçerli bir yatan hasta işlemi üzerinden görülebilir');
                        return;
                    }
                    that.showInpatientTreatmentClinicApp(inpatientTreatmentClinicApp, data).then(result => {
                        let modalActionResult = result as ModalActionResult;
                        if (modalActionResult.Result === DialogResult.OK) {
                            let obj = result.Param as InPatientTreatmentClinicApplication;
                        }
                    }).catch(error => {
                        that.messageService.showError(error);

                    });
                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        } else {
            this.messageService.showError('Yatan Hasta Klinik İşlemleri ancak geçerli bir yatan hasta işlemi üzerinden görülebilir');
        }
    }


    public async printIsBasiCalisirKagidiReport(subEpisode: Guid, workDate: Date, leaveDate: Date, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'ISBASICALISIRKAGIDI',
            ReportParams: { SubEpisodeID: subEpisode.toString(), WorkDate: workDate.toLocaleString(), LeaveDate: leaveDate.toLocaleString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, activeIDsModel);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İşbaşı Çalışır Kağıdı";

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public async printHastaEmanetRaporuReport(episode: Guid, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'HASTAEMANETRAPORU',
            ReportParams: { EpisodeID: episode.toString()},
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, activeIDsModel);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Hasta Emanet Raporu";

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }


    private showInpatientTreatmentClinicApp(data: InPatientTreatmentClinicApplication, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InPatientTreatmentClinicAcceptionForm';
            componentInfo.ModuleName = 'YatanHastaModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.objectID = data.ObjectID.toString();
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();

            if (data.IsDailyOperation) {
                modalInfo.Title = i18n("M17634", "Yatışa Çevirme İşlemleri");
            }
            else {
                modalInfo.Title = i18n("M17634", "Yatan Hasta Klinik İşlemleri");
            }
            modalInfo.Width = 1400;
            modalInfo.Height = 900;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Yatan Hasta Klinik İşlemleri>

    //#region Fizyoterapi istek
    public openPhysiotherapyRequest(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;

        if (episodeAction != null) {
            let that = this;
            this.httpService.get<PhysiotherapyRequest>("api/PatientExaminationService/StartPhysiotherapyRequest?episodeActionId=" + episodeAction + "&IsRequestAcceptionByDoctor=" + true, PhysiotherapyRequest).then(result => {

                let physiotherapyRequest: PhysiotherapyRequest = result;

                that.showPhysiotherapyRequest(physiotherapyRequest, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as PhysiotherapyRequest;
                    }
                });

            }).catch(error => {
                alert("FTR İstek Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError(i18n("M14482", "FTR isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir"));
        }
    }
    private showPhysiotherapyRequest(data: PhysiotherapyRequest, parentInstance: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PhysiotherapyOrderRequestForm';
            componentInfo.ModuleName = "FizyoterapiModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.RefreshComponent = false;
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = parentInstance.ParentInstance;
            //componentInfo.objectID = data.ObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M14483", "FTR istek");
            modalInfo.Width = 1300;
            modalInfo.Height = 770;
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion Fizyoterapi istek

    //#region Fizyoterapi Tedavi Seyri
    public openPhysiotherapyTreatmentNote(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;

        if (episodeAction != null) {
            let that = this;
            this.httpService.get<any>("api/PatientExaminationService/GetPhysiotherapyTreatmentNote?episodeActionId=" + episodeAction).then(result => {

                let physiotherapyRequestId: Guid = result;

                that.showPhysiotherapyTreatmentNote(physiotherapyRequestId, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {

                        //let obj = res.Param as PhysiotherapyRequest;
                    }
                });

            }).catch(error => {
                alert("FTR Tedavi Seyri Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError("FTR Tedavi Seyri  ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir");
        }
    }
    private showPhysiotherapyTreatmentNote(physiotherapyRequestId: Guid, parentInstance: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let _inputParam = {};
            _inputParam['isNewTreatmentNote'] = false;//true->Yeni, false->eski ; Yeni tedavi notu ise not giriş inputu açılacak değilse sadece girilmiş notlar gösterilecek. 

            let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PhysiotherapyTreatmentNoteForm';
            componentInfo.ModuleName = "FizyoterapiModule";
            componentInfo.ModulePath = 'Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.RefreshComponent = false;
            componentInfo.InputParam = new DynamicComponentInputParam(_inputParam, new ActiveIDsModel(physiotherapyRequestId, null, null));
            componentInfo.ParentInstance = parentInstance.ParentInstance;
            //componentInfo.objectID = data.ObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "F.T.R. Tedavi Seyri";
            modalInfo.Width = 1300;
            modalInfo.Height = 770;
            //modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion Fizyoterapi Tedavi Seyri

    public printEpicrisisForm(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            const objectIdParam = new GuidParam(episodeAction);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReportModal('EpicrisisReportForPatient', reportParameters);
        }
    }

    public printInPatientExaminationForm(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            const objectIdParam = new GuidParam(episodeAction);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('InPatientExaminationFormReport', reportParameters);
        }
    }



    public printInpatientAdmissionInfoByTreatmentClinicReport(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        if (model.episodeId != null) {
            let that = this;
            that.httpService.get<string>('/api/InPatientTreatmentClinicApplicationService/GetLastActiveInPatientTreatmentClinicAppObjectId?EpisodeID=' + model.episodeId)
                .then(response => {
                    if (response == null) {
                        that.messageService.showError(i18n("M15346", "Hasta Yatış Raporu ancak geçerli bir yatan hasta işlemi üzerinden görülebilir"));
                        return;
                    }
                    const objectIdParam = new GuidParam(response);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                    that.reportService.showReport('InpatientAdmissionInfoByTreatmentClinic', reportParameters);

                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        } else {
            this.messageService.showError(i18n("M15346", "Hasta Yatış Raporu ancak geçerli bir yatan hasta işlemi üzerinden görülebilir"));
        }
    }

    public printInpatientAllProceduresReport(subepisodeObjectID: Guid) {

        let that = this;

        let reportData: DynamicReportParameters = {

            Code: 'TUMISLEMRAPORU',
            ReportParams: { ObjectID: subepisodeObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "TÜM İŞLEMLER RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    public printOrthesisProsthesisReceptionReport(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        if (model.episodeId != null) {
            let that = this;
            that.httpService.get<string>('/api/OrthesisProsthesisRequestService/GetLastActiveOrthesisProthesisRequestObjectId?EpisodeID=' + model.episodeId)
                .then(response => {
                    if (response == null) {
                        that.messageService.showError(i18n("M19788", "Ortez Protez Reçetesi ancak geçerli bir ortez protez işlemi üzerinden görülebilir."));
                        return;
                    }
                    const objectIdParam = new GuidParam(response);
                    let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                    that.reportService.showReport('OrthesisProsthesisReceptionReport', reportParameters);

                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        } else {
            this.messageService.showError(i18n("M19788", "Ortez Protez Reçetesi ancak geçerli bir ortez protez işlemi üzerinden görülebilir."));
        }
    }

    public showAppointmentForm(data: ClickFunctionParams): Promise<ModalActionResult> {
        let model: GiveAppointmentModel = data.Params;
        return new Promise((resolve, reject) => {
            let appointmentFormViewModel: AppointmentFormViewModel = new AppointmentFormViewModel();
            if (model.transDef) {
                appointmentFormViewModel.CurrentObjectTransDefID = model.transDef.StateTransitionDefID;
                appointmentFormViewModel.CurrentObject = model.ttObject;
            }
            else
                appointmentFormViewModel.StarterObject = model.ttObject;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "AppointmentForm";
            componentInfo.ModuleName = "RandevuModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule";
            componentInfo.InputParam = appointmentFormViewModel;
            componentInfo.ParentInstance = data.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20714", "Randevu");
            modalInfo.Width = 1500;
            modalInfo.Height = 768;
            modalInfo.IsShowCloseButton = false;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async printInpatientTreatmentBarcode(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let hospital = await SystemParameterService.GetParameterValue('HOSPITAL', '985FE4B6-66C5-4B32-8CEF-392ED46FD2C4');
            let that = this;
            that.httpService.get<InpatientTreatmentBarcodeInfo>("/api/InPatientTreatmentClinicApplicationService/GetInpatientTreatmentBarcodeInfoByEpisodeActionId?episodeActionId=" + episodeAction.toString())
                .then(response => {
                    if (hospital == "985FE4B6-66C5-4B32-8CEF-392ED46FD2C4")//Gaziler
                        that.barcodePrintService.printAllBarcode(response, "generateInpatientTreatmentBarcode2", "printInpatientTreatmentBarcode2");
                    else
                        that.barcodePrintService.printAllBarcode(response, "generateInpatientTreatmentBarcode", "printInpatientTreatmentBarcode");
                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        } else {
            this.messageService.showError(i18n("M24380", "Yatan Hasta Barkodu  ancak geçerli bir Yatan hasta işlemi üzerinden basılabilir."));
        }

    }


    public async printInPatientWristBarcode(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let hospital = await SystemParameterService.GetParameterValue('HOSPITAL', '985FE4B6-66C5-4B32-8CEF-392ED46FD2C4');
            let that = this;
            that.httpService.get<InpatientWristBarcodeInfo>("/api/InPatientTreatmentClinicApplicationService/GetInpatientWristBarcodeInfoByEpisodeActionId?episodeActionId=" + episodeAction.toString())
                .then(response => {
                    if (hospital == "985FE4B6-66C5-4B32-8CEF-392ED46FD2C4")
                        that.barcodePrintService.printAllBarcode(response, "generateInPatientWristBarcode2", "printInPatientWristBarcode");
                    else
                        that.barcodePrintService.printAllBarcode(response, "generateInPatientWristBarcode", "printInPatientWristBarcode");
                })
                .catch(error => {
                    that.messageService.showError(error);

                });
        } else {
            this.messageService.showError(i18n("M24380", "Yatan Hasta Barkodu  ancak geçerli bir Yatan hasta işlemi üzerinden basılabilir."));
        }

    }


    showENabizDataSets(EpisodeActionID): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "DataSetsForm";
            componentInfo.ModuleName = "ENabizModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule";
            componentInfo.objectID = "";

            componentInfo.InputParam = EpisodeActionID;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13708", "E-Nabız");
            modalInfo.Width = 500;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public onPathologyRequest(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;


        let that = this;
        let episode = model.episodeId;
        if (episode != null) {
            this.episodeActionHelper.getNewEpisodeAction(PathologyRequest.ObjectDefID, episode, PathologyRequest.PathologyRequestStates.Request).then(result => {

                let pathologyRequest: PathologyRequest = result as PathologyRequest;

                this.showPathologyRequest(pathologyRequest, data, null).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as PathologyRequest;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError('Patoloji isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }


    }

    public onPathologyRequestFromCheck(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;


        let that = this;
        let episode = model.episodeId;
        if (episode != null) {
            this.episodeActionHelper.getNewEpisodeAction(PathologyRequest.ObjectDefID, episode, PathologyRequest.PathologyRequestStates.Request).then(result => {

                let pathologyRequest: PathologyRequest = result as PathologyRequest;

                this.showPathologyRequest(pathologyRequest, data, true).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as PathologyRequest;
                    }
                });
            }).catch(err => {
                this.messageService.showError(err);
            });
        } else {
            this.messageService.showError('Patoloji isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }


    }



    private showPathologyRequest(data: PathologyRequest, clickFunctionParams: ClickFunctionParams, fromcheckPathologyRequest: any): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PathologyRequestForm';
            componentInfo.ModuleName = 'PatolojiModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Patoloji_Modulu/PatolojiModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20230", "Patoloji İstek");
            modalInfo.Width = 1300;
            modalInfo.Height = 750;
            if (fromcheckPathologyRequest == true)
                modalInfo.IsShowCloseButton = false;
            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onKetemCancerScreening(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/CancerScreeningService/CheckCancerScreeningForm?EpisodeActionId=" + episodeAction).then(result => {

                that.openKetemCancerScreening(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Toplum Tabanlı Kanser Tarama Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }

    openKetemCancerScreening(cancerScreeningObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "CancerScreeningForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";
            componentInfo.objectID = cancerScreeningObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Toplum Tabanlı Kanser Tarama";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    // Doğum-Anne-Bebek Bilgileri
    public openBirthResult(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;

        if (episodeAction != null) {
            let that = this;
            this.httpService.get<RegularObstetric>("api/InPatientPhysicianApplicationService/StartBirthResult?episodeActionId=" + episodeAction, RegularObstetric).then(result => {

                let regularObstetric: RegularObstetric = result;

                that.showBirthResult(regularObstetric, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as RegularObstetric;
                    }
                });

            }).catch(error => {
                alert("Doğum İstek Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError('Doğum isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }
    }
    private showBirthResult(data: RegularObstetric, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'RegularObstetricNewForm';
            componentInfo.ModuleName = 'NormalDogumModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Normal_Dogum_Modulu/NormalDogumModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.InputParam = new DynamicComponentInputParam(null, activeIDsModel);
            if (!data.IsNew) {
                componentInfo.objectID = data.ObjectID.toString();
            }
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Doğum Başlat';
            //modalInfo.Width = 1300;
            //modalInfo.Height = 770;
            modalInfo.fullScreen = true;
            //modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //Doğum-Anne-Bebek Bilgileri

    /* Ortez Protez Listesi - Hasta Geçmişi */

    public openOrthesisList(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeActionID = model.episodeActionId;

        if (episodeActionID != null) {
            let that = this;
            this.objectContextService.getObject<EpisodeAction>(episodeActionID, EpisodeAction.ObjectDefID).then(result => {

                let episodeAction: EpisodeAction = result;

                that.showOrthesisList(episodeAction, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as EpisodeAction;
                    }
                });

            }).catch(error => {
                alert("Ortez Listesi Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError(i18n("M14482", "Ortez Protez Listesi isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir"));
        }
    }

    private showOrthesisList(data: EpisodeAction, parentInstance: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PatientHistoryForm";
            componentInfo.ModuleName = "PatientHistoryModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule';
            componentInfo.objectID = "";
            componentInfo.ParentInstance = parentInstance.ParentInstance;
            let _inputParam: object = null;
            _inputParam = new Object();

            _inputParam["subEpisode"] = data.SubEpisode;
            _inputParam["actionType"] = "ORTHESISPROSTHESISREQUEST";

            componentInfo.InputParam = new DynamicComponentInputParam(_inputParam, activeIDsModel);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "";
            modalInfo.Width = 1300;
            modalInfo.Height = 770;
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    /* Ortez Protez Listesi - Hasta Geçmişi */

    /* Fizyo Terapi Listesi - Hasta Geçmişi */

    public openPhysioTherapyList(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeActionID = model.episodeActionId;

        if (episodeActionID != null) {
            let that = this;
            this.objectContextService.getObject<EpisodeAction>(episodeActionID, EpisodeAction.ObjectDefID).then(result => {

                let episodeAction: EpisodeAction = result;

                that.showPhysioTherapyList(episodeAction, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as EpisodeAction;
                    }
                });

            }).catch(error => {
                alert("FTR İstek Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError(i18n("M14482", "FTR isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir"));
        }
    }

    private showPhysioTherapyList(data: EpisodeAction, parentInstance: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "PatientHistoryForm";
            componentInfo.ModuleName = "PatientHistoryModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule';
            componentInfo.objectID = "";
            componentInfo.ParentInstance = parentInstance.ParentInstance;

            let _inputParam: object = null;
            _inputParam = new Object();

            _inputParam["subEpisode"] = data.SubEpisode;
            _inputParam["actionType"] = "PHYSIOTHERAPYREQUEST";

            componentInfo.InputParam = new DynamicComponentInputParam(_inputParam, activeIDsModel);


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "";
            modalInfo.Width = 1300;
            modalInfo.Height = 770;
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async patientNoShown(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeActionID = model.episodeActionId;

        if (episodeActionID != null) {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Muayeneye Gelmedi',
                "İşlem 'Hasta Gelmedi' aşamasına geçirilecektir. Devam etmek istediğinize emin misiniz? ");
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "İşlemden Vazgeçildi"));
            }
            else {
                try {
                    let that = this;
                    that.setPatientNoShown(episodeActionID);
                } catch (error) {
                    ServiceLocator.MessageService.showError(error);
                    //alert("Hata : " + error);
                    console.log(error);
                }

            }
        } else {
            this.messageService.showError(i18n("M14482", "Muayeneye Gelmedi özelliği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir."));
        }
    }


    private setPatientNoShown(episodeActionID: Guid) {

        let that = this;
        let apiUrl: string = '/api/PatientExaminationService/setPatientNoShown';

        if (episodeActionID != null) {
            let that = this;
            let apiUrl: string = "/api/PatientExaminationService/setPatientNoShown?episodeActionId=" + episodeActionID;
            that.httpService.get<any>(apiUrl).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(i18n("M16826", "İşlem başarılı."));
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    //alert("Hata : " + error);
                    console.log(error);
                });
        }
    }
    /* Fizyo Terapi Listesi - Hasta Geçmişi */

    /*INFLUENZA BEGIN*/
    public UpdateInfluenzaResult(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeID = model.episodeId;

        if (episodeID != null) {
            let that = this;
            let fullApiUrl: string = 'api/InfluenzaResultService/IsExistingInfluenzaDiagnosis?EpisodeID=' + episodeID;
            let input = { 'EpisodeID': episodeID };
            this.httpService.get(fullApiUrl).then((ress: string) => {

                if (ress) {

                    that.setInfluenzaResult(ress, data).then(res => {
                        let modalActionResult = res as ModalActionResult;
                        if (modalActionResult.Result === DialogResult.OK) {
                            // tslint:disable-next-line:no-unused-variable
                            let obj = res.Param as EpisodeAction;
                        }
                    });
                }
                else {
                    this.messageService.showError(i18n("M14482", "Bu ekranı açmak için hastanın Influenza tanısına sahip olması gerekmekte."));
                }
            }
            ).catch(error => {
                TTVisual.InfoBox.Alert(error);
            });

        }
        else {
            this.messageService.showError(i18n("M14482", "Influenza işlemi geçerli bir hasta işlemi üzerinden gerçekleştirilebilir"));
        }


    }

    private setInfluenzaResult(_influenzaID: string, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "InfluenzaResultForm";
            componentInfo.ModuleName = "ENabizModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/E_Nabiz_Modulu/ENabizModule';
            componentInfo.objectID = _influenzaID;
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            componentInfo.InputParam = new DynamicComponentInputParam(null, activeIDsModel);
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Influenza Tanı";
            modalInfo.Width = 800;
            modalInfo.Height = 200;
            modalInfo.fullScreen = false;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    /*INFLUENZA END*/

    public openNursingNoteReport(model: ActiveIDsModel) {
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            const objectIdParam = new GuidParam(episodeAction);
            let reportParameters: any = {};
            this.reportService.showReportModal('NursingNoteReport', reportParameters);
        }
    }

    /*DOKTOR KOTA BEGIN */

    public openDoctorQuota() {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'DoctorQuotaDefForm';
        componentInfo.ModuleName = "DoktorKotaTanimlamaModule";
        componentInfo.ModulePath = '/Modules/Core_Destek_Modulleri/Doktor_Kota_Tanimlama_Modulu/DoktorKotaTanimlamaModule';
        componentInfo.CloseWithStateTransition = true;
        componentInfo.DestroyComponentOnSave = true;
        componentInfo.RefreshComponent = true;
        componentInfo.InputParam = null;
        componentInfo.objectID = "";

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = i18n("M14483", "Doktor Kota Formu");
        modalInfo.Width = 900;
        modalInfo.Height = 600;
        modalInfo.fullScreen = false;
        modalInfo.DonotClosOnActionExecute = true;

        let result = this.modalService.create(componentInfo, modalInfo);

    }

    /*DOKTOR KOTA END */


    //#region Hemodiyaliz Bilgileri
    public openHemodialysisRequest(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;

        if (episodeAction != null) {
            let that = this;
            this.httpService.get<HemodialysisRequest>("api/InPatientPhysicianApplicationService/StartHemodialysisRequest?episodeActionId=" + episodeAction, HemodialysisRequest).then(result => {

                let hemodialysisRequest: HemodialysisRequest = result;

                that.showHemodialysisRequest(hemodialysisRequest, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                alert("Hemodiyaliz İstek Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError('Hemodiyaliz isteği ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir');
        }
    }

    private showHemodialysisRequest(data: HemodialysisRequest, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HemodialysisOrderForm';
            componentInfo.ModuleName = 'HemodiyalizModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodiyalizModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.RefreshComponent = false;
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            if (data.HemodialysisOrders != null && data.HemodialysisOrders.length > 0) {
                componentInfo.objectID = data.HemodialysisOrders[0].ObjectID.toString();//Mevcut bir order varsa o açılır.
            }
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Hemodiyaliz İstek';
            modalInfo.Width = 800;
            modalInfo.Height = 630;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion Hemodiyaliz Bilgileri

    //Adli Vaka Formu
    onForensicMedicalReportOpen(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<ForensicMedicalReport>("api/ForensicMedicalReportService/CheckForensicMedicalReport?EpisodeActionId=" + episodeAction, ForensicMedicalReport).then(result => {

                let forensicMedicalReport: ForensicMedicalReport = result;

                that.showForensicMedicalReport(forensicMedicalReport, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Adli Vaka Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }


    showForensicMedicalReport(data: ForensicMedicalReport, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "ForensicMedicalReportForm";
            componentInfo.ModuleName = "HastaRaporlariModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule";
            componentInfo.InputParam = new DynamicComponentInputParam(null, activeIDsModel);
            if (!data.IsNew) {
                componentInfo.objectID = data.ObjectID.toString();
            }
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Adli Vaka Formu"
            modalInfo.Width = 1300;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    //Adli Vaka Formu

    //Yatış
    private showInpatientAdmissionRequest(data: InpatientAdmission, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InpatientAdmissionRequestForm';
            componentInfo.ModuleName = 'YatanHastaModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Yatan_Hasta_Modulu/YatanHastaModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15337", "Hasta Yatış");
            modalInfo.Width = 800;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    onInpatientAdmissionRequestOpen(data: ClickFunctionParams) {


        this.objectContextService.getNewObject<InpatientAdmission>(InpatientAdmission.ObjectDefID, InpatientAdmission).then(result => {
            let inpatientAdmission: InpatientAdmission = result;
            this.showInpatientAdmissionRequest(inpatientAdmission, data).then(res => {
                let modalActionResult = res as ModalActionResult;
                if (modalActionResult.Result === DialogResult.OK) {
                    // tslint:disable-next-line:no-unused-variable
                    let obj = res.Param as InpatientAdmission;
                }
            });
        }).catch(err => {
            this.messageService.showError(err);
        });


    }
    //Yatış
    onPrintForensicMedicalReport(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<ForensicMedicalReport>("api/ForensicMedicalReportService/CheckForensicMedicalReport?EpisodeActionId=" + episodeAction, ForensicMedicalReport).then(result => {

                let forensicMedicalReport: ForensicMedicalReport = result;

                that.printForensicMedicalReport(forensicMedicalReport, data);

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Adli Vaka Formu ancak geçerli bir hasta işlemi üzerinden açılabilir.');
        }

    }

    printForensicMedicalReport(data: ForensicMedicalReport, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        if (!data.IsNew) {

            if (data.CurrentStateDefID != ForensicMedicalReport.ForensicMedicalReportStates.Completed) {
                this.messageService.showError('Tamamlanmamış Adli Vaka Raporunu Görüntüleyemezsiniz.');
                return;
            }

            let reportData: DynamicReportParameters = {

                Code: 'ADLIVAKA',
                ReportParams: { ObjectID: data.ObjectID.toString() },
                ViewerMode: true
            };

            return new Promise((resolve, reject) => {

                let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = new DynamicComponentInputParam(reportData, activeIDsModel);

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "ADLİ VAKA FORMU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        } else {
            this.messageService.showError('Hastanun Adli Vaka Formu bulunmamaktadır.');
        }


    }

    onProcedureReportOpen(clickFunctionParams: ClickFunctionParams) {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "ProcedureReportForm";
            componentInfo.ModuleName = "HastaRaporlariModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule";
            componentInfo.InputParam = activeIDsModel;
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İşlem Raporları";
            modalInfo.Width = 900;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    async openOBSWeb(clickFunctionParams: ClickFunctionParams) {

        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), "Ölüm Bildirim Sistemine Yönlendirileceksiniz. Devam Etmek İstiyor Musunuz? ", 1);
        if (result === "H")
            return;

        let viewmodel: any = clickFunctionParams.ParentInstance._ViewModel;
        let that = this;

        let fullApiUrl: string = 'api/TreatmentDischargeService/OpenOBS?SubepisodeID=' + viewmodel.SubepisodeID + '&ProcedureDoctorObjectIDForOBS=' + viewmodel.ProcedureDoctorObjectIDForOBS;
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();

        }).catch(error => {
            TTVisual.InfoBox.Alert(error);

        });
    }
    patientDocumentUpload(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PatientDocumentUploadForm';
            componentInfo.ModuleName = "HastaDokumantasyonModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Dokumantasyon_Modulu/HastaDokumantasyonModule';
            componentInfo.InputParam = activeIDsModel;
            //new DynamicComponentInputParam(this.patientExaminationDoctorFormNewViewModel._PatientExamination.Episode, new ActiveIDsModel(this._PatientExamination.ObjectID, null, null));
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M15185", "Hasta Dosyası Yükle");
            modalInfo.Width = 700;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onEmergencyOrderOpen(clickFunctionParams: ClickFunctionParams){
        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'EmergencyOrderComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = activeIDsModel;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13913", "Acil Servis Doktor Direktifi");
            modalInfo.Width = 1000;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });





    }


    public openEpisode(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episode = model.episodeId;
        if (episode != null) {
            let that = this;
            let apiUrl: string = "/api/EpisodeService/openEpisode?episodeId=" + episode;
            that.httpService.get<any>(apiUrl).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(i18n("M16826", "İşlem başarılı."));
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    console.log(error);
                });
        }
        else {
            this.messageService.showError('Vaka Açma, ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir.');
        }
    }

    public closeEpisode(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episode = model.episodeId;
        if (episode != null) {
            let that = this;
            let apiUrl: string = "/api/EpisodeService/closeEpisode?episodeId=" + episode;
            that.httpService.get<any>(apiUrl).then(response => {
                let result = response;
                ServiceLocator.MessageService.showSuccess(i18n("M16826", "İşlem başarılı."));
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    console.log(error);
                });
        }
        else {
            this.messageService.showError('Vaka Kapama, ancak geçerli bir hasta işlemi üzerinden gerçekleştirilebilir.');
        }
    }


    public openRadiologyHistory(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PatientAllRadiologyTestResultsForm';
            componentInfo.ModuleName = "RadyolojiModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Radyoloji_Modulu/RadyolojiModule';
            componentInfo.InputParam = activeIDsModel;
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Radyoloji Sonuçları";
            modalInfo.Width = 1200;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openPathologyHistory(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'AllPathologyReportsForm';
            componentInfo.ModuleName = "RadyolojiModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Radyoloji_Modulu/RadyolojiModule';
            componentInfo.InputParam = activeIDsModel;
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Patoloji Sonuçları";
            modalInfo.Width = 1200;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openNuclearMedicineHistory(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'NuclearMedicineResultsQueryForm';
            componentInfo.ModuleName = "NukleerTipModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Nukleer_Tip_Modulu/NukleerTipModule';
            componentInfo.InputParam = activeIDsModel;
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Nükleer Tıp Sonuçları";
            modalInfo.Width = 1200;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public async openTestHistory(clickFunctionParams: ClickFunctionParams): Promise<void> {

        let that = this;
        let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

        let viewResultURL = <string>await this.httpService.get('/api/ProcedureRequestService/GetURLForAllTestResultsByPatientID?PatientID=' + activeIDsModel.patientId);

        if (viewResultURL == "") {
            InfoBox.Alert(i18n("M12080", "Tahlil Sonuçları Bulunamadı!"));
        } else {
            let win = window.open(viewResultURL, '_blank');
            win.focus();
        }
    }

    public async getEDurumBildirirParameter() {
        let openPopup = await SystemParameterService.GetParameterValue('EDURUMBILDIRIRPOPUPAKTIF', 'FALSE');

        if (openPopup === "TRUE")
            return true;

        return false;
    }

    public openEDurumBildirirReportPopUp(episodeActionId: string) {
        let that = this;
        let apiUrl: string = '/api/EReportService/openCreateEDurumBildirirReport?episodeActionId=' + episodeActionId;

        that.httpService.get<string>(apiUrl)
            .then(response => {
                let win = window.open(response, '_blank');
                win.focus();
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    public OpenEDurumBildirirIndex() {
        let that = this;
        let apiUrl: string = '/api/EReportService/openEDurumBildirirReportIndex';

        that.httpService.get<string>(apiUrl)
            .then(response => {
                let win = window.open(response, '_blank');
                win.focus();
            })
            .catch(error => {
                this.messageService.showError(error);
            });

    }

    onKetemBreastScreening(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/BreastScreeningService/CheckBreastScreeningForm?EpisodeActionId=" + episodeAction).then(result => {



                that.openKetemBreastScreening(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Meme Tarama Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }

    openKetemBreastScreening(breastScreeaningObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "BreastScreeningForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";

            componentInfo.objectID = breastScreeaningObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Meme Tarama Formu";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    onKetemProstateScreening(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/ProstateScreeningService/CheckProstateScreeningForm?EpisodeActionId=" + episodeAction).then(result => {



                that.openKetemProstateScreening(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Prostat Kanseri Tarama Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }

    openKetemProstateScreening(prostateScreeaningObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "ProstateScreeningForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";

            componentInfo.objectID = prostateScreeaningObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Prostat Kanseri Tarama Formu";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onKetemSmearScreening(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/SmearScreeningService/CheckSmearScreeningForm?EpisodeActionId=" + episodeAction).then(result => {



                that.openKetemSmearScreening(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Smear Tarama Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }

    openKetemSmearScreening(smearScreeaningObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "SmearScreeningForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";

            componentInfo.objectID = smearScreeaningObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Smear Tarama Formu";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onCigaretteInspection(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/CigaretteExaminationService/CheckCigaretteExamination?EpisodeActionId=" + episodeAction).then(result => {



                that.openCigaretteInspection(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Sigara İzlem Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }

    openCigaretteInspection(cigaretteInspectionObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "CigaretteInspectionForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";

            componentInfo.objectID = cigaretteInspectionObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Sigara İzlem Formu";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onCigaretteExamination(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/CigaretteExaminationService/CheckCigaretteExamination?EpisodeActionId=" + episodeAction).then(result => {



                that.openCigaretteExamination(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Sigara İzlem Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }

    openCigaretteExamination(cigaretteExaminationObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "CigaretteExaminationForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";

            componentInfo.objectID = cigaretteExaminationObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Sigara Muayene Formu";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onCigaretteAssesment(data: ClickFunctionParams) {

        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;
        if (episodeAction != null) {
            let that = this;
            this.httpService.get<string>("api/CigaretteExaminationService/CheckCigaretteExamination?EpisodeActionId=" + episodeAction).then(result => {

                that.openCigaretteAssesment(result, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = res.Param as HemodialysisRequest;
                    }
                });

            }).catch(error => {
                this.messageService.showError(error);
            });

        } else {
            this.messageService.showError('Sigara Değerlendirme Formu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        }


    }





    openCigaretteAssesment(cigaretteExaminationObjectID, data: ClickFunctionParams): Promise<ModalActionResult> {
        let that = this;

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = data.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "CigaretteAssessmentForm";
            componentInfo.ModuleName = "KetemModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Ketem_Modulu/KetemModule";

            componentInfo.objectID = cigaretteExaminationObjectID;

            componentInfo.InputParam = new DynamicComponentInputParam("", activeIDsModel);
            componentInfo.ParentInstance = data.ParentInstance;


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Sigara Değerlendirme Formu";
            modalInfo.Width = 700;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    //Hsata Takip Kabul Bazlı
    public trackBySubepisode(data: ClickFunctionParams) {
        let model: FollowingPatients = data.Params;
        if (model.Paitent != null) {
            let that = this;

            model.FollowingType = PatientFollowingTypeEnum.BySubEpisode;

            this.httpService.post<boolean>("api/EpisodeActionService/TrackPatientByType", model).then(result => {

                if (result)
                    this.messageService.showSuccess("Hasta Başarılı Bir Şekilde Takip Listenize Eklendi");
                else
                    this.messageService.showError("Hasta Takip Listenize Eklenemedi.Lütfen bir süre sonra tekrar deneyin.");


            }).catch(error => {
                this.messageService.showError(error);
                console.log(error);
            });

        } else {
            this.messageService.showError("Lütfen takibinize almak istediğiniz hastayı yükleyin");
        }
    }

    //Hsata Takip Hasta Bazlı
    public trackbyPatient(data: ClickFunctionParams) {
        let model: FollowingPatients = data.Params;
        if (model.Paitent != null) {
            let that = this;

            model.FollowingType = PatientFollowingTypeEnum.ByPatientID;

            this.httpService.post<boolean>("api/EpisodeActionService/TrackPatientByType", model).then(result => {

                if (result)
                    this.messageService.showSuccess("Hasta Başarılı Bir Şekilde Takip Listenize Eklendi");
                else
                    this.messageService.showError("Hasta Takip Listenize Eklenemedi.Lütfen bir süre sonra tekrar deneyin.");


            }).catch(error => {
                this.messageService.showError(error);
                console.log(error);
            });

        } else {
            this.messageService.showError("Lütfen takibinize almak istediğiniz hastayı yükleyin");
        }
    }




    //#region Hemodiyaliz Eğitim Bilgileri
    public openHemodialysisInstruction(data: ClickFunctionParams) {
        let model: ActiveIDsModel = data.Params;
        let episodeAction = model.episodeActionId;

        if (episodeAction != null) {
            let that = this;
            this.httpService.get<HemodialysisInstruction>("api/HemodialysisRequestService/OpenHemodialysisInstruction?episodeActionId=" + episodeAction, HemodialysisInstruction).then(result => {

                let hemodialysisInstruction: HemodialysisInstruction = result;

                that.showHemodialysisInstruction(hemodialysisInstruction, data).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        // tslint:disable-next-line:no-unused-variable
                        let obj = res.Param as HemodialysisInstruction;
                    }
                });

            }).catch(error => {
                alert("Hemodiyaliz Eğitim Hata=" + error);
                console.log(error);
            });

        } else {
            this.messageService.showError('Hemodiyaliz Eğitim Bilgileri ancak geçerli bir hemodiyaliz işlemi üzerinden gerçekleştirilebilir');
        }
    }
    private showHemodialysisInstruction(data: HemodialysisInstruction, clickFunctionParams: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InstructionListForm';
            componentInfo.ModuleName = 'HemodiyalizModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemodiyaliz_Modulu/HemodiyalizModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.InputParam = new DynamicComponentInputParam(null, activeIDsModel);
            if (!data.IsNew) {
                componentInfo.objectID = data.ObjectID.toString();
            }
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Hemodiyaliz Eğitim Bilgileri';
            modalInfo.Width = 1300;
            modalInfo.Height = 400;
            //modalInfo.fullScreen = true;
            //modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion Hemodiyaliz Eğitim Bilgileri

    public async openBirthInfoReport(BirthInfoReportStartDate, BirthInfoReportEndDate, SelectedBirthTypes): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'DOGUMBILGISI',
            ReportParams: { BaslangicTarihi: BirthInfoReportStartDate, BitisTarihi: BirthInfoReportEndDate, DogumYontemi: SelectedBirthTypes },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "DOĞUM BİLGİLERİ RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async openExPatientListReport(): Promise<ModalActionResult> {

        let reportData: DynamicReportParameters = {

            Code: 'ACILEXLISTESI',
            ReportParams: {},
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Acil Ex Hasta Listesi"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openUserPackage(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'UserPackageForm';
            componentInfo.ModuleName = 'ProcedureRequestModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.InputParam = new DynamicComponentInputParam(null, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Kullanıcı Paket Tanımları';
            modalInfo.Width = 800;
            modalInfo.Height = 1000;
            //modalInfo.fullScreen = true;
            //modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openArchiveDeliveryForm(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ArchiveDeliveryForm';
            componentInfo.ModuleName = 'HemsirelikIslemleriModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hemsirelik_Islemleri_Modulu/HemsirelikIslemleriModule';
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.InputParam = new DynamicComponentInputParam(activeIDsModel.episodeActionId, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Arşiv Teslim Formu';
            modalInfo.Width = 800;
            modalInfo.Height = 700;
            //modalInfo.fullScreen = true;
            //modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public OpenRadiologyTemplate(clickFunctionParams: ClickFunctionParams) {
        return new Promise((resolve, reject) => {
            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'RadiologyTemplateForm';
            componentInfo.ModuleName = 'RadyolojiModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Radyoloji_Modulu/RadyolojiModule';
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.InputParam = new DynamicComponentInputParam(activeIDsModel.episodeActionId, activeIDsModel);
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Radyoloji Şablon Tanımı';
            modalInfo.Width = 800;
            modalInfo.Height = 700;
            //modalInfo.fullScreen = true;
            //modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }



    public showSurgeryChecklist(data: Guid, parentInstance: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise(async (resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SafeSurgeryCheckListForm';
            componentInfo.ModuleName = "AmeliyatModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = false;
            componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            componentInfo.ParentInstance = parentInstance.ParentInstance;
            componentInfo.objectID = data.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M14483", "Güvenli Cerrahi Kontrol Listesi");
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    loadRequestAcceptingPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    public LaboratoryItemModel: LaboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel(); 
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
       //poliklinik, yatan hasta, hemsirelik ekranlarından istek kabulde bulunan istemlerin numune alma asamasina gecirilip barkodlarinin basilmasi
       public async printLabBarcode(clickFunctionParams: ClickFunctionParams){
        let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
        let EpisodeActionID = activeIDsModel.episodeActionId;
        let fullApiUrl: string = 'api/EpisodeActionService/QueryLaboratoryDetailItemByEpisodeAction?EpisodeActionID=' + EpisodeActionID ; //QueryLaboratoryDetailItemByEpisode ";
        await this.httpService.post<LaboratoryWorkListItemMasterModel>(fullApiUrl, LaboratoryWorkListItemMasterModel).then(async result => {
            if (result != null){
                this.LaboratoryItemModel = result as LaboratoryWorkListItemMasterModel;
                await this.btnSampleTakingClick();
            }
            else{
                ServiceLocator.MessageService.showInfo("Hastanın laboratuvar tetkiki bulunmamaktadır");
            }
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error);
        });
    }

    public async btnSampleTakingClick() {

        this.loadRequestAcceptingPanelOperation(true, 'İstekler LIS tarafına kaydediliyor, lütfen bekleyiniz.');

        try {
            let inputDVO = new ProcedureInfoInputDVO();
            inputDVO.EpisodeID = this.LaboratoryItemModel.EpisodeID;
            this.LaboratoryItemModel.TubeInformationList = Array<TubeInformation>();

            let labProcObjectIDList: Array<string> = new Array<string>();
            for (let vmLabProc of this.LaboratoryItemModel.LaboratoryProcedureList) {
                    if (vmLabProc.BarcodeID != null && vmLabProc.BarcodeID.toString() == "" && vmLabProc.StateDefID == "5eaf4c46-c99e-491c-a880-37d07484437e") //Sec ısaretlı ve Istek Kabul asamasında ve barocode u bos ıse
                    {
                        labProcObjectIDList.push(vmLabProc.ObjectID.toString());
                    }
            }

            if (labProcObjectIDList.length > 0) {
                inputDVO.LabProcedures = labProcObjectIDList;

                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/SampleAcceptToSampleTakingGroupByPatient";
                let result = await this.httpService.post<any>(fullApiUrl, inputDVO, ProcedureInfoOutputDVO) as Array<ProcedureInfoOutputDVO>;

                if (result != null) {
                    for (let resultInfo of result) {
                        for (let testCode of resultInfo.LabProcedures) {
                            for (let lp of this.LaboratoryItemModel.LaboratoryProcedureList) {
                                if (lp.ObjectID.toString() == testCode.PlacerOrderNumber) {
                                    lp.BarcodeID = testCode.PlacerGroupNumber;
                                    lp.SpecimenID = resultInfo.SpecimenID;
                                    break;
                                }
                            }
                        }

                        for (let tubeInfo of resultInfo.TubeInformations) {
                            let vmTubeInfo: TubeInformation = new TubeInformation();
                            vmTubeInfo.FromResourceName = tubeInfo.FromResourceName;
                            vmTubeInfo.SpecimenID = tubeInfo.SpecimenID;
                            vmTubeInfo.ContainerID = tubeInfo.ContainerID;
                            vmTubeInfo.SpecialHandlingCode = tubeInfo.SpecialHandlingCode;
                            vmTubeInfo.OtherEnvFactor = tubeInfo.OtherEnvFactor;
                            vmTubeInfo.RequestAcceptionDate = tubeInfo.RequestAcceptionDate;

                            this.LaboratoryItemModel.TubeInformationList.push(vmTubeInfo);

                        }

                    }
                }
            }
            this.loadRequestAcceptingPanelOperation(false, '');
            await this.btnSampleTakingClick();
        }
        catch (err) {
            this.loadRequestAcceptingPanelOperation(false, '');
            ServiceLocator.MessageService.showError(err);
        }


    }

    protected barcodeServiceValue: IBarcodePrintService;
    protected dateValue: DatePipe;
    public async btnPrintBarcodeClick() {
        try {
            let idrarAciklama: string = (await SystemParameterService.GetParameterValue('XXXXXXIDRARACIKLAMA', i18n("M10248", "24h ve Spot idrar")));
            for (let vmTubeInfo of this.LaboratoryItemModel.TubeInformationList) {
                let idrarBarcode: boolean = false;
                let info: LaboratoryBarcodeInfo = new LaboratoryBarcodeInfo();
                info.PatientFullName = this.LaboratoryItemModel.PatientNameSurname;
                info.PatientTCNo = this.LaboratoryItemModel.PatientTCNo;
                info.BirthDate = this.LaboratoryItemModel.PatientBirthDate;
                if (this.LaboratoryItemModel.isEmergency == true)
                    info.Emergency = "ACİL";
                else
                    info.Emergency = "";

                let fromResInfoArray: Array<string>;
                fromResInfoArray = vmTubeInfo.FromResourceName.split("|");
                info.FromResourceQRef = fromResInfoArray[0];
                info.FromResourceName = fromResInfoArray[1];

                let recDate: Date = (await CommonService.RecTime());
                recDate = plainToClass(Date, recDate);
                info.PrintDate = this.dateValue.transform(recDate, 'dd.MM.yyyy HH:mm');
                info.BarcodeCode = vmTubeInfo.ContainerID;

                let tubeName: string = "";
                let tubeInfoArray: Array<string> = vmTubeInfo.SpecialHandlingCode.split('&');
                if (tubeInfoArray != null) {
                    if (tubeInfoArray.length > 0) {
                        if (tubeInfoArray[2] != null) {
                            //TODO: Kod donmelı XXXXXX ya sorulacak
                            //24h ve Spot idrar tup bilgisinde farkli barcode basiliyor.
                            if (tubeInfoArray[2] == idrarAciklama)
                                idrarBarcode = true;

                            tubeName = tubeName + tubeInfoArray[2];
                            if (tubeInfoArray[4] != null)
                                tubeName = tubeName + ' ' + tubeInfoArray[4];
                        }
                    }
                }
                info.TubeName = tubeName;

                if (idrarBarcode == true)
                    this.barcodeServiceValue.printAllBarcode(info, "generatePeeLaboratoryBarcode", "printPeeLaboratoryBarcode");
                else
                    this.barcodeServiceValue.printAllBarcode(info, "generateLaboratoryBarcode", "printLaboratoryBarcode");


            }


            let specimenID: any;
            if (this.LaboratoryItemModel.TubeInformationList.length > 0) {
                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/UpdateBarcodeDateForSpecimen";
                let result = await this.httpService.post(fullApiUrl, this.LaboratoryItemModel.TubeInformationList);

                if (specimenID == null)
                    specimenID = this.LaboratoryItemModel.TubeInformationList[0].SpecimenID;
            }

            if (specimenID != null)
            {
                let that = this;
                let fullApiUrl: string = "api/LaboratoryWorkListService/UpdateSampleDateAsBarcodeDate?specimenID=" + specimenID.toString();
                let result = await this.httpService.get(fullApiUrl);
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }


    //#region Yatan Hasta Randevu
    public openInpatientAppointment(data: ClickFunctionParams) {

        return new Promise((resolve, reject) => {

            //let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InpatientAppWorkListForm';
            componentInfo.ModuleName = "InpatientAppWorkListModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Randevu_Modulu/Yatan_Randevu_Is_Listesi/InpatientAppWorkListModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.RefreshComponent = false;
            //componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            //componentInfo.ParentInstance = parentInstance.ParentInstance;
            //componentInfo.objectID = data.ObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Yatan Hasta Randevu Listesi";
            modalInfo.Width = 1300;
            modalInfo.Height = 770;
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    private showInpatientAppointment(data: PhysiotherapyRequest, parentInstance: ClickFunctionParams): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = parentInstance.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PhysiotherapyOrderRequestForm';
            componentInfo.ModuleName = "FizyoterapiModule";
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
            componentInfo.CloseWithStateTransition = true;
            componentInfo.DestroyComponentOnSave = true;
            componentInfo.RefreshComponent = false;
            //componentInfo.InputParam = new DynamicComponentInputParam(data, activeIDsModel);
            //componentInfo.ParentInstance = parentInstance.ParentInstance;
            //componentInfo.objectID = data.ObjectID.toString();

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M14483", "FTR istek");
            modalInfo.Width = 1300;
            modalInfo.Height = 770;
            modalInfo.fullScreen = true;
            modalInfo.DonotClosOnActionExecute = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    //#endregion Fizyoterapi istek

    //İş Kazası Raporu
    onIndustrialAccidentReportOpen(clickFunctionParams: ClickFunctionParams) {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "IndustrialAccidentReportForm";
            componentInfo.ModuleName = "HastaRaporlariModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule";
            componentInfo.InputParam = activeIDsModel;
      
            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İş Kazası Raporu";
            modalInfo.Width = 700;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

        //let model: ActiveIDsModel = data.Params;
        //let episodeAction = model.episodeActionId;
        //if (episodeAction != null) {
        //    let that = this;
        //    this.httpService.get<CheckIndustrialAccidentReportOutPut>("api/IndustrialAccidentReportService/CheckIndustrialAccidentReport?EpisodeActionId=" + episodeAction, CheckIndustrialAccidentReportOutPut).then(result => {

        //        let res: CheckIndustrialAccidentReportOutPut = result;

        //        that.showIndustrialAccidentReport(res, data).then(res => {
        //            let modalActionResult = res as ModalActionResult;
        //            if (modalActionResult.Result === DialogResult.OK) {
        //                let obj = res.Param as HemodialysisRequest;
        //            }
        //        });

        //    }).catch(error => {
        //        this.messageService.showError(error);
        //    });
            

        //} else {
        //    this.messageService.showError('İş kazası raporu ancak geçerli bir hasta işlemi üzerinden doldurulabilir.');
        //}


    }


    openHastaNakilFormu(clickFunctionParams: ClickFunctionParams) {

        return new Promise((resolve, reject) => {

            let activeIDsModel: ActiveIDsModel = clickFunctionParams.Params;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "HastaNakilFormu";
            componentInfo.ModuleName = "HastaRaporlariModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule";
            componentInfo.InputParam = activeIDsModel;

            componentInfo.ParentInstance = clickFunctionParams.ParentInstance;
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Hasta Nakil Formu";
            modalInfo.Width = 1200;
            modalInfo.Height = 850;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });



    }
    public async printPatientArchieveBarcode(barcodeInfo: PatientArchieveBarcodeInfo) {
        
       
        this.barcodePrintService.printAllBarcode(barcodeInfo, "generatePatientArchieveBarcode", "printPatientArchieveBarcode");
        
    }
   
}
