//$FFCEC513
import { Component, ViewChild, OnInit, OnDestroy, HostListener, NgZone } from '@angular/core';
import { EpisodeActionFormViewModel, InpatientHC_Class, DailyInpatientInfoModel, HealthCommitteandReqReason, ShortHcInfo, OldHealthCommitte, BirthTypeModel } from "./EpisodeActionFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/ActionForm";
import { ActionTypeEnum, PatientAdmissionResourcesToBeReferred, ResClinic, PatientExamination, InPatientPhysicianApplication, HealthCommittee, EDisabledReport, EStatusNotRepCommitteeObj, FollowingPatients } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeAction } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionService } from "ObjectClassService/EpisodeActionService";
import { ImportantMedicalInformation } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StateStatusEnum } from "NebulaClient/Utils/Enums/StateStatusEnum";
import { SubEpisodeService } from "ObjectClassService/SubEpisodeService";
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { TTObject } from "NebulaClient/StorageManager/InstanceManagement/TTObject";
import { TTObjectContext } from "NebulaClient/StorageManager/InstanceManagement/TTObjectContext";
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { AppointmentFormViewModel } from "../Randevu_Modulu/AppointmentFormViewModel";
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { RequestedProceduresForm } from "../Tetkik_Istem_Modulu/RequestedProceduresForm";
import { HCRequestReason, WhoPaysEnum } from 'NebulaClient/Model/AtlasClientModel';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { HCRequestReasonDetail, GetHCRequestReasonDetailsResponse } from 'Modules/Tibbi_Surec/Kayit_Kabul_Modulu/PatientAdmissionFormViewModel';
import { ActiveEmergencyOrderIDsModel, ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import List from 'app/NebulaClient/System/Collections/List';
import { DailyProvisionInputModel } from '../Tetkik_Istem_Modulu/ProcedureRequestViewModel';
import { TreatmentMaterialForm } from '../Sarf_Malzeme_Modulu/TreatmentMaterialForm';
import { ClinicResultModel } from '../Tetkik_Istem_Modulu/RequestedProceduresFormViewModel';
import { IModalService } from 'app/Fw/Services/IModalService';
import { HelpMenuService } from 'app/Fw/Services/HelpMenuService';
import { LaboratoryWorkListItemMasterModel, ProcedureInfoInputDVO, TubeInformation, ProcedureInfoOutputDVO } from '../Laboratuar_Is_Listesi/LaboratoryWorkListFormViewModel';
import { LaboratoryBarcodeInfo } from 'app/Barcode/Models/LaboratoryBarcodeInfo';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import { DatePipe } from '@angular/common';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';

@Component({
    selector: 'EpisodeActionForm',
    templateUrl: './EpisodeActionForm.html',
    providers: [MessageService]
})
export class EpisodeActionForm extends ActionForm implements OnInit, OnDestroy {
    @ViewChild('scrollPanel') ScrollPanel: HTMLElement;
    public episodeActionFormViewModel: EpisodeActionFormViewModel = new EpisodeActionFormViewModel();
    
    
    public get _EpisodeAction(): EpisodeAction {
        return this._TTObject as EpisodeAction;
    }
    private EpisodeActionForm_DocumentUrl: string = '/api/EpisodeActionService/EpisodeActionForm';
    constructor(protected httpService: NeHttpService,
        //protected httpService2:HttpClient,
        protected messageService: MessageService,
        protected ngZone: NgZone,
       ) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.EpisodeActionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

    }

    protected _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public hasRequestedProceduresForm: boolean = false;
    @ViewChild(RequestedProceduresForm) requestedProceduresFormInstance: RequestedProceduresForm;
    @ViewChild(TreatmentMaterialForm) treatmentMaterialFormInstance: TreatmentMaterialForm;

    public dentistResourceList: Array<ResSection> = new Array<ResSection>();
    public dentistList: Array<ResUser> = new Array<ResUser>();
    public ShowDentistList: boolean = false;

    public OpenHCAdmission: boolean = false;
    public hCRequestReasonList: Array<HCRequestReason> = new Array<HCRequestReason>();
    public shortHcInfo: Array<ShortHcInfo> = new Array<ShortHcInfo>();

    public showEALoadPanel = false;
    public EALoadPanelMessage: string = '';

    /** Boş dolu yatak raporu begin*/
    public ShowEmptyBedPopup: boolean = false;
    public GetAllClinicForReport: boolean = false;
    public ReportClinicList: Array<ResClinic> = new Array<ResClinic>();
    public SelectedClinicList: Array<ResClinic> = new Array<ResClinic>();
    /** Boş dolu yatak raporu end*/

    /**     GENEL RAPOR BAŞLNGIÇ BİTİŞ ZAMANI BEGİN     */

    public generalReportStartDate: Date = new Date();
    public generalReportEndDatee: Date = new Date();
    public ShowInpatientListPopup: boolean = false;
    public ShowPatientVacationListPopup:boolean = false;
    /**     GENEL RAPOR BAŞLNGIÇ BİTİŞ ZAMANI END     */

    /*protected _actionType: ActionTypeEnum;
    public get ActionType(): ActionTypeEnum {
        return this._actionType;
    }*/

    /* Gunubirlik yatis islemleri icin */
    gunubirlikYatisKontrol: boolean = false;
    public dailyApplicationControl: boolean = false;
    public summaryEpicrisis: string = "";
    public birim: any;
    public ClinicList = new List<ResClinic>();
    public loadingVisible: boolean = false;
    public InpatientDate: Date = new Date();
    public createRequest: boolean = false;

    /*Doğum Bilgileri Raporu*/
    public openBirthInfoPopUp: boolean = false;
    public BirthInfoReportStartDate: Date = new Date();
    public BirthInfoReportEndDate: Date = new Date();
    public BirthTypeList = new List <BirthTypeModel>();
    public SelectedBirthTypes: Guid[] = new Array<Guid>();

    public saveCommandVisible: boolean = true;
    public cancelCommandVisible: boolean = true;

    public LaboratoryItemModel: LaboratoryWorkListItemMasterModel = new LaboratoryWorkListItemMasterModel(); 
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    protected toShortDateStringWithDot(date: Date): string {
        return date.getDate() +
            '.' + (date.getMonth() + 1) +
            '.' + date.getFullYear();
    }

    protected async closeStatePanelIsInvoiced(): Promise<void>{
        if ((await EpisodeActionService.CheckInvoicedCompletely(this._EpisodeAction.ObjectID))) {
            this.makeStatePanelReadOnly();
            this.ReadOnly = true;
            this.saveAndCloseCommandVisible = false;
            this.saveCommandVisible = false;
        }
    }

    protected showAppointmentForm(transDef: TTObjectStateTransitionDef): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let data: AppointmentFormViewModel = new AppointmentFormViewModel();
            if (transDef) {
                data.CurrentObjectTransDefID = transDef.StateTransitionDefID;
                data.CurrentObject = this._TTObject;
            }
            else
                data.StarterObject = this._TTObject;
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "AppointmentForm";
            componentInfo.ModuleName = "RandevuModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this._EpisodeAction.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M20714", "Randevu");
            modalInfo.Width = 1500;
            modalInfo.Height = 768;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        try {
            await super.PostScript(transDef);
            if (transDef != null) {
                let isAttExists: boolean = await CommonService.IsAppointmentTransitionAttributeExists(transDef.StateTransitionDefID, this._EpisodeAction);
                if (isAttExists === true) {
                    let result = await this.showAppointmentForm(transDef);
                    if (result.Result === DialogResult.Cancel) {
                        ServiceLocator.MessageService.showError(i18n("M16907", "İşlemden vazgeçildi"));
                        return;
                    }

                    //if (result.Result === DialogResult.OK) {
                    //    await super.setState(transDef);
                    //    ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._EpisodeAction);
                    //}
                }
            }

        } catch (err) {
            ServiceLocator.MessageService.showError(err);
            return;
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        await super.ClientSidePreScript();
        await this.getActionType();
        //await this.ShowPatientPrivacyInformation(this._EpisodeAction.Episode.Patient);
        //await this.ShowImportantMedicalInformation(this._EpisodeAction);
        //await this.PrepareFormTitle();
        ////            if(this._EpisodeAction.CurrentStateDef==null || this._EpisodeAction.CurrentStateDef.IsEntry==true)
        ////            {
        ////                this._EpisodeAction.BeforeSetEpisode(this._EpisodeAction.Episode);
        ////            }
        ////IfNulların metodları hep bu sıra ile çalışmalı
        //await this.IfNullSelectFromResource();
        //await this.IfNullSelectMasterResource();
        //await this.IfNullSelectProcedureSpeciality();
        //await this.IfDiagnosisIsRequired();

        //acil dışındaki muayenelere
        if ((this._EpisodeAction.constructor.name == "PatientExamination" && (<PatientExamination>(this._EpisodeAction)).EmergencyIntervention == null)
            || this._EpisodeAction.constructor.name != "PatientExamination")
            (await EpisodeActionService.CheckPaid(this._EpisodeAction.ObjectID));

        await this.getWarningMessage();
        //this.DropReportsOfSecurePatient();
    }

    async getWarningMessage(): Promise<void> {
        if (this._EpisodeAction != null) {
            await this.httpService.get<string>("api/EpisodeActionService/WarningMessage?EpisodeActionObjectId=" + this._EpisodeAction.ObjectID.toString()).then(response => {
                let result: string = <string>(response);
                if (String.isNullOrEmpty(result)) {

                }
            }
            );
        }
    }

    async getActionType(): Promise<void> {
        if (this._EpisodeAction != null) {
            await this.httpService.get<ActionTypeEnum>("api/EpisodeActionService/GetActionType?EpisodeActionObjectID=" + this._EpisodeAction.ObjectID.toString() + '&EpisodeActionObjectDefID=' + this._EpisodeAction.ObjectDefID.toString()).then(response => {
                let result: ActionTypeEnum = <ActionTypeEnum>(response);
                this._EpisodeAction.ActionType = result;
            }
            );
        }
    }

    protected async loadErrorOccurred(err: any) {
        if (err != null) {
            if (err.split('-')[0].trim() === 'SM0141') {
                this.ReadOnly = true;
            }
        }
    }

    @HostListener('window:resize', ['$event'])
    resize(event: Event) {
        if (this.ScrollPanel) {
            let rect: ClientRect = this.ScrollPanel['nativeElement'].getBoundingClientRect();
            let top = rect.top;

            let viewPortHeight: number = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
            this.ScrollPanel['nativeElement'].style.height = (viewPortHeight - (top + 17)).toString() + "px";
        }
    }

    public isContextSaved: Boolean = false; //TANI için // Kaydetme  tamamlandığında  bu parametre trueya çekilir . Bu parametre Tanı paneline  gönderiliyor  Ana form kaydedildiğinde bu parametre trueya çekiliyor tanı paneli de  remove edilen tanıları view modelden temizliyor

    ngOnDestroy() {
    }

    protected isRefreshWorkList: boolean = true;
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        await super.AfterContextSavedScript(transDef);
        this.httpService.episodeActionWorkListSharedService.refreshWorklist(this.isRefreshWorkList);
        //TANI için
        let that = this;
        setTimeout(() => {
            that.isContextSaved = true; // Bu parametre Tanı paneline  gönderiliyor  Ana form kaydedildiğinde bu parametre trueya çekiliyor tanı paneli de bu parametre true ise  remove edilen tanıları view modelden temizliyor
        }, 100);

        setTimeout(() => {
            that.isContextSaved = false; // tekrar tekrar basınca hep çalışsın diye
        }, 100);
    }


    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo) {
        if (transDef != null) {
            if (transDef.ToStateStatus != StateStatusEnum.Cancelled && transDef.ToStateStatus != StateStatusEnum.CompletedUnsuccessfully) {
                if (this.hasRequestedProceduresForm == true) {
                    let returnValue: number;
                    returnValue = await this.requestedProceduresFormInstance.fireRequestedProceduresActions(this._EpisodeAction);
                    if (returnValue != null) {
                        if (returnValue == 2) {
                            throw new TTException(i18n("M22395", "SUT Kural ihlali oldu ve işlemden vazgeçildi!"));
                        }
                        else {
                            await super.setState(transDef, saveInfo);
                        }
                    }
                }
                else
                    await super.setState(transDef, saveInfo);
            }
            else
                await super.setState(transDef, saveInfo);
        }
    }

    protected async save(saveInfo?: FormSaveInfo) {
        if (this.hasRequestedProceduresForm == true) {
            let saveuserOption = await this.requestedProceduresFormInstance.saveProcedureTestFilterUserOption();
            let returnValue: number;
            returnValue = await this.requestedProceduresFormInstance.fireRequestedProceduresActions(this._EpisodeAction);
            if (returnValue != null) {
                if (returnValue == 2) {
                    throw new TTException(i18n("M22395", "SUT Kural ihlali oldu ve işlemden vazgeçildi!"));
                }
                else {
                    await super.save(saveInfo);
                }
            }
        }
        else
            super.save(saveInfo);

    }



    // ***** Method declarations start *****

    public LoadActiveIDsModel() {
        let episodeActionIdParam: Guid;
        let episodeIdParam: Guid;
        let patientIdParam: Guid;
        if (this._EpisodeAction != null) {
            episodeActionIdParam = this._EpisodeAction.ObjectID;
            if (this._EpisodeAction.Episode != null) {
                if (typeof this._EpisodeAction.Episode === "string") {
                    episodeIdParam = this._EpisodeAction.Episode;
                } else {
                    episodeIdParam = this._EpisodeAction.Episode.ObjectID;
                    if (this._EpisodeAction.Episode.Patient != null) {
                        if (typeof this._EpisodeAction.Episode.Patient === "string") {
                            patientIdParam = this._EpisodeAction.Episode.Patient;
                        } else {
                            patientIdParam = this._EpisodeAction.Episode.Patient.ObjectID;
                        }
                    }
                }
            }
        }
        this.ActiveIDsModel = new ActiveIDsModel(episodeActionIdParam, episodeIdParam, patientIdParam);
    }
    /*


    private async RunSUTRules(): Promise<void> {
        if (TTObjectClasses.SystemParameter.IsMedulaIntegration) {
            let results: Array<RuleBase.RuleResult> = new Array<RuleBase.RuleResult>();
            if (this._EpisodeAction.SubactionProcedures.length > 0) {
                for (let subActionProcedure of this._EpisodeAction.SubactionProcedures) {
                    if ((<ITTObject>subActionProcedure).IsNew) {
                        let actionDate: Date;
                        if ((subActionProcedure.ActionDate !== undefined))
                            actionDate = subActionProcedure.ActionDate.Value;
                        else actionDate = TTObjectDefManager.ServerTime;
                        results.AddRange(subActionProcedure.ProcedureObject.RunRules(actionDate, <ISUTInstance>subActionProcedure));
                    }
                }
            }
            if (this._EpisodeAction instanceof EpisodeActionWithDiagnosis && (<EpisodeActionWithDiagnosis>this._EpisodeAction).Diagnosis.length > 0) {
                for (let diagnosisGrid of (<EpisodeActionWithDiagnosis>this._EpisodeAction).Diagnosis) {
                    if ((<ITTObject>diagnosisGrid).IsNew) {
                        let actionDate: Date;
                        if ((diagnosisGrid.DiagnoseDate !== undefined))
                            actionDate = diagnosisGrid.DiagnoseDate.Value;
                        else actionDate = TTObjectDefManager.ServerTime;
                        results.AddRange(diagnosisGrid.Diagnose.RunRules(actionDate, <ISUTInstance>diagnosisGrid));
                    }
                }
            }
            if (results.length > 0)
                this.ShowResults(results);
        }
    }
    private async ShowResults(results: Array<RuleBase.RuleResult>): Promise<void> {
        let warningRuleResults: Array<RuleBase.RuleResult> = new Array<RuleBase.RuleResult>();
        let errorRuleResults: Array<RuleBase.RuleResult> = new Array<RuleBase.RuleResult>();
        for (let ruleResult of results) {
            if (ruleResult.IsWarningOnly)
                warningRuleResults.push(ruleResult);
            else errorRuleResults.push(ruleResult);
        }
        if (warningRuleResults.length > 0) {
            let result: string = "\"\"";
            let i: number = 1;
            for (let ruleResult of warningRuleResults) {
                result += ruleResult.RuleDescription;
                if (i !== results.length)
                    result += "\r\n";
                i++;
            }
            TTVisual.InfoBox.Alert("Bilgilendirme Mesajıdır.\r\n\r\n" + result, MessageIconEnum.InformationMessage);
        }
        if (errorRuleResults.length > 0) {
            let result: string = "\"\"";
            let i: number = 1;
            for (let ruleResult of errorRuleResults) {
                result += ruleResult.RuleDescription;
                if (i !== results.length)
                    result += "\r\n";
                i++;
            }
            let hataParamList: string[] = [result];
            throw new TTException((await SystemMessageService.GetMessageV3(143, hataParamList)));
        }
    }
    protected async CheckObjectReportToPrint(objectReportDef: TTObjectReportDef): Promise<boolean> {
        if (UserHelper.CurrentResource.IsPatientSecureAndHasNoRightOfUser(<IEpisodeActionPermission>this._EpisodeAction)) {
            return false;
        }
        return true;
    }*/

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        // if (!this.ValidateSutRules(this)) {
        //     throw new TTException("Sut kuralları doğrulaması başarısız oldu");//ApplicationException
        // }
    }

    /*  protected async CreateQueueItem(transDef: TTObjectStateTransitionDef): Promise<void> {
          if (this._EpisodeAction.MasterResource instanceof ResPoliclinic && (<ResPoliclinic>this._EpisodeAction.MasterResource).PatientCallSystemInUse === true) {
              if (transDef !== null && (await CommonService.IsTransitionAttributeExists(typeof CreateQueueItemAttribute, transDef))) {
                  let queueDef: ExaminationQueueDefinition = null;
                  queueDef = this.SelectQueue(this._EpisodeAction.ObjectContext, this._EpisodeAction.MasterResource, false);
                  if (queueDef === null)
                      throw new Exception((await SystemMessageService.GetMessage(1015)));
                  else {
                      let queueUser: ResUser = this.SelectQueueUser(this._EpisodeAction.ObjectContext, queueDef, false);
                      if (queueUser !== null) {
                          this.SetAuthorizedUserByQueueUser(queueUser, <EpisodeAction>this._EpisodeAction);
                          if (this._EpisodeAction.AuthorizedUsers.length > 0) {
                              let authorizedUser: AuthorizedUser = this._EpisodeAction.AuthorizedUsers[this._EpisodeAction.AuthorizedUsers.length - 1];
                              this._EpisodeAction.ProcedureDoctor = authorizedUser.User;
                          }
                      }
                      else {
                          let uKey: string = TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Doktor Atama", "Doktor atama yapmadan devam etmek istediğinize emin misiniz?", 2);
                          if (String.isNullOrEmpty(uKey) === true || uKey === "H")
                              throw new Exception((await SystemMessageService.GetMessage(80)));
                      }
                      let isEmergency: boolean = false;
                      if (this._EpisodeAction.FromResource !== null) {
                          for (let spg of this._EpisodeAction.FromResource.ResourceSpecialities) {
                              if (spg.Speciality !== null)
                                  if (spg.Speciality.Code === (await SystemParameterService.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE", "4400")).toString())
                                      isEmergency = true;
                          }
                      }
                      let queueItem: ExaminationQueueItem = null;
                      queueItem = this._EpisodeAction.CreateExaminationQueueItem(this._EpisodeAction.Episode.PatientAdmission, queueDef);
                      if (queueItem === null)
                          throw new Exception((await SystemMessageService.GetMessageV2(1016, queueDef.Name.toString())));
                      else TTVisual.InfoBox.Show(this._EpisodeAction.Episode.Patient.RefNo + " " + this._EpisodeAction.Episode.Patient.FullName + " hastası," + queueDef.Name + " sırasına eklendi. Sıradaki Toplam Hasta Sayısı : " + queueDef.CurrentItemsCount.toString(), MessageIconEnum.InformationMessage);
                  }
              }
          }
      }*/
    protected async IfDiagnosisIsRequired(): Promise<void> {
        (await EpisodeActionService.DiagnosisIsRequired(this._EpisodeAction));
    }
    protected async IfNullSelectFromResource(): Promise<void> {
        if (this._EpisodeAction.FromResource === null) {
            //if (TTUser.CurrentUser.UserObject!== null) {
            if (this._EpisodeAction.Episode !== null) {
                let episode: Episode = this._EpisodeAction.Episode;
                // this._EpisodeAction.SetFromResource(episode);

                if (this._EpisodeAction.FromResource === null) {
                    let availableUserResourcesByAllocationList = (await EpisodeActionService.GetAvailableUserResourcesByAllocation(episode, this._EpisodeAction));
                    if (availableUserResourcesByAllocationList.length < 1) {
                        throw new TTException((await SystemMessageService.GetMessage(145)));
                    }
                    else {
                        let MSItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                        for (let resSection of availableUserResourcesByAllocationList) {
                            if (!MSItem.IsItemExists(resSection.ObjectID.toString()))
                                MSItem.AddMSItem(resSection.Name, resSection.ObjectID.toString(), resSection);
                        }
                        let key: string = await MSItem.GetMSItem(this, i18n("M15561", "Havale Eden Birim Seçiniz"), false, true, false, false, false, true);
                        if (!String.isNullOrEmpty(key))
                            this._EpisodeAction.FromResource = <ResSection>MSItem.MSSelectedItemObject;
                        else throw new TTException((await SystemMessageService.GetMessage(146)));
                    }
                }
            }
            else {
                throw new TTException((await SystemMessageService.GetMessage(147)));
            }
            //}
            //else {
            //    throw new TTException((await SystemMessageService.GetMessage(148)));
            //}
        }
    }
    protected async IfNullSelectMasterResource(): Promise<void> {
        if (this._EpisodeAction.MasterResource === null) {
            //if (UserHelper.CurrentResource!== null) {
            if (this._EpisodeAction.Episode !== null) {
                let episode: Episode = this._EpisodeAction.Episode;
                // this._EpisodeAction.SetMasterResource(episode, false);

                if (this._EpisodeAction.MasterResource === null) {
                    let masterResource: ResSection = await this.GetSelectedAcionDefualtMasterResource(this._EpisodeAction.ObjectContext, i18n("M16941", "İşlemin Yapılacağı Birimi Seçiniz"));
                    if (masterResource !== null) {
                        this._EpisodeAction.MasterResource = masterResource;
                        return;
                    }
                }
                if (this._EpisodeAction.FromResource !== null) {
                    let limitedMasterResourceTypeList: Array<any> = (await EpisodeActionService.LimitedMasterResourceTypes(this._EpisodeAction));
                    if (limitedMasterResourceTypeList.length < 1 || limitedMasterResourceTypeList.Contains(this._EpisodeAction.FromResource.ObjectDef.Name)) {
                        this._EpisodeAction.MasterResource = this._EpisodeAction.FromResource;
                        return;
                    }
                    else {
                        let hataParamList: string[] = [this._EpisodeAction.FromResource.Name];
                        throw new TTException((await SystemMessageService.GetMessageV3(149, hataParamList)));
                    }
                }
                else {
                    throw new TTException((await SystemMessageService.GetMessage(145)));
                }
            }
            else {
                throw new TTException((await SystemMessageService.GetMessage(147)));
            }
            //}
            //else {
            //    throw new TTException((await SystemMessageService.GetMessage(148)));
            //}
        }
    }

    protected async PrapareFormToShow(frm: TTVisual.TTForm): Promise<void> {

    }
    protected async PrepareFormTitle(): Promise<void> {
        if (this._EpisodeAction.Episode === null) {
            throw new TTException((await SystemMessageService.GetMessage(144)));
        }
    }
    protected async PreScript() {
        this.resize(undefined);
        super.PreScript();
    }
    protected async ShowAction_ObjectUpdated(ttObject: TTObject, contextSaved: boolean): Promise<void> {
        ttObject.ObjectContext.Save();
        contextSaved = true;
    }

    public async GetIfPatientApprovalFormIsGiven(isGiven: boolean): Promise<boolean> {
        if (isGiven !== true) {
            //string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Form Seç,&Verildi,&Verilmedi", "S,V,Vd", "Uyarı", "Aydınlatılmış Onam Formu verildi mi?", "Aydınlatılmış Onam Formu hastaya verilmeden ise işleme devam edilemez.");
            /// let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Form Seç,&Verildi,&Verilmedi", "S,V,Vd", "Uyarı", "Aydınlatılmış Onam Formu verildi mi?", (await SystemMessageService.GetMessage(154)));
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Verildi,&Verilmedi", "V,Vd", i18n("M23735", "Uyarı"), i18n("M11308", "Aydınlatılmış Onam Formu verildi mi?"), (await SystemMessageService.GetMessage(154)));
            if (result === "V")
                return true;
            else if (result === "Vd") {
                throw new TTException((await SystemMessageService.GetMessage(154)));
            }
            //else {
            //    return this.GetPatientApprovalForm(); // TODO Bu formu Action içinden açma işi yapılırsa Form Seç seçeneği de eklenir
            //}
        }
        return isGiven;
    }
    public async DirectPurchaseMaterialByPatient(): Promise<void> {
        //let msItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        ////Servera tek seferde gidip gelsin diye kullanılacak dic
        //let dPADetailFirmPriceOfferDic: Dictionary<Guid, DPADetailFirmPriceOffer> = new Dictionary<Guid, DPADetailFirmPriceOffer>();
        //let dPADetailFirmPriceOffers: Array<DPADetailFirmPriceOffer> = <Array<DPADetailFirmPriceOffer>>(await DPADetailFirmPriceOfferService.GetUnsedAndApproved22FMaterialByPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID));
        //for (let dPADetailFirmPriceOffer of dPADetailFirmPriceOffers) {
        //    if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode !== null && String.isNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode) === false && String.isNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) === false)
        //        msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode + " " + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.toString());
        //    else if (String.isNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) === false)
        //        msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.toString());
        //    else if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial !== null)
        //        msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MaterialName, dPADetailFirmPriceOffer.ObjectID.toString());
        //    dPADetailFirmPriceOfferDic.push(new Guid(dPADetailFirmPriceOffer.ObjectID.toString()), dPADetailFirmPriceOffer);
        //}
        //let key: string = msItem.GetMSItem(null, "Hastanın 22F Malzemesi Bulunmakta, Kullanmak İstediklerinizi Seçiniz", false, false, true);
        //if (!String.isNullOrEmpty(key)) {
        //    let selectedDPADetailFirmPriceOffer: Array<DPADetailFirmPriceOffer> = new Array<DPADetailFirmPriceOffer>();
        //    for (let sp of msItem.MSSelectedItems.Keys) {
        //        let dpa: DPADetailFirmPriceOffer = null;
        //        dPADetailFirmPriceOfferDic.TryGetValue(new Guid(sp), dpa);
        //        if (dpa !== null) {
        //            if (dpa.OfferedUBB !== null) {
        //                let sdp: SurgeryDirectPurchaseGrid = new SurgeryDirectPurchaseGrid(this._EpisodeAction.ObjectContext);
        //                sdp.DPADetailFirmPriceOffer = dpa;
        //                this._EpisodeAction.TreatmentMaterials.push(sdp);
        //            }
        //            else {
        //                let cdp: CodelessMaterialDirectPurchaseGrid = new CodelessMaterialDirectPurchaseGrid(this._EpisodeAction.ObjectContext);
        //                cdp.DPADetailFirmPriceOffer = dpa;
        //                this._EpisodeAction.TreatmentMaterials.push(cdp);
        //            }
        //        }
        //    }
        //}
    }

    /*  public async AddReturnDescriptionInput(orthesisProsthesisRequest: OrthesisProsthesisRequest): Promise<void> {
          if (this._EpisodeAction instanceof OrthesisProsthesisRequest) {
              let pReturnForm: StringEntryForm = new StringEntryForm();
              let res: DialogResult = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
              if (res === DialogResult.OK) {
                  let theGrid: OrthesisProsthesis_ReturnDescriptionsGrid = null;
                  theGrid = new OrthesisProsthesis_ReturnDescriptionsGrid(this._EpisodeAction.ObjectContext);
                  theGrid.Description = pReturnForm.StringContent;
                  theGrid.EntryDate = (await CommonService.RecTime());
                  theGrid.UserName = UserHelper._currentResource === null ? "" : UserHelper._currentResource.Name;
                  orthesisProsthesisRequest.ReturnDescriptions.push(theGrid);
              }
          }
    }

      public async ApplyProcedure(stoneBreakUpProcedure: StoneBreakUpProcedure): Promise<void> {
          if (stoneBreakUpProcedure.ProcedureDate === null) {
              //  SetProcedureObject(Common.RecTime());
              stoneBreakUpProcedure.ProcedureDate = (await CommonService.RecTime());
          }
      }
      public async CheckDiagnosisOzelDurums(): Promise<void> {
          if (this._EpisodeAction instanceof IDiagnosisOzelDurum) {
              let diagnosisOzelDurumEA: IDiagnosisOzelDurum = <IDiagnosisOzelDurum>this._EpisodeAction;
              let selectedDiagnosisDef: DiagnosisDefinition = null;
              let neededOzelDurumList: Array<OzelDurum> = new Array<OzelDurum>();
              let hasError: boolean = false;
              if ((await EpisodeService.IsMedulaEpisode(this._EpisodeAction.Episode))) {
                  for (let diagnosis of diagnosisOzelDurumEA.Diagnosis) {
                      for (let ozelDurumGrid of diagnosis.Diagnose.DiagnosisDefOzelDurumlar) {
                          selectedDiagnosisDef = diagnosis.Diagnose;
                          neededOzelDurumList.push(ozelDurumGrid.OzelDurum);
                      }
                      if (neededOzelDurumList.length === 0)
                          continue;
                      else {
                          if (diagnosisOzelDurumEA.OzelDurum === null)
                              hasError = true;
                          else if (neededOzelDurumList.Contains(diagnosisOzelDurumEA.OzelDurum) === false)
                              hasError = true;
                      }
                      if (hasError)
                          break;
                  }
                  let neededOzelDurums: string = "\"\"";
                  if (hasError) {
                      for (let ozelDurum of neededOzelDurumList) { neededOzelDurums += "\r\n" + ozelDurum.ozelDurumKodu + " - " + ozelDurum.ozelDurumAdi; }
                      throw new TTException("'" + selectedDiagnosisDef.Code + "-" + selectedDiagnosisDef.Name + "' tanısı girildiğinde aşağıdaki medula özel durumlarından birisinin seçilmesi zorunludur!" + neededOzelDurums);
                  }
              }
          }
      }
      public async CheckForDiagnosys(): Promise<void> {
          if (this._EpisodeAction.Episode.Diagnosis.length === 0)
              throw new TTException("Bu işlem epizotunda hiçbir tanı bulunmayan hastalara başlatılamaz!");
      }
      public async CheckForensicMedicalReport(treatmentDischarge: TreatmentDischarge): Promise<void> {
          if (treatmentDischarge.Episode.PatientAdmission.AdmissionType === AdmissionTypeEnum.JudicialObservation) {
              if (treatmentDischarge.Episode.ForensicMedicalReports.length === 0)
                  throw new Exception((await SystemMessageService.GetMessage(677)));
          }
      }

      public async CompleteMyExaminationQueueItems(): Promise<void> {
          let itemList: Array<ExaminationQueueItem> = (await ExaminationQueueItemService.GetByEpisodeAction(this._EpisodeAction.ObjectContext, this._EpisodeAction.ObjectID));
          if (itemList.length > 0) {
              for (let item of itemList) {
                  if (item.CurrentStateDefID !== ExaminationQueueItem.ExaminationQueueItemStates.Completed && item.CurrentStateDefID !== ExaminationQueueItem.ExaminationQueueItemStates.Cancelled) {
                      item.CurrentStateDefID = ExaminationQueueItem.ExaminationQueueItemStates.Completed;
                      if (item.EpisodeAction.ProcedureDoctor !== null)
                          item.CompletedBy = item.EpisodeAction.ProcedureDoctor;
                  }
              }
          }
      }
      public async CreateCompletedTreatmentDischarge(stateDefID: Guid, objList: Dictionary<string, Object>): Promise<void> {
          let context: TTObjectContext = this._EpisodeAction.ObjectContext;
          let td: TreatmentDischarge = new TreatmentDischarge(this._EpisodeAction);
          for (let kp of objList) {
              switch (kp.Key) {
                  case "Conclusion":
                      td.Conclusion = <string>kp.Value;
                      break;
                  case "DischargeType":
                      td.DischargeType = <DischargeTypeEnum>kp.Value;
                      break;
                  case "DischargeToPlace":
                      td.DischargeToPlace = <DishargeToPlaceEnum>kp.Value;
                      break;
                  case "HospitalSendingTo":
                      td.HospitalSendingTo = <ResSection>kp.Value;
                      break;
                  case "DispatchedSpeciality":
                      td.DispatchedSpeciality = <SpecialityDefinition>kp.Value;
                      break;
              }
          }
          if (this._EpisodeAction.ProcedureDoctor !== null)
              td.ProcedureDoctor = this._EpisodeAction.ProcedureDoctor;
          td.CurrentStateDefID = TreatmentDischarge.TreatmentDischargeStates.New;
          td.Update();
          td.CurrentStateDefID = stateDefID;
          context.Save();
          let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
          let newParameterItem: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
          newParameterItem.push("Value", td.ObjectID.toString(), "T", "TTOBJECTID");
          parameters.push("TTOBJECTID", newParameterItem);
          TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_TreatmentDischargeReport, true, 1, parameters);
      }
      public async CreateNewAnesthesiaConsultation(): Promise<void> {
          //SaveContextForNewDiagnose();
          let consultation: TTObjectClasses.AnesthesiaConsultation;
          //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          //TTObjectContext objectContext = new TTObjectContext(false);
          let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          try {
              consultation = new TTObjectClasses.AnesthesiaConsultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
          }
          catch (ex) {
              this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
              TTVisual.InfoBox.Show(ex);
          }
          finally {

          }
      }
      public async CreateNewBirthReportRequest(InANewContext: boolean): Promise<void> {
          let birthReportRequest: BirthReportRequest;
          let tempBirthReport: BirthReportRequest = this._EpisodeAction.MyBirthReportRequest();
          if (InANewContext) {
              let objectContext: TTObjectContext = new TTObjectContext(false);
              let savePointGuid: Guid = objectContext.BeginSavePoint();
              try {
                  if (tempBirthReport === null)
                      birthReportRequest = new BirthReportRequest(objectContext, this._EpisodeAction);
                  else birthReportRequest = <BirthReportRequest>objectContext.GetObject(tempBirthReport.ObjectID, "BirthReportRequest");
              }
              catch (ex) {
                  objectContext.RollbackSavePoint(savePointGuid);
                  TTVisual.InfoBox.Show(ex);
              }
              finally {
                  objectContext.Dispose();
              }
          }
          else {
              if (tempBirthReport === null)
                  birthReportRequest = new BirthReportRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
              else birthReportRequest = <BirthReportRequest>this._EpisodeAction.ObjectContext.GetObject(tempBirthReport.ObjectID, "BirthReportRequest");
              //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
              //TTForm frm = TTForm.GetEditForm(birthReportRequest);
              //this.PrapareFormToShow(frm);
              //if (frm.ShowEdit(this.FindForm(), birthReportRequest) != DialogResult.OK)
              //{
              //    throw new TTUtils.TTException(SystemMessage.GetMessage(155));
              //    //throw new Exception("Doğum Raporu Giriş İşleminden Vazgeçildi");
              //}
              let a = 1;
          }
      }
      public async CreateNewConsultationRequest(): Promise<void> {
          //            MultiSelectForm pForm = new MultiSelectForm();
          //            pForm.AddMSItem("Normal Konsültasyon", "ConsultationRequest");
          //            pForm.AddMSItem("Diş Konsültasyonu", "DentalConsultationRequest");
          //            string consultationType = pForm.GetMSItem(this, "Konsültasyon Tipini Seçiniz");
          //            pForm.ClearMSItems();
          //            if(consultationType == "ConsultationRequest")
          this.CreateNewNormalConsultationRequest();
          //            else if (consultationType == "DentalConsultationRequest")
          //                CreateNewDentalConsultationRequest();
          //            else
          //            {
          //                InfoBox.Show("Konsültasyon isteğinden vazgeçildi.");
          //                return;
          //            }
          let a = 1;
      }
      public async CreateNewDentalConsultationRequest(): Promise<void> {
          ////SaveContextForNewDiagnose();
          //DentalConsultationRequest dentalConsultationRequest;
          ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          ////TTObjectContext objectContext = new TTObjectContext(false);
          //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          //try
          //{
          //    dentalConsultationRequest = new DentalConsultationRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
          //    //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
          //    //TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
          //    //this.PrapareFormToShow(frm);
          //    //if (frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
          //    //    this._EpisodeAction.ObjectContext.Save();
          //    //else
          //    //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
          //}
          //catch (Exception ex)
          //{
          //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
          //    InfoBox.Show(ex);
          //}
          let a = 1;
      }
      public async CreateNewInpatientAdmission(): Promise<void> {
          // Acil serviste muayeneleri YEŞİL ALAN olarak işaretlenen hastaların kliniklere yatışına Medulada ödeme kapsamında olmadığı için  izin verilmemektedir.

          if (this._EpisodeAction !== null) {
              if (this._EpisodeAction.Episode !== null) {
                  for (let ei of this._EpisodeAction.Episode.EmergencyInterventions) {
                      for (let ippa of ei.InPatientPhysicianApplications) {
                          //if (ippa.IsGreenAreaExamination != null)
                          {
                              if (ippa.IsGreenAreaExamination === true)
                                  throw new Exception("Yeşil alan muayenelerinde hasta yatış işlemi başlatılamaz!");
                          }
                      }
                      for (let pe of ei.PatientExaminations) {
                          if (pe.IsGreenAreaExamination === true)
                              throw new Exception("Yeşil alan muayenelerinde hasta yatış işlemi başlatılamaz!");
                      }
                  }
              }
          }
          //SaveContextForNewDiagnose();
          let inpatientAdmission: InpatientAdmission;
          //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          //TTObjectContext objectContext = new TTObjectContext(false);
          let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          try {
              inpatientAdmission = new InpatientAdmission(this._EpisodeAction.ObjectContext, this._EpisodeAction);
          }
          catch (ex) {
              this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
              TTVisual.InfoBox.Show(ex);
          }
          finally {

          }
      }
      public async CreateNewNormalConsultationRequest(): Promise<void> {
          //SaveContextForNewDiagnose();
          let consultationRequest: Consultation;
          //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          //TTObjectContext objectContext = new TTObjectContext(false);
          let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          try {
              consultationRequest = new Consultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
          }
          catch (ex) {
              this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
              TTVisual.InfoBox.Show(ex);
          }
          finally {

          }
      }
      public async CreateNewOutPatientPrescriptionn(): Promise<void> {
          //SaveContextForNewDiagnose();
          if (this._EpisodeAction.Episode.PatientStatus === PatientStatusEnum.Outpatient) {
              let outPatientPrescription: OutPatientPrescription;
              //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
              //TTObjectContext objectContext = new TTObjectContext(false);
              let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
              try {
                  outPatientPrescription = new OutPatientPrescription(this._EpisodeAction.ObjectContext, this._EpisodeAction);
              }
              catch (ex) {
                  this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                  TTVisual.InfoBox.Show(ex);
              }
              finally {

              }
          }
          else {
              TTVisual.InfoBox.Show("Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır.");
              return;
          }
      }
      public async CreateNewPhysiotherapyRequest(): Promise<void> {
          //SaveContextForNewDiagnose();
          let physiotherapyRequest: PhysiotherapyRequest;
          //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          //TTObjectContext objectContext = new TTObjectContext(false);
          let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          try {
              physiotherapyRequest = new PhysiotherapyRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
          }
          catch (ex) {
              this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
              TTVisual.InfoBox.Show(ex);
          }
          finally {

          }
      }
      public async CreateNewPlannedMedicalActionRequest(): Promise<void> {
          //SaveContextForNewDiagnose();
          let plannedMedicalActionRequest: PlannedMedicalActionRequest;
          //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          //TTObjectContext objectContext = new TTObjectContext(false);
          let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          try {
              plannedMedicalActionRequest = new PlannedMedicalActionRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
          }
          catch (ex) {
              this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
              TTVisual.InfoBox.Show(ex);
          }
          finally {

          }
      }
      public async CreateNewTreatmentDischarge(): Promise<void> {
          //SaveContextForNewDiagnose();
          let treatmentDischarge: TreatmentDischarge;
          let tempTreatmentDischarge: TreatmentDischarge;
          //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
          //TTObjectContext objectContext = new TTObjectContext(false);
          //Guid savePointGuid = objectContext.BeginSavePoint();
          let savePointGuid: Guid = this._EpisodeAction.ObjectContext.BeginSavePoint();
          try {
              if (this._EpisodeAction instanceof InPatientPhysicianApplication || this._EpisodeAction instanceof PatientExamination || this._EpisodeAction instanceof FollowUpExamination) {
                  tempTreatmentDischarge = (<PhysicianApplication>this._EpisodeAction).TreatmentDischarge;
                  if (tempTreatmentDischarge === null)
                      treatmentDischarge = new TreatmentDischarge(this._EpisodeAction);
              }
              else return;
          }
          catch (ex) {
              this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
              //objectContext.RollbackSavePoint(savePointGuid);
              TTVisual.InfoBox.Show(ex);
          }
          finally {

          }
      }
      public async CreateSubActionMatPricingDet(): Promise<void> {
          for (let tm of this._EpisodeAction.TreatmentMaterials) {
              if (tm instanceof SurgeryDirectPurchaseGrid) {
                  let sdg: SurgeryDirectPurchaseGrid = <SurgeryDirectPurchaseGrid>tm;
                  let titubbPrice: SubActionMatPricingDet = new SubActionMatPricingDet(this._EpisodeAction.ObjectContext);
                  titubbPrice.PatientPrice = 0;
                  titubbPrice.SubActionMaterial = sdg;
                  if (sdg.DPADetailFirmPriceOffer !== null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode !== null) {
                      titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
                      titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
                      titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
                  }
                  titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
              }
          }
      }
      public async DeleteMedulaProvisionData(_context: TTObjectContext, subEp: SubEpisode): Promise<void> {
          let sep: SubEpisodeProtocol = subEp.SGKSEP;
          if (sep !== null) {
              if (String.isNullOrEmpty(sep.MedulaTakipNo))
                  //Takip fatura ekranından silindikten sonra başlatılan hasta kabul düzeltmede sorun çıkardığı için exception kapatıldı. MC
                  //throw new TTUtils.TTException("Meduladan silinmesi gereken takip no bilgisine ulaşılamıyor.");
                  return;
              else {
                  if (sep.GetChildSEP(true) != null)
                      throw new TTException("Bu takibe bağlı başka takipler alınmış.Öncelikle onları silmelisiniz.");
                  else {
                      //Menudeki islem iptalinden cagrilmasinda sorun oldugu icin asagidaki showbox commentlendi.
                      //if (TTVisual.S howBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Medula provizyonu iptal edilecektir. Devam etmek istediğinize emin misiniz?") == "H")
                      //     throw new TTUtils.TTException("İşlemden vazgeçildi");

                      let takipSilGirisDVO: HastaKabulIslemleri.takipSilGirisDVO = new HastaKabulIslemleri.takipSilGirisDVO();
                      takipSilGirisDVO.saglikTesisKodu = (await SystemParameterService.GetSaglikTesisKodu());
                      takipSilGirisDVO.takipNo = sep.MedulaTakipNo;
                      let response: HastaKabulIslemleri.takipSilCevapDVO = HastaKabulIslemleri.WebMethods.hastaKabulIptalSync(TTObjectClasses.Sites.SiteLocalHost, takipSilGirisDVO);
                      if (response.sonucKodu !== "0000" && response.sonucKodu !== "0535")
                          throw new TTException(response.sonucMesaji);
                      else {
                          let hastaKabulIptalParam: XXXXXXMedulaServices.HastaKabulIptalParam = new XXXXXXMedulaServices.HastaKabulIptalParam(takipSilGirisDVO, sep.ObjectID.toString());
                          hastaKabulIptalParam.HastaKabulIptalCompletedInternal(response, takipSilGirisDVO, sep.ObjectID.toString(), _context);
                          sep.CurrentStateDefID = MedulaProvision.MedulaProvisionStates.Cancelled;
                          TTVisual.InfoBox.Alert("Provizyon başarılı bir şekilde iptal edilmiştir.", MessageIconEnum.InformationMessage);
                      }
                  }
              }
          }
      }

      public async DropReportsOfSecurePatient(): Promise<void> {
          if ((TTUser.CurrentUser.UserObject).IsPatientSecureAndHasNoRightOfUser)
              UserHelper.CurrentResource.IsPatientSecureAndHasNoRightOfUser(<IEpisodeActionPermission>this._EpisodeAction)) {
              for (let stateReport of this._EpisodeAction.CurrentStateDef.ReportDefs) {
                  this.DropCurrentStateReport(stateReport.ReportDefID);
              }
          }
      }

      public async GetPatientApprovalForm(): Promise<boolean> {
          //            rtfForm.GetTemplates = this.GetTemplates;
          //            rtfForm.SaveTemplate = this.SaveTemplate;
          //            rtfForm.TemplateSelected = this.TemplateSelected;
          //return rtfForm.PrintWithTemplateGroupName("Onam Formu","PatientApprovalForm");
          //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
          //PatientApprovalForm frm = new PatientApprovalForm();
          //DialogResult dialogResult = frm.ShowEdit(this.FindForm(), _EpisodeAction, true);
          //if (dialogResult != DialogResult.OK)
          //{
          //    throw new TTUtils.TTException(SystemMessage.GetMessage(80));
          //    //throw new Exception("İşlemden Vazgeçildi");
          //    //return false;
          //}
          return true;
      }
      public async GetPatientApprovalForm(allowToCancel: boolean): Promise<boolean> {
          //            rtfForm.GetTemplates = this.GetTemplates;
          //            rtfForm.SaveTemplate = this.SaveTemplate;
          //            rtfForm.TemplateSelected = this.TemplateSelected;
          //return rtfForm.PrintWithTemplateGroupName("Onam Formu","PatientApprovalForm");
          //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
          //PatientApprovalForm frm = new PatientApprovalForm();
          //DialogResult dialogResult = frm.ShowEdit(this.FindForm(), _EpisodeAction, true);
          //if (dialogResult != DialogResult.OK)
          //{
          //    if (!allowToCancel)
          //    {
          //        throw new TTUtils.TTException(SystemMessage.GetMessage(80));
          //        //throw new Exception("İşlemden Vazgeçildi");
          //    }
          //    return false;
          //}
          return true;
      }*/
    public async GetSelectedAcionDefualtMasterResource(context: TTObjectContext, msItemTitle: string): Promise<ResSection> {
        let actionDMRList: Array<ResSection> = (await EpisodeActionService.AcionDefualtMasterResources(context, null, this._EpisodeAction));
        if (actionDMRList.length > 0) {
            let mSItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let resSection of actionDMRList) {
                if (!mSItem.IsItemExists(resSection.ObjectID.toString()))
                    mSItem.AddMSItem(resSection.Name.toString(), resSection.ObjectID.toString(), resSection);
            }
            let key: string = await mSItem.GetMSItem(null, msItemTitle, true, true, false, false, true, true);
            if (!String.isNullOrEmpty(key)) {
                return <ResSection>mSItem.MSSelectedItemObject;
            }
            else {
                throw new TTException((await SystemMessageService.GetMessage(150)));
            }
        }
        return null;
    }/*
    public async GetStore(treatmentMaterialDef: TTObjectDef): Promise<Store> {
        if (treatmentMaterialDef.AllAttributes.containsKey(typeof StoreUsageAttribute.toString()) === false) {
            return this._EpisodeAction.MasterResource.Store;
        }
        else {
            let storeUsageEnum: string = treatmentMaterialDef.Attributes["STOREUSAGEATTRIBUTE"].Parameters["StoreUsage"].Value.toString();
            switch (storeUsageEnum) {
                case "0":
                    return null;
                case "1":
                    return this._EpisodeAction.MasterResource.Store;
                case "2":
                    return this._EpisodeAction.FromResource.Store;
                case "3":
                    return this._EpisodeAction.SecondaryMasterResource.Store;
                case "4":
                    return UserHelper.CurrentResource.Store;
                case "5":
                    return (await EpisodeActionService.GetSpecialResourceForStore(this._EpisodeAction)).Store;
                default:
                    return this._EpisodeAction.MasterResource.Store;
            }
        }
    }*/
    public async IfNullSelectProcedureSpeciality(): Promise<void> {


        if ((await CommonService.IsAttributeExists("NotRequiredProcedureSpecialityAttribute", <TTObject>this._EpisodeAction)) === false) {
            if (this._EpisodeAction.ProcedureSpeciality === null) {
                if (this._EpisodeAction.Episode !== null) {
                    let resource: ResSection = null;
                    let title: string = "";
                    if ((await EpisodeActionService.SetProcedureSpecialtyBy(this._EpisodeAction.ObjectDefID)).toUpperCase() === "MASTERRESOURCE") {
                        resource = this._EpisodeAction.MasterResource;
                        title = i18n("M16947", "İşlemin Yapılacağı Uzmanlık Dalını");
                    }
                    else if ((await EpisodeActionService.SetProcedureSpecialtyBy(this._EpisodeAction.ObjectDefID)).toUpperCase() === "FROMRESOURCE") {
                        resource = this._EpisodeAction.FromResource;
                        title = i18n("M16607", "İsteğin Yapıldığı Uzmanlık Dalını");
                    }
                    if (resource !== null) {
                        if (resource.ResourceSpecialities.length === 1) {
                            this._EpisodeAction.ProcedureSpeciality = resource.ResourceSpecialities[0].Speciality;
                        }
                        else if (resource.ResourceSpecialities.length > 1) {
                            let MSItem: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                            let getTime: boolean = false;
                            while (getTime === false) {
                                for (let specialityGrid of resource.ResourceSpecialities) {
                                    //if(!MSItem.Contains (specialityGrid.Speciality.Name))
                                    if (!MSItem.IsItemExists(specialityGrid.Speciality.ObjectID.toString()))
                                        MSItem.AddMSItem(specialityGrid.Speciality.Name, specialityGrid.Speciality.ObjectID.toString(), specialityGrid.Speciality);
                                }
                                title = title + i18n("M21571", " seçiniz");
                                let key: string = await MSItem.GetMSItem(this, title, false, true, false, false, false, true);
                                if (!String.isNullOrEmpty(key)) {
                                    this._EpisodeAction.ProcedureSpeciality = <SpecialityDefinition>MSItem.MSSelectedItemObject;   // selectedspecialityList.Values[0];
                                    getTime = true;
                                }
                            }
                        }
                    }
                }
                else {
                    throw new TTException((await SystemMessageService.GetMessage(147)));
                }
            }
        }
    }

    public async RequiresAdvance(): Promise<boolean> {
        let subEpisode = this._EpisodeAction.SubEpisode;
        if (subEpisode !== null && (await SubEpisodeService.GetActiveSubEpisodeProtocol(subEpisode)) !== null && (await SubEpisodeService.GetActiveSubEpisodeProtocol(subEpisode)).Protocol.RequiresAdvance === true) {
            for (let advance of this._EpisodeAction.Episode.Advances) {
                if (advance.IsCancelled === false)
                    return false;
            }
            return true;
        }
        return false;
    }

    /*
    public async IsMedulaProvisionNecessaryProcedureExists(): Promise<boolean> {
        for (let sp of this._EpisodeAction.SubactionProcedures) {
            if (sp.ProcedureObject !== null && sp.ProcedureObject.MedulaProvisionNecessity === true)
                return true;
        }
        return false;
    }
    public async MakingDirectPurchaseHasUsed(): Promise<void> {
        for (let treatmentMaterials of this._EpisodeAction.TreatmentMaterials) {
            if (treatmentMaterials instanceof SurgeryDirectPurchaseGrid) {
                (<SurgeryDirectPurchaseGrid>treatmentMaterials).DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
            }
            if (treatmentMaterials instanceof CodelessMaterialDirectPurchaseGrid) {
                (<CodelessMaterialDirectPurchaseGrid>treatmentMaterials).DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
            }
        }
    }

    public async SaveContextForNewDiagnose(): Promise<void> {
        //            if (this._EpisodeAction.Episode.Diagnosis.Count > 0)
        //            {
        //                TTObjectContext context = new TTObjectContext(true);
        //                Episode episode = (Episode)context.GetObject(this._EpisodeAction.Episode.ObjectID, typeof(Episode));
        //                if (episode.Diagnosis.Count < this._EpisodeAction.Episode.Diagnosis.Count)
        //                {
        //                    //string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşlemi kaydetmek istediğinize emin misiniz?", "Girilen tanılar henüz kaydedilmemiştir.İstek yapmak için işlemi kaydedip devam etmek istediğinize emin misiniz?", 1);
        ////                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşlemi kaydetmek istediğinize emin misiniz?", SystemMessage.GetMessage(173), 1);
        ////                    if (result == "E")
        this._EpisodeAction.ObjectContext.Save();
        //                }
        //            }
        let a = 1;
    }
    public async SelectTemplate(objectContext: TTObjectContext, ProcedureRequestTemplateType: string, ToUpdate: boolean): Promise<ProcedureRequestTemplateDefinition> {
        let templates: Array<any>;
        if (ToUpdate === false || TTUser.CurrentUser.IsSuperUser) {
            templates = objectContext.QueryObjects(ProcedureRequestTemplateType.toUpperCase(), " RESUSER = '" + UserHelper._currentResource.ObjectID.toString() + "' OR RESUSER IS NULL ");
        }
        else {
            templates = objectContext.QueryObjects(ProcedureRequestTemplateType.toUpperCase(), " RESUSER = '" + UserHelper._currentResource.ObjectID.toString() + "'");
        }
        let pForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let template of templates) {
            pForm.AddMSItem(template.Name, template.ObjectID.toString(), template);
        }
        let sKey: string = pForm.GetMSItem(this, this._EpisodeAction.ObjectDef.DisplayText + " şablonu seçiniz.", false, false, false, false, true, false);
        if (!String.isNullOrEmpty(sKey)) {
            return <ProcedureRequestTemplateDefinition>pForm.MSSelectedItemObject;
        }
        return null;
    }
    public async SetDirectPurchaseListFilter(directPurchaseDetailColumn: TTVisual.ITTGridColumn): Promise<void> {
        let filterString: string = "";
        if (this._EpisodeAction.Episode.Patient !== null)
            filterString = "DIRECTPURCHASEACTIONDETAIL.DIRECTPURCHASEACTION.PATIENT = '" + this._EpisodeAction.Episode.Patient.ObjectID.toString() + "'";
        (<TTVisual.ITTListBoxColumn>directPurchaseDetailColumn).ListFilterExpression = filterString;
    }
    public async SetFormReadOnly(): Promise<void> {
        for (let control of this.pnlControls.Controls) {
            if (!(control instanceof ITTTabControl)) {
                control.Enabled = false;
            }
        }
    }
    public async SetPreDiagnosisAsSecDiagnosis(episodeActionWithDiagnosis: EpisodeActionWithDiagnosis): Promise<void> {
        let diagnoseName: string = string.Empty;
        let secdiagnosisYok: boolean = true;
        let prediagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
        if (episodeActionWithDiagnosis.Diagnosis.length <= 0) {
            for (let diagnose of episodeActionWithDiagnosis.Diagnosis) {
                if (diagnose.DiagnosisType === DiagnosisTypeEnum.Seconder) {
                    secdiagnosisYok = false;
                    break;
                }
                else {
                    prediagnosisGridList.push(diagnose);
                    diagnoseName += diagnose.Diagnose.Code + " " + diagnose.Diagnose.Name + "\r\n";
                }
            }
            if (secdiagnosisYok && !String.isNullOrEmpty(diagnoseName)) {
                let hataParamList: string[] = [diagnoseName];
                let massage: string = (await SystemMessageService.GetMessageV3(152, hataParamList));
                // if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Tanı Girişi", "Hiç kesin tanı girmediniz.\r\nGirdiğiniz ön tanıların kesinleştirilmesini ister misiniz? \r\nGirilen Ön Tanılar:\r\n" + diagnoseName) == "E")
                if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Tanı Girişi", massage) === "E") {
                    for (let preDiagnose of prediagnosisGridList) {
                        let secDiagnose: DiagnosisGrid = new DiagnosisGrid(episodeActionWithDiagnosis.ObjectContext);
                        secDiagnose.AddToHistory = preDiagnose.AddToHistory;
                        secDiagnose.Diagnose = preDiagnose.Diagnose;
                        secDiagnose.DiagnoseDate = (await CommonService.RecTime());
                        secDiagnose.Episode = preDiagnose.Episode;
                        secDiagnose.EntryActionType = preDiagnose.EntryActionType;
                        secDiagnose.EpisodeAction = preDiagnose.EpisodeAction;
                        secDiagnose.FreeDiagnosis = preDiagnose.FreeDiagnosis;
                        secDiagnose.ImportantMedicalInformation = preDiagnose.ImportantMedicalInformation;
                        secDiagnose.IsMainDiagnose = preDiagnose.IsMainDiagnose;
                        secDiagnose.SubactionProcedure = preDiagnose.SubactionProcedure;
                        secDiagnose.DiagnosisType = DiagnosisTypeEnum.Seconder;
                    }
                }
                else {
                    throw new TTException((await SystemMessageService.GetMessage(153)));
                }
            }
        }
    }
    public async SetProcedureDoctorAsCurrentResource(): Promise<void> {
        if (this._EpisodeAction.CurrentStateDef.Status === StateStatusEnum.Uncompleted) {
            if (this._EpisodeAction.ProcedureDoctor === null && UserHelper._currentResource.TakesPerformanceScore === true) {
                this._EpisodeAction.ProcedureDoctor = UserHelper._currentResource;
            }
        }
    }
    public async SetTreatmentMaterialListFilter(treatmentMaterialDef: TTObjectDef, treatmentMaterialMaterialColumn: TTVisual.ITTGridColumn): Promise<void> {
        // set edilen depoya göre Malzeme listesinin filtrelenmesi
        let filterString: string = "\"\"";
        //            string filterString = " THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION') ";
        //            if (treatmentMaterialDef.AllAttributes.ContainsKey(typeof(TreatmentMaterialsInculdeDrugDefinitionAttribute).Name.ToString()))
        //            {
        //                filterString = "THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";
        //            }

        if (!((await SystemParameterService.GetParameterValue("WORKWITHOUTSTOCK", "FALSE")) === "TRUE")) {
            let store: Store = this.GetStore(treatmentMaterialDef);
            if (store === null)
                filterString = "OBJECTID is null";
            else filterString = " STOCKS.INHELD>0 AND STOCKS.STORE = '" + store.ObjectID.toString() + "'";
        }
        (<TTVisual.ITTListBoxColumn>treatmentMaterialMaterialColumn).ListFilterExpression = filterString;
    }*/
    public async ShowImportantMedicalInformation(ea: EpisodeAction): Promise<void> {
        if (!(ea instanceof ImportantMedicalInformation)) {
            if (ea.Episode.Patient.ImportantMedicalInformation !== null) {
                if (ea.Episode.Patient.ImportantMedicalInformation.WarnAllMedicalPersonnel === true) {
                    let importantMedicalInformation: ImportantMedicalInformation = ea.Episode.Patient.ImportantMedicalInformation;
                    let frm: TTVisual.TTForm = TTVisual.TTForm.GetEditForm(importantMedicalInformation);
                    if (frm === null) {
                        TTVisual.InfoBox.Show(i18n("M20023", "Önemli Tıbbi bilgilere form tanımı yapılmadığından işlem açılamamaktadır"));
                    }
                    else {
                        frm.ShowReadOnly(this.FindForm(), importantMedicalInformation);
                    }
                }
            }
        }
    }
    public async ShowPatientPrivacyInformation(patient: Patient): Promise<void> {
        if (patient.IsPatientPrivacy === true) {
            //TODO NE : WarningMessageForm çözülene kadar InfoBox kullandık

            //Gönderilen hasta için bir daha gösterme check i işaretlendiyse uyarı ekranı gelmesin diye
            //if(!TTUser.CurrentUser.PrivacyPatientNotShownList.Contains(patient.ObjectID))
            // {
            //    let frm: WarningMessageForm = new WarningMessageForm();
            //    frm.CurrentPatient = patient;
            //    frm.WarningMessage = patient.FullName + " hastası " + patient.PrivacyEndDate.Value.Date.toString() + " tarihine kadar gizli hastadır.\r\n\r\nGizlilik Sebebi :\r\n" + patient.PrivacyReason;
            //    TTVisual.InfoBox.Show("frm.ShowDialog(this);");
            //}
            let message: string = "";
            if (patient.PrivacyEndDate != null)
                message = patient.FullName + " hastası " + patient.PrivacyEndDate.toString() + i18n("M22850", " tarihine kadar gizli hastadır.\r\n\r\nGizlilik Sebebi :\r\n") + patient.PrivacyReason;
            TTVisual.InfoBox.Show(message);
        }
    }/*
    public async ShowTempleteForm(selectedTemplate: ProcedureRequestTemplateDefinition, templateDefinitionList: string): Promise<void> {
        let frm: TTDefinitionForm;
        let filter: string = "";
        if (!TTUser.CurrentUser.IsSuperUser) {
            filter = " RESUSER = '" + UserHelper._currentResource.ObjectID.toString() + "'";
        }
        //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
        //frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs[templateDefinitionList], filter);
        //frm.ShowEdit(this.FindForm(), TTObjectDefManager.Instance.ListDefs[templateDefinitionList], selectedTemplate, filter);
        let a = 1;
    }
    public async StartPatientAdmissionCorrection(): Promise<void> {

    }
    */

    public async ValidateSutRules(owner: Object): Promise<boolean> {


        //TODO: calısmaya devam edılecek
        /*
        let that = this;
        let inputDVO = new SUTRuleEngineInputViewModel();
        inputDVO.episodeAction = this._EpisodeAction;

        //TODO: Ameliyat surecı ıcın test amaclı yazıldı. Degıstırılecek
        let objectContext: TTObjectContext = new TTObjectContext(true);
        let ea: Surgery = <Surgery>this._EpisodeAction;
        let subActionProcedure: SubActionProcedure;
        for(let sp of ea.MainSurgeryProcedures)
        {
            subActionProcedure = <SubActionProcedure>sp;  //<SubActionProcedure> objectContext.GetObject(sp.ObjectID, "SubActionProcedure");
            inputDVO.subActionProcedures.push(subActionProcedure);
        }

        let fullApiUrl: string = 'api/EpisodeActionService/ValidateSUTRules2';
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post(fullApiUrl, inputDVO);


        if (result != null) {
        }
        */

        return true;

    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new EpisodeAction();
        this.episodeActionFormViewModel = new EpisodeActionFormViewModel();
        this._ViewModel = this.episodeActionFormViewModel;
        this.episodeActionFormViewModel._EpisodeAction = this._TTObject as EpisodeAction;
    }

    protected loadViewModel() {
        let that = this;
        that.episodeActionFormViewModel = this._ViewModel as EpisodeActionFormViewModel;
        that._TTObject = this.episodeActionFormViewModel._EpisodeAction;
        if (this.episodeActionFormViewModel == null)
            this.episodeActionFormViewModel = new EpisodeActionFormViewModel();
        if (this.episodeActionFormViewModel._EpisodeAction == null)
            this.episodeActionFormViewModel._EpisodeAction = new EpisodeAction();

    }

    async ngOnInit() {
        let that = this;
        await this.load(EpisodeActionFormViewModel);

    }


    protected redirectProperties(): void {

    }

    public initFormControls(): void {

    }

    public async CheckIsDiagnosisExists(DiagnosisGridList: DiagnosisGrid[]) {
        if (DiagnosisGridList) {
            if (DiagnosisGridList.filter(dr => dr.RemoveSubEpisodeRelation != true).length < 1) {
                throw new TTException(await SystemMessageService.GetMessage(635));
            }
        } else {
            throw new TTException(await SystemMessageService.GetMessage(635));
        }
    }

    public CheckIsDiagnosisExistsForReports(DiagnosisGridList: DiagnosisGrid[]): boolean {
        if (DiagnosisGridList) {
            if (DiagnosisGridList.filter(dr => dr.IsNew != true).length > 0) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public async CheckIsDiagnosisExistsForCommitteeExamination(episodeAction: EpisodeAction, DiagnosisGridList: DiagnosisGrid[]) {
        if (DiagnosisGridList) {
            if (DiagnosisGridList.filter(dr => dr.EpisodeAction.toString() == episodeAction.ObjectID.toString() && dr.RemoveSubEpisodeRelation != true).length < 1) {
                throw new TTException(await SystemMessageService.GetMessage(635));
            }
        } else {
            throw new TTException(await SystemMessageService.GetMessage(635));
        }
    }

    /*YATAN HASTA DİŞ KABULU*/
    public getDentistResource() {
        let that = this;
        this.httpService.get<Array<ResSection>>("api/EpisodeActionService/GetDentistResource")
            .then(result => {
                this.dentistResourceList = result as Array<ResSection>;
                this.ShowDentistList = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public getDentist(e: any) {
        let that = this;
        this.httpService.get<Array<ResUser>>("api/EpisodeActionService/GetDentist?ResourceID=" + e.value)
            .then(result => {
                this.dentistList = result as Array<ResUser>;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public _dentistResourceID: string = null;
    public _dentistDoctorID: string = null;

    public disKabul_Al() {
        let that = this;
        if (this._dentistDoctorID == null || this._dentistResourceID == null)
            throw new TTException("Kabul alabilmek için lütfen doktor ve poliklinik seçimi yapınız");

        that.loadEAPanelOperation(true, 'Diş kabulü oluşturuluyor, lütfen bekleyiniz.');
        this.httpService.get<Array<ResUser>>("api/EpisodeActionService/CreateDentalExamFromInpatient?ResourceID='" + this._dentistResourceID + "'&DoctorID='" + this._dentistDoctorID
            + "'&MasterActionID='" + this.getMasterObjectIdForDentalExam() + "'")
            .then(result => {
                this.dentistResourceList = new Array<ResSection>();
                this.dentistList = new Array<ResUser>();
                this._dentistDoctorID = null;
                this._dentistResourceID = null;
                ServiceLocator.MessageService.showSuccess(i18n("M16830", "İşlem başarılı olarak tamamlandı."));
                this.ShowDentistList = false;
                that.loadEAPanelOperation(false, '');

            })
            .catch(error => {
                that.messageService.showError(error);
                that.loadEAPanelOperation(false, '');
            });
    }

    public getMasterObjectIdForDentalExam() {
        return this.ObjectID;
    }
    /*YATAN HASTA DİŞ KABULU END*/

    /*YATAN HASTA SAĞLIK KURULU KABULU*/
    public _hcID: string = null;
    public _newHC = true;
    public _eStatusNotfReportObj: EStatusNotRepCommitteeObj = null;
    public _eDisabledReport: EDisabledReport = null;
    public selectedReportIsDisabled: boolean = false;
    public _hcReasonID: string = null;
    public _hcModeOfPayment: WhoPaysEnum = null;
    public inpatientHealthCommitteGridHeight = "350px";
    //@Type(() => PatientAdmissionResourcesToBeReferred)
    public ResourcesToBeReferredList: Array<PatientAdmissionResourcesToBeReferred> = new Array<PatientAdmissionResourcesToBeReferred>();
    public inpatientHC_Class: InpatientHC_Class = new InpatientHC_Class();

    public tempResourcesToBeReferredPoliclinic: string;
    public tempProcedureDoctorToBeReferred: string;


    public getHealthCommitteandReqReason(data: ClickFunctionParams) {
        let that = this;
        this.httpService.get<HealthCommitteandReqReason>("api/EpisodeActionService/GetHealthCommitteandReqReason?episodeActionId=" + data.Params.episodeActionId)
            .then(result => {
                that.hCRequestReasonList = result.hCRequestReasons as Array<HCRequestReason>;

                that.shortHcInfo = result.shortHealthCommittees as Array<ShortHcInfo>;
                that.OpenHCAdmission = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public async HCRequestReason_Changed(): Promise<void> {
        if (this._hcID == null) {
            this.ResourcesToBeReferredList.Clear();
            if (this.inpatientHC_Class.resourcesToBeReferredList != undefined)
                this.inpatientHC_Class.resourcesToBeReferredList.Clear();

            if (this._hcReasonID != null) {
                this.inpatientHC_Class = new InpatientHC_Class();
                this.inpatientHC_Class._hcReasonID = this._hcReasonID;
                this.inpatientHC_Class.episodeActionObjectID = this._EpisodeAction.ObjectID;
                let apiUrlForReasonForExamination: string = '/api/PatientAdmissionService/GetHCRequestReasonDetails?requestReasonObjectID=' + this._hcReasonID;
                //let hCRequestReasonDetail = <HCRequestReasonDetail>await this.httpService.get(apiUrlForReasonForExamination, HCRequestReasonDetail);

                let response = <GetHCRequestReasonDetailsResponse>await this.httpService.get(apiUrlForReasonForExamination, GetHCRequestReasonDetailsResponse);
                let hCRequestReasonDetail = response.requestReasonDetail;
                if (hCRequestReasonDetail != null && hCRequestReasonDetail.ReasonForExaminationDefinition != null) {
                    this.inpatientHC_Class.reasonForExaminationDefinition = hCRequestReasonDetail.ReasonForExaminationDefinition;
                    if (hCRequestReasonDetail.HospitalsUnits != null && hCRequestReasonDetail.HospitalsUnits.length > 0) {
                        for (let hospitalsUnitsDef of hCRequestReasonDetail.HospitalsUnits) {
                            let patientAdmissionResourcesToBeReferred: PatientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(this._EpisodeAction.ObjectContext);
                            patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = hospitalsUnitsDef.ProcedureDoctor;
                            patientAdmissionResourcesToBeReferred.Resource = hospitalsUnitsDef.Policlinic;
                            patientAdmissionResourcesToBeReferred.Speciality = hospitalsUnitsDef.Speciality;
                            this.ResourcesToBeReferredList.push(patientAdmissionResourcesToBeReferred);
                        }
                        this.inpatientHC_Class.resourcesToBeReferredList = this.ResourcesToBeReferredList;
                    }
                    if (response.reportTypeDefinition != null && response.reportTypeDefinition.IsDisabled == true) {
                        this._eDisabledReport = new EDisabledReport();
                        this.selectedReportIsDisabled = true;
                        this._eStatusNotfReportObj = null;
                        this.inpatientHealthCommitteGridHeight = "220px";
                    } else {
                        this.inpatientHealthCommitteGridHeight = "350px";
                        this._eStatusNotfReportObj = new EStatusNotRepCommitteeObj();
                        this._eDisabledReport = null;
                        this.selectedReportIsDisabled = false;
                    }
                }


            }
        }
    }

    public async HealthCommitte_Changed(_healthCommitte): Promise<void> {
        this.ResourcesToBeReferredList.Clear();
        if (this.inpatientHC_Class.resourcesToBeReferredList != undefined)
            this.inpatientHC_Class.resourcesToBeReferredList.Clear();

        if (this._hcID != null) {
            this.inpatientHC_Class = new InpatientHC_Class();
            this.inpatientHC_Class.episodeActionObjectID = this._EpisodeAction.ObjectID;
            let apiUrlForReasonForExamination: string = '/api/EpisodeActionService/GetOldHealthCommitteByID?hcID=' + this._hcID;
            //let hCRequestReasonDetail = <HCRequestReasonDetail>await this.httpService.get(apiUrlForReasonForExamination, HCRequestReasonDetail);


            let response = <OldHealthCommitte>await this.httpService.get(apiUrlForReasonForExamination, OldHealthCommitte);

            if (response.HCStateID.toString() != HealthCommittee.HealthCommitteeStates.New.id.toString()) {
                this._hcID = null;
                ServiceLocator.MessageService.showError("Durumu 'heyet kabul' olmayan sağlık kurulları güncellenemez.");
                throw new TTException("Durumu 'heyet kabul' olmayan sağlık kurulları güncellenemez.");
            }

            this._hcReasonID = response.HCReasonID;
            this._hcModeOfPayment = response.HCModeOfPayment;
            this.inpatientHC_Class.reasonForExaminationDefinition = response.ReasonForExamination;

            if (response != null && response.ReasonForExamination != null) {
                this.inpatientHC_Class.reasonForExaminationDefinition = response.ReasonForExamination;
                if (response.HospitalsUnits != null && response.HospitalsUnits.length > 0) {
                    for (let hospitalsUnitsDef of response.HospitalsUnits) {
                        let patientAdmissionResourcesToBeReferred: PatientAdmissionResourcesToBeReferred = new PatientAdmissionResourcesToBeReferred(this._EpisodeAction.ObjectContext);
                        patientAdmissionResourcesToBeReferred.ProcedureDoctorToBeReferred = hospitalsUnitsDef.ProcedureDoctor;
                        patientAdmissionResourcesToBeReferred.Resource = hospitalsUnitsDef.Policlinic;
                        patientAdmissionResourcesToBeReferred.Speciality = hospitalsUnitsDef.Speciality;
                        patientAdmissionResourcesToBeReferred.IsNew = false;
                        this.ResourcesToBeReferredList.push(patientAdmissionResourcesToBeReferred);
                    }
                    this.inpatientHC_Class.resourcesToBeReferredList = this.ResourcesToBeReferredList;
                }
            }
            if (response != null && response.EDisabledReport != null) {
                this._eDisabledReport = response.EDisabledReport;
                this._eStatusNotfReportObj = null;
                this.selectedReportIsDisabled = true;
                this.inpatientHealthCommitteGridHeight = "220px";
            } else {
                this.inpatientHealthCommitteGridHeight = "350px";
                this._eStatusNotfReportObj = response.eStatusNotfReportObj;
                this._eDisabledReport = null;
                this.selectedReportIsDisabled = false;
            }

        }
    }

    public async HcKabul_Al() {
        let that = this;
        let hasErrorInfo = false;
        if (this._hcReasonID == null || this.ResourcesToBeReferredList.length == 0 || this._hcModeOfPayment == null) {
            ServiceLocator.MessageService.showError(i18n("M16830", "Kabul alabilmek için lütfen tüm alanları doldurunuz."));
            return false;
        }
        else {
            this.ResourcesToBeReferredList.forEach(x => {
                if (x.ProcedureDoctorToBeReferred == null || x.Resource == null) {
                    hasErrorInfo = true;
                }
                //throw new Exception(i18n("M23115", "Muayene edilecek birim ve doktor seçim alanlarını lütfen doldurunuz."));
            });
        }

        if (hasErrorInfo) {
            ServiceLocator.MessageService.showError(i18n("M16830", "Muayene edilecek birim ve doktor seçim alanlarını lütfen doldurunuz."));
            return false;
        }

        let _patient = null;

        if (that._EpisodeAction.Episode != null && typeof that._EpisodeAction.Episode.Patient !== "string") {
            _patient = that._EpisodeAction.Episode.Patient.ObjectID;

            let fullApiUrl = '/api/PatientAdmissionService/HasSameReceptionForSameReason/?Reason=' + this._hcReasonID + '&PatientID=' + _patient;
            let hasAdmission = await this.httpService.get<any>(fullApiUrl); // await this.hasSameReceptionForSameReason()

            if (hasAdmission) {
                ServiceLocator.MessageService.showError("Aynı rapor nedeni ile alınmış bir kabul mevcut olduğu için tekrar kabul alamazsınız.");
                return false;
            }
        }
        if(this._eDisabledReport != null){
            this.inpatientHC_Class.eDisabledReport = this._eDisabledReport;
            if(!this.CheckEReportProperties()){
                return;
            }
        }
        if (this._eStatusNotfReportObj != null) {
            this.inpatientHC_Class.eStatusNotfReportObj = this._eStatusNotfReportObj;
            if (!this.CheckEReportProperties()) {
                return;
            }
        }
        this.inpatientHC_Class.HCModeOfPayment = this._hcModeOfPayment;
        this.inpatientHC_Class.episodeActionObjectID = this._EpisodeAction.ObjectID;

        this.httpService.post<any>("api/EpisodeActionService/CreateHCFromInpatient", this.inpatientHC_Class)
            .then(result => {
                ServiceLocator.MessageService.showSuccess(i18n("M16830", "İşlem başarılı olarak tamamlandı."));
                this.onHCAdmissionPopupHiding();

            })
            .catch(error => {
                that.messageService.showError(error);
            });


    }

    public CheckEReportProperties() : boolean {
        
        
        if (this._eDisabledReport != null) {
            if (this._eDisabledReport.ApplicationReason == null) {
                ServiceLocator.MessageService.showError ("Engelli Kurul Kabullerine Müraacaat Nedeni Seçilmeden Devam Edilemez!");
                return false;
            } else {
                if (this._eDisabledReport.ApplicationReason == 0) {
                    if (this._eDisabledReport.ApplicationType == null) {
                        ServiceLocator.MessageService.showError ("Engelli Kurul Kabullerine Müraacaat Şekli Seçilmeden Devam Edilemez!");
                        return false;
                        
                    }
                    if (this._eDisabledReport.ApplicationType == 1) {
                        if (this._eDisabledReport.PersonalApplicationType == null) {
                            ServiceLocator.MessageService.showError ("Engelli Kurul Kabullerine Müraacaat Türü Seçilmeden Devam Edilemez!");
                            return false;
                        }
                    } else if (this._eDisabledReport.ApplicationType == 0) {
                        if (this._eDisabledReport.CorporateApplicationType == null) {
                            ServiceLocator.MessageService.showError ("Engelli Kurul Kabullerine Müraacaat Türü Seçilmeden Devam Edilemez!");
                            return false;
                        }
                    }
                } else if (this._eDisabledReport.ApplicationReason == 1) {
                    if (this._eDisabledReport.TerrorAccidentInjuryAppType == null) {
                        ServiceLocator.MessageService.showError ("Engelli Kurul Kabullerine Müraacaat Şekli Seçilmeden Devam Edilemez!");
                        return false;
                    }
                    if (this._eDisabledReport.TerrorAccidentInjuryAppReason == null) {
                        ServiceLocator.MessageService.showError ("Engelli Kurul Kabullerine Kaza Yaralanma Nedeni Seçilmeden Devam Edilemez!");
                        return false;
                    }
                }
            }
        } if (this._eStatusNotfReportObj != null) {
            if (this._eStatusNotfReportObj.ApplicationType == null) {
                ServiceLocator.MessageService.showError("Kurul Kabullerine Müraacaat Nedeni Seçilmeden Devam Edilemez!");
                return false;
            }
        }
        return true;
    }

    public async HcKabul_Guncelle() {
        let that = this;
        let hasErrorInfo = false;

        this.ResourcesToBeReferredList.forEach(x => {
            if (x.ProcedureDoctorToBeReferred == null || x.Resource == null) {
                hasErrorInfo = true;
            }
        });

        if (hasErrorInfo) {
            ServiceLocator.MessageService.showError(i18n("M16830", "Muayene edilecek birim ve doktor seçim alanlarını lütfen doldurunuz."));
            return false;
        }

        if(this._eDisabledReport != null)
        {
            this.inpatientHC_Class.eDisabledReport = this._eDisabledReport;
            if(!this.CheckEReportProperties()){
                return;
            }
        }
        if (this._eStatusNotfReportObj != null) {
            this.inpatientHC_Class.eStatusNotfReportObj = this._eStatusNotfReportObj;
            if (!this.CheckEReportProperties()) {
                return;
            }
        }
        this.inpatientHC_Class.HCModeOfPayment = this._hcModeOfPayment;
        this.inpatientHC_Class.episodeActionObjectID = new Guid(this._hcID);// Update için Healthcommitte ObjectID'si gönderiliyor

        this.httpService.post<any>("api/EpisodeActionService/UpdateHCFromInpatient", this.inpatientHC_Class)
            .then(result => {
                ServiceLocator.MessageService.showSuccess(i18n("M16830", "Güncelleme başarılı olarak tamamlandı."));
                this.onHCAdmissionPopupHiding();

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public HcKabul_Yeni() {
        this.onHCAdmissionPopupHiding()
        this.OpenHCAdmission = true;
    }

    public onHCAdmissionPopupHiding() {
        this._hcReasonID = null;
        this.ResourcesToBeReferredList.Clear();
        this._hcModeOfPayment = null;
        this.OpenHCAdmission = false;
        this._hcID = null;
        this._eDisabledReport = null;
        this._eStatusNotfReportObj = null;
        this.selectedReportIsDisabled = false;
        this.inpatientHealthCommitteGridHeight = "300px";
    }




    /*YATAN HASTA SAĞLIK KURULU KABULU END*/

    /**BOŞ/DOLU YATAK RAPORU BEGİN */
    public getActiveClinicsForReport(reportName: ClickFunctionParams) {
        let that = this;
        this.httpService.get<Array<ResClinic>>("api/EpisodeActionService/GetActiveClinicsForReport")
            .then(result => {
                this.ReportClinicList = result as Array<ResClinic>;
                if (reportName.Params == "BOSYATAKLISTESI")
                    this.ShowEmptyBedPopup = true;
                else if (reportName.Params == "YATANHASTALISTESI")
                    this.ShowInpatientListPopup = true;
                else if (reportName.Params == "IZINLIHASTALISTESI")
                    this.ShowPatientVacationListPopup = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    public openEmptyBedReport(): Promise<ModalActionResult> {
        let reportData: DynamicReportParameters = {

            Code: 'BOSYATAKLISTESI',
            ReportParams: { AllClinics: this.GetAllClinicForReport, SelectedClinicList: this.SelectedClinicList },
            ViewerMode: true
        };

        this.ShowEmptyBedPopup = false;

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = reportData;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "ACİL MÜŞAHEDE FORMU"

            modalInfo.fullScreen = true;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    /**BOŞ/DOLU YATAK RAPORU END */

    /**
 * YATAN HASTA LİSTESİ
 */
    async openGeneralPopupFromPopup()
    {
        if(this.ShowInpatientListPopup)
            this.openYatanHastaListesiReport();
        else if (this.ShowPatientVacationListPopup)
            this.openPatientVacationListReport();
    }

    public openYatanHastaListesiReport(): Promise<ModalActionResult> {
        let reportData: DynamicReportParameters = {

            Code: 'YATANHASTALISTESI',
            ReportParams: { BaslangicTarihi: this.generalReportStartDate, BitisTarihi: this.generalReportEndDatee, AllClinics: this.GetAllClinicForReport, SelectedClinicList: this.SelectedClinicList },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            this.ShowInpatientListPopup = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "YATAN HASTA LİSTESİ"

            modalInfo.fullScreen = true;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    /**
     * İZİNLİ HASTA LİSTESİ BEGIN
     */
    public onGeneralReportPopupHiding()
    {
        this.ShowInpatientListPopup = false;
        this.ShowPatientVacationListPopup = false;
    }

    public openPatientVacationListReport(): Promise<ModalActionResult> {
        let reportData: DynamicReportParameters = {

            Code: 'IZINLIHASTALISTESI',
            ReportParams: { BaslangicTarihi: this.generalReportStartDate, BitisTarihi: this.generalReportEndDatee, AllClinics: this.GetAllClinicForReport, SelectedClinicList: this.SelectedClinicList },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            this.ShowPatientVacationListPopup = false;

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "İZİNLİ HASTA LİSTESİ"

            modalInfo.fullScreen = true;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {

                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    /**
     * İZİNLİ HASTA LİSTESİ END
     */

    

    public getEmergencyClickFunctionParams(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams;
        this.IfNullSelectMasterResource();
        if (typeof this._EpisodeAction.Episode == "string") {
            clickFunctionParams = new ClickFunctionParams(this, new ActiveEmergencyOrderIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode, null,null));
        } else {
            if (typeof this._EpisodeAction.Episode.Patient == "string"){
                clickFunctionParams = new ClickFunctionParams(this, new ActiveEmergencyOrderIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient,null));
                if(typeof this._EpisodeAction.MasterResource == "string"){
                    clickFunctionParams = new ClickFunctionParams(this, new ActiveEmergencyOrderIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient,this._EpisodeAction.MasterResource));
                }else{
                    clickFunctionParams = new ClickFunctionParams(this, new ActiveEmergencyOrderIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient,this._EpisodeAction.MasterResource.ObjectID));
                }
            }
            else{
                if(typeof this._EpisodeAction.MasterResource == "string"){
                    clickFunctionParams = new ClickFunctionParams(this, new ActiveEmergencyOrderIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient.ObjectID,this._EpisodeAction.MasterResource));
                }
                else{
                    clickFunctionParams = new ClickFunctionParams(this, new ActiveEmergencyOrderIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient.ObjectID,this._EpisodeAction.MasterResource.ObjectID));
                }
            }
        } return clickFunctionParams;
    }




    public getClickFunctionParams(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams;
        if (typeof this._EpisodeAction.Episode == "string") {
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode, null));
        } else {
            if (typeof this._EpisodeAction.Episode.Patient == "string"){
                clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient));
            }
            else{
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient.ObjectID));
            }
        } return clickFunctionParams;
    }

    public getPatientTrackingParams():ClickFunctionParams
    {
        let clickFunctionParams: ClickFunctionParams;
        let trackbyPatient:FollowingPatients =new FollowingPatients();

        trackbyPatient=new FollowingPatients()
        if (typeof this._EpisodeAction.Episode.Patient == "string"){
            
            trackbyPatient.Paitent = this._EpisodeAction.Episode.Patient;
        }
        else{
            trackbyPatient.Paitent = this._EpisodeAction.Episode.Patient.ObjectID;
        }

        if (typeof this._EpisodeAction.SubEpisode == "string"){
            
            trackbyPatient.Subepisode = this._EpisodeAction.SubEpisode;
        }
        else{
            trackbyPatient.Subepisode = this._EpisodeAction.SubEpisode.ObjectID;
        }

        clickFunctionParams = new ClickFunctionParams(this,trackbyPatient);
        return clickFunctionParams;
    }

    public getActiveIDsModel(): ActiveIDsModel {
        let episodeID: Guid;
        let patientID: Guid;

        if (!this._EpisodeAction.Episode.ObjectID)
            episodeID = <any>this._EpisodeAction['Episode'];
        else
            episodeID = this._EpisodeAction.Episode.ObjectID;

        if (!this._EpisodeAction.Episode.Patient.ObjectID) {
            if (this._EpisodeAction.Episode.Patient)
                patientID = <any>this._EpisodeAction.Episode['Patient'];
            else
                patientID = null;
        }
        else
            patientID = this._EpisodeAction.Episode.Patient.ObjectID;

        let activeIDsModel: ActiveIDsModel = new ActiveIDsModel(this._EpisodeAction.ObjectID, episodeID, patientID);
        return activeIDsModel;
    }

    loadEAPanelOperation(visible: boolean, message: string): void {
        this.showEALoadPanel = visible;
        if (visible)
            this.EALoadPanelMessage = message;
        else
            this.EALoadPanelMessage = '';
    }

    //Gunubirlik yatis islemleri

    async controlDailyInpatient() {
        let result: DailyInpatientInfoModel = new DailyInpatientInfoModel();
        let apiUrl: string = 'api/EpisodeActionService/ControlDailyInpatient?episodeActionID=' + this._EpisodeAction.ObjectID;
        result = await this.httpService.get<DailyInpatientInfoModel>(apiUrl);

        this.gunubirlikYatisKontrol = result.HasDailyInpatient;

        if (this.gunubirlikYatisKontrol == true && this._EpisodeAction.ObjectDefID != InPatientPhysicianApplication.ObjectDefID) {
            this.messageService.showInfo("Hastanın " + result.DailyInpatientProtocolNo + " kabulü ile günübirlik yatışı bulunmaktadır.")
        }
    }

    public async onDailyOperationClick() {

        if (this.gunubirlikYatisKontrol == false) {

            try {
                let that = this;
                let body = "";
                let apiUrlForPASearchUrl: string;
                let headers = new Headers({ 'Content-Type': 'application/json' });
                apiUrlForPASearchUrl = '/api/RequestedProceduresService/FillClinicList';
                let index;
                let input: EpisodeAction = this._EpisodeAction;

                await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(response => {
                    let result = response as ClinicResultModel;
                    if (result) {
                        that.ClinicList = result.ClinicList;
                        if(result.DefaultClinic != null)
                        that.birim = result.DefaultClinic.ObjectID;
                    }

                    this.dailyApplicationControl = true;

                }).catch(error => {
                    ServiceLocator.MessageService.showError("Hata : " + error);
                });
            }

            catch (ex) {
                ServiceLocator.MessageService.showError(ex);
            }
        }

        else {
            ServiceLocator.MessageService.showError("Hastanın aktif bir günübirlik yatışı bulunmaktadır.");
        }
    }

    public async DailyOperations() {
        if (this.summaryEpicrisis.Equals("")) {
            ServiceLocator.MessageService.showError("Özet epikriz yazılmadan günübirlik yatış işlemi başlatılamaz");
            return;
        }

        if (this.birim == null) {
            ServiceLocator.MessageService.showError("Birim seçilmeden günübirlik yatış işlemi başlatılamaz");
            return;
        }

        if (this.InpatientDate == null) {
            ServiceLocator.MessageService.showError("Yatış tarihi seçilmeden günübirlik yatış işlemi başlatılamaz");
            return;
        }
        this.dailyApplicationControl = false;

        this.loadingVisible = true;
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/EpisodeActionService/DailyInpatientOperations';
            let input: DailyProvisionInputModel = new DailyProvisionInputModel();
            input.EpisodeAction = this._EpisodeAction;
            input.Epicrisis = this.summaryEpicrisis;
            input.InpatientDate = this.InpatientDate;
            if (this.birim != undefined)
                input.TreatmentClinic = new Guid(this.birim.toString());

            if (typeof this._EpisodeAction.ProcedureDoctor === "string")
                input.ProcedureDoctorID = new Guid(this._EpisodeAction.ProcedureDoctor);
            else
                input.ProcedureDoctorID = this._EpisodeAction.ProcedureDoctor.ObjectID;

            input.DailyInpatientControl = this.gunubirlikYatisKontrol;
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });

            await this.httpService.post<any>(apiUrlForPASearchUrl, input).then(
                response => {
                    let result = response;
                    if (result) {
                        this.gunubirlikYatisKontrol = true;
                    }
                });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
        this.loadingVisible = false;

        if (this.gunubirlikYatisKontrol === true)
            ServiceLocator.MessageService.showInfo("Günübirlik yatış oluşturuldu.");
    }

    public onDailyOperationCancel() {
        this.dailyApplicationControl = false;
    }


    public episodeActionId;
    public async OpenChemoRadioPopUp(data: ClickFunctionParams) {
        this.createRequest = true;    
        let model: ActiveIDsModel = data.Params;
        this.episodeActionId = model.episodeActionId;
    }

    public async OpenBirthInfoReportPopUp(){
        
        try {
            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string;
            let headers = new Headers({ 'Content-Type': 'application/json' });
            apiUrlForPASearchUrl = '/api/EpisodeActionService/GetBirthTypeList';

            await this.httpService.post<List <BirthTypeModel>>(apiUrlForPASearchUrl, null).then(response => {
                if (response) {
                    that.BirthTypeList = response;
                }

                this.openBirthInfoPopUp = true;

            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    protected helpMenuService: HelpMenuService;
    public OpenHelpMenuServiceFunction(){
        this.helpMenuService.openBirthInfoReport(this.BirthInfoReportStartDate, this.BirthInfoReportEndDate, this.SelectedBirthTypes);
    }

    }

